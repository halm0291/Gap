import { Component, OnInit } from '@angular/core';
import { Appointment, AppointmentType } from '../auth/models/appointment';
import { AppointmentService } from '../auth/services/appointment.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements OnInit {

  constructor(private router: Router, private appointmentService: AppointmentService) { }
  displayedColumns: string[] = ['type', 'date', 'hour' ,'delete'];
  data: Appointment[] = [];
  isLoadingResults = true;
  ngOnInit() {
    this.getAppointments();
  }

  getAppointmentType(id: number): string {
    return AppointmentType[id];
  }

  deleteAppointment(id){
    this.isLoadingResults = true;
    this.appointmentService.deleteAppointment(id)
      .subscribe(res => {
          this.isLoadingResults = false;
          this.getAppointments();
          if (res==null) alert("Sorry you can't cancel this appointment");
        }, (err) => {          
          console.log(err);
          this.isLoadingResults = false;
        }
      );
  }

  getAppointments(){
    this.appointmentService.getAppointmentsByPatientId(1)
    .subscribe(res => {
      this.data = res;
      this.isLoadingResults = false;
    }, err => {
      this.isLoadingResults = false;
    });
  }

}
