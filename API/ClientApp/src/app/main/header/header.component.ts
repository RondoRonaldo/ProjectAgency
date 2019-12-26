import { Component, OnInit } from '@angular/core';
import { LogoutService } from 'src/app/core/logout.service';
import { Router } from '@angular/router';
import { MainService } from '../main.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
public isAdmin = false;
    constructor(private _exit: LogoutService,private router: Router,private _mainService: MainService) {}
    public logOut() {
        this._exit.logOut().subscribe(()=>
        this.router.navigateByUrl('auth'));
        this._mainService.removeUser();
    }
}
