import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { StoreService } from 'src/app/site/store/services/store.service';

@Component({
  selector: 'action-button',
  templateUrl: './action-button.component.html',
  styleUrls: ['./action-button.component.scss'],
})
export class ActionButtonComponent implements OnInit, OnDestroy {

  suscription: any;
  newStoreAlert: boolean = false;

  constructor(private authService: AuthService,
    private storeService: StoreService) { }


  ngOnInit(): void {
    this.suscription = this.storeService.onChangeStore
      .subscribe(_ => this.newStoreAlert = true);
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }

  signOff = () => this.authService.signOff();

}
