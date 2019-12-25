import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { RequestDashboardModel } from './request-dashboard.model';

const path = 'request/userrequests';
@Injectable({
    providedIn: 'root'
})
export class ManagerRequestsService {

    constructor(private _http: HttpClient) {
    }

    public GetRequests(): Observable<RequestDashboardModel> {
        return this._http.get<RequestDashboardModel>(path);
    }



}
