import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class ErrorService {
    getClientMessage(error: Error): string {
      debugger;
        if (!navigator.onLine) {
            return 'Sin conexión a Internet';
        }
        return error.message ? error.message : error.toString();
    }

    getClientStack(error: Error): string {
        return error.stack;
    }

    getServerMessage(error: HttpErrorResponse): string {
        return error.message;
    }

    getServerStack(error: HttpErrorResponse): string {
        return error.name;
    }
}
