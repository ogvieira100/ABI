export class Ratting {
    rate: number = 0;
    count: number = 0;
  }
  
    
  export class Product {
    id: string = '';
    title: string = '';
    price: number = 0;
    description: string = '';
    category: string = '';
    image: string = '';
    ratting?: Ratting;
  }