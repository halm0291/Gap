import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: [''],
      password: ['']
    });
  }


  login() {
    this.authService.login(
      {
        username: this.loginForm.controls["username"].value,
        password: this.loginForm.controls["password"].value
      }
    )
    .subscribe(success => {
      if (success) {
        this.router.navigate(['/appointments']);
      }
    });
  }
}
