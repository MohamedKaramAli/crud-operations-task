import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injector, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { PagedResult } from '../model/PagedResult';
import { SupplierDTO } from '../model/SupplierDto';
import { SupplierFilterDTO } from '../model/SupplierFilterDTO';

import { finalize, startWith, switchMap, catchError, map, } from 'rxjs/operators';
import { merge, Observable, of as observableOf } from 'rxjs';
import { SupplierDialogComponent } from '../supplier-dialog/supplier-dialog.component';

import { ToastrService } from 'ngx-toastr';
import { SuppliersService } from 'src/Services/supplier.service';
import { AppComponentBase } from '../app-component-base';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.scss']
})
export class SuppliersComponent  extends AppComponentBase  implements OnInit {


  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;
  resultsLength:number=0
   suppliers: SupplierDTO[]=[];
  filter: SupplierFilterDTO = new SupplierFilterDTO();
  isLoadingResults: boolean=false;
  displayedColumns: string[] = ["Name" ,
    "PhoneNumber",
    "Address" ,
    "TypeId" ,
    "GovernorateId" ,'actions'];

  constructor( 
    private _supplierService:SuppliersService, 
    injector:Injector   
     ) {
super(injector);
  }
  ngOnInit(): void {
    this.search();
  
    this.sort?.sortChange.subscribe(()=>{
      this.search();
    });
    this.paginator?.page.subscribe(()=>{
      this.search();
    });


  }
  search() {
    this.isLoadingResults = true;
    this.filter.pageCount = this.paginator?.pageSize;
    this.filter.page = this.paginator?.pageIndex;
    this.filter.sort = this.sort?.active;
    this.filter.sortDir = this.sort?.direction 
    this._supplierService.getAll(this.filter).subscribe((data:any)=>{
      this.isLoadingResults = false;
      this.resultsLength = data.totalCount;
      this.suppliers =  data.items;

    },error=>{
      this.isLoadingResults = false;
      return observableOf([]);
    });


   //this.fillData().subscribe(res=> this.suppliers = res)
  }


  fillData()
   {

    // return merge(this.sort?.sortChange, this.paginator?.page)
    // .pipe(startWith({}),
    //     switchMap(()=> {
    //       this.isLoadingResults = true;
    //       this.filter.pageCount = this.paginator?.pageSize;
    //       this.filter.page = this.paginator?.pageIndex;
    //       this.filter.sort = this.sort?.active;
    //       this.filter.sortDir = this.sort?.direction 
    //       return this._supplierService.getAll(this.filter);
    //     }),
    //     map((data:PagedResult<SupplierDTO>) => {
            
    //         this.isLoadingResults = false;
    //         this.resultsLength = data.totalCount;
    //         return data.items;
    //     }),
    //     catchError(() => {
    //         this.isLoadingResults = false;
    //         return observableOf([]);
    //     })
    // )
}
showCreateOrEditSupplierDialog(id?: number): void {
  let createOrEditSupplierDialog;

      createOrEditSupplierDialog = this.dRef.open(SupplierDialogComponent, {
          data: { _id: id },
          disableClose: true
      });
  createOrEditSupplierDialog.afterClosed().subscribe(result => {
      if (result) {
         
              this.search();
      }
  });
}

 protected delete(supplier:SupplierDTO): void {
  this.confirmWithSubscribtion(this._supplierService.delete(supplier.id),'are you sure?, you will delete the selected item'
  ,()=>{this.search()},null  
  );
}

}
