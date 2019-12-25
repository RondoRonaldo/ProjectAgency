

import { Component } from '@angular/core';
// import { Router } from '@angular/router';
import { LoginModel } from './login.model';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    providers: [LoginService]
})
export class LoginComponent {


    public showPassword = false;
    public userData: FormGroup;

    constructor(private _loginService: LoginService, private router: Router, private _fb: FormBuilder) {
        this.userData = this._fb.group({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required]),
            isPersistent: new FormControl(false)
        });
    }

    public SignIn(): void {
        this._loginService.signIn(this.userData.value).subscribe(() =>
            this.router.navigate(['..', 'main', 'dashboard']));

    }
}
