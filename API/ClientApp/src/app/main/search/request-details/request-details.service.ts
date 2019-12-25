import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CommentModel } from './comment.model';
import { RequestDetailsModel } from './request-details.model';


@Injectable({
  providedIn: 'root'
})
export class RequestDetailsService {
private readonly requestDetailsPath = 'request/userrequests/';
private readonly updateCommentsPath = 'comment/create';

  constructor(private _http: HttpClient) {

   }

 public getRequestDetails(id: string) : Observable<RequestDetailsModel>{
return this._http.get<RequestDetailsModel>(this.requestDetailsPath.concat(id));
}
public updateComments(data: CommentModel): Observable<any>{
    return this._http.post(this.updateCommentsPath, data);
}
}
