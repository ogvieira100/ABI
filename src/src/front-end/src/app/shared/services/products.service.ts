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
import { UpdateProductRequest } from '../models/request/update-product-request';

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
    upadteProducts(createProductRequest:UpdateProductRequest):Observable<ApiResponseSend<Product>>{  

      return this.http
         .put<ApiResponseSend<Product>>(this.getUrlProduct(), createProductRequest)
         .pipe(
             catchError((error) => {
                 this.treateErrorHttp(error);
                 return throwError(() => error);
             })
         )  
    }

    async upadteProductsAsync(updateProductRequest:UpdateProductRequest):Promise<ApiResponseSend<Product>>{

      const ret = await lastValueFrom(this.upadteProducts(updateProductRequest))
       return ret
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

getProduct(id:string):Observable<ApiResponseSend<Product>>{
    let url  = `${this.getUrlProduct()}/${id}`;
    return this.http
       .get<ApiResponseSend<Product>>(url)
       .pipe(
           catchError((error) => {
               this.treateErrorHttp(error);
               return throwError(() => error);
           })
       )
 }

 async getProductAsync(id:string):Promise<ApiResponseSend<Product>>{

      const ret = await lastValueFrom(this.getProduct(id))
       return ret
 }

 deleteProduct(id:string):Observable<ApiResponseSend<Product>>{
    let url  = `${this.getUrlProduct()}/${id}`;
    return this.http
       .delete<ApiResponseSend<Product>>(url)
       .pipe(
           catchError((error) => {
               this.treateErrorHttp(error);
               return throwError(() => error);
           })
       )
 }

 async deleteProductAsync(id:string):Promise<ApiResponseSend<Product>>{

      const ret = await lastValueFrom(this.deleteProduct(id))
       return ret
 }
}
