export class PagedDataRequest {
    page: number = 1;
    limit: number = 10; 
    active?: boolean;
    column?: string;
    desc: boolean = false;  
  }