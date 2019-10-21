import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { of, Observable } from 'rxjs';
import { catchError, mapTo, tap } from 'rxjs/operators';
import { config } from '../../config';
import { Tokens } from '../models/tokens';
import { Appointment } from '../models/appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
    constructor(private http: HttpClient) {
    }
    getAppointmentsByPatientId(patientId: number): Observable<Appointment[]>{
        return this.http.get<Appointment[]>(`${config.apiUrl}/GetAppointmentsByPatientId/Id/${patientId}`).pipe(
            tap(_ => console.log('fetched appointments')),
            catchError(this.handleError('getAppointmentsByPatientId', []))
        );
    }
    addAppointment(appointment): Observable<Appointment> {
        return this.http.post<Appointment>(`${config.apiUrl}/AddApointment`, appointment).pipe(
          tap(_ => console.log(`added appointment w/ id=${appointment.id}`)),
          catchError(this.handleError<Appointment>('addProduct'))
        );
      }
    deleteAppointment(id): Observable<Appointment> {
       return this.http.delete<Appointment>(`${config.apiUrl}/CancelApointment/Id/${id}`).pipe(
          tap(_ => console.log(`deleted appointment id=${id}`)),
          catchError(this.handleError<Appointment>('deleteAppointment'))
        );
      }
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
          console.error(error); // log to console instead
          return of(result as T);
        };
      }
}