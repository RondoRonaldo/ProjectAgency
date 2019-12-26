import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { MainRoutingModule, userRouterComponents } from './main.routing.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatFormFieldModule, MatInputModule, MatRadioButton, MatRadioModule, MatListModule, MatSelectModule, MatIconModule, MatButtonModule, MatDatepicker, MatDatepickerModule, MatNativeDateModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '../shared/shared.module';
import { MainService } from './main.service';
import { RequestFilterComponent } from './search/request-filter/request-filter.component';
import { RequestListItemComponent } from './dashboard/manager-requests/request-list-item/request-list-item.component';



@NgModule({
    declarations: [MainComponent, userRouterComponents, RequestFilterComponent, HeaderComponent, RequestListItemComponent],
    imports: [
        CommonModule,
        SharedModule,
        MainRoutingModule,
        RouterModule,
        ReactiveFormsModule,
        FormsModule,
        NgbModule,
        MatFormFieldModule,
        MatInputModule,
        BrowserAnimationsModule,
        MatRadioModule,
        MatListModule,
        MatSelectModule,
        MatIconModule,
        MatButtonModule,
        MatDatepickerModule,
        MatNativeDateModule


    ],
    providers: [MainService]

})
export class MainModule { }
