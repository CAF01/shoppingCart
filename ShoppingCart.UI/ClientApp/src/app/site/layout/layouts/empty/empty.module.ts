import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmptyComponent } from './empty.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { LoaderComponent } from 'src/app/shared/controls/loader/loader.component';

@NgModule({
  declarations: [EmptyComponent],
  imports: [CommonModule, LoaderComponent,SharedModule,RouterModule],
  exports: [EmptyComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class EmptyModule {}
