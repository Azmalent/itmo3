import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginBodyComponent } from './login-body/login-body.component';
import { SignupBodyComponent } from './signup-body/signup-body.component';
import { MainBodyComponent } from './main-body/main-body.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login',  component: LoginBodyComponent },
  { path: 'signup', component: SignupBodyComponent },
  { path: 'main',   component: MainBodyComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}

