import { Injectable } from '@angular/core';
import { ReplaySubject, Observable } from 'rxjs';
import { ProfileModel } from '../admin/profile.model';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class MainService {

    private readonly path = 'account/get';

	private user = new ReplaySubject<ProfileModel>(1);
	private hasUser = false;
    constructor(private _http: HttpClient) { }



private fetchUserProfile(): Observable<ProfileModel>
{
return this._http.get<ProfileModel>(this.path);
}



    public getUser(): Observable<ProfileModel> {
        if (!this.hasUser) {
            return this.fetchUserProfile().pipe
                (map(profile => {
                    this.user.next(profile);
                    this.hasUser = true;
                    return profile;
                }));
        }
        return this.user.asObservable();
    }

public removeUser(): void {
    this.hasUser = false;
    this.user.next({ email: '', role: '', name: '',phoneNumber: '' });
}



}
