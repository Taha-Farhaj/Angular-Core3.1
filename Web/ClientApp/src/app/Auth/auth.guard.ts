import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authenticationService : AuthenticationService){

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const currentUser = this.authenticationService.currentUserValue;
      if(currentUser != null)
        return true;
      // let url: string = state.url;
      // var token = localStorage.getItem('currentUser');

      // if (token  != null && !this.jwtHelper.isTokenExpired(token)) {
      //   let userData = this.jwtHelper.decodeToken(token);
      //   return true;
      // }
      // else if (token  != null){
      //   localStorage.removeItem('token');
      //   localStorage.removeItem('userRoleName');
      //   localStorage.removeItem('userId');
      // }
      //this.route.snapshot.queryParams['returnUrl'] || '/';
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
      return false;
  }
  
}
