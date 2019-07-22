import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';

@Component({
    selector: 'app-signin',
    template: '<div>Login...</div>'
})
export class SigninComponent implements OnInit {
    constructor(
            private router: Router, 
            private authService: AuthService
            ) { }

    ngOnInit(): void { 
        this.authService.endSigninMainWindow()
        .then( () => {
            this.router.navigate(['main']);
    
        });

    }
}
