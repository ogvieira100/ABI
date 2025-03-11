import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductsService } from '../../shared/services/products.service';
import { UpdateProductRequest } from '../../shared/models/request/update-product-request';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'dev-ev-update',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent implements OnInit {  

  productForm!: FormGroup;


  constructor(private route: ActivatedRoute, private fb: FormBuilder,
     private productService: ProductsService) 
{
    this.productForm = this.fb.group({
      id: ['', Validators.required],
      title: ['', Validators.required],
      price: [null, [Validators.required, Validators.min(0.01)]],
      description: [''],
      category: ['', Validators.required],
      image: [''],
      rate: [null, [Validators.min(0), Validators.max(5)]],
      count: [null, [Validators.min(0)]]
    });
  }
  ngOnInit(): void {
    this.getProductById();  
  }


  getProductById() {
    this.route.paramMap.subscribe(async (par) => {
        const id = par.get('id') ?? '';

        this.productService.getProduct(id).subscribe(response => {
          this.productForm.patchValue(response.data);
        }, error => {
          alert('Erro ao buscar produto.')});
          
    });
  }

  submitForm() {
    if (this.productForm.valid) {
      const product: UpdateProductRequest = this.productForm.value;
      this.productService.upadteProducts(product).subscribe(response => {
        alert('Produto Atualizado com sucesso!');

      }, error => {
        alert('Erro ao atualizar produto.');
      });
    }
  }

}
