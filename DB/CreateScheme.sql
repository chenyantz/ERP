CREATE DATABASE shenzhenERP ;
USE shenzhenERP ;

CREATE TABLE account (
  accountName VARCHAR (255) PRIMARY KEY,
  accountPassword VARCHAR (255),
  email VARCHAR (255),
  job TINYINT
  /*0:admin, 1:sales, 2:saleManager,3:buyer,4:buyerManager. 5:warehouse 6,warehouseManager. 7:financial 8;financial manager
*/
) ;

CREATE TABLE custVendor(
 
  cvtype TINYINT, /*0,customer, 1, vendor*/
  cvname VARCHAR(255),
  country VARCHAR(255),
  rate TINYINT,
  term VARCHAR(255),
  contact1 VARCHAR(65535),
  contact2 VARCHAR(65535),
  phone1 VARCHAR(255),
  phone2 VARCHAR(255),
  cellphone VARCHAR(255),
  fax VARCHAR(255),
  email1 VARCHAR(255),
  email2 VARCHAR(255),
  updateName VARCHAR(255),
  lastUpdateDate DATE,
  blacklisted TINYINT, /*0: no, 1:yes*/
  amount INT,
  notes VARCHAR(65535),
  
  CONSTRAINT pk_cvtype_cvname PRIMARY KEY (cvtype,cvname)
);

CREATE TABLE rfq(

rfqNo INT PRIMARY KEY AUTO_INCREMENT,
partNo VARCHAR(255),
mfg VARCHAR(20),
dc SMALLINT,
qty SMALLINT,
resale FLOAT,
cost FLOAT,
customername VARCHAR(255),
rfqdate DATE,
rfqstate TINYINT, /* to do continued for the states*/
pa VARCHAR(255), /*assign to which buyer*/
rohs TINYINT, /* 0 no-rohs, 1:rohs*/
rpr TINYINT, /* 1:cost down, 2:shortage, 3:history*/
alt VARCHAR(255),
assign VARCHAR(255)
);



