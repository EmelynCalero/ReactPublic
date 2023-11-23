import {Component, OnInit} from '@angular/core';
import { navItems } from '../../_nav';
//import { variablesGlobales } from '../../util/variables-globales';
import { Router, NavigationEnd } from '@angular/router';
import { S001_Usuario } from '../../entity/S001_Usuario';


@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent {
  public navItems = navItems;
  goS001_Usuario: S001_Usuario = {};
  goRouter: Router;

  constructor(private _router: Router){
    this.goS001_Usuario = JSON.parse(sessionStorage.getItem("stS001_Usuario"));
  }
  ngOnInit() {}
}
