
export class PageDataModel {
	public pageSize: number;
	public pageIndex: number;

	constructor(pageSize: number, pageIndex: number) {
		this.pageSize = pageSize;
		this.pageIndex = pageIndex;
	}
}


export class PageRequestModel<T> extends PageDataModel{

     constructor(pageSize: number, pageIndex: number, request: T){
         super(pageSize,pageIndex);
         this.request = request;
     }
request: T;
}



export class PageModel<T>  {
	public totalRecords: number;
	public records: T[];


}
