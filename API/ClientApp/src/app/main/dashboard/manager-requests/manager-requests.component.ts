import { Component, OnInit } from '@angular/core';


import { RequestDashboardModel } from './request-dashboard.model';
import { ManagerRequestsService } from './manager-requests.service';



@Component({
    selector: 'app-manager-requests',
    templateUrl: './manager-requests.component.html',
    styleUrls: ['./manager-requests.component.scss']
})
export class ManagerRequestsComponent implements OnInit {
    public page: number = 1;
    public pageSize: number = 6;

    public requestRecords = new RequestDashboardModel();
    ngOnInit() {
        this._requestService.GetRequests().subscribe(data => this.requestRecords = data);
        // this._requestService.GetRequests().subscribe(data => this.requestRecords = data, error => notificationService.error('msg'));
    }


    constructor(private _requestService: ManagerRequestsService) {


    }


}





