import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { Patient } from '../Patient/Patient.PatientModel';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [RouterOutlet , 
            FormsModule,
            CommonModule],
  templateUrl: './Home.AboutUs.html',
  styleUrl: './Home.component.css'
})
export class AboutUsComponent {
  
}
