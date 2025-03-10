import { PagedDataRequest } from "./paged-data-request";

export class GetPaginatedProductsRequest extends PagedDataRequest {
  title?: string;
  price?: number;
  description?: string;
  category?: string;
  image?: string;
  rate?: number;
  count?: number;
}