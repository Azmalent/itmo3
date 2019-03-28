import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-body',
  templateUrl: './login-body.component.html',
  styleUrls: ['./login-body.component.css']
})
export class LoginBodyComponent implements OnInit {
  loginPlaceholder : string = "Введите логин";
  passwordPlaceholder : string = "Введите пароль";

  constructor() { }

  ngOnInit() { }
}
