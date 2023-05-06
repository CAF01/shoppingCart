import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'dense-layout',
  templateUrl: './dense.component.html',
  styleUrls: ['./dense.component.scss'],
})
export class DenseComponent implements OnInit {
  @Output() public sidenavClose = new EventEmitter();

  constructor(public authService: AuthService) {
  }

  ngOnInit(): void { }

  close = () => {
    this.sidenavClose.emit();
  }
}
