import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-products-details',
  templateUrl: './products-details.component.html',
  styleUrls: ['./products-details.component.scss']
})
export class ProductsDetailsComponent implements OnInit {

  productDeatils:{name:string,entryDate:string,currentPrice:number};
  constructor(private dataService:DataService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    const productId = this.route.snapshot.paramMap.get('id');
    if(productId)
    this.dataService.getData$( `products/${productId}`).subscribe((response: any) => {
      this.productDeatils = response?.product;
     
});
  }

}
