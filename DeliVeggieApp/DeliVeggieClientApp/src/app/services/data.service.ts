import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiBaseUrl = 'https://localhost:44397/api/';
  constructor(private http: HttpClient) { }


getData$(apiName): Observable<any[]>{
 

  return this.http.get<any>(`${this.apiBaseUrl}${apiName}/`);
}
}
