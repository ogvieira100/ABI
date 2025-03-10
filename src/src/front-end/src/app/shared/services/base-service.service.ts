import { Injectable } from '@angular/core';

import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService {

  protected controller: string = '';

  protected abstract getController(): string;

  protected url: string = environment.api;


  protected getUrl(): string {
      return this.url + this.controller;
  }

  constructor( protected router: Router,
               protected http:HttpClient) {

      this.controller = this.getController();
  }
}
