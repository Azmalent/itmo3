import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LoginBodyComponent } from './login-body/login-body.component';
import { SignupBodyComponent } from './signup-body/signup-body.component';
import { MainBodyComponent } from './main-body/main-body.component';

import { AppRoutingModule } from './app-routing.module';

import { YesnoPipe } from './app.yesno';
import { TruncPipe } from './app.trunc';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginBodyComponent,
    SignupBodyComponent,
    MainBodyComponent,
    YesnoPipe,
    TruncPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
