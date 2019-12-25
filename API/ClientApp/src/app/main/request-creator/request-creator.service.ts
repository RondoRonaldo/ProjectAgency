import { Injectable } from '@angular/core';
import { RequestModel } from './request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DistrictModel } from 'src/app/admin/district/district.model';
@Injectable({
    providedIn: 'root'
})
export class RequestCreatorService {
    private readonly createPath = 'request/create';

    constructor(private _http: HttpClient) {
    }
    public CreateRequest(RequestData: RequestModel): Observable<Object> {
        return this._http.post(this.createPath, RequestData);
    }

}
