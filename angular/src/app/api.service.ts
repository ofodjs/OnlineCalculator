import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {OperationResult} from './operationresult';
import {Observable} from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private API_URL = 'http://localhost:4201/api';

  constructor(private http: HttpClient) {}

  calculate(requestData): Observable<OperationResult> {
    return this.http
      .post<OperationResult>(`${this.API_URL}/calculate/`, requestData);
  }
} 