import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ArticleService } from '../services/article.service';
import { StoreResponse } from '../../store/models/response/store.response';
import { CreateArticleRequest } from '../models/request/create-article.request';
import { ArticleResponse } from '../models/response/article.response';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html',
  styleUrls: ['./create-article.component.scss']
})
export class CreateArticleComponent {

  form: FormGroup;
  imageFile: File;

  constructor(
    private articleService: ArticleService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<CreateArticleComponent>,
    private authService: AuthService
  ) {
    this.form = this.fb.group({
      code: ['', [Validators.required, Validators.maxLength(30)]],
      description: ['', [Validators.required, Validators.maxLength(150)]],
      price: [0, [Validators.required, Validators.min(1)]],
      stock: [0, [Validators.required, Validators.min(1)]],
      idStore: [null, [Validators.required, Validators.min(1)]],
      image: [null, [Validators.required]]
    });

    
  }

  onSelectStore(store: StoreResponse): void {
    this.form.patchValue({
      idStore: store.idStore
    });
    this.updateFormControl('idStore');
  }

  loadImage(file: File): void {
    this.imageFile = file;
    this.form.patchValue({
      image: file.name
    });
    this.updateFormControl('image');
  }

  uploadImage(): void {
    this.articleService.uploadFile(this.imageFile).subscribe({
      next: (response: string) => { },
      error: (err) => {
        if (err && err.status === 200) {
          let url_image = JSON.stringify(err.error.text);
          this.updateImage(url_image.replace('"', '').replace('"', ''));
        }
      }
    });
  }

  updateImage(url: string): void {
    this.form.patchValue({
      image: url
    });
    this.updateFormControl('image');
    this.saveArticle();
  }

  saveArticle(): void {
    this.articleService.createArticle(this.form.value).subscribe({
      next: (idResponse) => {
        let NewArticle = this.form.value as ArticleResponse;
        NewArticle.idArticle = idResponse;
        NewArticle.image = this.form.value.image;
        NewArticle.branch = this.authService.currentStore.branch;
        this.dialogRef.close(NewArticle);
      }
    });
  }

  updateFormControl(controlName: string): void {
    const control = this.form.get(controlName);
    control.updateValueAndValidity();
  }

  add(): void {
    this.uploadImage();
  }
}
