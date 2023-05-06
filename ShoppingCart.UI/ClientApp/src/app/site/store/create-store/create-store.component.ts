import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { StoreService } from '../services/store.service';
import { SharedModule } from 'src/app/shared/shared.module';

@Component({
  selector: 'app-create-store',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './create-store.component.html',
  styleUrls: ['./create-store.component.scss']
})
export class CreateStoreComponent {

  form: FormGroup;

  constructor(private fb: FormBuilder,
    private storeService: StoreService,
    public dialogRef: MatDialogRef<CreateStoreComponent>) {
    this.createForm();
  }

  private createForm() {
    this.form = this.fb.group({
      branch: new FormControl<string>(null, [Validators.required, Validators.maxLength(50)]),
      address: new FormControl<string>(null, [Validators.required, Validators.maxLength(150)])
    });
  }

  add() {
    this.storeService
      .createStore(this.form.value)
      .subscribe({
        next: (idStore: number) => {

          let NewStore = {
            idStore: idStore,
            branch: this.form.value.branch,
            address: this.form.value.address
          };

          this.storeService.onChangeStore.emit(NewStore);

          this.dialogRef.close(NewStore);
        },
        error: (e) => { this.dialogRef.close(); }
      })
  }
}
