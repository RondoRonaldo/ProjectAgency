import { CommentDashboardModel } from "./Comment-dashboard.model";
import { RequestModel } from "../../request-creator/request.model";
import { UserInfoModel } from "../../account/userInfo.model";

export class RequestDetailsModel extends RequestModel {
    id: string;
    creationDate: Date;
    userInfo: UserInfoModel;
    comments: CommentDashboardModel[];
}
