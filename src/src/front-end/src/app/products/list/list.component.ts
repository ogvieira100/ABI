import { Component } from '@angular/core';
import { PaginatedResponse } from '../../shared/models/response/paginated-response';
import { Product } from '../../shared/models/domain/product';

@Component({
  selector: 'dev-ev-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent {

  paginatedResponse: PaginatedResponse<Product> = new PaginatedResponse(); 

  constructor() { }

}
