
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SupplierDTO } from 'src/app/model/SupplierDto';
import { SupplierFilterDTO } from 'src/app/model/SupplierFilterDTO';

@Injectable({
  providedIn: 'root',
})
export class SuppliersService {

  constructor(    private http: HttpClient,
    @Inject('BASE_URL')private baseUrl: string) { }

getAll(filter:SupplierFilterDTO)
{
  return this.http.post(this.baseUrl + 'supplier/getall',filter);
}
getSupplierTypes()
{
  return this.http.get(this.baseUrl + 'supplier/getsuppliertypes');
}
getGovernorates()
{
  return this.http.get(this.baseUrl + 'supplier/getgovernorates');
}
delete(id:number){
  return this.http.delete(this.baseUrl + `supplier/delete/${id}`);
}
update(supplier:SupplierDTO){
  return this.http.put(this.baseUrl + `supplier/update`,supplier);
}
create(supplier:SupplierDTO){
  return this.http.post(this.baseUrl + `supplier/create`,supplier);
}
getById(id:number):Observable<SupplierDTO>
{
  return this.http.get<SupplierDTO>(this.baseUrl + `supplier/getbyid/${id}`);
}
}