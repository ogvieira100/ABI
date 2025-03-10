import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from '../../shared/services/products.service';
import { UpdateProductRequest } from '../../shared/models/request/update-product-request';

@Component({
  selector: 'dev-ev-update',
  standalone: true,
  imports: [],
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent {

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
        const product: UpdateProductRequest = this.productForm.value;
        this.productService.createProducts(product).subscribe(response => {
          alert('Produto Atualizado com sucesso!');
          
        }, error => {
          alert('Erro ao atualizar produto.');
        }); 
      }
    }

}
