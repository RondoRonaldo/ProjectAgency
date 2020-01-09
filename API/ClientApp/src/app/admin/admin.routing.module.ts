import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminGuard } from './admin.guard';
import { DistrictComponent } from './district/district.component';

const adminRoutes: Routes = <Routes>[
    {
        path: 'admin', component: AdminComponent, canActivate: [AdminGuard], children:
            [
                { path: 'districts', component: DistrictComponent }

            ]
    }];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(adminRoutes)
    ]
})



export class AdminRoutingModule { }
