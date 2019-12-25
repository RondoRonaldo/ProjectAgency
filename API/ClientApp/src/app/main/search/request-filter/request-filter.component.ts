import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SearchService } from '../requests-dashboard/search.service';
import { PageRequestModel, PageDataModel } from 'src/app/shared/pagination/page.model';
import { AdminService } from 'src/app/admin/admin.service';
import { map } from 'rxjs/operators';
import { AdminFilterModel, UserFilterModel } from './filter.model';
import { DistrictDashboardModel } from 'src/app/admin/district/district.model';
import { DistrictService } from 'src/app/admin/district/district.service';

@Component({
    selector: 'app-request-filter',
    templateUrl: './request-filter.component.html',
    styleUrls: ['./request-filter.component.scss'],
    providers: [FormBuilder]
})
export class RequestFilterComponent implements OnDestroy {

    public totalRecords = 0;
    @Input() pageSize = 5;
    public filter = new AdminFilterModel();
    public isAdmin: boolean;
    public districts: DistrictDashboardModel[];
    constructor(private fb: FormBuilder, private _searchService: SearchService, private _adminService: AdminService, private _districtService: DistrictService) {

        this.adminCheck();
        this.getDistricts();
    }

    private adminCheck() {
        return this._adminService.isAdmin().subscribe(data => {this.isAdmin = data;this.getResults()});
    }

    ngOnDestroy(): void {
        this._searchService.refreshCurrentSearch();
        this._adminService
    }


    private getData(request: PageRequestModel<AdminFilterModel>)
    {
        if (this.isAdmin) {
            this._searchService.getDataAsAdmin(request).subscribe(data => this.totalRecords = data.totalRecords)
        }
        else {
            this._searchService.getDataAsUser(request).subscribe(data => this.totalRecords = data.totalRecords)
        }
    }

    public getResults() {
        let request = new PageRequestModel<AdminFilterModel>(this.pageSize, 0, this.filter);
        this.getData(request);
    }


    public onPageChanged(page: PageDataModel) {
        let request = new PageRequestModel<AdminFilterModel>(page.pageSize, page.pageIndex, this.filter);
        this.getData(request);
    }

    public getDistricts() {
        this._districtService.get().subscribe(data => this.districts = data);
    }
}