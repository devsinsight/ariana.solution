import { Injectable, EventEmitter } from '@angular/core';
import { UserManager, UserManagerSettings, User, WebStorageStateStore } from 'oidc-client';
import { Router } from '@angular/router';
import { Observable, from } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private user: User = null;
  private manager: UserManager = new UserManager(this.getClientSettings());
  userLoadedEvent: EventEmitter<User> = new EventEmitter<User>();

  constructor(private router: Router) {
    this.manager.getUser()
      .then((user) => {
          this.user = user;
          this.userLoadedEvent.emit(user);
      });

    this.manager.events.addUserLoaded(user => {
      this.user = user;
      this.userLoadedEvent.emit(user);
    });

    this.manager.events.addUserUnloaded((e) => {
      this.userLoadedEvent.emit(null);
    });

    this.manager.events.addAccessTokenExpiring( (e) => {
      this.manager.removeUser();
    });

  }

  getUser(): Observable<User> {
      return from(this.manager.getUser())
            .pipe(map<User, User>((user) => user));
    }

  getClaims(): any {
    return this.user.profile;
  }

  getAuthorizationHeaderValue(): string {
    return this.user ? `${this.user.token_type} ${this.user.access_token}` : '';
  }

  startSigninMainWindow(): Promise<User> {
    return this.manager.signinRedirect();
  }

  endSigninMainWindow(): Promise<void> {
      return this.manager.signinRedirectCallback().then(user => {
          this.user = user;
          console.log(this.user);
      });
  }

  startSignoutMainWindow(): Promise<any> {
    return this.manager.signoutRedirect();
  }

  endSignoutMainWindow(): Promise<void> {
    return this.manager.signoutRedirectCallback().then(function (resp) {
    });
  }

  startSilentSigninMainWindow(): Promise<any> {
    return this.manager.signinSilentCallback();
  }

  getClientSettings(): UserManagerSettings {
    return {
        authority: 'http://localhost:5000',
        client_id: 'angular2s',
        redirect_uri: 'http://localhost:4200/signin-callback',
        post_logout_redirect_uri: 'http://localhost:4200/signout-callback',
        silent_redirect_uri: 'http://localhost:4200/silent-renew-callback',    
        response_type: 'id_token token',
        scope: 'openid profile email resource1',
        filterProtocolClaims: true, 
        loadUserInfo: true,
        automaticSilentRenew: true,
        userStore: new WebStorageStateStore({ store: window.localStorage }),
    };
  }
}
