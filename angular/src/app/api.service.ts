import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {OperationResult} from './operationresult';
import {Observable} from 'rxjs';
import {HttpHeaders} from '@angular/common/http';
import {environment} from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private API_URL = environment.api_url;

  constructor(private http: HttpClient) {}

  calculate(requestData): Observable<OperationResult> {
    return this.http
      .post<OperationResult>(`${this.API_URL}/calculate/`, requestData);
  }
}
