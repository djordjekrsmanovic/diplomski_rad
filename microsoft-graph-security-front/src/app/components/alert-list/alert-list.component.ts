import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Alert } from 'src/app/model/Alert';
import { AlertService } from 'src/app/services/alert.service';

@Component({
  selector: 'app-alert-list',
  templateUrl: './alert-list.component.html',
  styleUrls: ['./alert-list.component.css']
})
export class AlertListComponent implements OnInit {

  constructor(private alertService:AlertService,private router:Router) { }

  alerts:Alert[]=[];

  ngOnInit(): void {
    this.alertService.getAlerts().subscribe(data=>{this.alerts=data});
  }

  rowClicked(alert:Alert){
    console.log('clicked');
    const url='/alert/'+alert.id;
    this.router.navigate([url]);
  }

}
