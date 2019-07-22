import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './pages/main.component';
import { SigninComponent } from './core/component/signin-callback.component';
import { SignoutComponent } from './core/component/signout-callback.component';
import { SilentRenewComponent } from './core/component/silent-renew-callback.component';
import { WelcomeComponent } from './pages/welcome.component';
import { AuthGuardService } from './core/service/auth-guard.service';

const routes: Routes = [
  { path: '', component: WelcomeComponent},
  { path: 'main' ,component: MainComponent, canActivate: [AuthGuardService] },
  { path: 'signin-callback', component: SigninComponent },
  { path: 'signout-callback', component: SignoutComponent },
  { path: 'silent-renew-callback', component: SilentRenewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
