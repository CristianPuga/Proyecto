import { Injectable } from '@angular/core';
import { Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { CanActivate } from '@angular/router';
import { LoginService } from '../login/services/login.service';
import { Observable } from 'rxjs';

@Injectable({providedIn: "root"})
export class AuthGuard implements CanActivate {

    constructor(private authService: LoginService, private router: Router) { }

    canActivate() {
        // If the user is not logged in we'll send them back to the home page
        if (!this.authService.isLogged()) {
            console.log('No estás logueado');
            window.alert("No estas logueado, si quieres ver esa pagina inicia sesion primero");
            this.router.navigate(['/']);
            return false;
        }

        return true;
    }
}