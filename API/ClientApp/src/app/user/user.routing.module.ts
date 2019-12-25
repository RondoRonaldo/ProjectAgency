import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { LoginGuard } from './canActivate.guard';
import { AuthPageComponent } from './auth-page/auth-page.component';



const userRoutes: Routes = <Routes>[
    {
        path: 'auth', component : AuthPageComponent, canActivate: [LoginGuard],
        children: [
            { path: 'registration', component: RegistrationComponent },
            { path: 'login', component: LoginComponent },
            {path: '', redirectTo: 'login',pathMatch: 'full'}
        ]
    }
];



export const userRouterComponents = [
    LoginComponent,
    RegistrationComponent,
    AuthPageComponent];

@NgModule({
       imports: [
        RouterModule.forChild(userRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class UserRoutingModule { }
