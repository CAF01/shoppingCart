import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared.module';
import { StoreResponse } from 'src/app/site/store/models/response/store.response';
import { StoreService } from 'src/app/site/store/services/store.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'store-select',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './store-select.component.html',
  styleUrls: ['./store-select.component.scss']
})
export class StoreSelectComponent implements OnInit, OnDestroy {

  stores: StoreResponse[] = [];

  subscription: any;

  constructor(private storeService: StoreService,
    private authService: AuthService) { }


  ngOnInit(): void {
    this.getStores();

    this.subscription = this.storeService.onChangeStore
      .subscribe(item => this.stores.push(item));
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  setStore(store): void {
    this.authService.currentStore = store;
  }

  getStores(): void {
    this.storeService.getStores()
      .subscribe({
        next: (response) => {
          this.stores = response;
          if (this.stores.length > 0) {
            this.authService.currentStore = this.stores[0];
          }

        }
      });
  }
}
