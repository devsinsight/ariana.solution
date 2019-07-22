import { Router, CanActivate, CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
/**
 * Guard, checks access token availability and allows or disallows access to page,
 * and redirects out
 *
 * usage: { path: 'test', component: TestComponent, canActivate: [ AuthGuard ] }
 *
 * @export
 */
export declare class ProtectedGuard implements CanActivate, CanActivateChild {
    private authService;
    private publicFallbackPageUri;
    private router;
    constructor(authService: AuthService, publicFallbackPageUri: string, router: Router);
    /**
     * CanActivate handler
     */
    canActivate(_route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>;
    /**
     * CanActivateChild handler
     */
    canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>;
    /**
     * Check, if current page is public fallback page
     */
    private isPublicPage(state);
    /**
     * Navigate away from the app / path
     */
    private navigate(url);
}
