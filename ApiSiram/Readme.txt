https://developers.redhat.com/articles/2024/01/11/connect-dotnet-app-external-postgresql-database#implementing_the_database_connection
https://medium.com/@saisiva249/how-to-configure-postgres-database-for-a-net-a2ee38f29372
https://stackoverflow.com/questions/65471657/creating-classes-from-postgres-database-for-entity-framework-core
https://www.learnentityframeworkcore.com/walkthroughs/existing-database

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

cd D:\IMI\Siram\aplikasi\SIRAM\ApiSiram
dotnet ef dbcontext scaffold "Host=localhost;Database=dbsiram;Username=postgres;Password=P@ssword" Npgsql.EntityFrameworkCore.PostgreSQL -o Models


dotnet ef migrations add initialMigration
dotnet ef migrations remove
dotnet ef database update
dotnet ef migrations script 


select * from users u order by id;
select * from roles r  ;
select * from role_has_permissions rhp  ;
select * from "groups" g ;
select * from user_groups ug ;
select * from permissions p ;
select * from role_has_permissions rhp  ;

TRUNCATE TABLE "groups" RESTART IDENTITY;


COPY 
pangkat(id, divisi_id, kategori, sub_kategori, pangkat_id, kd_pangkat, nama_pangkat, herarki, parent_id, status, created_at, updated_at, last_updated_at, updated_by)
TO 'D:\IMI\Siram\aplikasi\DATABASE\pangkat.csv'
DELIMITER ';'
CSV HEADER;
