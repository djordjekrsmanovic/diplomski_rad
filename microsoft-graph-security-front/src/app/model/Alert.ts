

export class Alert{
    constructor(
        public id:string='',
        public title:string='',
        public severity:string='',
        public status:string='',
        public category:string='',
        public createDateTime:string='',
        public assignedTo:string='',
        public provider:string=''
    ){

    }
}