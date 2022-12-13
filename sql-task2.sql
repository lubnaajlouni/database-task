create database lubna;
create table customers1 (
id int,
fname varchar(20),
lname varchar(20),
PRIMARY KEY (id),
);
SELECT * FROM Customers1;





create table orders1 (
id int,
price float,
product varchar(20),
total float,
PRIMARY KEY (price),
FOREIGN KEY (id) REFERENCES customers1 ,
);
SELECT * FROM orders1;


create table Products1(
id int,
kind varchar(20),
Price float,
PRIMARY KEY (id),
FOREIGN KEY (price) REFERENCES orders1,
);
SELECT * FROM Products1;


INSERT INTO customers1 VALUES(12,'lubna','ajlouni'),(22,'nsreen','nedal'),(1,'ahmad','odat');

INSERT INTO orders1 VALUES(12,20000,'ferari',40000),(22,30000,'mrcedes',50000),(1,60000,'toyota',80000);

INSERT INTO Products1 VALUES(11,'mar',20000),(13,'var',30000),(14,'rrr',60000);

 
SELECT customers1.fname, customers1.lname
FROM customers1
INNER JOIN orders1 ON customers1.id=orders1.id;

SELECT customers1.fname, customers1.lname
FROM customers1
LEFT JOIN orders1 ON customers1.id=orders1.id;

SELECT orders1.price, orders1.product,orders1.total
FROM orders1
LEFT JOIN customers1 ON customers1.id=orders1.id;

SELECT orders1.price, orders1.product,orders1.total
FROM orders1
RIGHT JOIN Products1 ON Products1.Price=orders1.price;

SELECT orders1.id, orders1.product,orders1.total
FROM orders1
FULL OUTER JOIN Products1 ON Products1.Price=orders1.price;


SELECT orders1.id, orders1.product,orders1.total
FROM orders1
LEFT JOIN Products1 ON Products1.Price=orders1.price
LEFT JOIN customers1 ON customers1.id=orders1.id;