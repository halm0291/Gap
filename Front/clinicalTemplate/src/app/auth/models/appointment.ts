import { Time } from '@angular/common';

export class Appointment {
    Id: string;
    Type: AppointmentType;
    PatientId: number;
    Date: Date;
    Hour: Time;
}

export enum AppointmentType {
        GeneralMedicine = 1,
        Odontology = 2,
        Pediatrics = 3,
        Neurology = 4
}
