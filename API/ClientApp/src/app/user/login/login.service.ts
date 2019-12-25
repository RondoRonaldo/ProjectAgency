import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from './login.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
const path = 'auth/login';
@Injectable()

export class LoginService {


    constructor(private http: HttpClient) { }
    public signIn(userData: LoginModel): Observable<any> {
        return this.http.post(path, userData);
    }
}


