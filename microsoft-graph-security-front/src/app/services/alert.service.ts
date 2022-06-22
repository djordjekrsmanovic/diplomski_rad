import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Alert } from "../model/Alert";
import { AlertDetails } from "../model/AlertDetails";
import { AlertFilter } from "../model/AlertFilter";
import { AlertStatistic } from "../model/Statistic";



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

    filterAlerts(filter:AlertFilter){
      const url=this.serverUrl+'alerts/filter';
      return this.http.post<Alert[]>(url,filter);
    }

    getSeverityStatistic(){
      const url=this.serverUrl+'alerts/statistic/severity';
      return this.http.get<AlertStatistic[]>(url);
    }
    getStatusStatistic(){
      const url=this.serverUrl+'alerts/statistic/status';
      return this.http.get<AlertStatistic[]>(url);
    }
  }