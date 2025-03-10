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
        path: 'produto',   
        loadComponent:()=> import('./products/search/search.component').then(m => m.SearchComponent)     
    },    
    {
        path: 'novo-produto',   
        loadComponent:()=> import('./products/new/new.component').then(m => m.NewComponent)     
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
