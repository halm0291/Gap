import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService } from './auth/services/appointment.service';
import { AuthService } from './auth/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'clinicalTemplate';
  /**
   *
   */
  constructor(private router: Router, private authService: AuthService) {

  }
  logout(){
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
