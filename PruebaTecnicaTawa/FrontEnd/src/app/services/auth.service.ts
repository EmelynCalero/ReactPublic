import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router, CanActivate, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 
constructor(public jwtHelper: JwtHelperService, public router: Router) { }

public isAuthenticated(): boolean {  
  return true;
}
}
