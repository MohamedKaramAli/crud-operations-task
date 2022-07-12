# crud-operations-task


Crud Operations (List,Create,Update,Delete)

*brief
The crud operations is for entity called suppliers, each supplier have (Name,Phone,email,address,type,govornorate)
the type and govornorate are selectable fields, their data is populated from database tables (SupplierTypes,Governorates) - 
these two tables have seed data

*project layers

InfratStructure(repository,unitofwork)
DAL(Entities)
BLL (Services, interfaces)
DTO
controllers

presentation Layer(angular)

*Extra Features
Sort (server-side)
Paging(serve-side)
confirmation (before operation(yes-no dialog), after operation (toastr))

*performance notes

1- when using server-side paging, server-side sorting must be used with it, to return the correct sorting
2- Querable with paging is used in the backend to reduce -as possible
the amount of transfered data from database to application.
3- paging also reduces the amount of data
that is transfered through network from application to client side

*important notes
1- technologies (angular- asp.net core -sql)

2- angular and asp.net core are in the same project all you have to do to test the project is to run it from visual studio
3- the project is database First,you must first
modify connectionstring in appsettings.json file, then
 execute update-database command (package-manager)
4- for the angular project you will need to run npm install, if there was a problem with the npm install command try npm install --force


