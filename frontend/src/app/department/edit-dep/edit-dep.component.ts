import { Component, Inject, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/services/department.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar} from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Department } from 'src/app/models/department.model';

@Component({
  selector: 'app-edit-dep',
  templateUrl: './edit-dep.component.html',
  styleUrls: ['./edit-dep.component.css']
})
export class EditDepComponent implements OnInit {

  myForm: FormGroup;
  depId : number;
  depName : string;
  depCreate : string;

  constructor(private service: DepartmentService, 
              private formBuilder: FormBuilder,
              private snackBar: MatSnackBar,
              public dialogRef: MatDialogRef<EditDepComponent>, 
              @Inject(MAT_DIALOG_DATA) public data: any
              ) 
              { 
                this.depId = data.depId;
                this.depName = data.depName;
                this.depCreate = data.depCreate;
              }

  ngOnInit() {
    this.myForm = this.formBuilder.group({
      departmentName: [this.depName, Validators.required],
      createdOn: [this.depCreate, Validators.required],
    });
  }

  onSubmit( ){
    // Display the Data in the form
    console.log(this.myForm.value);


    // Create Department Object for Put Endpoint
    const obj = new Department(this.depId,this.myForm.get('departmentName').value, this.myForm.get('createdOn').value);


    // Put Data to API
    this.service.updateDepartment(obj).subscribe
    ( response =>{
      console.log('Department Updated '+ response);
      // Observable to capture submit event and refresh Table
      this.service.filter('Department Updated');
      // Snackbar Alert
      this.openSnackBar('Department Updated','Success',3);
      // Close the Dialog
      this.dialogRef.close();

    },
      error => {
        console.log(error);
      });

  }


  openSnackBar(message: string, action: string, duration: number) {
    this.snackBar.open(message, action, {
      duration: duration * 1000, // duration * 1 Sec
      horizontalPosition: 'center' ,
      verticalPosition: 'bottom' ,
    });
  }

}
