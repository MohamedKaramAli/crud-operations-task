import { Component, Inject, OnInit,Optional,ViewEncapsulation }      from '@angular/core';
import { MatDialogRef, MatDialog, MAT_DIALOG_DATA } from "@angular/material/dialog";

@Component({
	selector: 'ms-demo-dialog',
	template: `
		<h1>{{message}}</h1>

		<mat-dialog-actions align="end">
			<button mat-button (click)="dialogRef.close('No!')">No</button>
			<button mat-button color="primary" (click)="dialogRef.close('Yes!')">Yes</button>
		</mat-dialog-actions>`
})
export class DemoDialog {
	message:string="";
	constructor(public dialogRef: MatDialogRef<DemoDialog>,
		@Optional() @Inject(MAT_DIALOG_DATA) private data: any) {
		if (data != null) {
			if (data.message != null) {
			  this.message= data.message;
			} 
		  }
	}
}



