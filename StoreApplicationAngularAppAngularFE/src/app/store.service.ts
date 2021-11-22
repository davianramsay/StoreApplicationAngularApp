import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Store } from './store';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private http: HttpClient) { }

  private storeurl = 'https://localhost:44338';

  


  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };


  storelist(): Observable<Store[]> {
    return this.http.get<Store[]>(`${this.storeurl}/storelocations`);
  }
  
  }



