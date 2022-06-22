import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertDetails } from '../../model/AlertDetails';
import { AlertService } from '../../services/alert.service';

@Component({
  selector: 'app-alert-view',
  templateUrl: './alert-view.component.html',
  styleUrls: ['./alert-view.component.css']
})
export class AlertViewComponent implements OnInit {

  constructor(private activatedRoute:ActivatedRoute,private alertService:AlertService) { }

  alert:AlertDetails;
  dataLoaded:boolean=false;
  ngOnInit(): void {
    const id=this.activatedRoute.snapshot.paramMap.get('id');
    if (id!=null){
      this.alertService.getAlert(id).subscribe(data=>{this.alert=data;this.dataLoaded=true;console.log(this.alert)} );
    }
    
  }

}
