import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { ServerErrorComponent } from './shared/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'store', loadChildren: () => import('./store/store.module').then(mod => mod.StoreModule) },
  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  {
    path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule)
  },
  {
    path: 'orders',
    canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module').then(mod => mod.OrdersModule)
  },
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
