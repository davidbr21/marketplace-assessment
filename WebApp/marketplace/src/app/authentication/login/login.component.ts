import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule],
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required])
  });

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
  }

  login(){
    if(this.loginForm.valid && !this.loginForm.controls.username.value.includes(" ")){
      this.auth.logIn(this.loginForm.controls.username.value);
    } else {
      alert("You must enter a valid username")
    }
  }
}
