import { Component } from '@angular/core';
import { FilterComponent } from "../filter/filter.component";
import { ListComponent } from "../list/list.component";
import { PaginationComponent } from "../../shared/components/pagination/pagination.component";

@Component({
  selector: 'dev-ev-search',
  standalone: true,
  imports: [FilterComponent, ListComponent, PaginationComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {

}
