import { Component, Input } from '@angular/core';
import { RequestDashboardModel } from '../request-dashboard.model';

@Component({
    selector: 'app-request-list-item',
    templateUrl: './request-list-item.component.html',
    styleUrls: ['./request-list-item.component.scss']
})
export class RequestListItemComponent {
    @Input() item: RequestDashboardModel;
    @Input() displayPersonalInfo: boolean;
}
