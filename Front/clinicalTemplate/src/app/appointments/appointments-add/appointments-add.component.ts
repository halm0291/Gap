import { Router } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { AppointmentType, Appointment } from 'src/app/auth/models/appointment';
import { OnInit, Component } from '@angular/core';
import { AppointmentService } from 'src/app/auth/services/appointment.service';
import { Time } from '@angular/common';

@Component({
  selector: 'app-appointments-add',
  templateUrl: './appointments-add.component.html',
  styleUrls: ['./appointments-add.component.scss']
})
export class AppointmentsAddComponent implements OnInit {

  constructor(private router: Router, private appointmentService: AppointmentService, private formBuilder: FormBuilder) { }
  appointmentForm: FormGroup;
  appointmentType: AppointmentType;
  appointmentDate: Date;
  appointmentHour: Time;
  isLoadingResults = false;
 
  ngOnInit() {
    this.appointmentForm = this.formBuilder.group({
      'appointmentType' : [null, Validators.required],
      'appointmentDate' : [null, Validators.compose([
                                Validators.required])],
      'appointmentHour' : [null, Validators.required],

    });
  }

  onFormSubmit(form:NgForm) {
    this.isLoadingResults = true;
    let newAppointment = new Appointment();
    newAppointment.Type = this.appointmentForm.controls['appointmentType'].value;
    newAppointment.Date = this.appointmentForm.controls['appointmentDate'].value;
    newAppointment.Hour = this.appointmentForm.controls['appointmentHour'].value;
    newAppointment.PatientId = 1;
    this.appointmentService.addAppointment(newAppointment)
      .subscribe(res => {
        console.log(res);
        
          if (res == null) {
            this.isLoadingResults = false;
            alert("Sorry you can't add this appointment, try other day");
          } else {
            this.isLoadingResults = false;
            this.router.navigate(['/appointments']);
          }
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        });
  }

}
