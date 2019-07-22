import { Component, OnInit } from '@angular/core';
import { AuthService } from '../app/core/service/auth.service'
import { Router, RouterEvent, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'angular-poc-oidc';
  user: any;

  constructor(private authService: AuthService, private router: Router){
    
  }

  ngOnInit() {
    this.router.events.pipe(
      filter((event: RouterEvent) => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.authService.getUser().subscribe( user => {
        console.log(user)
        this.user = user;
      });
    });
  }

  login() {
    this.authService.startSigninMainWindow();

  }

  logout() {
    this.authService.startSignoutMainWindow();

  }
  
}
