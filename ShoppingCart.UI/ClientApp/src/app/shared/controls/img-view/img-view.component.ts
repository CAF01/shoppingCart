import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'img-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './img-view.component.html',
  styleUrls: ['./img-view.component.scss']
})
export class ImgViewComponent {
  public img: string;
}
