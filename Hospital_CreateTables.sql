USE db_hospital;
CREATE TABLE PATIENT(
ID INT IDENTITY(1,1),
FIRSTNAME VARCHAR(15),
LASTNAME VARCHAR(15),
INSURANCENO INT,
PHONENUMBER CHAR(10),
ADDRESS_ VARCHAR(20)
PRIMARY KEY (ID))

CREATE TABLE DOCTOR(
ID INT IDENTITY(1,1),
FIRSTNAME VARCHAR(15),
LASTNAME VARCHAR(15),

PHONENUMBER CHAR(10),
ADDRESS_ VARCHAR(20)
PRIMARY KEY (ID))

CREATE TABLE APPOINTMENT(
ID INT IDENTITY(1,1),
DATETIME_ DATE,
DOCTORID INT,
PATIENTID INT
PRIMARY KEY (ID))