import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

//pages
import { AppComponent } from './app.component';

//components
import { HomePageComponent } from './home-page/home-page.component';
import { CalculaterComponent } from './calculater/calculater.component';

const routes: Routes =[
  {path: 'home-page', component:HomePageComponent },
  {path: 'calculater', component: CalculaterComponent },
]
@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    CalculaterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
