import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DenseComponent } from './dense.component';
import { NavigationModule } from './components/navigation/navigation.module';
import { RouterModule } from '@angular/router';
import { ActionButtonModule } from './components/action-button/action-button.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LoaderComponent } from 'src/app/shared/controls/loader/loader.component';

@NgModule({
  declarations: [DenseComponent],
  imports: [
    CommonModule,
    NavigationModule,
    RouterModule,
    ActionButtonModule,
    SharedModule,
    LoaderComponent
  ],
  exports: [DenseComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class DenseModule {}
