import { CanActivate, CanActivateChild, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
/**
 * Guard, checks access token availability and allows or disallows access to page,
 * and redirects out
 *
 * usage: { path: 'test', component: TestComponent, canActivate: [ PublicGuard ] }
 *
 * @export
 */
export declare class PublicGuard implements CanActivate, CanActivateChild {
    private authService;
    private protectedFallbackPageUri;
    private router;
    constructor(authService: AuthService, protectedFallbackPageUri: string, router: Router);
    /**
     * CanActivate handler
     */
    canActivate(_route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>;
    /**
     * CanActivateChild handler
     */
    canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>;
    /**
     * Check, if current page is protected fallback page
     */
    private isProtectedPage(state);
    /**
     * Navigate away from the app / path
     */
    private navigate(url);
}
