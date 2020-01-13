call addUser ("dumDialect69", "1234", (select id from Roles where role = "Cashier"));
select * from Credentials where userLogin = "dumDialect69";
call getRolePass("dumDialect69", "1234");



select "2 inserts should fail" as info;

insert into Clients values (
    "99012266642",
    "D",
    "Beaver",
    "1999-06-11"
);

insert into Clients values (
    "96041388801",
    "T",
    "Sql",
    "2006-04-13"
);

insert into Clients values (
    "99012266643",
    "Maria",
    "Db",
    "1999-01-22"
), (
    "96041388801",
    "Heidi",
    "Sql",
    "1996-04-13"
);

call addProduct("Masuo", 69, 699);
call addProduct("Hasuo", 42, 2137);
call addProduct("Saduo", 13, 666);
call addProduct("Myduo", 420, 420);
call addProduct("Stek wouowy", 7, 1337);

call modifyProductPrice((select id from Products where name = "Masuo"), 599);
call modifyProductPrice((select id from Products where name = "Masuo"), 499);
call modifyProductPrice((select id from Products where name = "Masuo"), 399);
call modifyProductPrice((select id from Products where name = "Stek wouowy"), 1537);


select "this select is ok" as info;
call addInvoice((select id from Clients where name = "Heidi"), now());

select "1 procedure should fail" as info;
call addProductToInvoice((select id from Invoices), (select id from Products where name = "Masuo"), 70);
call addProductToInvoice((select id from Invoices), (select id from Products where name = "Masuo"), 50);
call addProductToInvoice((select id from Invoices), (select id from Products where name = "Hasuo"), 10);
call addProductToInvoice((select id from Invoices), (select id from Products where name = "Saduo"), 5);
call addProductToInvoice((select id from Invoices), (select id from Products where name = "Myduo"), 150);
call addProductToInvoice((select id from Invoices), (select id from Products where name = "Stek wouowy"), 2);

select "4 procedures should fail" as info;
update Invoices set dateOfIssue = "2070-01-01" where 1=1;
update Invoices set dateOfIssue = "1980-01-01" where 1=1;
update Invoices set dateOfIssue = "2000-01-01" where 1=1;
update Invoices set dateOfIssue = "2016-01-01" where 1=1;

call removeAllProductsFromInvoice((select id from Invoices));


select "prices can be effed up because sql is too" as info;


