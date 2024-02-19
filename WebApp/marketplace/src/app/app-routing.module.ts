import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from './authentication/login/login.component';
import {OfferListComponent} from './offers/offer-list/offer-list.component';
import {OfferCreationComponent} from './offers/offer-creation/offer-creation.component';
import { canActivate } from './core/guards/auth.guard';
import { SignUpComponent } from './authentication/signup/signup.component';


const routes: Routes = [
  {path: '',   redirectTo: '/list', pathMatch: 'full' },
  {path: 'login', component: LoginComponent, pathMatch: 'full'},
  {path: 'signup', component: SignUpComponent, pathMatch: 'full'},
  {path: 'post-new', component: OfferCreationComponent, pathMatch: 'full', canActivate: [canActivate]},
  {path: 'list', component: OfferListComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
