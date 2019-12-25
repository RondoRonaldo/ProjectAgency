import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PasswordModel } from './updatePassword.model';
import { UserInfoModel } from './userInfo.model';



@Injectable({
    providedIn: 'root'
})
export class UserService {
    private readonly updateInfoPath = 'account/update';
    private readonly updatePasswordPath = 'account/password';
    private readonly getUserInfoPath = 'account/info';
    constructor(private _http: HttpClient) { }

    public UpdateUserInfo(info: UserInfoModel): Observable<object> {
        return this._http.post(this.updateInfoPath, info);
    }

    public UpdateUserPassword(info: PasswordModel): Observable<object> {
        return this._http.post(this.updatePasswordPath, info);
    }

    public GetUserInfo(): Observable<UserInfoModel> {
        return this._http.get<UserInfoModel>(this.getUserInfoPath);
    }

}
