import { Routes } from '@angular/router';

export const routes: Routes = [

    {
        path: '',   
        loadComponent:()=> import('./home/home.component').then(m => m.HomeComponent)     
    },
    {
        path: 'home',   
        loadComponent:()=> import('./home/home.component').then(m => m.HomeComponent)     
    },  
    {
        path: 'login',   
        loadComponent:()=> import('./login/login.component').then(m => m.LoginComponent)     
    },
    {
        path: 'acesso-negado',   
        loadComponent:()=> import('./access-denied/access-denied.component').then(m => m.AccessDeniedComponent)     
    },
    {
        path: 'nao-encontrado',   
        loadComponent:()=> import('./not-found/not-found.component').then(m => m.NotFoundComponent)     
    },
    {
        path: '**',   
        loadComponent:()=> import('./not-found/not-found.component').then(m => m.NotFoundComponent)     
    }

];
