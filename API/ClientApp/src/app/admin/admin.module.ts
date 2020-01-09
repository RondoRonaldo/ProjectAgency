import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin.routing.module';
import { AdminComponent } from './admin.component';
import { AdminService } from './admin.service';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { DistrictComponent } from './district/district.component';
import { MatInputModule, MatButtonModule } from '@angular/material';



@NgModule({
    declarations: [AdminComponent, AdminHeaderComponent, DistrictComponent],
    imports: [
        CommonModule,
        FormsModule,
        AdminRoutingModule,
        RouterModule,
        MatInputModule,
        MatButtonModule
    ],
    providers: [AdminService]
})
export class AdminModule { }
