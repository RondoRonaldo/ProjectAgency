import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main.component';
import { RequestSearchComponent } from './search/requests-dashboard/request-dashboard.component';
import { ManagerRequestsComponent } from './dashboard/manager-requests/manager-requests.component';
import { AccountComponent } from './account/account.component';
import { RequestEditorComponent } from './dashboard/request-editor/request-editor.component';
import { RequestCreatorComponent } from './request-creator/request-creator.component';
import { LoginGuard } from '../user/canActivate.guard';
import { MainGuard } from './canActivate.guard';
import { RequestDetailsComponent } from './search/request-details/request-details.component';
import { SearchComponent } from './search/search.component';





const mainRoutes: Routes = <Routes>[
    {
        path: 'main', component: MainComponent, canActivate: [MainGuard], children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: ManagerRequestsComponent },
            { path: 'search', component: SearchComponent },
            { path: 'account', component: AccountComponent },
            { path: 'dashboard/:id', component: RequestEditorComponent },
            { path: 'search/:id', component: RequestDetailsComponent },
            { path: 'create', component: RequestCreatorComponent },
        ]
    }
];

export const userRouterComponents = [
    RequestSearchComponent,
    ManagerRequestsComponent,
    AccountComponent,
    RequestEditorComponent,
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
