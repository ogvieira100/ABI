import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, lastValueFrom, Observable, throwError } from 'rxjs';
import { PaginatedResponse } from '../models/response/paginated-response';
import { Product } from '../models/domain/product';
import { GetPaginatedProductsRequest } from '../models/request/get-paginated-products-request';
import { Commons } from '../util/Commons';
import { ApiResponse, ApiResponseSend } from '../models/response/api-response';
import { CreateProductRequest } from '../models/request/create-product-request';

@Injectable({
  providedIn: 'root'
})
export class ProductsService extends BaseService {


  protected override getController(): string {
    return  'Products'
  }

    constructor(protected override router: Router,
        protected override http: HttpClient) {
        super(router,http);
    }

    async createProductsAsync(getPaginatedProductsRequest:CreateProductRequest):Promise<ApiResponseSend<Product>>{
       const ret = await lastValueFrom(this.createProducts(getPaginatedProductsRequest))
       return ret
    }
    createProducts(createProductRequest:CreateProductRequest):Observable<ApiResponseSend<Product>>{  

      return this.http
         .post<ApiResponseSend<Product>>(this.getUrlProduct(), createProductRequest)
         .pipe(
             catchError((error) => {
                 this.treateErrorHttp(error);
                 return throwError(() => error);
             })
         )  
    }

    getProducts(getPaginatedProductsRequest:GetPaginatedProductsRequest):Observable<ApiResponse<Product>>{

      const queryString =    Commons.toQueryString(getPaginatedProductsRequest);
      let url  = `${this.getUrlProduct()}`;
      if (queryString)
          url += queryString

      return this.http
         .get<ApiResponse<Product>>(url)
         .pipe(
             catchError((error) => {
                 this.treateErrorHttp(error);
                 return throwError(() => error);
             })
         )
   }

   async getProductsAsync(getPaginatedProductsRequest:GetPaginatedProductsRequest):Promise<ApiResponse<Product>>{

        const ret = await lastValueFrom(this.getProducts(getPaginatedProductsRequest))
         return ret
   }
}
