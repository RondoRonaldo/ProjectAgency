import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { UserService } from './User.service';
import { UserInfoModel } from './userInfo.model';
import { passwordMatchValidator } from 'src/app/user/registration/registration.validators';
import { NotificationService } from 'src/app/core/notifications/notification.service';

@Component({
    selector: 'app-account',
    templateUrl: './account.component.html',
    styleUrls: ['./account.component.scss']
})
export class AccountComponent {

    public passwordForm: FormGroup;
    public personalInfoForm: FormGroup;

    constructor(private _fb: FormBuilder, private _updateService: UserService, private notification: NotificationService) {
        this._updateService.GetUserInfo().subscribe(data => this.FillInfoFormGroup(data));
        this.passwordForm = this._fb.group({
            oldPassword: [''],
            newPasswords: this._fb.group({
                password: ['', [Validators.required, Validators.minLength(8)]],
                confirmPassword: ['', Validators.required]
            }, { validators: passwordMatchValidator })
        });

        this.personalInfoForm = this._fb.group({
            name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
            phoneNumber: ['', Validators.required]
        });
    }
    public UpdateUserInfo(): void {
        this._updateService.UpdateUserInfo(this.personalInfoForm.value).subscribe(() => this.notification.success('Personal information updated'), error => this.notification.error("Something went wrong, try later"));
    }

    public UpdateUserPassword(): void {
        this._updateService.UpdateUserPassword(this.passwordForm.value).subscribe(() => this.notification.success('Password updated.'), error => this.notification.error("Something went wrong, try later"));
    }

    private FillInfoFormGroup(userInfo: UserInfoModel) {
        this.personalInfoForm.controls['name'].setValue(userInfo.name);
        this.personalInfoForm.controls['phoneNumber'].setValue(userInfo.phoneNumber);
    }


}





