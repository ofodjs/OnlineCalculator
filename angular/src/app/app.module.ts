import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {Routes, RouterModule} from '@angular/router';
import {HttpClientModule} from '@angular/common/http';

import {AppComponent} from './app.component';
import {CalculatorComponent} from './calculator/calculator.component';
import {MenuComponent} from './menu/menu.component';
import {AboutComponent} from './about/about.component';

const routes: Routes = [
  {path: '', redirectTo: 'calculator', pathMatch: 'full'},
  {
    path: 'calculator',
    component: CalculatorComponent
  },
  {
    path: 'about',
    component: AboutComponent
  },
];

@NgModule({
  declarations: [
    AppComponent,
    CalculatorComponent,
    MenuComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
