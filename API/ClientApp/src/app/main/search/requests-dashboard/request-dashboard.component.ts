import { Component, OnInit } from '@angular/core';
import { SearchService } from './search.service';
import { AdminService } from 'src/app/admin/admin.service';
import { RequestModerationModel } from './request-moderation.model';
import { RequestDashboardModel } from './request-dashboard.model';
import { NotificationService } from 'src/app/core/notifications/notification.service';

@Component({
    selector: 'app-request-dashboard',
    templateUrl: './request-dashboard.component.html',
    styleUrls: ['./request-dashboard.component.scss']
})
export class RequestSearchComponent implements OnInit {
    public isAdmin: boolean;
    public totalRecords: number;
    public data: RequestDashboardModel[];
    constructor(private _search: SearchService, private _adminService: AdminService,private notification: NotificationService) {
        this.adminCheck();
    }

    ngOnInit(): void {
        this._search.currentSearch.subscribe(data => {
            this.data = data;
        });
    }

    private adminCheck() {
        return this._adminService.isAdmin().subscribe(data => this.isAdmin = data);
    }

    public moderateRequest(requestId: string,isAccepted: boolean) {
        var request = new RequestModerationModel(requestId,isAccepted);
        this._search.requestModeration(request).subscribe(()=>this.notification.success('Status updated.'), error => this.notification.error("Something went wrong, try later"));
    }

}
