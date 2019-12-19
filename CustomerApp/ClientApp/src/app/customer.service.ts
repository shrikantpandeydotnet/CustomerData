import { Injectable } from '@angular/core';
import { HttpClient, HttpClientJsonpModule, HttpHeaders } from '@angular/common/http';
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { IResponseModel, ICustomer } from './customer/customer';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class Customerservice {

  readonly rootUrl = 'https://localhost:44399';

  constructor(private http: Http) { }

  // Method is used to save the Customer Record.
  saveCustomer(customer: ICustomer): Observable<IResponseModel> {
    let body = JSON.stringify(customer);
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    let options = new RequestOptions({ headers: headers });
    debugger;

    return this.http.post(this.rootUrl + '/api/values/PostCustomer', body, options)
      .map((response: Response) => <IResponseModel>response.json())
      .catch(this.handleError);
  }

  // Method is used to get all the customer added in the same session.
  getAllCustomer(): Observable<IResponseModel> {
    debugger;
    return this.http.get(this.rootUrl + '/api/values')
      .map((response: Response) => <IResponseModel>response.json())
      .catch (this.handleError);
  }

    // Throwing the error and log it at the Observer.
  handleError(error: Response)
  {
    return Observable.throw(error);
  }

}
