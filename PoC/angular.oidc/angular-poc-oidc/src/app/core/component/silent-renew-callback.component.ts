import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';

@Component({
    selector: 'app-name',
    template: '<div>Renew...</div>'
})
export class SilentRenewComponent implements OnInit {
    constructor(private authService: AuthService) { }

    ngOnInit(): void {
        this.authService.startSilentSigninMainWindow();
     }
}
