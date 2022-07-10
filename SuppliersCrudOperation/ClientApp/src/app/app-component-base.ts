
import { Injector } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { DemoDialog } from './dialog/dialog.component';

export abstract class AppComponentBase {
  toastr: ToastrService;
  dRef :MatDialog;
  constructor(private injector: Injector ) {
    this.toastr = injector.get(ToastrService)
    this.dRef = injector.get(MatDialog)
  }
   

  confirmWithSubscribtion(subscribtion: Observable<any>, message: string, successFunc: any, errorFunc: any) {
    
    let demoDialogRef = this.dRef.open<DemoDialog>(DemoDialog, {
      data: { message: message },
      disableClose: false
    });

    demoDialogRef.afterClosed().subscribe(result => {
      if (result == 'Yes!') {
        subscribtion.subscribe((res) => {
          this.toastr.success('Successfully');
          if (successFunc != null)
            successFunc();
        }, err => {
          if (err.error != null && err.error.length > 0)
            this.toastr.error(err.error[0]);
          else
            this.toastr.error("error")
          console.log(err)
          if (errorFunc != null) errorFunc();
        });
      }
      demoDialogRef = null;
    });
  }


  confirm( message: string, yesFunc: any, noFunc: any) {
    
    let demoDialogRef = this.dRef.open<DemoDialog>(DemoDialog, {
      data: { message: message },
      disableClose: false
    });

    demoDialogRef.afterClosed().subscribe(result => {
      if (result == 'Yes!') {
        if (yesFunc!=null)    
          yesFunc();
        }else{
          if (noFunc!=null)    
          noFunc();
        }
  });
}

}