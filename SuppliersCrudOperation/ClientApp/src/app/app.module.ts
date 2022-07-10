import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { SuppliersComponent } from './suppliers/suppliers.component';
import { SupplierDialogComponent } from './supplier-dialog/supplier-dialog.component';
import { MatAutocompleteModule, MatButtonModule, MatDialogModule, MatFormFieldModule, MatIconModule, MatInputModule, MatMenuModule, MatNativeDateModule, MatPaginatorModule, MatProgressSpinnerModule, MatSelectModule, MatSortModule, MatTableModule } from '@angular/material';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { DemoDialog } from './dialog/dialog.component';

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
    MatAutocompleteModule,
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
