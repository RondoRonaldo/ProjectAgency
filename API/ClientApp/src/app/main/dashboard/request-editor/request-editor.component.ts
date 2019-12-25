import { Component, OnInit } from '@angular/core';
import { RequestEditorService } from './request-editor.service';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestModel } from '../../request-creator/request.model';
import { RequestUpdateModel } from './request-update.model';
import { RequestDetailsModel } from '../../search/request-details/request-details.model';

@Component({
  selector: 'app-request-update',
  templateUrl: './request-editor.component.html',
  styleUrls: ['./request-editor.component.scss']
})
export class RequestEditorComponent implements OnInit{


public requestData = new RequestDetailsModel();


    ngOnInit() {
        this._editorService.GetUserRequest(this.route.snapshot.params['id']).subscribe(data => this.requestData = data);

    }

    public userRequest = new RequestDetailsModel();
    constructor(private _editorService: RequestEditorService, private route: ActivatedRoute, private router: Router) {

  }

public updateRequest() : void{
this._editorService.UpdateRequest(this.requestData as RequestUpdateModel).subscribe();
}

public deleteRequest() : void{
    this._editorService.DeleteRequest(this.route.snapshot.params['id']).subscribe();
    this.router.navigate(['..', 'main', 'dashboard']);
    }


}
