export class RequestModerationModel {
    requestId: string;
    isAccepted: boolean;
    constructor(requestId: string,
        isAccepted: boolean) {
this.requestId=requestId;
this.isAccepted=isAccepted;
    }
}