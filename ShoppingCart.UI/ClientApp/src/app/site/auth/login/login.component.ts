import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { AccountService } from '../services/account.service';
import { LoginResponse } from '../models/response/login-response';
import { MatDialog } from '@angular/material/dialog';
import { RegisterComponent } from '../register/register.component';
import { NotificationService } from '../../../infrastructure/services/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder,
    private accountService: AccountService,
    private authService: AuthService,
    private router: Router,
    public dialog: MatDialog,
    private notificationService: NotificationService) {

  }


  ngOnInit(): void {
    this.createForm();
  }

  private createForm() {
    this.form = this.fb.group({
      email: new FormControl('anayeli.vargas@solotalento.com.mx', [Validators.required,Validators.email,Validators.maxLength(50)]),
      password: new FormControl('FromTalenteca123', [Validators.required,
      Validators.pattern(/^(?=\D*\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{8,30}$/)
      ])
    });
  }

  login() {
    if (this.form.invalid) {
      this.notificationService.open('Please enter a valid email and password', 'Error');
      return;
    }
      
    this.accountService.login(this.form?.value).subscribe({
      next: (user: LoginResponse) => this.loginResponse(user),
      error: (e) => { }
    });
  }

  loginResponse(user: LoginResponse) {
    if (user) {
      this.authService.credentials = user;
      this.router.navigateByUrl('/home');
    }
  }

  register(): void {
    let dialogRef = this.dialog.open(RegisterComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.form.get('email').setValue(result);
      }
    });

  }

}
