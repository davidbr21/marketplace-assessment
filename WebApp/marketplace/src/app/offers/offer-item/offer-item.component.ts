import {Component, Input, OnInit} from '@angular/core';
import {  DatePipe } from '@angular/common';
import { Offer } from 'src/app/core/models/offer.model';

@Component({
  selector: 'app-offer-item',
  templateUrl: './offer-item.component.html',
  styleUrls: ['./offer-item.component.scss'],
  standalone: true,
  imports: [DatePipe],
})
export class OfferItemComponent implements OnInit {

  @Input()
  offer: Offer;

  @Input()
  cardSize: "md" | "xl" = "md"; 

  constructor() { }

  ngOnInit(): void {
  }

}
