import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HealthCheckComponent } from './health-check/health-check.component';
import { TestFormComponent } from './test-form/test-form.component';
import { TestTableComponent } from './test-table/test-table.component';
import { TestImageComponent } from './test-image/test-image.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'health-check', component: HealthCheckComponent },
  { path: 'test-form', component: TestFormComponent },
  { path: 'test-table', component: TestTableComponent },
  { path: 'test-image', component: TestImageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

