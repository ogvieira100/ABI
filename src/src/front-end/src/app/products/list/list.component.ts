import { Component } from '@angular/core';
import { PaginatedResponse } from '../../shared/models/response/paginated-response';

@Component({
  selector: 'dev-ev-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent {

  paginatedResponse: PaginatedResponse = new PaginatedResponse(); 

  constructor() { }

}
