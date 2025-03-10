import { Component, EventEmitter, Output } from '@angular/core';
import { GetPaginatedProductsRequest } from '../../shared/models/request/get-paginated-products-request';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'dev-ev-filter',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.css'
})
export class FilterComponent {


  frmFilter!: FormGroup;
  @Output() sendFilterEvent:EventEmitter<GetPaginatedProductsRequest> = new EventEmitter<GetPaginatedProductsRequest>();
  getPaginatedProductsRequest = new GetPaginatedProductsRequest();  

  sendFilterClick(){
      this.getPaginatedProductsRequest.title = this.title;  
      this.sendFilterEvent.emit(this.getPaginatedProductsRequest); 
  }

  redirecionarNovoProduto() {
    this.router.navigate(['/novo-produto']);
  }

  get title(){
      return this.frmFilter.get('title')?.value;  
  }

  constructor(private router: Router, private fb: FormBuilder,){

    this.createForm();  

  }

  createForm(){
    this.frmFilter = this.fb.group({
      title:['']
    });
  }

}
