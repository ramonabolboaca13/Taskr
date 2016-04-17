/*
	Name: Tables Creation
	For:  Taskr
	Date: 2016-03-23
	By:   Kovacs Gyorgy
	
	Notes: La mine baza de date se numea `test`, deci daca
	la tine difera numele, nu uita sa il schimbi.
*/

-- Seamana foarte mult cu users, oare nu le unim?
-- Si secretara poate sa plece, poate ar trebui sa pun
-- si DateLeft etc... cum spui tu.
CREATE TABLE `test`.`secretary` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`FirstName` TEXT NOT NULL,
	`LastName` TEXT NOT NULL,
	`DisplayName` TEXT NOT NULL,
	`AvatarLink` TEXT NOT NULL, 
	`Email` TEXT NOT NULL,
	`PasswordHash` TEXT NOT NULL,
	`PhoneNumber` TEXT NOT NULL,
	`JoinDate` DATE NOT NULL,
	`Status` TEXT NOT NULL,
	`PersonalNotes` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

-- Am unit former users cu users, ca nu difera prea mult
CREATE TABLE `test`.`users` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`FirstName` TEXT NOT NULL,
	`LastName` TEXT NOT NULL,
	`DisplayName` TEXT NOT NULL,
	`AvatarLink` TEXT NOT NULL,
	`Email` TEXT NOT NULL,
	`PasswordHash` TEXT NOT NULL,
	`PhoneNumber` TEXT NOT NULL,
	`JoinDate` DATE NOT NULL,
	`AddedBy` INT NOT NULL,
	`ActiveProject` INT NULL,
	`ActiveTask` INT NULL,
	`WorkStatus` TEXT NOT NULL,
	`PersonalNotes` TEXT NULL,
	`LeaveDate` DATE NULL,
	`ReasonForLeaving` TEXT NULL,
	`RejoinDesirability` TEXT NULL,
	`Observations` TEXT NULL,
	PRIMARY KEY (`Id`)
);

CREATE TABLE `test`.`projectSuggestions` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Title` TEXT NOT NULL,
	`ShortDescription` TEXT NOT NULL,
	`DetailedDescription` TEXT NULL,	
	`CreatedBy` INT NOT NULL,
	`DateCreated` DATE NOT NULL,
	`InvestmentRequired` TEXT NOT NULL,
	`EstimatedReturn` TEXT NOT NULL,
	`Priority` TEXT NOT NULL,
	`Notes` TEXT NULL,
	PRIMARY KEY (`Id`)
);

-- Am unit asta cu archived projects
CREATE TABLE `test`.`projects` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Title` TEXT NOT NULL,
	`ShortDescription` TEXT NOT NULL,
	`DetailedDescription` TEXT NULL,
	`CreatedBy` INT NOT NULL,
	`ProjectLead` INT NOT NULL,
	`DateCreated` DATE NOT NULL,
	`ModificationLogLink` TEXT NOT NULL,
	`Notes` TEXT NULL,
	`AvailableFunds` TEXT NULL,
	`CurrentYield` TEXT NULL,
	`DateTerminated` DATE NULL,
	`TerminationReason` TEXT NULL,
	`TerminatedBy` INT NULL,
	`CollectedFunds` TEXT NULL,
	`ConsumedFunds` TEXT NULL,
	PRIMARY KEY (`Id`)
);

CREATE TABLE `test`.`tasks` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`ParentId` INT NULL,
	`Title` TEXT NOT NULL,
	`ShortDescription` TEXT NOT NULL,
	`DetailedDescription` TEXT NULL,
	`ParentProject` INT NOT NULL,
	`DateCreated` DATE NOT NULL,
	`CreatedBy` INT NOT NULL,
	`DateCompleted` DATE NULL,
	`CompletedBy` INT NULL,
	`DeadLine` DATE NULL,
	`Status` TEXT NULL,
	PRIMARY KEY (`Id`)
);

-- These two tables will store the requests from users to join a project
-- or accept a task.
CREATE TABLE `test`.`projectrequests` (
  `user_id` INT NOT NULL,
  `project_id` INT NOT NULL
);

CREATE TABLE `test`.`taskrequests` (
  `user_id` INT NOT NULL,
  `task_id` INT NOT NULL
);

/*
	Name: Tables Population
	For:  Taskr
	Date: 2016-03-23 ---> 2016-03-25
	By:   Bolboaca Ramona
	
*/

