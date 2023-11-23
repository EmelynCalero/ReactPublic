import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorService } from '../services/error.service';
//import { LoggingService } from './logging.service';
//import { NbToastrService } from '@nebular/theme';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

    constructor(private injector: Injector) { }

    handleError(error: Error | HttpErrorResponse) {
  debugger;
        const errorService = this.injector.get(ErrorService);
        //const logger = this.injector.get(LoggingService);

        let message;
        let stackTrace;

        if (error instanceof HttpErrorResponse) {

            message = errorService.getServerMessage(error);
            stackTrace = errorService.getServerStack(error);
        } else {

            message = errorService.getClientMessage(error);
            stackTrace = errorService.getClientStack(error);
        }

        //this.toastrService.show('AIO WebApp', message);

        // Log en carpeta del WebAPI
        //logger.logError(message, stackTrace);

        // Log en consola del browser
        debugger;
        console.log(message + '\n' + stackTrace);

    }
}
