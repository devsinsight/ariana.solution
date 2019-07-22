import { Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
export declare class AuthInterceptor implements HttpInterceptor {
    private injector;
    /**
     * Is refresh token is being executed
     */
    private refreshInProgress;
    /**
     * Notify all outstanding requests through this subject
     */
    private refreshSubject;
    constructor(injector: Injector);
    /**
     * Intercept an outgoing `HttpRequest`
     */
    intercept(req: HttpRequest<any>, delegate: HttpHandler): Observable<HttpEvent<any>>;
    /**
     * Process all the requests via custom interceptors.
     */
    private processIntercept(original, delegate);
    /**
     * Request interceptor. Delays request if refresh is in progress
     * otherwise adds token to the headers
     */
    private request(req);
    /**
     * Failed request interceptor, check if it has to be processed with refresh
     */
    private responseError(req, res);
    /**
     * Add access token to headers or the request
     */
    private addToken(req);
    /**
     * Delay request, by subscribing on refresh event, once it finished, process it
     * otherwise throw error
     */
    private delayRequest(req);
    /**
     * Retry request, by subscribing on refresh event, once it finished, process it
     * otherwise throw error
     */
    private retryRequest(req, res);
}
