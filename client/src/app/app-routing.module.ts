import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { ServerErrorComponent } from './shared/server-error/server-error.component';
import { TestErrorComponent } from './shared/test-error/test-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'test-error', component: TestErrorComponent},
  { path: 'server-error', component: ServerErrorComponent},
  { path: 'not-found', component: NotFoundComponent},
  { path: 'book', loadChildren: () => import('./book/book.module').then(mod => mod.BookModule) },
  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  { path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
