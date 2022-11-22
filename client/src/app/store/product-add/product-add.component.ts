import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { IProduct } from 'src/app/models/product';
import { StoreService } from 'src/app/services/store.service';


@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.scss']
})
export class ProductAddComponent implements OnInit {
  productAddForm: FormGroup;

  constructor(private storeService: StoreService, private snackBar: MatSnackBar, private dialog: MatDialog, private router: Router) { }

  ngOnInit(): void {
    this.createRoomForm();
  }

  createRoomForm() {
    this.productAddForm = new FormGroup({
      model: new FormControl('', [Validators.required]),
      productName: new FormControl('', [Validators.required]),
      imageUrl: new FormControl('', [Validators.required]),
      price: new FormControl(null, [Validators.required]),
      topologyId: new FormControl('', [Validators.required]),
      functionId: new FormControl('', [Validators.required]),
      dimensions: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required])
    })
  }

  get producModel() { return this.productAddForm.get('model'); }
  get productName() { return this.productAddForm.get('productName'); }
  get imageUrl() { return this.productAddForm.get('imageUrl'); }
  get price() { return this.productAddForm.get('price'); }
  get topologyId() { return this.productAddForm.get('topologyId'); }
  get functionId() { return this.productAddForm.get('functionId'); }
  get dimensions() { return this.productAddForm.get('dimensions'); }
  get description() { return this.productAddForm.get('description'); }


  onSubmit() {
    const productModel = {
      model: this.producModel.value,
      productName: this.productName.value,
      imageUrl: this.imageUrl.value,
      price: this.price.value,
      topology: this.topologyId.value,
      function: this.functionId.value,
      dimensions: this.dimensions.value,
      description: this.description.value

    } as IProduct;

    console.log(productModel);
    this.storeService.addProduct(productModel).subscribe({
      next: () => {
        this.storeService.setRefresh(true);
        this.router.navigateByUrl('/store');
        this.snackBar.open('Product was successfully added', 'Close', {
          duration: 5000
        });
        this.dialog.closeAll();
      },
      error: (error) => {
        this.snackBar.open(error.errors, 'Close', {
          duration: 5000
        });
    }});

  }

}
