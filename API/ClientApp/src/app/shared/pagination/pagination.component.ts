import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PageEvent } from '@angular/material';
import { PageDataModel } from './page.model';


@Component({
    selector: 'app-pagination',
    templateUrl: './pagination.component.html',
    styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {

    @Input() totalRecords: number;
    @Output() onPageChanged: EventEmitter<PageDataModel> = new EventEmitter<PageDataModel>();

    public pageSize: number = 5;
    public pageSizeOptions: number[] = [5, 10, 20];

    ngOnInit() {
        let page = new PageDataModel(this.pageSize, 0);
        this.onPageChanged.emit(page);
    }

    public onPagination(e: PageEvent) {
        let page = new PageDataModel(e.pageSize, e.pageIndex);
        this.onPageChanged.emit(page);
    }

}
