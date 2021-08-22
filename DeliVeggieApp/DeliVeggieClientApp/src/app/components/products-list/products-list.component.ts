import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {
  products: any[];
  headElements = ['ID', 'Name',''];
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getData$('products').subscribe((products: any[]) => {
           this.products = products;
    });
  }

}

