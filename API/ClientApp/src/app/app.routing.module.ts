import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const appRoutes: Routes = <Routes>[
    { path: '', redirectTo: '/main/dashboard', pathMatch: 'full' },
    { path: '**', redirectTo: '/main/dashboard' }
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
