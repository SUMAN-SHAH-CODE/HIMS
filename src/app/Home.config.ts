import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './Home.routes';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes)]
};
