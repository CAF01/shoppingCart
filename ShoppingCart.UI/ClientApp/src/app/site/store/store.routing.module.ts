import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { StoresComponent } from "./stores/stores.component";


const routes: Routes = [
    { path: '', component: StoresComponent }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class StoreRoutingModule { }