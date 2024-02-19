import { CommonModule } from '@angular/common';
import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, UntypedFormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/core/models/category.model';
import { PostOfferDTO } from 'src/app/core/models/offer.model';
import { User } from 'src/app/core/models/user.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { OfferService } from 'src/app/core/marketplace-api/offer.service';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';

@Component({
  selector: 'app-offer-creation',
  templateUrl: './offer-creation.component.html',
  styleUrls: ['./offer-creation.component.scss'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
})
export class OfferCreationComponent implements OnInit {

  offerForm = new FormGroup({
    categoryId: new FormControl(null, [Validators.required]),
    description: new FormControl('', [Validators.required]),
    location: new FormControl('', [Validators.required]),
    pictureUrl: new FormControl('', [Validators.required]),
    title: new FormControl('', [Validators.required]),
    userId: new FormControl(null, [Validators.required]),
  });

  categories: Category[];
  $user: Subscription;
  constructor(private offerService: MarketplaceApiService, private auth:AuthService, private router: Router) { }

  ngOnInit(): void {
    this.$user = this.auth.$user.subscribe((user:User) => {
      this.offerForm.controls.userId.setValue(user.id);
    })
    this.populateCategories();
  }

  ngOnDestroy(): void{
    this.$user?.unsubscribe();
  }

  async offerSubmit(){
    if(this.offerForm.valid){
      const offerData: PostOfferDTO = {
        categoryId: this.offerForm.controls.categoryId.value,
        description: this.offerForm.controls.description.value,
        location: this.offerForm.controls.location.value,
        pictureUrl: this.offerForm.controls.pictureUrl.value,
        title: this.offerForm.controls.title.value,
        userId: this.offerForm.controls.userId.value,
      }

      try{
        const result = await this.offerService.postOffer(offerData).toPromise()
        if(result){
          alert("Offer posted successfully");
          this.router.navigate(["/list"]);
        } else {
          alert("An error occured while creating the user")
        }
      } catch(e){
        console.log(e);
      }
    } else {
      alert("You must enter a valid post offer")
    }
  }

  async populateCategories(){
    this.categories = await this.offerService.getCategories();
  }
}
