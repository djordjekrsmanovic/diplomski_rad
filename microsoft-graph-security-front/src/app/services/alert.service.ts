import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Alert } from "../model/Alert";
import { AlertDetails } from "../model/AlertDetails";



@Injectable({
    providedIn: 'root'
  })

  export class AlertService{

    constructor(private http:HttpClient){

    }
      
    serverUrl=environment.server;

    getAlerts(){
        const url=this.serverUrl+'alerts';
        return this.http.get<Alert[]>(url);
    }

    getAlert(id:string){
        const url=this.serverUrl+'alerts/'+id;
        return this.http.get<AlertDetails>(url);
    }
  }