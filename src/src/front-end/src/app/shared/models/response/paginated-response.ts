// models/paginated-response.ts
import { Product } from '../domain/product';    

export class PaginatedResponse {
  currentPage: number = 1;
  totalPages: number = 0;
  totalCount: number = 0;
  data: Product[] = [];
  success: boolean = false;
  message: string = '';
  errors: string[] = [];
}