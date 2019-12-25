import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DistrictDashboardModel, DistrictModel } from './district.model';

@Injectable({
  providedIn: 'root'
})
export class DistrictService {
private readonly createPath = 'district/create';
private readonly getPath = 'district/get';
private readonly updatePath='district/update';
private readonly deletePath = 'district/';
  constructor(private _http: HttpClient) { }

public get(): Observable<DistrictDashboardModel[]>{
    return this._http.get<DistrictDashboardModel[]>(this.getPath);
}

public update(model: DistrictDashboardModel):Observable<any>{
    return this._http.post(this.updatePath,model);
}

public delete(id: string):Observable<string>{
    return this._http.delete<string>(this.deletePath.concat(id));
}

public create(model: DistrictModel):Observable<any>{
    return this._http.post(this.createPath,model);
}

}
