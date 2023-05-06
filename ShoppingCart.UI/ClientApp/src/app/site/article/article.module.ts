import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateArticleComponent } from './create-article/create-article.component';
import { ArticleRoutingModule } from './article.routing.module';
import { ArticleListComponent } from './article-list/article-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { StoreFilterComponent } from 'src/app/shared/controls/store-filter/store-filter.component';
import { UploadFileComponent } from 'src/app/shared/controls/upload-file/upload-file.component';



@NgModule({
  declarations: [ CreateArticleComponent,
                ArticleListComponent],
  imports: [
    CommonModule,
    SharedModule,
    ArticleRoutingModule,
    StoreFilterComponent,
    UploadFileComponent
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class ArticleModule { }
