import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar} from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { MatDialog} from '@angular/material/dialog';
import { AddDepComponent } from 'src/app/department/add-dep/add-dep.component';
import { EditDepComponent } from 'src/app/department/edit-dep/edit-dep.component';
import { DeleteDepComponent } from 'src/app/department/delete-dep/delete-dep.component';
import { DepartmentService } from 'src/app/services/department.service';


@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {


  constructor(private service: DepartmentService, 
              private dialog : MatDialog,
              private snackBar: MatSnackBar
              ) {
    // Observable for Add department
    this.service.listen().subscribe((obs: any) =>{
      console.log('Observer triggered: '+ obs +' - RefreshDepartmentList()');
      this.refreshDepartmentList();
    })
   }

 
  listData: MatTableDataSource<any> = null;
  displayedColumns : string[] = ['departmentName','createdOn','Options'];
  @ViewChild(MatSort) sort: MatSort;
  

  // Spinner
  isLoading: boolean = true;
  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'indeterminate';
  value: number = 90;
 

  ngOnInit(): void {
    this.refreshDepartmentList();
  }

  // Load/Refresh Table
  refreshDepartmentList(){
    this.service.getDepartmentList().subscribe(
    response => {
      this.isLoading = false;
      this.listData = new MatTableDataSource(response);
      this.listData.sort = this.sort;
    },
    error => {
      console.log(error);
    }
    )}

  // Edit Department
  onEdit(dep: any){

    const dialogRef = this.dialog.open(EditDepComponent, {
      data: {depId: dep.departmentID, depName: dep.departmentName, depCreate: dep.createdOn },
      width: '50%',
      disableClose: false,
      autoFocus: true
    });
    
  }

  // Delete Department / Show Delete Dialog/Modal
  onDelete(dep: any){
    
    console.log(dep.departmentID);

    // dialog opens
    const dialogRef = this.dialog.open(DeleteDepComponent, {
      width: '300px',
      data: {depId: dep.departmentID, depName: dep.departmentName },
      disableClose: false,
      autoFocus: true,
    });

    // Dialogue closes
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed '+ result);
      if (result !== undefined )
      this.service.deleteDepartment(result).subscribe(
        response =>{
          this.openSnackBar('Department Deleted','Success',3);
          this.refreshDepartmentList();
        },
        error => {
          console.log(error);
        }
      );
    });
      
  }

  // Show Add Department Modal/Dialog
  onAdd(){
    const dialogRef = this.dialog.open(AddDepComponent, {
      width: '50%',
      disableClose: false,
      autoFocus: true
    });
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
