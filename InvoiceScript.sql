
drop database if exists InvoiceManagement;
create database InvoiceManagement;
use InvoiceManagement;





create table Clients (
    id varchar(11) not null,
    name varchar(20) not null,
    surname varchar(20) not null,
    dateOfBirth date not null,
    
    primary key (id)
);

create table Invoices (
    id int not null auto_increment,
    clientId varchar(11) not null,
    dateOfIssue datetime not null,

    primary key (id),
    foreign key fk_Invoices_clientId (clientId) references Clients(id) on delete cascade on update cascade
);

create table Products (
    id int not null auto_increment,
    name varchar(50) not null unique,
    storageAmount int not null,

    primary key (id)
);

create table InvoiceProducts (
    productId int not null,
    invoiceId int not null,
    amount int not null,
    priceAtTheTime float not null,

    primary key (invoiceId, productid),
    foreign key fk_InvoiceProducts_invoiceId (invoiceId) references Invoices (id) on delete cascade on update cascade,
    foreign key fk_InvoiceProducts_productId (productId) references Products (id) on delete cascade on update cascade
);

create table ProductPrice (
    productId int not null,
    dateOfChange datetime not null,
    newPrice float not null,

    primary key (productId, dateOfChange),
    foreign key fk_ProductPrice_productId (productId) references Products (id) on delete cascade
);
create index ProductPrice_dateOfChange using btree on ProductPrice (dateOfChange);


create table Roles (
    id int not null auto_increment,
    role varchar(15) not null,
    pass varchar(32) not null,

    primary key (id)
);

create table Credentials (
    userLogin varchar(20) not null,
    userPassword varchar(32) not null,
    roleId int not null auto_increment,

    primary key (userLogin),
    foreign key fk_Credentials_roleId (roleId) references Roles (id) on delete cascade
);





delimiter $$
create function getProductPriceAtDate(id int, priceDate dateTime) returns float
begin
    return (
        select newPrice from ProductPrice
        where productId = id
        and dateOfChange <= priceDate
        order by dateOfChange desc
        limit 1
    );
end;$$
delimiter ;





delimiter $$
create trigger isIdValid before insert on Clients
for each row
begin
    if (left(new.id, 1) = 'n') then
        if (
            mod((cast(substr(new.id, 2, 1) as unsigned) * 6 +
            cast(substr(new.id, 3, 1) as unsigned) * 5 +
            cast(substr(new.id, 4, 1) as unsigned) * 7 +
            cast(substr(new.id, 5, 1) as unsigned) * 2 +
            cast(substr(new.id, 6, 1) as unsigned) * 3 +
            cast(substr(new.id, 7, 1) as unsigned) * 4 +
            cast(substr(new.id, 8, 1) as unsigned) * 5 +
            cast(substr(new.id, 9, 1) as unsigned) * 6 +
            cast(substr(new.id, 10, 1) as unsigned) * 7), 11)
            <>
            cast(substr(new.id, 11, 1) as unsigned)
        ) then
            signal sqlstate '45000';
        end if;
    else
        if (
            mod((cast(substr(new.id, 1, 1) as unsigned) * 9 +
            cast(substr(new.id, 2, 1) as unsigned) * 7 +
            cast(substr(new.id, 3, 1) as unsigned) * 3 +
            cast(substr(new.id, 4, 1) as unsigned) * 1 +
            cast(substr(new.id, 5, 1) as unsigned) * 9 +
            cast(substr(new.id, 6, 1) as unsigned) * 7 +
            cast(substr(new.id, 7, 1) as unsigned) * 3 +
            cast(substr(new.id, 8, 1) as unsigned) * 1 +
            cast(substr(new.id, 9, 1) as unsigned) * 9 +
            cast(substr(new.id, 10, 1) as unsigned) * 7), 10)
            <>
            cast(substr(new.id, 11, 1) as unsigned)
        ) then
            signal sqlstate '45000';
        end if;
    end if;
end;$$
delimiter ;



delimiter $$
create trigger isClient18Insert before insert on Clients
for each row
begin
    if (period_diff(date_format(now(), '%Y%m'), date_format(new.dateOfBirth, '%Y%m'))/12 < 18) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;

delimiter $$
create trigger isClient18Update before update on Clients
for each row
begin
    if (period_diff(date_format(now(), '%Y%m'), date_format(new.dateOfBirth, '%Y%m'))/12 < 18) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;



delimiter $$
create trigger wasClient18OnDateOfIssueAndDOINotFromFutureInsert before insert on Invoices
for each row
begin
    if (
        period_diff(date_format(new.dateOfIssue, '%Y%m'), date_format((select dateOfBirth from Clients where Clients.id = new.clientId), '%Y%m'))/12 < 18
        or
        new.dateOfIssue > now()
    ) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;

delimiter $$
create trigger Client18OnDateOfIssueAndDOINotFromFuturePlusMatchPriceUpdate before update on Invoices
for each row
begin
    if (
        period_diff(date_format(new.dateOfIssue, '%Y%m'), date_format((select dateOfBirth from Clients where Clients.id = new.clientId), '%Y%m'))/12 < 18
        or
        new.dateOfIssue > now()
    ) then
        signal sqlstate '45000';
    end if;
    
    update InvoiceProducts inner join Invoice on InvoiceProducts.invoiceId = Invoices.id
    set priceAtTheTime = getProductPriceAtDate(productId, new.dateOfIssue)
    where id = new.id;
end;$$
delimiter ;



delimiter $$
create trigger isAmountPositiveInsert before insert on InvoiceProducts
for each row
begin
    if (new.amount > (select storageAmount from Products where id = new.productId)) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;

