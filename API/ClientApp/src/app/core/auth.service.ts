import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { strict } from 'assert';
@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(private _http: HttpClient) { }
    public isLogedIn(): boolean {
        return this.getCookie('appAuth') ? true : false;
    }

    private getCookie(name: string) {
        let matches = document.cookie.match(new RegExp(
            '(?:^|; )' + name.replace(/([.$?|{}()[]\/+^])/g, '\$1') + '=([^;])'
        ));
        return matches ? decodeURIComponent(matches[1]) : undefined;
    }
}
