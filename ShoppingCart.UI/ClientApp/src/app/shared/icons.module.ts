import { NgModule } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';

@NgModule()
export class IconsModule {
  constructor(
    private _domSanitizer: DomSanitizer,
    private _matIconRegistry: MatIconRegistry
  ) {
    _matIconRegistry.addSvgIconSet(
      _domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/material-twotone.svg'
      )
    );
    _matIconRegistry.addSvgIconSetInNamespace(
      'mat_outline',
      _domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/material-outline.svg'
      )
    );
    _matIconRegistry.addSvgIconSetInNamespace(
      'mat_solid',
      _domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/material-solid.svg'
      )
    );
    _matIconRegistry.addSvgIconSetInNamespace(
      'heroicons_outline',
      _domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/heroicons-outline.svg'
      )
    );
  }
}
