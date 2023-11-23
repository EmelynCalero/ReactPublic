import { NgModule } from '@angular/core';
import { AuthGuardService as AuthGuard } from './services/auth-guard.service';
import { ExtraOptions, Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './containers';
import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { RegisterComponent } from './views/register/register.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'register',
    pathMatch: 'full',
  },
  {
    path: '404',
    component: P404Component,
    data: {
      title: 'Page 404'
    }
  },
  {
    path: '500',
    component: P500Component,
    data: {
      title: 'Page 500'
    }
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Register Page'
    }
  },  
  // {
  //   path: '',
  //   component: DefaultLayoutComponent,    
  //   children: [      
  //     {
  //       path: 'dashboard',
  //       loadChildren: () => import('./views/dashboard/dashboard.module').then(m => m.DashboardModule),
  //       canActivate:[AuthGuard]
  //     },

  //   ]
  // },
  { path: '**', component: P404Component }
];

const config: ExtraOptions = {
  useHash: false,
};

@NgModule({
  imports: [ RouterModule.forRoot(routes, config) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
