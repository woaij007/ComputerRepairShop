select * from AspNetUsers;

select * from AspNetUserRoles;

select * from AspNetRoles;

insert into AspNetRoles(Id,Name) values(1,'admin');
insert into AspNetRoles(Id,Name) values(2,'employee');

insert into AspNetUserRoles(UserId,RoleId) values('02f4d8e3-956d-4931-9da1-e4bdeb14f33e',1);