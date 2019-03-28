import {Pipe, PipeTransform} from '@angular/core';

@Pipe ({
   name : 'trunc'
})
export class TruncPipe implements PipeTransform {
   transform(val : number) : string {
      return val.toFixed(2);
   }
}