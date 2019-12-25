import { Component, OnInit } from '@angular/core';
import { DistrictDashboardModel, DistrictModel } from './district.model';
import { DistrictService } from './district.service';

@Component({
    selector: 'app-district',
    templateUrl: './district.component.html',
    styleUrls: ['./district.component.scss']
})
export class DistrictComponent implements OnInit {

    public districtData: DistrictDashboardModel[];
    public district = new DistrictModel();
    constructor(private districtService: DistrictService) {
    }

    ngOnInit() {
        this.getDistricts();
    }

    public createDistrict() {
        this.districtService.create(this.district).subscribe();
    }

    public getDistricts() {
        this.districtService.get().subscribe(data => this.districtData = data);
    }

    public updateDistrict(i: number) {
        this.districtService.update(this.districtData[i]).subscribe();
    }

    public deleteDistrict(id: string) {
        this.districtService.delete(id).subscribe();
    }

}
