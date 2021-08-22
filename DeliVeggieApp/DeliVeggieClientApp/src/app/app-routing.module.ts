import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsDetailsComponent } from './components/products-details/products-details.component';
import { ProductsListComponent } from './components/products-list/products-list.component';


const routes: Routes = [{ path: 'products', component: ProductsListComponent },
                        { path: 'products/:id', component: ProductsDetailsComponent},
                         {path: '', redirectTo: '/products', pathMatch: 'full'}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
