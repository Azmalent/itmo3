import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signup-body',
  templateUrl: './signup-body.component.html',
  styleUrls: ['./signup-body.component.css']
})
export class SignupBodyComponent implements OnInit {
  loginPlaceholder : string = "Введите логин";
  passwordPlaceholder : string = "Введите пароль";
  passwordRepeatPlaceholder : string = "Введите пароль ещё раз";

  constructor() { }

  ngOnInit() { }
}
