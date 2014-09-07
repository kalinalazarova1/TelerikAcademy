DROP TABLE IF EXISTS "books";
CREATE TABLE "books" ("BookId" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , "Title" VARCHAR NOT NULL , "Author" VARCHAR NOT NULL , "PublishDate" DATETIME NOT NULL , "ISBN" VARCHAR NOT NULL );
INSERT INTO "books" VALUES(1,'The One Plus One','Jojo Moyes','2014-07-31 00:00:00','9781405909051');
INSERT INTO "books" VALUES(2,'Police: A Harry Hole Thriller (Oslo Sequence 8)','Jo Nesbo','2014-08-14 00:00:00','9780099570097');
INSERT INTO "books" VALUES(3,'The Fault in Our Stars','John Green','2013-01-03 00:00:00','9780141345659');
INSERT INTO "books" VALUES(4,'Bones of the Lost: (Temperance Brennan 16)','Kathy Reichs','2014-07-31 00:00:00','9780099558057');
INSERT INTO "books" VALUES(5,'The Goldfinch','Donna Tartt','2014-06-05 00:00:00','9780349139630');
