import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, lastValueFrom, Observable, throwError } from 'rxjs';
import { PaginatedResponse } from '../models/response/paginated-response';
import { Product } from '../models/domain/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService extends BaseService {


  protected override getController(): string {
    return  ''
  }

    constructor(protected override router: Router,
        protected override http: HttpClient) {
        super(router,http);
    }

    getListMonthlyReceiptsDashboard():Observable<PaginatedResponse<Product>>{

      let url  = `${this.getUrlProduct()}/ListMonthlyReceiptsDashboard`;


      return this.http
         .get<PaginatedResponse<Product>>(url)
         .pipe(
             catchError((error) => {
                 this.treateErrorHttp(error);
                 return throwError(() => error);
             })
         )
   }

   async getListMonthlyReceiptsDashboardAsync():Promise<PaginatedResponse<Product>>{

        const ret = await lastValueFrom(this.getListMonthlyReceiptsDashboard())
         return ret
   }
}
