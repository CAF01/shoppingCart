import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { EmptyModule } from './layouts/empty/empty.module';
import { DenseModule } from './layouts/dense/dense.module';

const layouts = [EmptyModule, DenseModule];
@NgModule({
  declarations: [LayoutComponent],
  imports: [CommonModule,...layouts],
  exports: [...layouts],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class LayoutModule {}
