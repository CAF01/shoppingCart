import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './site/layout/layout.component';
import { AuthGuard } from './infrastructure/auth/auth.guard';



const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'auth',
  },
  {
    path: 'auth',
    data: {
      layout: 'empty',
      title: 'Login'
    },
    component: LayoutComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'sign-in',
      },
      {
        path: 'sign-in',
        loadChildren: () =>
          import('./site/auth/auth.module').then((m) => m.AuthModule),
      },
    ]
  },
  {
    path: 'home',
    data: {
      layout: 'dense',
      title: 'Shopping Cart'
    },
    component: LayoutComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'store'
      },
      {
        path: 'store',
        canActivate: [AuthGuard],
        loadChildren: () =>
          import('./site/home/home.module').then((m) => m.HomeModule)
      },
      {
        path: 'locations',
        canActivate: [AuthGuard],
        loadChildren: () =>
          import('./site/store/store.module').then((m) => m.StoreModule)
      },
      {
        path: 'article',
        canActivate: [AuthGuard],
        loadChildren: () =>
          import('./site/article/article.module').then((m) => m.ArticleModule)
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
