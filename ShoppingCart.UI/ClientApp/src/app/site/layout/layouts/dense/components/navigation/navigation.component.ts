import { Component, EventEmitter, OnInit, Output } from '@angular/core';

interface Navigation {
  hidden: boolean;
  active?: boolean;
  link: string;
  name: string;
  disabled: boolean;
  icon: string;
}
@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  @Output() public sidenavClose = new EventEmitter();
  constructor() { }

  ngOnInit(): void { }

  navigation: Array<Navigation> = [
    {
      hidden: false,
      link: 'store',
      name: 'Store',
      disabled: false,
      icon: 'heroicons_outline:shopping-cart'
    },
    {
      hidden: false,
      link: 'locations',
      name: 'Locations',
      disabled: false,
      icon: 'heroicons_outline:location-marker'
    },
    {
      hidden: false,
      link: 'article',
      name: 'Products',
      disabled: false,
      icon: 'heroicons_outline:shopping-bag'
    }
  ];
  items: Array<any> = Array(10);

  closeSidenav = () => {
    this.sidenavClose.emit();
  }
}
