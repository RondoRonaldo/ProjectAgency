import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const appRoutes: Routes = <Routes>[
    { path: '', redirectTo: '/main/search', pathMatch: 'full' },
    { path: '**', redirectTo: '/main/search' }
];







@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ]
})

export class AppRoutingModule {

}
