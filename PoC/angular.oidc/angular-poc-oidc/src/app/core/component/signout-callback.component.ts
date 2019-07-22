import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';

@Component({
    selector: 'app-name',
    template: '<div>Logout...</div>'
})
export class SignoutComponent implements OnInit {
    constructor(
        private router: Router, 
        private authService: AuthService
        ) { }

    ngOnInit(): void { 
        console.log("Logout...")
        this.authService.endSignoutMainWindow()
        .then( () => {
          this.router.navigate(['/']);
        });
    }
}
