import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../core/auth.service';
import { ReplaySubject, Observable } from 'rxjs';
import { ProfileModel } from './profile.model';
import { MainService } from '../main/main.service';
import { map } from 'rxjs/operators';
@Injectable({
    providedIn: 'root'
})
export class AdminService {
    constructor(private _http: HttpClient,
        private authService: AuthService,
        private _mainService: MainService) {

    }

    public isAdmin(): Observable<boolean> {
        if (this.authService.isLogedIn()) {
            return this._mainService.getUser().pipe
                (map(profile => 'admin' === profile.role));


        }
    }


}