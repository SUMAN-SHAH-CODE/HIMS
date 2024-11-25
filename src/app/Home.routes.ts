import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { AboutUsComponent } from './Home/Home.AboutUsComponent';

export const routes: Routes = [
   { path: 'AboutUs', component: AboutUsComponent },
   { path: 'Patient', loadComponent: 
   () => import('./Patient/Patient.Patientcomponent').
   then(x => x.PatientComponent)} ,
   { path: '', component: AboutUsComponent },

];
