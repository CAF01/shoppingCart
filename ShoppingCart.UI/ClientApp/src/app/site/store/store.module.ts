import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoresComponent } from './stores/stores.component';
import { StoreRoutingModule } from './store.routing.module';
import { CreateStoreComponent } from './create-store/create-store.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [StoresComponent],
  imports: [
    CommonModule,
    CreateStoreComponent,
    StoreRoutingModule,
    SharedModule
  ]
})
export class StoreModule { }
