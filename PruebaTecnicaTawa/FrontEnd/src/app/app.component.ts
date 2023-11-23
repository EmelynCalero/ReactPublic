import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { variablesGlobales } from './util/variables-globales';

@Component({
  // tslint:disable-next-line
  selector: 'body',
  template: '<router-outlet></router-outlet>'
})
export class AppComponent implements OnInit {
  constructor(private router: Router) { }

  ngOnInit() {
    variablesGlobales.usuario.Token = '';

    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });
  }
}
