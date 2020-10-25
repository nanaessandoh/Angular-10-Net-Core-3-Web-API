import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/services/department.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-dep',
  templateUrl: './add-dep.component.html',
  styleUrls: ['./add-dep.component.css']
})
export class AddDepComponent implements OnInit {
  
  myForm: FormGroup;

  constructor(private service: DepartmentService, 
              private formBuilder: FormBuilder,
              private snackBar: MatSnackBar
              ) { }

  ngOnInit() {
    this.myForm = this.formBuilder.group({
      departmentName: ['', Validators.required],
      createdOn: ['', Validators.required],
    });
  }


  onSubmit( ){
    // Display the Data in the form
    console.log(this.myForm.value);

    // Post Data to API
    this.service.addDepartment(this.myForm.value).subscribe
    (
      response => {
        console.log(response);
        // Observable to capture submit event and refresh Table
        this.service.filter('Department Added');
        // Snackbar Alert
        this.openSnackBar('Department Created','Success',3);
        // Reset form
        this.onReset();
      },
      error => {
        console.log(error);
        // Snackbar Alert
        this.openSnackBar('Department Not Created','Error',3);
      }
    );    
  }

  onReset(){
    this.myForm = this.formBuilder.group({
      departmentName: ['', Validators.required],
      createdOn: ['', Validators.required],
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


