import { VendorInformation } from "./VendorInformation";

export class AlertDetails{
    public id:string;
    public title:string;
    public severity:string;
    public status:string;
    public category:string;
    public createDateTime:string;
    public assignedTo:string;
    public vendorInformation:VendorInformation;
    public alertDescription:string;
    public recommendedActions:string[];
}