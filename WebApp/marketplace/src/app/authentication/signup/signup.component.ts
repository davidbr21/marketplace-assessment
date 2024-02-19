import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule],
})
export class SignUpComponent implements OnInit {
  signUpForm = new FormGroup({
    username: new FormControl('', [Validators.required])
  });

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  async signUp(){
    if(this.signUpForm.valid && !this.signUpForm.controls.username.value.includes(" ")){
      try{
        const id = await this.auth.signUp(this.signUpForm.controls.username.value).toPromise()
        if(id){
          alert("User created successfully")
          this.router.navigate(["/login"]);
        } else {
          alert("An error occured while creating the user")
        }
      } catch(e){
        console.log(e);
      }
    } else {
      alert("You must enter a valid username")
    }
  }

}
