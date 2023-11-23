import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'FilterPipe'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, input: any): any {
    debugger;
   if (input) {
     return value.filter(val => val.Medico.toString().toLowerCase().indexOf(input.toString().toLowerCase()) >= 0);
   } else {
     return value;
   }
  }
}
