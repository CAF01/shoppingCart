import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SharedModule } from '../../shared.module';

@Component({
  selector: 'upload-file',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})
export class UploadFileComponent implements OnInit {

  maxSize = 2000000;

  @Output() onSelectFile = new EventEmitter<any>();

  form: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      image: ['', Validators.required],
    });
  }

  handleImageInput(event: any): void {
    const file = event.target.files[0];

    if (file) {

      let image = file as File;

      if (image.size > this.maxSize) {
        alert(`Image Max Size ${(this.maxSize / 1000000)}MB`);

        return;
    
      }

    }
    this.form.patchValue({
      image: file,
    });
  
    this.form.get('image').updateValueAndValidity();

    this.onSelectFile.emit(file as File);

  }


}
