import { Component, OnInit } from '@angular/core';
import { NotificationService } from './notification.service';
import { notificationModel } from './notification.model';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {
public message: notificationModel;
  constructor(private _notificationService: NotificationService) {
  }

  ngOnInit() {
      this._notificationService.getMessage().subscribe(message=>this.message=message);
  }

  public closeNotification(){
      this.message=null;
  }
}
