import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RequestUpdateModel } from './request-update.model';
import { RequestDetailsModel } from '../../search/request-details/request-details.model';

@Injectable({
    providedIn: 'root'
})
export class RequestEditorService {
    private readonly getRequestPath = 'request/userrequests/';
    private readonly updateRequestPath = 'request/update';
    private readonly deleteRequestPath = 'request/delete/';
    constructor(private _http: HttpClient) {

    }

    public GetUserRequest(id: string): Observable<RequestDetailsModel>
    {
return this._http.get<RequestDetailsModel>(this.getRequestPath.concat(id));

    }

    public UpdateRequest(requestModel: RequestUpdateModel): Observable<any>
    {
        return this._http.post(this.updateRequestPath,requestModel);
    }

    public DeleteRequest(id: string): Observable<any>
    {
        return this._http.post(this.deleteRequestPath.concat(id),'');
    }



}
