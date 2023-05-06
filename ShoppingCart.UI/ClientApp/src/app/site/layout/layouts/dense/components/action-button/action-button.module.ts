import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionButtonComponent } from './action-button.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { StoreSelectComponent } from 'src/app/shared/controls/store-select/store-select.component';


@NgModule({
  declarations: [ActionButtonComponent],
  imports: [CommonModule,SharedModule,StoreSelectComponent],
  exports: [ActionButtonComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class ActionButtonModule {}
