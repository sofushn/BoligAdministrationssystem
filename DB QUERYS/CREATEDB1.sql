CREATE TABLE Lejligheder
(
	Lejlighed_No NVARCHAR(20) NOT NULL PRIMARY KEY, 
    Adresse NVARCHAR(50) NOT NULL, 
    Rum_Antal INT NOT NULL, 
    Stoerelse DECIMAL NOT NULL, 
    Maandelig_Leje DECIMAL NOT NULL,
);

CREATE TABLE Andelshaver
(
	Andelshaver_ID INT NOT NULL PRIMARY KEY,
	Navn NVARCHAR(50) NOT NULL,
	EMail NVARCHAR(50) NOT NULL,
	Mobil_Nummer NVARCHAR(12) NOT NULL,
);

CREATE TABLE Kontrakter
(
	Kontrakt_ID INT NOT NULL,
	Andelshaver_ID INT NOT NULL,
	Lejlighed_No NVARCHAR(20) NOT NULL,
	Start_Dato DATE NOT NULL,
	Slut_Dato DATE NULL,

	FOREIGN KEY (Lejlighed_No) REFERENCES Lejligheder(Lejlighed_No),
	FOREIGN KEY (Andelshaver_ID) REFERENCES Andelshaver(Andelshaver_ID),
	CONSTRAINT UIQ_SD_NULL UNIQUE (Lejlighed_No, Slut_Dato),
	PRIMARY KEY (Andelshaver_ID, Lejlighed_No, Kontrakt_ID)
);

CREATE TABLE Faldstammer
(
	Faldstamme_ID INT NOT NULL,
	Del_ID INT NOT NULL,
	Lejlighed_No NVARCHAR(20) NOT NULL,
	[Status] NVARCHAR(10) NOT NULL,

	FOREIGN KEY (Lejlighed_No) REFERENCES Lejligheder(Lejlighed_No),
	PRIMARY KEY (Faldstamme_ID, DEL_ID)
);

CREATE TABLE Status_Indberetninger
(
	[Status_ID] INT NOT NULL PRIMARY KEY,
	Sender INT NOT NULL,
	[Status] NVARCHAR(10) NOT NULL,
	Dato DATETIME NOT NULL,
	Note NVARCHAR NULL,

	FOREIGN KEY (Sender) REFERENCES Andelshaver(Andelshaver_ID)
);

CREATE TABLE Users
(
	Username NVARCHAR(20) NOT NULL PRIMARY KEY,
	[Password] NVARCHAR(30) NOT NULL,
	Account_Level NVARCHAR(1) NOT NULL,

	CONSTRAINT chkAccount_Level CHECK (Account_Level IN('A','M','U'))
);