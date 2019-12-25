import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { RegistrationModel } from './registration.model';
import { RegistrationService } from './registration.service';
import { passwordMatchValidator } from './registration.validators';
@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss'],
    providers: [RegistrationService, FormBuilder]
})
export class RegistrationComponent  {

    public userData: FormGroup;
public passwords: FormGroup;

    public phoneMask = ['(', /[0-9]/, /\d/, /\d/, ')', '-', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
    public showPassword = false;






    constructor(private _registration: RegistrationService, private _fb: FormBuilder) {
        this.passwords = this._fb.group({
            password: new FormControl('', [Validators.required, Validators.minLength(8)]),
            confirmPassword: new FormControl('', [Validators.required]),
        }, { validators: passwordMatchValidator });
        this.userData = this._fb.group({
            email: new FormControl('', [
                Validators.required,
                Validators.email,
            ]),
            passwords: this.passwords,
            phoneNumber: new FormControl('', [Validators.required]),
            name: new FormControl('')
        });
    }




    public Register(): void {
let data =this.userData.value as RegistrationModel;
    data.password = this.passwords.controls['password'].value;
    data.confirmPassword = this.passwords.controls['confirmPassword'].value;
        this._registration.signUp(data).subscribe();
    }

}






