import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Layout } from './layoute.types';

@Component({
  selector: 'layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent implements OnInit {
  constructor(private _activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.updateLayout();
  }

  layout: Layout = 'empty';

  private updateLayout() {
    let route = this._activatedRoute;
    while (route.firstChild) {
      route = route.firstChild;
    }

    const routeData = route.snapshot.data;
    if (route) {
      this.layout = routeData['layout'];
    }
    const paths = route.pathFromRoot;
    paths.forEach((r) => {
      if (r.routeConfig && r.routeConfig.data && r.routeConfig.data['layout']) {
        // Se configura el layout de la ruta
        this.layout = r.routeConfig.data['layout'];
      }
    });
  }
}
