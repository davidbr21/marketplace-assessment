import { Injectable, inject } from '@angular/core';
import {  ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { User } from '../models/user.model';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  class PermissionsService {
  
    constructor(private router: Router) {}
  
    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        const authService = inject(AuthService);
        const router = inject(Router);

        return authService.$user.asObservable().pipe(
            map((user: User) => {
                return user && user.id ? true : false
            }),
            catchError(() => {
                router.navigate(['/login']);
                return of(false);
            })
        )
    }
  }
  
  export const canActivate: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> => {
    return inject(PermissionsService).canActivate(next, state);
  }