import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { HisProfileChallengeService } from '@shared/services/his-profile-challenge/his-profile-challenge.service';
import { HistoryPD } from '@shared/models/historypd';
import { ExperienceHistory } from '@shared/models/experience-history';
import { AuthService } from '@shared/services/auth/auth.service';
import { LabelService } from '@shared/services/label/label.service';

@Component({
  selector: 'app-weekly-exp',
  templateUrl: './weekly-exp.component.html',
  styleUrls: ['./weekly-exp.component.scss']
})
export class WeeklyExpComponent implements OnInit {

  private hisProfileChallenge: Array<HistoryPD> = [];
  private historyExp: Array<ExperienceHistory> = [];

  public lineChartData: ChartDataSets[] = []
  public lineChartLabels: Label[] = [];

  lineChartOptions = {
    responsive: true,
    scales: {
      yAxes: [{
          ticks: {
              beginAtZero: true
          }
      }]
  }
  };

  lineChartColors: Color[] = [
    {
      borderColor: 'orange',
      backgroundColor: 'rgba(255,255,255,0.28)',
    },
  ];
  lineChartLegend = true;
  lineChartPlugins = [];
  lineChartType = 'line';

  constructor(private hispdService: HisProfileChallengeService, private authService: AuthService,public labelService: LabelService) { }

  ngOnInit(): void {
    this.getExpHistoryByProfile();
    console.log('this.lineChartOptions')
    console.log(this.lineChartOptions)
    console.log('this.historyExp')
    console.log(this.historyExp)
  }

  getExpHistoryByProfile() {
    this.hispdService.getExpHistoryByProfile(this.authService.getUser.ProfileId).subscribe(data => {
      this.historyExp = data;
      this.generateChart();
    })

  }

  generateChart() {
    let daysOfWeek: Array<string> = [];
    let expOfWeek: Array<number> = [];
    this.historyExp.forEach(e => {
      daysOfWeek.push(e.DayOfWeek);
      expOfWeek.push(e.Experience);
    })
    console.log(daysOfWeek);

    this.lineChartData = [{ data: expOfWeek, label: this.labelService.labels['exp-weekly'] },]
    daysOfWeek.forEach(element => {
      this.lineChartLabels.push(element)

    });
  }



}
