import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainComponent } from './pages/main.component';
import { SigninComponent } from './core/component/signin-callback.component';
import { AuthService } from './core/service/auth.service';
import { SignoutComponent } from './core/component/signout-callback.component';
import { SilentRenewComponent } from './core/component/silent-renew-callback.component';
import { WelcomeComponent } from './pages/welcome.component';
import { AuthGuardService } from './core/service/auth-guard.service';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    SigninComponent,
    SignoutComponent,
    SilentRenewComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [AuthService, AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
