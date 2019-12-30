
create database if not exists InvoiceManagement;
use InvoiceManagement;



create table if not exists Clients (
    id varchar(11) not null,
    name varchar(20) not null,
    surname varchar(20) not null,
    dateOfBirth date not null,
    
    primary key (id)
);

create table if not exists Invoices (
    id int not null auto_increment,
    clientId varchar(11) not null,
    dateOfIssue datetime not null,

    primary key (id),
    foreign key fk_Invoices_clientId (clientId) references Clients(id) on delete cascade
);

create table if not exists Products (
    id int not null auto_increment,
    name varchar(50) not null,
    storageAmount int not null,

    primary key (id)
);

create table if not exists InvoiceProducts (
    productId int not null,
    invoiceId int not null,
    amount int not null,
    priceAtTheTime float not null,

    primary key (invoiceId, productid),
    foreign key fk_InvoiceProducts_invoiceId (invoiceId) references Invoices (id) on delete Cascade,
    foreign key fk_InvoiceProducts_productId (productId) references Products (id) on delete cascade
);

create table if not exists ProductPrice (
    productId int not null,
    dateOfChange datetime not null,
    newPrice int not null,

    primary key (productId, dateOfChange),
    foreign key fk_ProductPrice_productId (productId) references Products (id) on delete cascade
);



create table if not exists Roles (
    id int not null auto_increment,
    role varchar(15) not null,

    primary key (id)
);

create table if not exists Credentials (
    userLogin varchar(20) not null,
    userPassword varchar(20) not null,
    roleId int not null auto_increment,

    primary key (userLogin),
    foreign key fk_Credentials_roleId (roleId) references Roles (id) on delete cascade
);




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
create trigger wasClient18OnDateOfIssueAndDateOfIssueNotFromFutureInsert before insert on Invoices
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
create trigger wasClient18OnDateOfIssueAndDateOfIssueNotFromFutureUpdate before update on Invoices
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




