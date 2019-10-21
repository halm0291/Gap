import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PatientsComponent } from './patients/patients.component';
import { LoginComponent } from './auth/containers/login/login.component';
import { AuthGuard } from './auth/guards/auth.guard';
import { PatientsGuard } from './auth/guards/patients.guard';
import { AppointmentsComponent } from './appointments/appointments.component';
import { AppointmentsAddComponent } from './appointments/appointments-add/appointments-add.component';
const routes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate : [AuthGuard]
  },
  {
    path: 'patients',
    component: PatientsComponent,
    canActivate : [PatientsGuard]
  },
  {
    path: 'appointments',
    component: AppointmentsComponent,
    canActivate : [PatientsGuard]
  },
  {
    path: 'appointments-add',
    component: AppointmentsAddComponent,
    canActivate : [PatientsGuard]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
