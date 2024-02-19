import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { PostOfferDTO } from '../models/offer.model';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class OfferService {
  constructor(private http: HttpClient, private router: Router) { 
  }

  postOffer(offer: PostOfferDTO): Observable<any>{
    return this.http.post(`${environment.apiUrl}Offer`, {...offer})
  }  

  getCategories(): Promise<Category[]>{
    return this.http.get<Category[]>(`${environment.apiUrl}Category`).toPromise()
  } 
}
