import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TablaProductosComponent } from 'src/app/components/tabla-productos/tabla-productos.component'
import { CrearProductoComponent } from 'src/app/components/crear-producto/crear-producto.component'

const routes: Routes = [
  { path: '', component: TablaProductosComponent },
  { path: 'create', component: CrearProductoComponent },
  { path: 'edit/:id', component: CrearProductoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
