import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public $user: Subject<User | null> = new ReplaySubject<User | null>(1);
  
  constructor(private http: HttpClient, private router: Router) { 
    const username = localStorage.getItem("username");
    if(username){
      this.getUser(localStorage.getItem("username")).toPromise().then((res: User) => {
        this.$user.next(res)
      });
    }
  }

  getUser(username): Observable<any> {
    return this.http.get(`${environment.apiUrl}User/GetUserByUserName`, { params: { username } })
  }

  logIn(username): void{
    localStorage.setItem("username", username);

    this.getUser(localStorage.getItem("username")).toPromise().then((user: User) => {
      if(user && user.username){
        this.$user.next(user)
        this.router.navigate(["/list"]);
      } else {
        alert("User " + username  +" doesn't exist.")
      }
    })
    .catch(e => {
      console.log(e);
    });
  }

  signUp(username): Observable<any>{
    return this.http.post(`${environment.apiUrl}User`, {username})
  }

  signOut(): void{
    this.$user.next(null);
    localStorage.removeItem("username");
    this.router.navigate(["/login"]);
  }
}
