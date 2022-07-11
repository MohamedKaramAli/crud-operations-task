
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GovernorateDto } from 'src/app/model/GovernorateDTO';
import { SupplierDTO } from 'src/app/model/SupplierDto';
import { SupplierFilterDTO } from 'src/app/model/SupplierFilterDTO';
import { SupplierTypeDto } from 'src/app/model/SupplierTypeDTO';

@Injectable({
  providedIn: 'root',
})
export class SuppliersService {
  
  constructor(    private http: HttpClient,
    @Inject('BASE_URL')private baseUrl: string) { }

getAll(filter:SupplierFilterDTO)
{
  const headers = new HttpHeaders()
  .append('Access-Control-Allow-Origin', 'http://localhost:4200')

  return this.http.post(this.baseUrl + 'supplier/getall',filter,{headers});
}
getSupplierTypes():Observable<SupplierTypeDto[]>
{
  
  return this.http.get<SupplierTypeDto[]>(this.baseUrl + 'supplier/getsuppliertypes');
}
getGovernorates():Observable<GovernorateDto[]>
{
  return this.http.get<GovernorateDto[]>(this.baseUrl + 'supplier/getgovernorates');
}
delete(id?:number){
  return this.http.delete(this.baseUrl + `supplier/delete/${id}`);
}
update(supplier:SupplierDTO){
  return this.http.put(this.baseUrl + `supplier/update`,supplier);
}
create(supplier:SupplierDTO){
  return this.http.post(this.baseUrl + `supplier/create`,supplier);
}
getById(id?:number):Observable<SupplierDTO>
{
  return this.http.get<SupplierDTO>(this.baseUrl + `supplier/getbyid/${id}`);
}
}