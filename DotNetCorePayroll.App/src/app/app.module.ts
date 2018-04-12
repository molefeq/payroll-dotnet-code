import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
<<<<<<< HEAD
    SharedModule,
    CoreModule,
=======
    BrowserAnimationsModule
>>>>>>> c4cac4af094d7cfed6e25240b096423245624c01
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
