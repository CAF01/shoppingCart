import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateStoreComponent } from '../create-store/create-store.component';
import { StoreService } from '../services/store.service';
import { StoreResponse } from '../models/response/store.response';

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.scss']
})
export class StoresComponent implements OnInit {

  displayedColumns: string[] = ['idStore', 'branch', 'address'];

  stores: StoreResponse[] = [];


  constructor(
    private storeService: StoreService,
    public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.getStores();
  }

  getStores(): void {
    this.storeService.getStores().subscribe({
      next: (response: StoreResponse[]) => { this.stores = response; }
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(CreateStoreComponent, {
      disableClose: true
    });

    dialogRef.afterClosed().subscribe({
      next: (branch: StoreResponse) => {
        if (branch) {
          this.stores = [...this.stores, branch];
        }
      }
    });

  }

}
