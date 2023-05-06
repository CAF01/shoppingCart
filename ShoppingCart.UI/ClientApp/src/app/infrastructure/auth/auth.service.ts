import { EventEmitter, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginResponse } from 'src/app/site/auth/models/response/login-response';
import { StoreResponse } from 'src/app/site/store/models/response/store.response';

const credentialsKey = 'credentials';
const storeKey = 'store';
@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private usuario: LoginResponse | undefined;
    private store: StoreResponse;
    public storeLabel: string = '';

    onChangeStore: EventEmitter<StoreResponse> = new EventEmitter();

    constructor(private router: Router) {
        const savedCredentials = sessionStorage.getItem(credentialsKey) || localStorage.getItem(credentialsKey);
        const savedStore = sessionStorage.getItem(storeKey) || localStorage.getItem(storeKey);

        if (savedCredentials) {
            this.usuario = JSON.parse(savedCredentials);
        }

        if (savedStore) {
            this.store = JSON.parse(savedStore);
        }
    }

    isAuthenticated(): boolean {
        return !!this.credentials;
    }

    get currentStore(): StoreResponse | undefined {
        return this.store;
    }

    set currentStore(currentStore: StoreResponse | undefined) {
        if (currentStore) {
            this.store = currentStore;
            this.storeLabel = ` - ${this.store.branch}`;
            this.onChangeStore.next(this.store);
            localStorage.setItem(storeKey, JSON.stringify(currentStore));
        }
    }


    get credentials(): LoginResponse | undefined {
        return this.usuario;
    }

    set credentials(credentials: LoginResponse | undefined) {

        if (credentials) {
            this.usuario = credentials;

            localStorage.setItem(credentialsKey, JSON.stringify(credentials));
        } else {
            localStorage.removeItem(credentialsKey);
        }
    }

    signOff(): void {
        this.credentials = undefined;
        this.router.navigateByUrl('/auth', { replaceUrl: true });
    }



}
