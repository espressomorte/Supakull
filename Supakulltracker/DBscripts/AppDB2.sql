DROP TABLE "TASKMAIN" cascade constraints;
DROP sequence taskmain_seq;
DROP TABLE "MATCHEDTASKS" cascade constraints;
DROP TABLE "TASKMAIN_TO_USER" cascade constraints;
DROP TABLE "USER" cascade constraints;
DROP TABLE "USER_FOR_AUTHENTIFICATION" cascade constraints;


CREATE TABLE "TASKMAIN"
(
  "TK_ID" number,
  "TK_TASKID" VARCHAR2(20 BYTE),
	"TK_SUMMARY" VARCHAR2(1000 BYTE), 
	"TK_DESCRIPTION" VARCHAR2(1000 BYTE), 
	"TK_SUB_TYPE" VARCHAR2(30 BYTE), 
	"TK_STATUS" VARCHAR2(30 BYTE), 
	"TK_PRIORITY" VARCHAR2(30 BYTE), 
	"TK_PRODUCT" VARCHAR2(30 BYTE), 
	"TK_PROJECT" VARCHAR2(30 BYTE), 
	"TK_CR_DATE" VARCHAR2(30 BYTE), 
	"TK_CR_BY" VARCHAR2(40 BYTE), 
	"TK_LINK_TO_TRACKER" VARCHAR2(30 BYTE), 
	"TK_TARG_VERSION" VARCHAR2(30 BYTE), 
	"TK_ESTIMATION" VARCHAR2(30 BYTE), 
	"TK_COMENTS" VARCHAR2(2000 BYTE), 
	"TK_PARENT" VARCHAR2(20 BYTE)
);
create sequence taskmain_seq;
ALTER TABLE "TASKMAIN" MODIFY ("TK_ID" NOT NULL ENABLE);
ALTER TABLE "TASKMAIN" ADD CONSTRAINT "TASKMAIN_PK" PRIMARY KEY ("TK_ID");
CREATE UNIQUE INDEX "TASKMAIN_INDEX_ID_TRACKER" ON "TASKMAIN" ("TK_TASKID", "TK_LINK_TO_TRACKER");


CREATE TABLE "MATCHEDTASKS" 
(
  "MTK_TASKMAINID" number, 
	"MTK_MATCHEDTASKID" number
);
ALTER TABLE "MATCHEDTASKS" MODIFY ("MTK_TASKMAINID" NOT NULL ENABLE);
ALTER TABLE "MATCHEDTASKS" MODIFY ("MTK_MATCHEDTASKID" NOT NULL ENABLE);
ALTER TABLE "MATCHEDTASKS" ADD CONSTRAINT "MATCHEDTASKS_FK1" FOREIGN KEY ("MTK_TASKMAINID")
	  REFERENCES "TASKMAIN" ("TK_ID") ENABLE;
   
   
CREATE TABLE "USER" 
(
  "US_ID" VARCHAR2(20 BYTE), 
	"US_NAME" VARCHAR2(30 BYTE)
);
ALTER TABLE "USER" MODIFY ("US_ID" NOT NULL ENABLE);
ALTER TABLE "USER" ADD CONSTRAINT "USER_PK" PRIMARY KEY ("US_ID");
INSERT INTO "USER" (US_ID,US_NAME) values ('user1','user name 1');
INSERT INTO "USER" (US_ID,US_NAME) values ('user2','user name 2');


CREATE TABLE "TASKMAIN_TO_USER" 
(
  "TKU_TK_ID" number, 
	"TKU_US_ID" VARCHAR2(20 BYTE)
);
ALTER TABLE "TASKMAIN_TO_USER" MODIFY ("TKU_TK_ID" NOT NULL ENABLE);
ALTER TABLE "TASKMAIN_TO_USER" MODIFY ("TKU_US_ID" NOT NULL ENABLE);
ALTER TABLE "TASKMAIN_TO_USER" ADD CONSTRAINT "TASKMAIN_TO_USER_FK1" FOREIGN KEY ("TKU_TK_ID")
	  REFERENCES "TASKMAIN" ("TK_ID") ENABLE;
ALTER TABLE "TASKMAIN_TO_USER" ADD CONSTRAINT "TASKMAIN_TO_USER_FK2" FOREIGN KEY ("TKU_US_ID")
	  REFERENCES "USER" ("US_ID") ENABLE;

  
CREATE TABLE "USER_FOR_AUTHENTIFICATION" 
(
  "US_ID" NUMBER, 
  "US_LOGIN" VARCHAR2(100 BYTE),
  "US_PINCODE" VARCHAR2(100 BYTE)
);
ALTER TABLE "USER_FOR_AUTHENTIFICATION" MODIFY ("US_ID" NOT NULL ENABLE);
ALTER TABLE "USER_FOR_AUTHENTIFICATION" ADD CONSTRAINT "USER_FOR_AUTHENTIFICATION_PK" PRIMARY KEY ("US_ID");
INSERT INTO "USER_FOR_AUTHENTIFICATION" (US_ID, US_LOGIN) VALUES (1, 'supakull');
INSERT INTO "USER_FOR_AUTHENTIFICATION" (US_ID, US_LOGIN) VALUES (2, 'user1');

commit;