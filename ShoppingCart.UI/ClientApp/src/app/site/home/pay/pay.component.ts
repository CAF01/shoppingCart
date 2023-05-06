import { Component, OnInit } from '@angular/core';
import { Resume } from '../models/resume';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  styleUrls: ['./pay.component.scss']
})
export class PayComponent implements OnInit {
  displayedColumns: string[] = ['Code', 'Count', 'Total'];

  public resume: Resume[] = [];

  constructor(public dialogRef: MatDialogRef<PayComponent>) { }

  ngOnInit(): void {

  }

  pay = () =>
    this.dialogRef.close(this.resume.length > 0 ? true : false);


}
