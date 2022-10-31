import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CONFIGURATION_GAME_LIFE, GAMES_ENUM } from '@data/contants';
import { AutocompleteGame } from '@shared/models/autocomplete';
import { Challenge } from '@shared/models/challenge';
import { MultipleChoice } from '@shared/models/multiplechoice';
import { PairSelection } from '@shared/models/pairselection';
import { StepDetail } from '@shared/models/stepDetail';
import { MenuService } from '@shared/services/menu/menu.service';
import { ProfileService } from '@shared/services/profile/profile.service';
import { StepService } from '@shared/services/step/step.service';
import { UserService } from '@shared/services/user/user.service';
import { Utils } from '@shared/utils/utils';

@Component({
    selector: 'app-game',
    templateUrl: './game.component.html',
    styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {
    life:number;
    currentStep = 1;
    challengeId: number;
    challenge: Challenge;
    sectionId: number;
    stepDetail: Array<StepDetail> = [];
    autoComplete: Array<AutocompleteGame> = [];
    multipleChoice: Array<MultipleChoice> = [];
    pairSelection: Array<PairSelection> = [];
    currentGame: PairSelection | MultipleChoice | AutocompleteGame;
    currentGameView: GAMES_ENUM;
    $GAMES_ENUM = GAMES_ENUM;

    constructor(private route: ActivatedRoute, private stepService: StepService, private routeNavigation: Router, private menuService: MenuService, private profileService: ProfileService,private userService: UserService) { }

    ngOnInit(): void {
        this.life = CONFIGURATION_GAME_LIFE;
        this.challengeId = this.route.snapshot.params['id'];
        this.getSteps(this.challengeId);
        this.menuService.showMenu = false;
    }

    getSteps(id: number) {
        this.stepService.getStepDetailByChallengeId(id).subscribe(resp => {
            this.stepDetail = resp;
            this.loadGame();
        });
    }

    loadGame() {
        this.challenge = this.stepDetail[0].Challenge;

        this.stepDetail.forEach(e => {
            switch (e.GameType.Code) {
                case 'AUTCOMPLETADO':
                    console.log(e.AutoComplete);
                    this.autoComplete.push(e.AutoComplete);
                    break;
                case 'SELCPARES':
                    this.pairSelection.push(e.PairSelection);
                    break;
                case 'MULCHOICE':
                    this.multipleChoice.push(e.MultipleChoice);
                    break;
                default:
                    break;
            }
        });

        Utils.shuffleArray(this.autoComplete);
        Utils.shuffleArray(this.pairSelection);
        Utils.shuffleArray(this.multipleChoice);

        this.executeGame();
    }

    executeGame() {
        if (this.hasGames()) {
            const view: GAMES_ENUM = Utils.randomNumber(1, 3);
            switch (view) {
                case GAMES_ENUM.AUTOCOMPLETADO:
                    if (this.autoComplete.length > 0) {
                        this.currentGame = this.autoComplete.pop();
                        return this.currentGameView = GAMES_ENUM.AUTOCOMPLETADO;
                    }
                    break;
                case GAMES_ENUM.PAIRSELECTION:
                    if (this.pairSelection.length > 0) {
                        this.currentGame = this.pairSelection.pop();
                        return this.currentGameView = GAMES_ENUM.PAIRSELECTION;
                    }
                    break;
                case GAMES_ENUM.MULTIPLECHOISE:
                    if (this.multipleChoice.length > 0) {
                        this.currentGame = this.multipleChoice.pop();
                        return this.currentGameView = GAMES_ENUM.MULTIPLECHOISE;
                    }
                    break;
                default:
                    break;
            }

            this.executeGame();
        }
        else {
            this.challengeFinished();
        }
    }


    accepted() {
        this.menuService.loaderActive();
        this.currentStep++
        this.executeGame();
    }

    failed(game: PairSelection | MultipleChoice | AutocompleteGame) {
        this.menuService.loaderActive();

        if (this.life == 1) {
            this.menuService.showMenu = true;
            this.routeNavigation.navigateByUrl("/Managment/challenges/" + this.challenge.SectionId);
        }
        else {
            this.life--;
            this.addGame(Object.assign({}, game));
            this.executeGame();
        }

    }

    addGame(game: PairSelection | MultipleChoice | AutocompleteGame) {
        switch (this.currentGameView) {
            case GAMES_ENUM.AUTOCOMPLETADO:
                this.autoComplete.push(<AutocompleteGame>game);
                Utils.shuffleArray(this.autoComplete);
                break;
            case GAMES_ENUM.PAIRSELECTION:
                this.pairSelection.push(<PairSelection>game);
                Utils.shuffleArray(this.pairSelection);
                break;
            case GAMES_ENUM.MULTIPLECHOISE:
                this.multipleChoice.push(<MultipleChoice>game);
                Utils.shuffleArray(this.multipleChoice);
                break;
            default:
                break;
        }
    }

    challengeFinished() {
        this.menuService.fullLoader = true;
        this.profileService.addExperienceAndHistory(this.challengeId).subscribe(resp => {
            this.menuService.showMenu = true;
            this.userService.loadCurrentUser();
            this.menuService.fullLoader = false;
            this.routeNavigation.navigateByUrl("/Managment/challenges/" + this.challenge.SectionId);
        });
    }

    hasGames(): boolean {
        return this.pairSelection.length != 0 || this.multipleChoice.length != 0 || this.autoComplete.length != 0;
    }
}
