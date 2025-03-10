import { Injectable } from '@angular/core';

import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService {

  protected controller: string = '';

  protected abstract getController(): string;

  protected urlCarts: string = environment.apiCarts;
  protected urlProduct: string = environment.apiProduct;


  protected getUrlCarts(): string {
      return this.urlCarts + this.controller;
  }

  protected getUrlProduct(): string {
    return this.urlProduct + this.controller;
}

  protected treateErrorHttp(returnHttp: any) {
    if (returnHttp.status)
    {
        /*unauthorized*/
        if (returnHttp.status == 401)
        {

           
            return

        }
    }
  let messaSend: string | null = null;
  if (!returnHttp.error?.errors) {
      console.log(`${returnHttp.message}`)
      return
  }
  let countTotalMessages = returnHttp.error.errors.length;
  if (countTotalMessages > 0) {
      returnHttp.error.errors.map((mp: any) => {
          if (!messaSend)
              messaSend = '';
          messaSend += mp.message + '\n'
      })
      if (messaSend) {
          console.log(`${messaSend}`)
      }
  }

}

  constructor( protected router: Router,
               protected http:HttpClient) {

      this.controller = this.getController();
  }
}
