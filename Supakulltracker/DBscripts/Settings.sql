--------------------------------------------------------
--  File created - среда-окт€бр€-21-2015   
--------------------------------------------------------
DROP TABLE "MAPPING" cascade constraints;
DROP TABLE "SERVICE_ACCOUNT" cascade constraints;
DROP TABLE "SOURCES" cascade constraints;
DROP TABLE "TASKMAIN" cascade constraints;
DROP TABLE "TASKMAIN_TO_USER" cascade constraints;
DROP TABLE "TEMPLATE" cascade constraints;
DROP TABLE "TOKEN" cascade constraints;
DROP TABLE "USER" cascade constraints;
DROP TABLE "USER_FOR_AUTHENTIFICATION" cascade constraints;
DROP TABLE "USER_LINK" cascade constraints;
--------------------------------------------------------
--  DDL for Table MAPPING
--------------------------------------------------------

  CREATE TABLE "MAPPING" 
   (	"AA_ID" NUMBER, 
	"TEMPLATE_ID" NUMBER, 
	"FIELD_NAME_APP" VARCHAR2(50 BYTE), 
	"FIELD_NAME_SOURCE" VARCHAR2(50 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table SERVICE_ACCOUNT
--------------------------------------------------------

  CREATE TABLE "SERVICE_ACCOUNT" 
   (	"SERVICE_ID" NUMBER, 
	"ACCOUNT_NAME" VARCHAR2(50 BYTE), 
	"SOURCE_ID" NUMBER, 
	"TOKEN_ID1" NUMBER, 
	"TOKEN_ID2" NUMBER, 
	"TOKEN_ID3" NUMBER, 
	"TOKEN_ID4" NUMBER, 
	"TOKEN_ID5" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table SOURCES
--------------------------------------------------------

  CREATE TABLE "SOURCES" 
   (	"SOURCE_ID" NUMBER, 
	"SOURCE_NAME" VARCHAR2(50 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table TASKMAIN
--------------------------------------------------------

  CREATE TABLE "TASKMAIN" 
   (	"TK_ID" VARCHAR2(20 BYTE), 
	"TK_SUMMARY" VARCHAR2(500 BYTE), 
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
   ) ;
--------------------------------------------------------
--  DDL for Table TASKMAIN_TO_USER
--------------------------------------------------------

  CREATE TABLE "TASKMAIN_TO_USER" 
   (	"TK_ID" VARCHAR2(20 BYTE), 
	"US_ID" VARCHAR2(20 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table TEMPLATE
--------------------------------------------------------

  CREATE TABLE "TEMPLATE" 
   (	"TEMPLATE_ID" NUMBER, 
	"TEMPLATE_NAME" VARCHAR2(50 BYTE), 
	"SERVICE_ID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table TOKEN
--------------------------------------------------------

  CREATE TABLE "TOKEN" 
   (	"TOKEN_ID" NUMBER, 
	"KYE" VARCHAR2(50 BYTE), 
	"VALUE" VARCHAR2(1500 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table USER
--------------------------------------------------------

  CREATE TABLE "USER" 
   (	"USER_ID" VARCHAR2(20 BYTE), 
	"USER_NAME" VARCHAR2(30 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table USER_FOR_AUTHENTIFICATION
--------------------------------------------------------

  CREATE TABLE "USER_FOR_AUTHENTIFICATION" 
   (	"USER_ID" NUMBER, 
	"USER_LOGIN" VARCHAR2(100 BYTE), 
	"USER_PIN" VARCHAR2(500 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table USER_LINK
--------------------------------------------------------

  CREATE TABLE "USER_LINK" 
   (	"LINK_ID" NUMBER, 
	"USER_ID" NUMBER, 
	"SERVICE_ACCOUNT_ID" NUMBER, 
	"OWNER" NUMBER(1,0)
   ) ;
REM INSERTING into MAPPING
SET DEFINE OFF;
Insert into MAPPING (AA_ID,TEMPLATE_ID,FIELD_NAME_APP,FIELD_NAME_SOURCE) values ('1','1','Name','Name Trello');
Insert into MAPPING (AA_ID,TEMPLATE_ID,FIELD_NAME_APP,FIELD_NAME_SOURCE) values ('2','1','ID','BoarId');
Insert into MAPPING (AA_ID,TEMPLATE_ID,FIELD_NAME_APP,FIELD_NAME_SOURCE) values ('3','2','Name','Name Trello');
Insert into MAPPING (AA_ID,TEMPLATE_ID,FIELD_NAME_APP,FIELD_NAME_SOURCE) values ('4','2','ID','IdTrello');
REM INSERTING into SERVICE_ACCOUNT
SET DEFINE OFF;
Insert into SERVICE_ACCOUNT (SERVICE_ID,ACCOUNT_NAME,SOURCE_ID,TOKEN_ID1,TOKEN_ID2,TOKEN_ID3,TOKEN_ID4,TOKEN_ID5) values ('1','test account','1','10','15',null,null,null);
REM INSERTING into SOURCES
SET DEFINE OFF;
REM INSERTING into TASKMAIN
SET DEFINE OFF;
REM INSERTING into TASKMAIN_TO_USER
SET DEFINE OFF;
REM INSERTING into TEMPLATE
SET DEFINE OFF;
Insert into TEMPLATE (TEMPLATE_ID,TEMPLATE_NAME,SERVICE_ID) values ('1','MyTemplate','1');
Insert into TEMPLATE (TEMPLATE_ID,TEMPLATE_NAME,SERVICE_ID) values ('2','MyAnotherTemplate','1');
REM INSERTING into TOKEN
SET DEFINE OFF;
Insert into TOKEN (TOKEN_ID,KYE,VALUE) values ('10','ConnectionString','asdhfgsdygfy');
Insert into TOKEN (TOKEN_ID,KYE,VALUE) values ('10','Name','newToken');
Insert into TOKEN (TOKEN_ID,KYE,VALUE) values ('15','Name','newToken22');
Insert into TOKEN (TOKEN_ID,KYE,VALUE) values ('15','Date ','21.10.15');
REM INSERTING into "USER"
SET DEFINE OFF;
REM INSERTING into USER_FOR_AUTHENTIFICATION
SET DEFINE OFF;
Insert into USER_FOR_AUTHENTIFICATION (USER_ID,USER_LOGIN,USER_PIN) values ('1','supakull',null);
Insert into USER_FOR_AUTHENTIFICATION (USER_ID,USER_LOGIN,USER_PIN) values ('2','user',null);
REM INSERTING into USER_LINK
SET DEFINE OFF;
Insert into USER_LINK (LINK_ID,USER_ID,SERVICE_ACCOUNT_ID,OWNER) values ('1','1','1','1');
--------------------------------------------------------
--  DDL for Index MAPPING_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "MAPPING_PK" ON "MAPPING" ("AA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index USER_LINK_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "USER_LINK_PK" ON "USER_LINK" ("LINK_ID") 
  ;
--------------------------------------------------------
--  DDL for Index TEMPLATE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TEMPLATE_PK" ON "TEMPLATE" ("TEMPLATE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index SOURCES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SOURCES_PK" ON "SOURCES" ("SOURCE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index ISSUE_GLOBAL_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ISSUE_GLOBAL_PK" ON "TASKMAIN" ("TK_ID") 
  ;
--------------------------------------------------------
--  DDL for Index USER_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "USER_PK" ON "USER" ("USER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_USER_FOR_AUTHENTIFICATION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_USER_FOR_AUTHENTIFICATION" ON "USER_FOR_AUTHENTIFICATION" ("USER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index SERVICE_ACCOUNT_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SERVICE_ACCOUNT_PK" ON "SERVICE_ACCOUNT" ("SERVICE_ID") 
  ;
--------------------------------------------------------
--  Constraints for Table USER_LINK
--------------------------------------------------------

  ALTER TABLE "USER_LINK" MODIFY ("USER_ID" NOT NULL ENABLE);
  ALTER TABLE "USER_LINK" ADD CONSTRAINT "USER_LINK_PK" PRIMARY KEY ("LINK_ID") ENABLE;
  ALTER TABLE "USER_LINK" MODIFY ("LINK_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SOURCES
--------------------------------------------------------

  ALTER TABLE "SOURCES" ADD CONSTRAINT "SOURCES_PK" PRIMARY KEY ("SOURCE_ID") ENABLE;
  ALTER TABLE "SOURCES" MODIFY ("SOURCE_NAME" NOT NULL ENABLE);
  ALTER TABLE "SOURCES" MODIFY ("SOURCE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table MAPPING
--------------------------------------------------------

  ALTER TABLE "MAPPING" ADD CONSTRAINT "MAPPING_PK" PRIMARY KEY ("AA_ID") ENABLE;
  ALTER TABLE "MAPPING" MODIFY ("AA_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TEMPLATE
--------------------------------------------------------

  ALTER TABLE "TEMPLATE" ADD CONSTRAINT "TEMPLATE_PK" PRIMARY KEY ("TEMPLATE_ID") ENABLE;
  ALTER TABLE "TEMPLATE" MODIFY ("TEMPLATE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SERVICE_ACCOUNT
--------------------------------------------------------

  ALTER TABLE "SERVICE_ACCOUNT" ADD CONSTRAINT "SERVICE_ACCOUNT_PK" PRIMARY KEY ("SERVICE_ID") ENABLE;
  ALTER TABLE "SERVICE_ACCOUNT" MODIFY ("SOURCE_ID" NOT NULL ENABLE);
  ALTER TABLE "SERVICE_ACCOUNT" MODIFY ("ACCOUNT_NAME" NOT NULL ENABLE);
  ALTER TABLE "SERVICE_ACCOUNT" MODIFY ("SERVICE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TASKMAIN
--------------------------------------------------------

  ALTER TABLE "TASKMAIN" ADD CONSTRAINT "ISSUE_GLOBAL_PK" PRIMARY KEY ("TK_ID") ENABLE;
  ALTER TABLE "TASKMAIN" MODIFY ("TK_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USER_FOR_AUTHENTIFICATION
--------------------------------------------------------

  ALTER TABLE "USER_FOR_AUTHENTIFICATION" MODIFY ("USER_ID" NOT NULL ENABLE);
  ALTER TABLE "USER_FOR_AUTHENTIFICATION" ADD CONSTRAINT "PK_USER_FOR_AUTHENTIFICATION" PRIMARY KEY ("USER_ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table USER
--------------------------------------------------------

  ALTER TABLE "USER" MODIFY ("USER_ID" NOT NULL ENABLE);
  ALTER TABLE "USER" ADD CONSTRAINT "USER_PK" PRIMARY KEY ("USER_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table MAPPING
--------------------------------------------------------

  ALTER TABLE "MAPPING" ADD CONSTRAINT "MAPPING_FK1" FOREIGN KEY ("TEMPLATE_ID")
	  REFERENCES "TEMPLATE" ("TEMPLATE_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TASKMAIN_TO_USER
--------------------------------------------------------

  ALTER TABLE "TASKMAIN_TO_USER" ADD CONSTRAINT "TASKMAIN_TO_USER_FK1" FOREIGN KEY ("TK_ID")
	  REFERENCES "TASKMAIN" ("TK_ID") ENABLE;
  ALTER TABLE "TASKMAIN_TO_USER" ADD CONSTRAINT "TASKMAIN_TO_USER_FK2" FOREIGN KEY ("US_ID")
	  REFERENCES "USER" ("USER_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TEMPLATE
--------------------------------------------------------

  ALTER TABLE "TEMPLATE" ADD CONSTRAINT "TEMPLATE_FK1" FOREIGN KEY ("SERVICE_ID")
	  REFERENCES "SERVICE_ACCOUNT" ("SERVICE_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table USER_LINK
--------------------------------------------------------

  ALTER TABLE "USER_LINK" ADD CONSTRAINT "USER_LINK_FK1" FOREIGN KEY ("USER_ID")
	  REFERENCES "USER_FOR_AUTHENTIFICATION" ("USER_ID") ENABLE;
  ALTER TABLE "USER_LINK" ADD CONSTRAINT "USER_LINK_FK2" FOREIGN KEY ("SERVICE_ACCOUNT_ID")
	  REFERENCES "SERVICE_ACCOUNT" ("SERVICE_ID") ENABLE;
