import { HttpClient, HttpHeaders, HttpParams, JsonpClientBackend } from '@angular/common/http';
import { Component, OnInit,Injectable } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import Swal from 'sweetalert2'
import { DatePipe } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateParserFormatter,NgbDatepickerI18n, NgbDate, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import {CustomDatepickerI18n} from '../../util/CustomDatepickerI18n';
import {I18n} from '../../util/I18n';
import { H001_Persona } from '../../entity/H001_Persona';
import { H001_Departamento } from '../../entity/H001_Departamento';
import { H001_Provincia } from '../../entity/H001_Provincia';
import { H001_Distrito } from '../../entity/H001_Distrito';
import { H001_TipoDocumento } from '../../entity/H001_TipoDocumento';
import {map} from 'rxjs/operators'

@Component({
  selector: 'register.component',
  templateUrl: 'register.component.html',
  styleUrls: ['./register.component.scss'],
  providers: [I18n,DatePipe, {provide: NgbDatepickerI18n, useClass: CustomDatepickerI18n}]
})
export class RegisterComponent  implements OnInit { 
  goH001_Persona: H001_Persona = {};
  gloH001_TipoDocumento:H001_TipoDocumento[];
  gloH001_Departamento:H001_Departamento[];
  gloH001_Provincia:H001_Provincia[];
  gloH001_Distrito:H001_Distrito[];
  gsTipoDocumento: string = ""; 
  gdFechaSeleccionada: NgbDateStruct;
  
  constructor( private formBuilder: FormBuilder,public datepipe: DatePipe,private http:HttpClient){   
   }

  ngOnInit() {
  }

  ListarTipoDocumento(){      
  }
  ListarUbigeoDepartamento(){    
  }
  ListarUbigeoProvincia(){ 
  }
  ListarUbigeoDistrito(){   
  }
  InsertarPaciente(){   
  }
}
