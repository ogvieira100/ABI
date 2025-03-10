import { Component, OnInit } from '@angular/core';
import { PaginatedResponse } from '../../shared/models/response/paginated-response';
import { Product } from '../../shared/models/domain/product';
import { ProductsService } from '../../shared/services/products.service';
import { GetPaginatedProductsRequest } from '../../shared/models/request/get-paginated-products-request';
import { ApiResponse } from '../../shared/models/response/api-response';
import { PaginateModel } from '../../shared/models/utils/paginate-model';

@Component({
  selector: 'dev-ev-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {

  paginatedResponse: ApiResponse<Product> = new ApiResponse(); 
 

  constructor(private productsService:ProductsService) { 

  }
  ngOnInit(): void {
    
  }

  async searchGrid(getPaginatedProductsRequest:GetPaginatedProductsRequest){
      this.paginatedResponse = await this.productsService.getProductsAsync(getPaginatedProductsRequest)
       
    }
}