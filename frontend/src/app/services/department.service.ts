import { Injectable } from '@angular/core';
import { Department } from 'src/app/models/department.model';
import { Observable, Observer } from  "rxjs";
import { HttpClient } from  "@angular/common/http";
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }

  readonly APIUrl = 'https://localhost:44303/api';
  
  // Get Departments
  getDepartmentList(): Observable <Department[]> {
    return this.http.get<Department[]>(this.APIUrl + '/departments');
  }

  // Post to Departments
  addDepartment(dep:Department){
    return this.http.post(this.APIUrl+'/departments', dep);
  }

  // Delete a Department
  deleteDepartment(depId: number){
    return this.http.delete(this.APIUrl+'/departments/'+ depId);
  }

  // Put a Department
  updateDepartment(dep : Department){
    return this.http.put(this.APIUrl+'/departments/'+ dep.DepartmentID, dep);
  }


  // Observers (Rxjs)
  private _listeners = new Subject<any>();
  listen(): Observable<any>{
    return this._listeners.asObservable();
  }

  filter(filterBy: string){
    this._listeners.next(filterBy);
  }

  

}
