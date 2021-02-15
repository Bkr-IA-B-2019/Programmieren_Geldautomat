CREATE TABLE "Accounts" (
	"id"	INTEGER NOT NULL,
	"createdatetime"	BLOB NOT NULL,
	"firstname"	TEXT NOT NULL,
	"lastname"	TEXT NOT NULL,
	"money"	NUMERIC NOT NULL,
	"pinhash"	TEXT NOT NULL,
	"pinsalt" TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE TABLE "Transactions" (
	"id"	INTEGER NOT NULL,
	"translatedmoney"	NUMERIC NOT NULL,
	"subtracted"	BLOB NOT NULL,
	"accountid"	INTEGER NOT NULL,
	"datetime"	BLOB,
	PRIMARY KEY("id" AUTOINCREMENT)
);
