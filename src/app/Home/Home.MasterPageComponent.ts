import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Patient } from '../Patient/Patient.PatientModel';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet ,
            RouterLink, 
            FormsModule,
            CommonModule],
  templateUrl: './Home.MasterPageComponent.html',
  styleUrl: './Home.component.css'
})
export class MasterPageComponent {
  
}
