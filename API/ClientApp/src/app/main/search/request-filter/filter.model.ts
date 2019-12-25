export class UserFilterModel {
    squareFrom?: number;
    squareTo?: number;

    numberOfRoomsFrom?: number;
    numberOfRoomsTo?: number;

    dateFrom?: Date;
    dateTo?: Date;

    pageSize: number;
    pageIndex: number;

    district: string;
    isForRent?: boolean;

}

export class AdminFilterModel extends UserFilterModel {

    isModerated?: boolean;
    isAccepted?: boolean;
}
