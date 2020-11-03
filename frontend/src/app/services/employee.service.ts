import { Injectable } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { Observable, Observer } from  "rxjs";
import { HttpClient } from  "@angular/common/http";
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  readonly APIUrl = 'https://localhost:5001/api';

  
    // Get Departments
    getEmployeeList(): Observable <Employee[]> {
      return this.http.get<Employee[]>(this.APIUrl + '/employees');
    }



}
