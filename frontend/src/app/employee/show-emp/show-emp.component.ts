import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { AddEmpComponent } from 'src/app/employee/add-emp/add-emp.component';
import { EditEmpComponent } from 'src/app/employee/edit-emp/edit-emp.component';
import { DeleteEmpComponent } from 'src/app/employee/delete-emp/delete-emp.component';
import { EmployeeService } from 'src/app/services/employee.service';



@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(private service: EmployeeService,
              private dialog: MatDialog,
              private snackBar: MatSnackBar) {}

  listData: MatTableDataSource<any> = null;
  displayedColumns : string[] = ['employeeName','department','gender','age','doj','Options'];
  @ViewChild(MatSort) sort: MatSort;

  ngOnInit(): void {
    this.refreshDepartmentList();
  }


  // Spinner
  isLoading: boolean = true;
  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'indeterminate';
  value: number = 90;

  // Load/Refresh Table
  refreshDepartmentList(){
    this.service.getEmployeeList().subscribe(
    response => {
      this.isLoading = false;
      this.listData = new MatTableDataSource(response);
      this.listData.sort = this.sort;
    },
    error => {
      console.log(error);
    }
    )}


  onAdd(){

  }

  onEdit(){

  }

  onDelete(){

  }

  // Filter Table
  applyFilter(filterValue: string){
    this.listData.filter = filterValue.trim().toLocaleLowerCase();
  }


  // Show Snackbar
  openSnackBar(message: string, action: string, duration: number) {
    this.snackBar.open(message, action, {
      duration: duration * 1000, // duration * 1 Sec
      horizontalPosition: 'center' ,
      verticalPosition: 'bottom' ,
    });
  }



}



