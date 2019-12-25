import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule } from '@angular/material';
import { PaginationComponent } from './pagination/pagination.component';


@NgModule({
  declarations: [PaginationComponent],
  imports: [
    MatPaginatorModule


  ],
  exports: [PaginationComponent]
})
export class SharedModule { }
