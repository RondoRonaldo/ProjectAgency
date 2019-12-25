import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegistrationModel } from './registration.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
export const path = 'auth/registration';

@Injectable({
    providedIn: 'root'
})
export class RegistrationService {

    constructor(private _http: HttpClient) { }
    public signUp(userData: RegistrationModel): Observable<Object> {
        return this._http.post(path, userData);

    }
}
