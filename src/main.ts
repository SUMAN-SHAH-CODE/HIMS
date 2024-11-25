import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/Home.config';
import { MasterPageComponent } from './app/Home/Home.MasterPageComponent';
bootstrapApplication(MasterPageComponent, appConfig)
  .catch((err) => console.error(err));
