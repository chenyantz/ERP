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
priority TINYINT, /*0:cost down, 1:shortage, 2:history*/
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
firstPA SMALLINT,`rfq`
secondPA SMALLINT,
rfqStates TINYINT, /*0 new : 1,Route 2,Quote 3, closed 4, has SO, 5 SO Approved*/
infoToCustomer MEDIUMTEXT,
infoToInternal MEDIUMTEXT,
routingHistory MEDIUMTEXT,
closeReason TINYINT  /*0 Price to high;1 L/T too long; 2 D/C too old; 3 Packing issue; 4 Demand gone; 5 Others*/
);


SELECT * FROM rfq

CREATE TABLE rfqCopy(
salesId SMALLINT PRIMARY KEY,
rfqNo INT
);

/*procedure for rfqcopy*/




