import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { IProduct } from 'src/app/models/product';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.scss']
})
export class ProductUpdateComponent implements OnInit {
  product: IProduct;
  productUpdateForm: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public data: IProduct, private storeService: StoreService, private snackBar: MatSnackBar, private dialog: MatDialog, 
    private router: Router) {
   }
    
  ngOnInit(): void {
    this.loadRoom();
    this.updateRoomForm();
  }
  get productName() { return this.productUpdateForm.get('productName'); }
  get price() { return this.productUpdateForm.get('price'); }
  get dimensions() { return this.productUpdateForm.get('dimensions'); }
  get description() { return this.productUpdateForm.get('description'); }

  
  loadRoom(){
    this.storeService.getProduct(this.data.id).subscribe(response => {
      console.log(response);
      this.product = response;
      this.updateRoomForm();
    }, error => {
      console.log(error);
    })
  }

  updateRoomForm(){
    this.productUpdateForm = new FormGroup({
      productName: new FormControl(this.product?.productName, [Validators.required]),
      price: new FormControl(this.product?.price, [Validators.required]),
      dimensions: new FormControl(this.product?.dimensions, [Validators.required]),
      description: new FormControl(this.product?.description, [Validators.required])
    })
  }




  onSubmit(id: number){
    const formData = new FormData();
    formData.append('productName', this.productName?.value);
    formData.append('price', this.price?.value);
    formData.append('dimensions', this.dimensions?.value);
    formData.append('description', this.description?.value);
  
    this.storeService.updateProduct(id, formData).subscribe(response => {
      this.snackBar.open('Product was successfully updated', 'Close', {
        duration: 5000
      });
      this.dialog.closeAll();
    }, error => {
      console.log(error);
    });
  }

}
