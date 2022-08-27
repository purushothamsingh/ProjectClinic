create database Clinic
use clinic

CREATE TABLE USERMANAGEMENT(
USERNAME VARCHAR(10) PRIMARY KEY,
FIRSTNAME VARCHAR(20) NOT NULL,
LASTNAME VARCHAR(20) NOT NULL,
USER_PASSWORD VARCHAR(20) NOT NULL
);
---SELECT * FROM USERMANAGEMENT;
INSERT INTO USERMANAGEMENT VALUES('USER01','RAJ','KUMAR','CHECK@01');
INSERT INTO USERMANAGEMENT VALUES('USER02','KIRAN','SHA','CHECK@02');

select * from USERMANAGEMENT where USERNAME = 'USER01' AND USER_PASSWORD = 'CHECK@01';
go
create table DoctorDetails(
	docID int primary key,
	firstname varchar(20) not null,
	lastname varchar(20) not null,
	gender varchar(10) not null,
	specialization varchar(40) not null,
	shfrom time(0) not null,
	shto time(0) not null
	);

insert into DoctorDetails values(101,'raj','sham','Male','General Medicine','09:00:00','12:00:00');
insert into DoctorDetails values(102,'janu','kiran','Female','General Medicine','13:00:00','16:00:00');
insert into DoctorDetails values(103,'lakshmi','bai','Female','Internal Medicine','10:00:00','12:00:00');
insert into DoctorDetails values(104,'mohan','rao','Others','Internal Medicine','14:00:00','16:00:00');
insert into DoctorDetails values(105,'mani','karna','male','orthopedics','08:00:00','10:00:00');

select firstname from DoctorDetails where docID = 101;

select * from DoctorDetails where specialization = 'General Medicine';
go

create table patientInfo(
	patientID int identity(10001,1) primary key,
	FNAME varchar(30) not null,
	LNAME varchar(30) not null,
    SEX varchar(30) not null,
	AGE int not null,
	DOB date not null
	);
select * from patientInfo;

select * from  patientInfo where patientID = 10002;

create table ScheduleAppointment(
	patientID int not null ,
	doctorID int not null,
	doctorName varchar(30) not null,
	phoneNumber varchar(30) not null unique,
	appointmentdate date not null,
	appointmenttime time not null,
	foreign key(patientID) references patientInfo(patientID),
	foreign key(doctorID) references DoctorDetails(docID)
	);
insert into ScheduleAppointment values(
'10001','120','Kiran','6305417391','2022/08/27','11:00'),
('10002','103','Kiran','6305417394','2022/08/28','11:00');

select * from ScheduleAppointment where doctorID = 101 or appointmentdate = '';
delete from ScheduleAppointment where patientID = 10001 and appointmentdate ='2022/08/27'  and appointmenttime = '10:00';
select * from ScheduleAppointment;
drop table ScheduleAppointment;


create table cancelAppointment(
patientid int not null,
appointmentdate date not null,
foreign key(patientid) references patientInfo(patientID),
);




