import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export const path = 'auth/logout';


@Injectable({
    providedIn: 'root'
})
export class LogoutService {

    constructor(private _http: HttpClient) { }

    public logOut(): Observable<object> {
        return this._http.post(path, '');

    }
}
