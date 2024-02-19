import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, Subject, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { Offer, PostOfferDTO } from '../models/offer.model';
import { Category } from '../models/category.model';
import { PaginationResult } from '../models/pagination-result.model';

@Injectable({
  providedIn: 'root'
})
export class MarketplaceApiService {
  private readonly marketplaceApUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) { 
  }

  getOffers(pageIndex: number, pageSize: number): Promise<PaginationResult<Offer>> {
    return this.http.get<PaginationResult<Offer>>(`${this.marketplaceApUrl}Offer`, { params: { pageIndex, pageSize } }).toPromise()
  }

  postOffer(offer: PostOfferDTO): Observable<any>{
    return this.http.post(`${this.marketplaceApUrl}Offer`, {...offer})
  }  

  getCategories(): Promise<Category[]>{
    return this.http.get<Category[]>(`${this.marketplaceApUrl}Category`).toPromise()
  } 
}
