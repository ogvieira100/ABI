// models/paginated-response.ts
import { Product } from '../domain/product';    

export class PaginatedResponse<T> {
  currentPage: number = 1;
  totalPages: number = 0;
  totalCount: number = 0;
  data: T[] = [];
  success: boolean = false;
  message: string = '';
  errors: string[] = [];
}