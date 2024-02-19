import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { User } from '../../models/user.model';
import { Observable, Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  standalone: true,
  imports: [CommonModule, RouterModule]
})
export class MenuComponent implements OnInit {
  user: User | null = null;

  openMobile = false;

  $user: Subscription;

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
    this.$user = this.auth.$user.subscribe((user: User) => {
      if(user && user.username){
        this.user = user;
      } else {
        this.user = null;
      }
    })
  }

  ngOnDestroy(): void {
    this.$user.unsubscribe();
  }

  logout(): void{
    this.auth.signOut();
  }
}
