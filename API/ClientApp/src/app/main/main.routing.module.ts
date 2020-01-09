import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main.component';
import { RequestSearchComponent } from './search/requests-dashboard/request-dashboard.component';
import { AccountComponent } from './account/account.component';
import { RequestCreatorComponent } from './request-creator/request-creator.component';
import { MainGuard } from './canActivate.guard';
import { RequestDetailsComponent } from './search/request-details/request-details.component';
import { SearchComponent } from './search/search.component';





const mainRoutes: Routes = <Routes>[
    {
        path: 'main', component: MainComponent, canActivate: [MainGuard], children: [
            { path: '', redirectTo: 'search', pathMatch: 'full' },
            { path: 'search', component: SearchComponent },
            { path: 'account', component: AccountComponent },
            { path: 'search/:id', component: RequestDetailsComponent },
            { path: 'create', component: RequestCreatorComponent },
        ]
    }
];

export const userRouterComponents = [
    RequestSearchComponent,
    AccountComponent,
    RequestCreatorComponent,
    RequestDetailsComponent,
    SearchComponent
];


@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild(mainRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
