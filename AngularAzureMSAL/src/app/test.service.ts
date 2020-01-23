import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private httpClient: HttpClient) { }

  getReservationsFilteredCount(): Observable<any> {
    return this.httpClient.get<any>('http://localhost:55680/api/authentication/test-auth');
  }
}