-- Am adaugat useri care participa la proiecte
-- Am adaugat useri care nu participe la proiecte (au projectid = 0)
-- Am adaugat ex emplpoyees

-- Am mai facut ceva update-uri deci am pus si codul de update, logic
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('1', 'Ardeleanu', 'Mircea', 'Mircea', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'ardeleanu.mircea@gmail.com', 'passwordmircea1', '0745692145', '03/05/15', '1', '1', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('2', 'Badea', 'Nicolae', 'Nicu', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'badea.nicolae@gmail.com', 'passwordnicolae2', '0741258745', '02/07/14', '1', '2', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('3', 'Baltag ', 'Octavian', 'Tavi', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'baltag.octavian@gmail.com', 'passwordoctavion3', '0741857457', '04/09/13', '1', '1', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('4', 'Coanda', 'George', 'George', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'coandageorge@gmail.com', 'passwordgeorge4', '0748978521', '02/08/15', '2', '1', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('5', 'Darie', 'Emanuel', 'Manu', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'darie.emanuel@gmail.com', 'passwordemanuel5', '0741288793', '02/09/14', '2', '2', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('6', 'Enache', 'Sorin', 'Soso', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'enache.sorin@gmail.com', 'passwordsorin6', '0721473698', '18/03/16', '3', '3', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('7', 'Gheorghe ', 'Daniel', 'Dani', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'gheorghe.daniel@gmail.com', 'passworddaniel7', '0723698741', '25/07/13', '1', '1', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('8', 'Jurca', 'Traian', 'Traian', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'jurca.traian@gmail.com', 'passwordtraian8', '0752142365', '18/09/15', '2', '3', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('9', 'Lascu', 'Dan', 'Dan', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'lascu.dan@gmail.com', 'passworddan9', '0721212585', '13/05/15', '2', '3', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('10', 'Lunca', 'Eduard', 'Edi', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'lunca.eduard@gmail.com', 'passwordlunca10', '0758787414', '12/04/14', '2', '3', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('11', 'Morariu', 'Simona', 'Simona', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'morariu.simona@gmail.com', 'passwordsimona11', '0758463881', '12/05/11', '2', '1', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('12', 'Munteanu', 'Teodora', 'Teo', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'munteanu.teodora@gmail.com', 'passwordteodora12', '0723469712', '23/04/13', '3', '5', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('13', 'Oltean', 'Maria', 'Maria', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'oltean.maria@gmail.com', 'passwordmaria13', '0721469734', '28/07/15', '4', '6', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('14', 'Pop', 'Dorina', 'Dorina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'pop.dorina@gmail.com', 'passworddorina14', '0745312711', '23/07/14', '1', '5', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('15', 'Popa', 'Cristina', 'Cristina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'popa.cristina@gmail.com', 'passwordcristina15', '0754221378', '28/04/15', '2', '6', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('16', 'Popescu ', 'Elena', 'Elena', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'popescu.elena@gmail.com', 'passwordelena16', '0754333121', '02/10/14', '3', '5', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('17', 'Rab', 'Laura', 'Laura', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'rab.laura@gmail.com', 'passwordlaura17', '0724667273', '03/03/15', '4', '4', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('18', 'Salceanu', 'Alexandra', 'Alexandra', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'salceanu.alexandra@gmail.com', 'passwordalexandra18', '0724671131', '04/08/14', '2', '3', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('19', 'Stanescu', 'Ioana', 'Ioana', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'stanesc.ioana@gmail.com', 'passwordioana19', '0753336724', '02/03/16', '2', '3', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('20', 'Ursea', 'Mirela', 'Mirela', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'ursea.mirela@gmail.com', 'passwordmirela20', '0745747641', '04/08/14', '3', '6', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('21', 'Abrudan', 'Emilia', 'Emi', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'abrudan.emilia@gmail.com', 'passwordemilia21', '0725836144', '15-01-21', '2', '0', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('22', 'Morar', 'Elizabeta', 'Liza', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'morar.elizabeta@gmail.com', 'passwordelizabeta22', '0752221436', '14-04-09', '2', '0', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`) VALUES ('23', 'Popescu', 'Andrei', 'Andrei', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'popescu.andrei@gmail.com', 'passwordandrei23', '0752551435', '15-08-08', '3', '0', 'Available');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('24', 'Maris', 'Denisa', 'Deni', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'maris.denisa@gmail.com', 'passworddenisa24', '0725699696', '13-06-11', '4', '0', 'Not Available', '16-03-20', 'Found another job', 'Low', 'Good employee');
INSERT INTO `test`.`users` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `WorkStatus`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('25', 'Oltean', 'Adina', 'Adina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'oltean.adina@gmail.com', 'passwordadina25', '0754412474', '14-05-05', '4', '0', 'Not Available', '16-02-25', 'Found another job', 'Low', 'Smart and good employee');


UPDATE `test`.`users` SET `JoinDate`='2013-05-15' WHERE `Id`='1';
UPDATE `test`.`users` SET `JoinDate`='2012-07-14' WHERE `Id`='2';
UPDATE `test`.`users` SET `JoinDate`='2014-09-13' WHERE `Id`='3';
UPDATE `test`.`users` SET `JoinDate`='2012-08-15' WHERE `Id`='4';
UPDATE `test`.`users` SET `JoinDate`='2012-09-14' WHERE `Id`='5';
UPDATE `test`.`users` SET `JoinDate`='2015-03-16' WHERE `Id`='6';
UPDATE `test`.`users` SET `JoinDate`='2015-07-13' WHERE `Id`='7';
UPDATE `test`.`users` SET `JoinDate`='2014-09-15' WHERE `Id`='8';
UPDATE `test`.`users` SET `JoinDate`='2013-04-13' WHERE `Id`='12';
UPDATE `test`.`users` SET `JoinDate`='2011-07-15' WHERE `Id`='13';
UPDATE `test`.`users` SET `JoinDate`='2013-07-14' WHERE `Id`='14';
UPDATE `test`.`users` SET `JoinDate`='2010-04-15' WHERE `Id`='15';
UPDATE `test`.`users` SET `JoinDate`='2012-10-14' WHERE `Id`='16';
UPDATE `test`.`users` SET `JoinDate`='2013-03-15' WHERE `Id`='17';
UPDATE `test`.`users` SET `JoinDate`='2014-08-14' WHERE `Id`='18';
UPDATE `test`.`users` SET `JoinDate`='2012-03-16' WHERE `Id`='19';
UPDATE `test`.`users` SET `JoinDate`='2014-08-14' WHERE `Id`='20';

-- Am adaugat proiecte active doar, va fi mai usor sa le facem arhivate prin intermediul aplicatiei
-- + Update-uri
INSERT INTO `test`.`projects` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`) VALUES ('1', 'Vehicle Tracking Using Driver Mobile Gps Tracking', 'This system will track location of the vehicle and will send details about the location to the admin. This system helps admin to find out the location of the driver driving the vehicle. Admin will know which driver is in which location. ', 'http://nevonprojects.com/vehicle-tracking-using-driver-mobile-gps-tracking/', '1', '1', '13/05/20', 'what is this?');
INSERT INTO `test`.`projects` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`) VALUES ('2', 'Fingerprint Based ATM System', 'Fingerprint Based ATM is a desktop application where fingerprint of the user is used as a authentication. The finger print minutiae features are different for each human being so the user can be identified uniquely.', 'http://nevonprojects.com/fingerprint-based-atm-system/', '2', '4', '12/08/20', 'what is this?');
INSERT INTO `test`.`projects` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`) VALUES ('3', 'Android Employee Tracker', 'This system is a combination of web as well as android application where the user will be using the android application and admin as well as HR will work with web application. This application is meant for field work Employers.', 'http://nevonprojects.com/android-employee-tracker/', '19', '19', '12-03-20', 'what is this?');
INSERT INTO `test`.`projects` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`) VALUES ('4', 'Sentiment Analysis for Product Rating', 'Here we propose an advanced Sentiment Analysis for Product Rating system that detects hidden sentiments in comments and rates the product accordingly. The system uses sentiment analysis methodology in order to achieve desired functionality.', 'http://nevonprojects.com/sentiment-analysis-for-product-rating/', '17', '17', '14-04-15', 'what is this?');
INSERT INTO `test`.`projects` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`) VALUES ('5', 'Android Customer Relationship Management System', 'Customer relationship management (CRM) is a system for managing a company’s interactions with current and future customers. It often involves using technology to organize, automate, and synchronize sales.', 'http://nevonprojects.com/android-customer-relationship-management-system/', '12', '12', '14-07-13', 'what is this?');
INSERT INTO `test`.`projects` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`) VALUES ('6', 'Real Estate Search Based On Data Mining', 'This project helps the users to make good decisions regarding buying or selling of valuable property. Prior to this online system this process involved a lot of travelling costs and searching time.', 'http://nevonprojects.com/real-estate-search-based-on-data-mining/', '20', '20', '15-08-08', 'what is this?');

UPDATE `test`.`projects` SET `DateCreated`='2015-05-20' WHERE `Id`='1';
UPDATE `test`.`projects` SET `DateCreated`='2015-08-20' WHERE `Id`='2';
UPDATE `test`.`projects` SET `DateCreated`='2016-03-20' WHERE `Id`='3';
UPDATE `test`.`projects` SET `DateCreated`='2015-04-15' WHERE `Id`='4';
UPDATE `test`.`projects` SET `DateCreated`='2015-07-13' WHERE `Id`='5';
UPDATE `test`.`projects` SET `ProjectLead`='2' WHERE `Id`='2';

-- Am adaugat cateva projectsuggestion care au fost create de users
INSERT INTO `test`.`projectsuggestions` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`) VALUES ('1', 'Online Herbs Shopping', 'This project helps the users in curing its disease by giving the list of fruits and herbs that the user should consume in order to get rid of its disease.', 'http://nevonprojects.com/online-herbs-shopping/', '15', '16-03-03', '5000', '7500', '1');
INSERT INTO `test`.`projectsuggestions` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`) VALUES ('2', 'Hotel Management Android Project', 'The regular hotel management system project entirely in an android app. This android application allows the hotel manager to handle all hotel activities in his android phone.', 'http://nevonprojects.com/hotel-management-android/', '21', '16-03-01', '8000', '1000', '1');
INSERT INTO `test`.`projectsuggestions` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`) VALUES ('3', 'Efficient Doctor Patient Portal', 'We here propose a doctor patient handling, managing system that helps doctors in their work and also patients to book doctor appointments and view medical progress. The system allows doctors to manage their booking slots online.', 'http://nevonprojects.com/efficient-doctor-patient-portal/', '22', '16-03-16', '10000', '13000', '1');
INSERT INTO `test`.`projectsuggestions` (`Id`, `Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`) VALUES ('4', 'Android Local Train Ticketing Project', 'A local train ticketing system project for local trains that allows users to book local train tickets and get ticket receipt online. This local train project provides login rights for normal users and admin. ', 'http://nevonprojects.com/android-local-train-ticketing-project/', '23', '16-03-17', '11000', '14000', '1');

-- Am adaugat secretare
INSERT INTO `test`.`secretary` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`) VALUES ('1', 'Pop', 'Diana', 'Diana', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'pop.diana@gmail.com', 'passworddiana1', '0741221148', '12-06-06', 'Available', '-');
INSERT INTO `test`.`secretary` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`) VALUES ('2', 'Mihailescu', 'Irina', 'Irina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'mihailescu.irina@gmail.com', 'passwordirina2', '0723365852', '12-03-04', 'Available', '-');
INSERT INTO `test`.`secretary` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`) VALUES ('3', 'Zelea', 'Ana-Maria', 'Ana-Maria', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'zelea.anamaria@gmail.com', 'passwordanamaria3', '0758885423', '12-05-20', 'Available', '-');
INSERT INTO `test`.`secretary` (`Id`, `FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`) VALUES ('4', 'Tusca', 'Florin', 'Florin', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'tusca.florin@gmail.com', 'passwordflorin4', '0723665478', '11-05-04', 'Available', '-');

-- Am creat cateva taskuri pentru fiecare proiect activ
-- Task-urile au status worked on, available, completed
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('1', 'Login', 'Make the login user interface and the connection to the database', '1', '2015-05-21', '2015-06-03', '11', '15-06-08', 'Completed');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `ActiveUser`, `DateCreated`, `Status`) VALUES ('2', ' Track the user’s location', 'Track the user’s location with the help of GPS and send this detail to admin.', '1', '11', '2015-07-03', 'Worked on');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `Status`) VALUES ('3', 'View the location of the driver', 'Make and graphical interface in order to view the location of the driver driving the vehicle', '1', '2016-02-01', 'Available');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `ActiveUser`, `DateCreated`, `Status`) VALUES ('4', 'Login', 'User will login to the system using his fingerprint.', '2', '2', '2016-01-21', 'Worked on');
UPDATE `test`.`tasks` SET `ActiveUser`='7' WHERE `Id`='2';
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DeadLine`, `Status`) VALUES ('5', 'Add Pin Code', ' User has to scan finger and add pin code in order to do transactions.', '2', '2016-01-22', '2016-04-01', 'Available');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `ActiveUser`, `DateCreated`, `DeadLine`, `Status`) VALUES ('6', 'Withdrawal of cash', 'User can withdraw cash by entering the amount he want to withdraw.', '2', '5', '2016-01-23', '2016-04-01', 'Worked on');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('7', 'Transfer of Money', 'User can transfer cash to other accounts by entering the account number he wants to transfer.', '2', '2016-01-23', '2016-01-29', '5', '2016-02-01', 'Completed');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('8', 'Login', 'Make the login user interface and the connection to the database.', '3', '2016-03-20', '2016-03-25', '6', '2016-04-20', 'Completed');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `ActiveUser`, `DateCreated`, `DeadLine`, `Status`) VALUES ('9', ' Track the user’s location', 'Track the user’s location with the help of GPS and send this detail to admin.', '3', '8', '2016-03-20', '2016-04-20', 'Worked on');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DeadLine`, `Status`) VALUES ('10', 'View the location of the employee', 'Make and graphical interface in order to view the location of the employee.', '3', '2016-03-20', '2016-04-20', 'Available');
UPDATE `test`.`tasks` SET `ShortDescription`='Make and graphical interface in order to view the location of the driver driving the vehicle.' WHERE `Id`='3';
UPDATE `test`.`tasks` SET `ShortDescription`='Make the login user interface and the connection to the database.' WHERE `Id`='1';
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `ActiveUser`, `DateCreated`, `DeadLine`, `Status`) VALUES ('11', 'Create database', ' Create a database of sentiment based keywords along with positivity or negativity weight in database', '4', '17', '2015-08-15', '2016-08-15', 'Worked on');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DeadLine`, `Status`) VALUES ('12', 'Rank user comment', 'Based on the sentiment keywords from the database the user comment needs to be ranked. ', '4', '2016-01-15', '2016-08-15', 'Available');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DeadLine`, `Status`) VALUES ('13', 'Rate the product', 'Rate the product based on the data recieved from the users comments.', '4', '2016-01-15', '2016-08-15', 'Available');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DateCompleted`, `CompletedBy`, `Status`) VALUES ('14', 'Create employee database and add new employees', 'Create the database with the specific tablles and fields. Add new employees by filling employee details and will provide identity number and password to the employee to access the system.', '5', '2015-08-13', '2015-09-13', '12', 'Completed');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DateCompleted`, `CompletedBy`, `Status`) VALUES ('15', 'Login', 'Make the login user interface and the connection to the database.When employee login to the system he will get email about the meetings that is going to be held on next day with the lead.', '5', '2015-09-13', '2015-10-13', '14', 'Completed');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `ActiveUser`, `DateCreated`, `Status`) VALUES ('16', 'Dashboard', 'User will be redirected to dashboard where he will get to know about number of leads he had converted and number of leads he had not converted.User will also get to know about profit and loss amount in the dashboard, based on number of leads he had converted.', '5', '16', '2016-02-13', 'Worked on');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `Status`) VALUES ('17', 'Meetings options', 'Employee can fix meeting with customer by specifying the meeting topic and description about the meeting. User can view meeting that is going to be held. User can also view the topic and description about the meeting. User can send SMS and E-mail to the customers.', '5', '2016-03-13', 'Available');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DateCompleted`, `CompletedBy`, `Status`) VALUES ('18', 'Create the estate database', 'Property details like Address, space measurement(sq ft), number of BHKs, Floor, Property Seller name and its contact number plus email-id. ', '6', '2015-08-10', '2015-09-08', '13', 'Completed');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `DateCreated`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('19', 'Search option', 'The user can search property depending on the area that it wants in, number of wash rooms, bedrooms, halls and kitchen.', '6', '2015-09-08', '2015-11-10', '15', '2015-11-11', 'Completed');
INSERT INTO `test`.`tasks` (`Id`, `Title`, `ShortDescription`, `ParentProject`, `ActiveUser`, `DateCreated`, `DeadLine`, `Status`) VALUES ('20', 'Loan algorithm', 'An algorithm that calculates loan that the user can take plus 20%-30% cash that the user has to pay.', '6', '20', '2016-02-10', '2016-04-28', 'Worked on');



