import { AutocompleteGame, AutocompleteGameDto } from "./autocomplete";
import { Challenge } from "./challenge";
import { GameType } from "./gametype";
import { MultipleChoice } from "./multiplechoice";
import { PairSelection } from "./pairselection";
import { Step } from "./step";

export class StepDetail extends Step{
    public GameType:GameType
    public AutoComplete:AutocompleteGameDto
    public PairSelection:PairSelection
    public MultipleChoice:MultipleChoice
    public Challenge:Challenge
}