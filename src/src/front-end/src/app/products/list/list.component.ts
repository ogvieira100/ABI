import { Component, OnInit } from '@angular/core';
import { PaginatedResponse } from '../../shared/models/response/paginated-response';
import { Product } from '../../shared/models/domain/product';
import { ProductsService } from '../../shared/services/products.service';
import { GetPaginatedProductsRequest } from '../../shared/models/request/get-paginated-products-request';
import { ApiResponse } from '../../shared/models/response/api-response';
import { PaginateModel } from '../../shared/models/utils/paginate-model';
import { Router } from '@angular/router';

@Component({
  selector: 'dev-ev-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {

  getPaginatedProductsRequest:GetPaginatedProductsRequest = new GetPaginatedProductsRequest();  
    editarProduto(_t16: Product) {

      this.router.navigate(['/editar-produto/'+_t16?.id]);  

    }
    async excluirProduto(_t16: Product) {
          if (confirm(`Atenção! Deseja realmente excluir o produto  ${_t16?.title} `))
          {
                await this.productsService.deleteProductAsync(_t16.id);
                await this.searchGrid(this.getPaginatedProductsRequest);
          }
    }

  paginatedResponse: ApiResponse<Product> = new ApiResponse(); 
 

  constructor(private router: Router,private productsService:ProductsService) { 

  }
  ngOnInit(): void {
    
  }

  async searchGrid(getPaginatedProductsRequest:GetPaginatedProductsRequest){
      this.getPaginatedProductsRequest = getPaginatedProductsRequest;
      this.paginatedResponse = await this.productsService.getProductsAsync(getPaginatedProductsRequest)
       
    }
}