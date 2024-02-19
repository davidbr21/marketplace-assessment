import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PageModel } from '../../models/page.model';
import { CommonModule } from '@angular/common';
import { Offer } from '../../models/offer.model';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss'],
  standalone: true,
  imports: [
    CommonModule
  ]
})
export class PaginatorComponent implements OnInit {
  /**
   * @description Odd number that defines the max amount of page buttons to display
   */
  readonly maxButtonsDisplayed: number = 9 

  pagesArr: Array<number>; //Array used to generate page buttons

  offset: number = 0;

  _pageConfig: PageModel<Offer>;

  @Input() set pageConfig(pageModel: PageModel<Offer>) {
    if(pageModel){
      this._pageConfig = pageModel;
      this.pagesArr = [...Array(pageModel.pageCount).keys()];
    }
  }

  @Output() pageChanged = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  switchPage(pageIndex: number){
    if(!(pageIndex < 0) && !(pageIndex >= this._pageConfig.pageCount)) { //Prevents user from navigating to -1 and higher than pageCount
      this._pageConfig.pageIndex = pageIndex;

      if(pageIndex-1 < 0) this._pageConfig.previousPageIndex = null;
      else this._pageConfig.previousPageIndex = pageIndex-1;
  
      if(pageIndex+1 >= this._pageConfig.pageCount) this._pageConfig.nextPageIndex = null;
      else this._pageConfig.nextPageIndex = pageIndex+1;

      this.pageChanged.emit();
    } 
  }
}
