import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { PaginateModel } from '../../models/utils/paginate-model';
@Component({
  selector: 'dev-ev-pagination',
  standalone: true,
  imports: [ NgbPaginationModule], // Adicione aqui
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css'
})
export class PaginationComponent {

  @Input() paginateModel: PaginateModel = new PaginateModel();  
  @Output() pageChange:EventEmitter<PaginateModel> = new EventEmitter<PaginateModel>();

  
  
  onPageChange(page: number) {
    this.paginateModel.currentPage = page;
    this.pageChange.emit(this.paginateModel);
  }

}
