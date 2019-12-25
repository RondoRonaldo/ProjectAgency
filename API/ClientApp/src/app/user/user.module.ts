import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule, userRouterComponents } from './user.routing.module';
import { ReactiveFormsModule, FormsModule} from '@angular/forms';
import { LoginService } from './login/login.service';
import { RegistrationService } from './registration/registration.service';
import { TextMaskModule } from 'angular2-text-mask';
import { HeaderComponent } from './header/header.component';
import { MatButtonModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatButtonToggleModule, MatIconModule, MatIconRegistry } from '@angular/material';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';



@NgModule({
  declarations: [userRouterComponents, HeaderComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    ReactiveFormsModule,
    TextMaskModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatButtonToggleModule,
    MatIconModule,
    MatSlideToggleModule

  ],

  providers : [LoginService, RegistrationService,MatIconRegistry]
})
export class UserModule { }
