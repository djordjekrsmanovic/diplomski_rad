import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Alert } from 'src/app/model/Alert';
import { AlertService } from 'src/app/services/alert.service';
import { AlertFilter } from '../../model/AlertFilter';
import { AlertFilterComponent } from '../../model/AlertFilterComponent';

@Component({
  selector: 'app-alert-list',
  templateUrl: './alert-list.component.html',
  styleUrls: ['./alert-list.component.css']
})
export class AlertListComponent implements OnInit {

  constructor(private alertService:AlertService,private router:Router) { }

  alerts:Alert[]=[];

  dataLoaded:boolean=false;

  severityFilterComponent:AlertFilterComponent={
    type:0,
    filterValues:[],
  }
  statusFilterComponent:AlertFilterComponent={
    type:1,
    filterValues:[],
  }
  topFilterComponent:AlertFilterComponent={
    type:2,
    filterValues:[],
  }
  filter:AlertFilter={
    filter:[]
  };

  ngOnInit(): void {
    this.alertService.getAlerts().subscribe(data=>{this.alerts=data; this.dataLoaded=true;});
  }

  rowClicked(alert:Alert){
    console.log('clicked');
    const url='/alert/'+alert.id;
    this.router.navigate([url]);
  }

  addSeverity(severity:string){
    if(this.severityFilterComponent.filterValues.find(x => x===severity)){      
      this.severityFilterComponent.filterValues.forEach((el, index) => {if (el===severity){
        this.severityFilterComponent.filterValues.splice(index,1)        
      }})
      return;
    }   
    this.severityFilterComponent.filterValues.push(severity)
  }

  addStatus(status:string){
    if(this.statusFilterComponent.filterValues.find(x => x===status)){      
      this.statusFilterComponent.filterValues.forEach((el, index) => {if (el===status){
        this.statusFilterComponent.filterValues.splice(index,1)        
      }})
      return;
    }   
    this.statusFilterComponent.filterValues.push(status)
  }

  filterAlerts(){
    this.filter.filter=[];
    this.filter.filter.length=0;
    this.filter.filter.push(this.severityFilterComponent);
    this.filter.filter.push(this.statusFilterComponent);
    this.filter.filter.push(this.topFilterComponent);
    console.log(this.filter);
  }

}
