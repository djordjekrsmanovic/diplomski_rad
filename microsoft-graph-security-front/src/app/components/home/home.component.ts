import { Component, OnInit } from '@angular/core';
import { AlertStatistic } from '../../model/Statistic';
import { AlertService } from '../../services/alert.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private alertService:AlertService) { }

  dataLoaded: boolean = false;

  colorScheme = [
    { name: "High", value: '#d43624' },
    { name: "Medium", value: '#d47324' },
    { name: "Low", value: '#ede31c' },
    { name: "Informational", value: '#abed1c' },
  ]
  

  statusStatistic:AlertStatistic[];
  severityStatistic:AlertStatistic[];

  ngOnInit(): void {
    this.alertService.getSeverityStatistic().subscribe((data)=>{
      this.severityStatistic=data
      this.alertService.getStatusStatistic().subscribe(data=>{this.statusStatistic=data; this.dataLoaded=true})
    })
    
  }

}
