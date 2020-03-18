import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements HttpInterceptor {

  constructor(private router: Router){}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  
    const token: string = localStorage.getItem('token');
    let request = req;

    if (token) {
      request = req.clone({
        setHeaders: {
          authorization: `Bearer ${ token }`
        }
      });
    }

    return next.handle(request)/*.pipe(
      catchError((err: HttpErrorResponse) => {

        if (err.status === 401) {
          this.router.navigateByUrl('/login');
        }

        return throwError( err );

      })
    );*/
  }
}



/*uri = 'http://localhost:5000/api';
  token;
 

  constructor(private http:HttpClient, private router:Router) { }

  login(nombreUsuario: string, contrasena: string){
    this.http.post(this.uri + '/token', {nombreUsuario: nombreUsuario,contrasena:contrasena})
    .subscribe((resp: any) => {
     
      this.router.navigate(['profile']);
      localStorage.setItem('auth_token', resp.token);
      
    })
  };  */
