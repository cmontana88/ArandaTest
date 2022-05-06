import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, FormBuilder } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TablaProductosComponent } from './components/tabla-productos/tabla-productos.component';
import { CrearProductoComponent } from './components/crear-producto/crear-producto.component';

@NgModule({
  declarations: [
    AppComponent,
    TablaProductosComponent,
    CrearProductoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
