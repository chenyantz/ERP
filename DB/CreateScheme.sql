`shenzhenerp`CREATE DATABASE shenzhenERP ;
USE shenzhenERP ;

CREATE TABLE account (
  id SMALLINT AUTO_INCREMENT PRIMARY KEY,
  accountName VARCHAR (255) ,
  accountPassword VARCHAR (255),
  email VARCHAR (255),
  job TINYINT,
  /*0:admin, 1:boss,2:sales, 3:saleManager,4:buyer,5:buyerManager. 6:warehouse 7,warehouseManager. 8:financial 9;financial manager
*/
  superviser SMALLINT
) ;




CREATE TABLE custVendor (
  cvtype TINYINT,
  /*0,customer, 1, vendor*/
  cvname VARCHAR (255),
  country VARCHAR (255),
  cvnumber VARCHAR(255),
  rate TINYINT,
  term VARCHAR (255),
  contact1 VARCHAR (65535),
  contact2 VARCHAR (65535),
  phone1 VARCHAR (255),
  phone2 VARCHAR (255),
  cellphone VARCHAR (255),
  fax VARCHAR (255),
  email1 VARCHAR (255),
  email2 VARCHAR (255),
  ownerName SMALLINT,  
  lastUpdateName SMALLINT,
  lastUpdateDate DATETIME,
  blacklisted TINYINT,
  /*0: no, 1:yes*/3
  amount INT,
  notes VARCHAR (65535),
  CONSTRAINT pk_cvtype_cvname_ownerName PRIMARY KEY (cvtype,cvname,ownerName)
) ;

CREATE TABLE rfq(

rfqNo INT PRIMARY KEY AUTO_INCREMENT,
customerName VARCHAR(255),
partNo VARCHAR(255),
salesId SMALLINT,
contact VARCHAR(65535),
project VARCHAR(255),
rohs TINYINT, /* 0 no-rohs, 1:rohs*/
phone VARCHAR(255),
fax VARCHAR(255),
email VARCHAR(255),
rfqdate DATE,
priority TINYINT, /* 1:cost down, 2:shortage, 3:history*/
dockdate DATE,
mfg VARCHAR(20),
dc VARCHAR(20),
custPartNo VARCHAR(255),
genPartNo VARCHAR(255),
alt VARCHAR(255),
qty SMALLINT,
packaging VARCHAR(255),
targetPrice FLOAT,
resale FLOAT,
cost FLOAT,
firstPA SMALLINT,
secondPA SMALLINT,
rfqStates TINYINT /*0 new : 1 routed 2,Route 3,Quote 4, closed 5, has SO, 6 SO Approved*/
);



CREATE TABLE rfqInfoAndHistory
(
rfqNo INT,
infoToCustomer MEDIUMTEXT,
infoToInternal MEDIUMTEXT,
routingHistory MEDIUMTEXT
);

CREATE TABLE rfqCopy(
saleId SMALLINT PRIMARY KEY,
rfqNo INT
);

/*procedure for rfqcopy*/




