import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { HomeRoutingModule } from './home.routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ImgViewComponent } from 'src/app/shared/controls/img-view/img-view.component';
import { PayComponent } from './pay/pay.component';

@NgModule({
  declarations: [
    HomeComponent,
    PayComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule,
    ImgViewComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HomeModule { }