delimiter $$
create trigger isAmountPositiveUpdate before update on InvoiceProducts
for each row
begin
    if (new.amount > (select storageAmount from Products where id = new.productId)) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;



delimiter $$
create trigger isPricePositiveInsert before insert on ProductPrice
for each row
begin
    if (new.newPrice <= 0) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;

delimiter $$
create trigger isPricePositiveUpdate before update on ProductPrice
for each row
begin
    if (new.newPrice <= 0) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;





delimiter $$
create procedure addProductToInvoice(in invoiceId int, in productId int, in amount int)
begin
    set autocommit = 0;
    start transaction;
    
    insert into InvoiceProducts values (
        productId,
        invoiceId,
        amount,
        (select newPrice from ProductPrice where ProductPrice.productId = productId order by ProductPrice.dateOfChange desc limit 1)
    );
    update Products set storageAmount = (storageAmount - amount) where id = productId;
    
    if ((select storageAmount from Products where id = productId) < 0) then
        rollback;
        set autocommit = 1;
        signal sqlstate '45000';
    else
        commit;
        set autocommit = 1;
    end if;
    
end;$$
delimiter ;



delimiter $$
create procedure addProduct(in name varchar(50), in amountInStock int, in startingPrice float)
begin
    insert ignore into Products (name, storageAmount) values (
        name,
        amountInStock
    );
    if (last_insert_id() = 0) then
        signal sqlstate '45000';
    else
        call modifyProductPrice((select name from Products where Products.name = name), startingPrice);
        if (last_insert_id() = 0) then
            signal sqlstate '45000';
        end if;
    end if;
end;$$
delimiter ;

delimiter $$
create procedure getProduct(in id int, in priceDate datetime)
begin
    select Products.*, getProductPriceAtDate(id, dateTime)
    from Products where Products.id = id;
end;$$
delimiter ;

delimiter $$
create procedure modifyProductPrice(in productId int, in newPrice float)
begin
    insert ignore into ProductPrice values (
        productId,
        now(),
        newPrice
    );
    if (last_insert_id() = 0) then
        signal sqlstate '45000';
    end if;
end;$$
delimiter ;



delimiter $$
create procedure getRolePass(in userLogin varchar(20), in userPassword varchar(20))
begin
    select role, pass from Roles inner join Credentials on Roles.id = Credentials.roleId
    where Credentials.userLogin = userLogin and Credentials.userPassword = md5(userPassword);
end;$$
delimiter ;





grant select, insert on InvoiceManagement.Clients
    to 'IMCashier'@'localhost' identified by '49778fc3d37abe24eedf7a29882370cd';
grant insert on InvoiceManagement.Invoices
    to 'IMCashier'@'localhost' identified by '49778fc3d37abe24eedf7a29882370cd';
grant select on InvoiceManagement.Products
    to 'IMCashier'@'localhost' identified by '49778fc3d37abe24eedf7a29882370cd';
grant execute on procedure InvoiceManagement.addProductToInvoice
    to 'IMCashier'@'localhost' identified by '49778fc3d37abe24eedf7a29882370cd';
 
grant select on InvoiceManagement.Clients
    to 'IMAccountant'@'localhost' identified by '70905350353b3e6adb4b6a74bdc3f61a';
grant select on InvoiceManagement.Invoices
    to 'IMAccountant'@'localhost' identified by '70905350353b3e6adb4b6a74bdc3f61a';
grant select on InvoiceManagement.Products
    to 'IMAccountant'@'localhost' identified by '70905350353b3e6adb4b6a74bdc3f61a';
grant select on InvoiceManagement.InvoiceProducts
    to 'IMAccountant'@'localhost' identified by '70905350353b3e6adb4b6a74bdc3f61a';
    
grant select, update, delete on InvoiceManagement.Products
    to 'IMManager'@'localhost' identified by '23f525e04f07113367e233d4d6416b69';
grant execute on procedure InvoiceManagement.addProduct
    to 'IMManager'@'localhost' identified by '23f525e04f07113367e233d4d6416b69';
grant execute on procedure InvoiceManagement.modifyProductPrice
    to 'IMManager'@'localhost' identified by '23f525e04f07113367e233d4d6416b69';
grant execute on procedure InvoiceManagement.getProduct
    to 'IMManager'@'localhost' identified by '23f525e04f07113367e233d4d6416b69';
    
grant select, insert, update, delete on InvoiceManagement.Clients
    to 'IMAdmin'@'localhost' identified by 'ceda392467dc055ce0cc55cd5a23e062';
grant select, insert, update, delete on InvoiceManagement.Invoices
    to 'IMAdmin'@'localhost' identified by 'ceda392467dc055ce0cc55cd5a23e062';
grant insert, update, delete on InvoiceManagement.Products
    to 'IMAdmin'@'localhost' identified by 'ceda392467dc055ce0cc55cd5a23e062';
grant select, insert, update, delete on InvoiceManagement.Credentials
    to 'IMAdmin'@'localhost' identified by 'ceda392467dc055ce0cc55cd5a23e062';
grant execute on InvoiceManagement.*
    to 'IMAdmin'@'localhost' identified by 'ceda392467dc055ce0cc55cd5a23e062';
    
grant execute on procedure InvoiceManagement.getRolePass
    to 'IMAccountFetcher'@'localhost' identified by 'accountFetcher';
    
    
   
    
    
insert into Roles (role, pass) values
    ("Cashier", "49778fc3d37abe24eedf7a29882370cd"),
    ("Accountant", "70905350353b3e6adb4b6a74bdc3f61a"),
    ("Manager", "23f525e04f07113367e233d4d6416b69"),
    ("Admin", "ceda392467dc055ce0cc55cd5a23e062");





