import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-delete-dep',
  templateUrl: './delete-dep.component.html',
  styleUrls: ['./delete-dep.component.css']
})
export class DeleteDepComponent implements OnInit {

  depId : number;
  depName : string;

  constructor(public dialogRef: MatDialogRef<DeleteDepComponent>, @Inject(MAT_DIALOG_DATA) public data: any) 
  { 
    this.depId = data.depId;
    this.depName = data.depName;
  }

  ngOnInit(): void {
  }



}
