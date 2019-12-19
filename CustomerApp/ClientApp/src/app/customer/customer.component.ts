import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Customerservice } from '../customer.service';
import { ICustomer, IResponseModel } from './customer';
import { Ng2SmartTableModule, LocalDataSource } from 'ng2-smart-table';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customerForm: FormGroup
  Name: FormControl
  DateOfBirth: FormControl
  Address: FormControl
  customer: ICustomer[];
  source: LocalDataSource = new LocalDataSource(); // Local data source to load ng2-smart-table

  constructor(private cust: Customerservice) { } // Getting cust service object using Angular Dependency Injection.

  ngOnInit() {

    this.Name = new FormControl();
    this.DateOfBirth = new FormControl();
    this.Address = new FormControl();

    this.customerForm = new FormGroup({
      Name: this.Name,
      DateOfBirth: this.DateOfBirth,
      Address: this.Address
    });

    this.getAllCustomer() // calling method to prefill the table.
  }

  // Method is used to save customer.
  saveCustomer(obj: ICustomer) {
    this.cust.saveCustomer(obj).subscribe((data) => {
      if (data) {
        alert("Data Saved Sucessfully");
        this.getAllCustomer();
      }

      // reseting the form after sucesfully Save.
      this.customerForm.reset();
    })
  }

  // Method is used to get all customer list and load the source.
  getAllCustomer() {
    this.cust.getAllCustomer().subscribe((data) => {
      if (data) {
        this.customer = JSON.parse(data.Data.toString());
        this.source.load(this.customer);
      }
    },
      // I am logging the error in console but we can save it in log file for troubleshooting the error.
      (error) => { console.error(error); });
  }

  settings = {
    columns: {
      Name: {
        title: 'Name'
      },
      DateOfBirth: {
        title: 'DateOfBirth'
      },
      Address: {
        title: 'Title'
      }
    }
  }
}
