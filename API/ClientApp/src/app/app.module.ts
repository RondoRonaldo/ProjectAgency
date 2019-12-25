import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { UserModule } from './user/user.module';
import { AppRoutingModule } from './app.routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Interceptor } from './core/interceptor';
import { MainModule } from './main/main.module';
import { LoginGuard } from './user/canActivate.guard';
import {CookieService} from 'ngx-cookie-service';
import { AdminModule } from './admin/admin.module';
import { NotificationComponent } from './core/notifications/notification.component';


@NgModule({
    declarations: [AppComponent,NotificationComponent],
    imports: [
        HttpClientModule,
        UserModule,
        RouterModule,
        BrowserModule,
        MainModule,
        AdminModule,
        AppRoutingModule
    ],
    bootstrap: [AppComponent],
    providers: [
    {
        provide : HTTP_INTERCEPTORS,
        useClass : Interceptor,
        multi : true
    },
    LoginGuard,
    CookieService
]
})


export class AppModule { }
