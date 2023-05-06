import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { ArticleListComponent } from "./article-list/article-list.component";
import { StoreFilterComponent } from "src/app/shared/controls/store-filter/store-filter.component";
import { UploadFileComponent } from "src/app/shared/controls/upload-file/upload-file.component";

const routes: Routes = [
    { path: '', component: ArticleListComponent }
]

@NgModule({
    imports: [RouterModule.forChild(routes),
        StoreFilterComponent,
        UploadFileComponent],
    exports: [RouterModule]
})
export class ArticleRoutingModule { }