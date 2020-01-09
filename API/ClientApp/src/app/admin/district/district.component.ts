import { Component, OnInit } from '@angular/core';
import { DistrictDashboardModel, DistrictModel } from './district.model';
import { DistrictService } from './district.service';
import { NotificationService } from 'src/app/core/notifications/notification.service';

@Component({
    selector: 'app-district',
    templateUrl: './district.component.html',
    styleUrls: ['./district.component.scss']
})
export class DistrictComponent implements OnInit {

    public districtData: DistrictDashboardModel[];
    public district = new DistrictModel();
    constructor(private districtService: DistrictService, private notification: NotificationService) {
    }

    ngOnInit() {
        this.getDistricts();
    }

    public createDistrict() {
        this.districtService.create(this.district).subscribe(() => this.notification.success('District created.'), error => this.notification.error("Something went wrong, try later"));
    }

    public getDistricts() {
        this.districtService.get().subscribe(data => this.districtData = data);
    }

    public updateDistrict(i: number) {
        this.districtService.update(this.districtData[i]).subscribe(() => this.notification.success('District updated.'), error => this.notification.error("Something went wrong, try later"));
    }

    public deleteDistrict(id: string) {
        this.districtService.delete(id).subscribe(() => this.notification.success('District deleted.'), error => this.notification.error("Something went wrong, try later"));
    }

}
