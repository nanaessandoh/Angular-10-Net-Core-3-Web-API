import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';
  empPage : boolean = true;
  depPage : boolean = false;

  openEmp(){
    this.empPage = true;
    this.depPage = false;
  }


  openDep(){
    this.empPage = false;
    this.depPage = true;
  }

}
