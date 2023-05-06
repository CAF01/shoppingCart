import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { MatDialogRef } from '@angular/material/dialog';
import { NotificationService } from 'src/app/infrastructure/services/notification.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder,
    private accountService: AccountService,
    public dialogRef: MatDialogRef<RegisterComponent>,
    private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.initForm();
  }


  initForm(): void {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(100)]],
      email: ['', [Validators.email]],
      password: ['', [Validators.required, Validators.maxLength(30), Validators.pattern(/^(?=\D*\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{8,30}$/)]],
      address: ['', [Validators.required, Validators.maxLength(150)]]
    });
  }


  save(): void {
    if (this.form.invalid) {
      this.notificationService.open('Fill all this fields', 'Error');
      return;
    }
    this.accountService.create(this.form.value)
      .subscribe({
        next: (idUser: number) => {
          if (idUser) {
            this.dialogRef.close(this.form.value.email);
            this.notificationService.open('Congratulations, you are now registered!!','Success')
          }
        }
      });
  }


}
