import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { notificationModel } from './notification.model';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
public subject = new Subject<notificationModel>();


public success(message: string){
    this.subject.next({type:'success', text: message })
}

public error(message: string){
    this.subject.next({type:'error', text: message })
}

public getMessage(): Observable<notificationModel>{
   return this.subject.asObservable();
}

}
