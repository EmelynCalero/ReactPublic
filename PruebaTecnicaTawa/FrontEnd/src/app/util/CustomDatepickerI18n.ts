
import { Component,Injectable } from '@angular/core';
import {NgbDatepickerI18n, NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import {I18n} from './I18n';

const I18N_VALUES = {
  'pe': {
    weekdays: ['LU', 'MA', 'MI', 'JU', 'VI', 'SA', 'DO'],
    months: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
  }
  // other languages you would support
};

// // Define a service holding the language. You probably already have one if your app is i18ned. Or you could also
// // use the Angular LOCALE_ID value
// @Injectable()
// export class I18n {
//   language = 'pe';
// }

// Define custom service providing the months and weekdays translations
@Injectable()
export class CustomDatepickerI18n extends NgbDatepickerI18n {

  constructor(private _i18n: I18n) {
    super();
  }

    getWeekdayShortName(weekday: number): string {
      return I18N_VALUES[this._i18n.language].weekdays[weekday - 1];
    }
    getMonthShortName(month: number): string {
      return I18N_VALUES[this._i18n.language].months[month - 1];
    }
    getMonthFullName(month: number): string {
      return this.getMonthShortName(month);
    }

    getDayAriaLabel(date: NgbDateStruct): string {
      return `${date.day}-${date.month}-${date.year}`;
    }
}


// export class FormatNgdatepicker {
// }
