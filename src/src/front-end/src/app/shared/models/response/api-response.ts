import { PaginatedResponse } from "./paginated-response";

export class ApiResponse<T> {

    data: PaginatedResponse<T> = new PaginatedResponse();   
    success: boolean = false;
    message: string = '';
    errors: string[] = [];
}

export class ApiResponseSend<T> {
    data: T;
    success: boolean;
    message: string;
    errors: { error: string; detail: string }[];
  
    constructor(
      data: T,
      success: boolean = true,
      message: string = '',
      errors: { error: string; detail: string }[] = []
    ) {
      this.data = data;
      this.success = success;
      this.message = message;
      this.errors = errors;
    }
  }