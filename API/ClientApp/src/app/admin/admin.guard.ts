import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AdminService } from './admin.service';
import { map } from 'rxjs/operators';
@Injectable({
    providedIn: 'root'
})
export class AdminGuard implements CanActivate {

    constructor(private _router: Router, private _adminService: AdminService) { }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        return this._adminService.isAdmin().pipe(
            map(resp => {
                if (!resp) {
                    this._router.navigateByUrl('/main');
                }
                return resp;
            }))
    }

}


