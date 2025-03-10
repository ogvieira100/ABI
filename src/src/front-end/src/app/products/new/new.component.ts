import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductsService } from '../../shared/services/products.service';
import { CreateProductRequest } from '../../shared/models/request/create-product-request';

@Component({
  selector: 'dev-ev-new',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new.component.html',
  styleUrl: './new.component.css'
})
export class NewComponent {
  productForm!: FormGroup;


  constructor(private fb: FormBuilder, private productService: ProductsService) {
    this.productForm = this.fb.group({
      title: ['', Validators.required],
      price: [null, [Validators.required, Validators.min(0.01)]],
      description: [''],
      category: ['', Validators.required],
      image: [''],
      rate: [null, [Validators.min(0), Validators.max(5)]],
      count: [null, [Validators.min(0)]]
    });
  }

  submitForm() {
    if (this.productForm.valid) {
      const product: CreateProductRequest = this.productForm.value;
      this.productService.createProducts(product).subscribe(response => {
        alert('Produto cadastrado com sucesso!');
        this.productForm.reset();
      }, error => {
        alert('Erro ao cadastrar produto.');
      }); 
    }
  }
}
  

