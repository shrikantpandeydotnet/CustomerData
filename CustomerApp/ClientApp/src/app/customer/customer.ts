export interface ICustomer {
  Name: string;
  DateOfBirth: Date;
  Address: string;
}

export interface IResponseModel {

  Data: ICustomer[];
  Status: boolean;
  Message: string;
}
