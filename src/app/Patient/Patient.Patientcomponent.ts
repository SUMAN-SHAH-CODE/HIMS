import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { Patient } from './Patient.PatientModel';
import { CommonModule } from '@angular/common';
import {AboutUsComponent} from "../Home/Home.AboutUsComponent"
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
@Component({
  standalone: true,
  imports: [RouterOutlet , 
            FormsModule,
            CommonModule,
            AboutUsComponent,
            HttpClientModule
           ],
  templateUrl: './Patient.Patientcomponent.html'
})
export class PatientComponent {
  title = 'HIMS'; // Add a title property so patientcomponent.spec ma error na aaos
  patientObj:Patient = new Patient();
  patientObjs:Array<Patient> = new Array<Patient>();

  constructor(public http:HttpClient){
    //this constructor is initiallize at once when PatientComponent class called 

  }
  AddPatient(){
    this.patientObjs.push(this.patientObj);
    this.patientObj = new Patient();
  }
  SubmitTOServer(){
    //
    //concept of Observer(client) and observable(server)
    var observable=this.http.post("https://localhost:44320/api/PatientAPI",this.patientObj);
    observable.subscribe(res=>this.Success(res),res=>this.Error(res));
  }
  Success(res:any){
    console.log(res);
  }
  Error(res:any){
    console.error(res);
  }
  GetAll(){
    var observable=this.http.get("https://localhost:44320/api/PatientAPI/");
    observable.subscribe(res=>{this.patientObjs=res as Array<Patient>},res=>this.Error(res));
  }
  
  // Method to get a specific patient by ID
 SearchById() {
  if (this.patientObj.Id) {
   var observable= this.http.get(`https://localhost:44320/api/PatientAPI/${this.patientObj.Id}`);
     observable .subscribe(
        (res: any) => {
          this.patientObjs = [res]; // Store the result in an array for display
        },
        (err) => {
          console.error('Error fetching patient:', err);
          alert('Patient not found or an error occurred!');
        }
      );
  } else {
    alert('Please enter a valid ID.');
  }
}
 
  
}


 