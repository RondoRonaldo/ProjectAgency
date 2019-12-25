import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RequestDetailsService } from './request-details.service';
import { RequestDetailsModel } from './request-details.model';
import { CommentModel } from './comment.model';
import { MainService } from '../../main.service';
import { CommentDashboardModel } from './Comment-dashboard.model';
import { UserInfoModel } from '../../account/userInfo.model';

@Component({
  selector: 'app-request-details',
  templateUrl: './request-details.component.html',
  styleUrls: ['./request-details.component.scss']
})
export class RequestDetailsComponent implements OnInit {

public  requestData = new RequestDetailsModel();

public commentData = new CommentModel();

  constructor(private route: ActivatedRoute,private _requestDetailsService: RequestDetailsService,private _mainService: MainService) { }

  ngOnInit() {
    this._requestDetailsService.getRequestDetails(this.route.snapshot.params['id']).subscribe(data=>{this.requestData=data,this.commentData.requestId=data.id});
}

public addComment(): void
{
  this._requestDetailsService.updateComments(this.commentData).subscribe(data=>this.requestData.comments.push(data));
}

}
