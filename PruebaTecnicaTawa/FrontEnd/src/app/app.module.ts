import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShowHidePasswordModule } from 'ngx-show-hide-password';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import {AutocompleteLibModule} from 'angular-ng-autocomplete';
import { NgxCaptchaModule } from 'ngx-captcha';
import { NgxSpinnerModule } from "ngx-spinner";
const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

import { AppComponent } from './app.component';

// Import containers
import { DefaultLayoutComponent } from './containers';
import { AuthGuardService} from './services/auth-guard.service';
import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { RegisterComponent } from './views/register/register.component';

const APP_CONTAINERS = [
  DefaultLayoutComponent
];

import {
  AppAsideModule,
  AppBreadcrumbModule,
  AppHeaderModule,
  AppFooterModule,
  AppSidebarModule,
} from '@coreui/angular';

// Import routing module
import { AppRoutingModule } from './app.routing';

// Import 3rd party components
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ChartsModule } from 'ng2-charts';
import { NgbModule,NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { EnvServiceProvider } from '../env.service.provider';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    AppAsideModule,
    AppBreadcrumbModule.forRoot(),
    AppFooterModule,
    AppHeaderModule,
    FormsModule,
    ReactiveFormsModule,
    AppSidebarModule,
    PerfectScrollbarModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ToastrModule.forRoot(),
    AutocompleteLibModule,
    NgxCaptchaModule,
    NgxSpinnerModule,
    ChartsModule,
    NgbModule,
    ShowHidePasswordModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: null,
        //whitelistedDomains: [],
        //blacklistedRoutes: []
      }
    }),
  ],
  declarations: [
    AppComponent,
    ...APP_CONTAINERS,
    P404Component,
    P500Component,    
    RegisterComponent  
  ],
  providers: [{
    provide: LocationStrategy,
    useClass: HashLocationStrategy
  },  
   AuthGuardService,EnvServiceProvider],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
