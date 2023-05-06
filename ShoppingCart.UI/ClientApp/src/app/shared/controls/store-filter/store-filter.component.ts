import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared.module';
import { StoreResponse } from 'src/app/site/store/models/response/store.response';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { StoreService } from 'src/app/site/store/services/store.service';

@Component({
  selector: 'store-filter',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './store-filter.component.html',
  styleUrls: ['./store-filter.component.scss']
})
export class StoreFilterComponent implements OnInit, OnDestroy {

  @Output() onSelectStore = new EventEmitter<StoreResponse>();

  stores: StoreResponse[] = [];

  storeControl = new FormControl<string | StoreResponse>('');

  filteredStoreOptions: Observable<StoreResponse[]>;

  subscription: any;

  constructor(private storeService: StoreService) { }


  ngOnInit(): void {
    this.getStores();

    this.subscription = this.storeService.onChangeStore
      .subscribe(item => this.stores.push(item));
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  initForm() {

    this.filteredStoreOptions = this.storeControl.valueChanges.pipe(
      startWith(''),
      map(value => {
        const name = typeof value === 'string' ? value : value?.branch;
        return name ? this._filterStore(name as string) : this.stores.slice();
      }),
    );

  }

  getStores(): void {
    this.storeService
      .getStores()
      .subscribe({
        next: (response: StoreResponse[]) => {
          this.stores = response;
          this.initForm();
        }
      });

  }

  selectStore = ($event) =>
    this.onSelectStore.emit($event.option.value);

  displayStorekFn = (truck: StoreResponse) => truck.branch;

  private _filterStore(name: string): StoreResponse[] {
    const filterValue = name.toLowerCase();

    return this.stores.filter(option => option.branch.toLowerCase().includes(filterValue));

  }
}
