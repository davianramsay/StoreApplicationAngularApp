import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //store: Store[] = [];
  test: string = 'test string';

  store: Store[] = []
 
  constructor(private storeService: StoreService) { }

  


  ngOnInit(): void {
    this.getStores();
    
  }


  getStores(): void {
    this.storeService.storelist().subscribe(x => {
    
     // console.log(x);
     this.store = x;
      console.log(this.store);
    });
  }

}
