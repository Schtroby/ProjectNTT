import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { PhonesComponent } from './phones/phones.component';
import { ReparationsComponent } from './reparations/reparations.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    PhonesComponent,
    ReparationsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
