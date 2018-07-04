import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';

import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { ComponentsModule } from './components/components.module';
import { AppRoutingModule } from './app-routing.module';
import { AppStartUpService } from './shared/services/app-startup-service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    SharedModule,
    CoreModule,
    ComponentsModule,
    AppRoutingModule,
  ],
  providers: [{ provide: APP_INITIALIZER, useFactory: (config: AppStartUpService) => () => config.load(), deps: [AppStartUpService], multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
