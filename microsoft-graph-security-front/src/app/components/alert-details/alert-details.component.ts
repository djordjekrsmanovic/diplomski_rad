import { Component, Input, OnInit } from '@angular/core';
import { AlertDetails } from '../../model/AlertDetails';

@Component({
  selector: 'app-alert-details',
  templateUrl: './alert-details.component.html',
  styleUrls: ['./alert-details.component.css']
})
export class AlertDetailsComponent implements OnInit {

  @Input() id:string='';
  @Input() date:string='';
  @Input() assignedTo:string='';
  @Input() category:string='';
  @Input() status:string='';
  @Input() severity:string='';
  @Input() vendor:string='';
  @Input() provider:string='';
  @Input() subprovider:string='';
  constructor() { }

  ngOnInit(): void {
    
  }

}
