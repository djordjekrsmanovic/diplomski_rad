import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlertDetailsComponent } from './components/alert-details/alert-details.component';
import { AlertListComponent } from './components/alert-list/alert-list.component';
import { AlertViewComponent } from './components/alert-view/alert-view.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"alerts",component:AlertListComponent},
  {path:"alert/:id",component:AlertViewComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
