import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { SuppliersComponent } from './suppliers/suppliers.component';
import { SupplierDialogComponent } from './supplier-dialog/supplier-dialog.component';

import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { DemoDialog } from './dialog/dialog.component';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu'
import {MatTableModule} from '@angular/material/table'
import{MatInputModule} from'@angular/material/input'
import{MatIconModule} from'@angular/material/icon'
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SuppliersComponent,
    SupplierDialogComponent,
    DemoDialog
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    //MatAutocompleteModule,
    MatNativeDateModule,
MatSelectModule,
    MatFormFieldModule,
  MatTableModule,
  MatSortModule,
  MatPaginatorModule ,
  CommonModule,
  MatDialogModule,
  FormsModule,
  MatInputModule,
  MatIconModule,
  MatMenuModule,
  MatProgressSpinnerModule,
  BrowserAnimationsModule,
  MatButtonModule,
  ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: SuppliersComponent, pathMatch: 'full' },

    ])
  ],
  entryComponents:[DemoDialog,SupplierDialogComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
