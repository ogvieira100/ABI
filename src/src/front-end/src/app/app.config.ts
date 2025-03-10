import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { ProductsService } from './shared/services/products.service';

export const appConfig: ApplicationConfig = {
  providers: [
    ProductsService,
    provideAnimations(),  
    provideRouter(routes), 
    provideHttpClient(),
    provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes)]
};
