import { Component, ViewChild } from '@angular/core';
import { FilterComponent } from "../filter/filter.component";
import { ListComponent } from "../list/list.component";
import { PaginationComponent } from "../../shared/components/pagination/pagination.component";
import { GetPaginatedProductsRequest } from "../../shared/models/request/get-paginated-products-request";
import { PaginateModel } from '../../shared/models/utils/paginate-model';

@Component({
  selector: 'dev-ev-search',
  standalone: true,
  imports: [FilterComponent, ListComponent, PaginationComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {


  async pageChange(event: PaginateModel) {
          this.paginateModel = event;
          this.getPaginatedProductsRequest.page = event.currentPage;
          await this.listComponent.searchGrid(this.getPaginatedProductsRequest);
          this.paginateModel.totalItens =  this.listComponent.paginatedResponse.data.totalCount;
          
  }

  @ViewChild('listComponent') listComponent!: ListComponent
  paginateModel:PaginateModel = new PaginateModel(); 
  getPaginatedProductsRequest:GetPaginatedProductsRequest = new GetPaginatedProductsRequest();  

  constructor() { }

    async sendFilterEvent(event:GetPaginatedProductsRequest) {
      event.page = 1; 
      await this.listComponent.searchGrid(event);
      this.getPaginatedProductsRequest = event; 
      this.paginateModel.totalItens =  this.listComponent.paginatedResponse.data.totalCount;
      this.paginateModel.currentPage = 1;
    }

}
