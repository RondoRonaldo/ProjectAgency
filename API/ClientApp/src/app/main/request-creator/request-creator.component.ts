import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RequestCreatorService } from './request-creator.service';
import { RequestModel } from './request.model';
import { DistrictDashboardModel, DistrictModel } from 'src/app/admin/district/district.model';
import { DistrictService } from 'src/app/admin/district/district.service';
import { NotificationService } from 'src/app/core/notifications/notification.service';

@Component({
    selector: 'app-request-creator',
    templateUrl: './request-creator.component.html',
    styleUrls: ['./request-creator.component.scss']
})
export class RequestCreatorComponent {
    public requestData: FormGroup;
    public districts: DistrictModel[];

    constructor(private fb: FormBuilder,private _requestService : RequestCreatorService,private _districtService: DistrictService, private notification: NotificationService) {

        this.requestData = this.fb.group({
            header: [''],
            body: [''],
            square: [''],
            numberOfRooms: [''],
            district: [''],
            isForRent: ['']
        });
        this.getDistricts();
    }

    public CreateRequest(): void {
        this._requestService.CreateRequest(this.requestData.value).subscribe(()=>this.notification.success('Request created.'), error => this.notification.error("Something went wrong, try later"));
    }

    public getDistricts()
    {
        this._districtService.get().subscribe(data=>this.districts=data);
    }
}
