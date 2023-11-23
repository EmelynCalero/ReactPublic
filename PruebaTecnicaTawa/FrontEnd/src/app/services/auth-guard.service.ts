import { Injectable } from '@angular/core';
import { Router, CanActivate, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()

export class AuthGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router) { }
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (!this.auth.isAuthenticated()) {
      //this.router.navigateByUrl("/login");
      return false;
    }
    return true;
  }
}
