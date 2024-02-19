import { Component, OnInit } from '@angular/core';
import { OfferItemComponent } from '../offer-item/offer-item.component';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from 'src/app/core/components/paginator/paginator.component';
import { PageModel } from 'src/app/core/models/page.model';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';
import { Offer } from 'src/app/core/models/offer.model';
import { PaginationResult } from 'src/app/core/models/pagination-result.model';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.scss'],
  standalone: true,
  imports: [
    CommonModule, 
    OfferItemComponent,
    PaginatorComponent
  ]
})
export class OfferListComponent implements OnInit {
  readonly itemsPerPage = 10;

  loading: boolean = false;

  pageConfig: PageModel<Offer>;


  constructor(private offerService: MarketplaceApiService) {
    this.loading = true;
    this.offerService.getOffers(0, this.itemsPerPage).then((res: PaginationResult<Offer>) => {
      this.loading = false;
      this.pageConfig = new PageModel<Offer>(res.items, 0, res.totalPages)
    })

  }

  ngOnInit(): void {
  }

  pageChanged(){
    this.loading = true;
    this.offerService.getOffers(this.pageConfig.pageIndex, this.itemsPerPage).then((res: PaginationResult<Offer>) => {
      this.pageConfig.items = res.items;
      window.scroll(0,0);
      this.loading = false;
    })
  }
}
