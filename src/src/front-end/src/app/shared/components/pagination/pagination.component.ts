import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'dev-ev-pagination',
  standalone: true,
  imports: [ NgbPaginationModule], // Adicione aqui
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css'
})
export class PaginationComponent {

  @Input() totalItems: number = 0;
  @Input() pageSize: number = 10;
  @Output() pageChange = new EventEmitter<number>();

  currentPage = 1;
  
  onPageChange(page: number) {
    this.currentPage = page;
    this.pageChange.emit(this.currentPage);
  }

}
