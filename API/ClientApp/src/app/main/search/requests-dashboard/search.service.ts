import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { PageRequestModel, PageModel } from 'src/app/shared/pagination/page.model';

import { AdminFilterModel, UserFilterModel } from '../request-filter/filter.model';
import { RequestModerationModel } from './request-moderation.model';
import { RequestDashboardModel } from './request-dashboard.model';

@Injectable({
    providedIn: 'root'
})
export class SearchService {
    private readonly filterAsAdminPath = 'admin/requestsearch';
    private readonly filterasUserPath = 'request/requestsearch';
    private readonly moderateRequestPath= 'admin/moderate';

    public currentSearch = new BehaviorSubject<RequestDashboardModel[]>(RequestDashboardModel['']);
    constructor(private _http: HttpClient) {}

    public getDataAsAdmin(searchData: PageRequestModel<AdminFilterModel>): Observable<PageModel<RequestDashboardModel>> {

        return this._http
            .post<PageModel<RequestDashboardModel>>(this.filterAsAdminPath,searchData)
            .pipe(tap(data =>
                this.currentSearch.next(data.records)
            ));
    }

    public getDataAsUser(searchData: PageRequestModel<UserFilterModel>): Observable<PageModel<RequestDashboardModel>> {

        return this._http
            .post<PageModel<RequestDashboardModel>>(this.filterasUserPath,searchData)
            .pipe(tap(data =>
                this.currentSearch.next(data.records)
            ));
    }

    public refreshCurrentSearch(): void {
        this.currentSearch.next(RequestDashboardModel['']);
    }

    public requestModeration(model: RequestModerationModel): Observable<any>
    {
        return this._http.post(this.moderateRequestPath,model);
    }
}
