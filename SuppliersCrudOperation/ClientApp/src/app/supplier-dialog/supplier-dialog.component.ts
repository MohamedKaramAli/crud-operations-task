

import { Injector, Optional, Inject, OnInit, Component } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';

import { finalize } from 'rxjs/operators';




import { SupplierDTO } from '../model/SupplierDto';
import { SuppliersService } from 'src/Services/supplier.service';
import { ToastrService } from 'ngx-toastr';
import { AppComponentBase } from '../app-component-base';
import { GovernorateDto } from '../model/GovernorateDTO';
import { SupplierTypeDto } from '../model/SupplierTypeDTO';

@Component({
  selector: 'app-supplier-dialog',
  templateUrl: './supplier-dialog.component.html',
  styleUrls: ['./supplier-dialog.component.scss']

})
export class SupplierDialogComponent  extends AppComponentBase implements OnInit {
  
  saving = false;
  supplier: SupplierDTO = new SupplierDTO();
  data: { _id: number };
  governorates:GovernorateDto[] = [];
  supplierTypes: SupplierTypeDto[] = [];  

  constructor(
    injector:Injector,
    private _supplierService:SuppliersService,
    
    private _dialogRef: MatDialogRef<SupplierDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA)  data:{ _id: number}
  ) {
     super(injector);
      this.data = data;
  }

    ngOnInit(): void {
        // this._devisionService.getFarms(false).subscribe(farms => {
        //     this.farmArr = farms
        // });
this._supplierService.getGovernorates().subscribe((res:GovernorateDto[])=>this.governorates = res );

this._supplierService.getSupplierTypes().subscribe((res:SupplierTypeDto[])=>this.supplierTypes = res );


        if (!(this.data._id == 0||  this.data._id == null))
        {

            this._supplierService.getById(this.data._id).subscribe((result:SupplierDTO) => {
                this.supplier = result;  
            });
        }
   
  }

  exit() {
    this._dialogRef.close(false);
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }

    save(): void {

      this.confirm("are you sure",() => {
                
        this.saving = true;
        if (this.data._id > 0) {
            this._supplierService
                .update(this.supplier)
                .pipe(
                    finalize(() => {
                        this.saving = false;
                    })
                )
                .subscribe(() => {
                    this.toastr.success('Saved Successfully ');
                    this.close(true);
                });
        } else {
            this._supplierService
                .create(this.supplier)
                .pipe(
                    finalize(() => {
                        this.saving = false;
                    })
                )
                .subscribe((res) => {
                    this.toastr.success('Saved Successfully');
                    this.close(true);
                });
        }},()=>{})

      

                }


}
