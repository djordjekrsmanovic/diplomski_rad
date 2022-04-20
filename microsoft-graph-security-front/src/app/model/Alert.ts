

export class Alert{
    constructor(
        public id:string='',
        public title:string='',
        public severity:string='',
        public status:string='',
        public category:string='',
        public createDateTime:Date=new Date(),
        public assignedTo:string='',
        public provider:string=''
    ){

    }
}