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

  calculate(x, y, operation): Observable<OperationResult> {
    const data = {
      Operand1: x,
      Operand2: y,
      MathOperation: operation,
    };
    return this.http
      .post<OperationResult>(`${this.API_URL}/calculate/`, data);
  }
} 