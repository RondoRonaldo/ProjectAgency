import { RequestModel } from "../../request-creator/request.model";
import { UserInfoModel } from "../../account/userInfo.model";

export class RequestDashboardModel extends RequestModel{
    id: string;
    CreationDate: Date;
    userInfo: UserInfoModel;
}