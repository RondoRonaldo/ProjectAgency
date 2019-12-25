import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../core/auth.service';



@Injectable()
export class LoginGuard implements CanActivate {
    constructor(private router: Router, private auth: AuthService) {

    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (!this.auth.isLogedIn()) {
            return true;
        }
        this.router.navigate(['..', 'main']);
        return false;
    }
}


