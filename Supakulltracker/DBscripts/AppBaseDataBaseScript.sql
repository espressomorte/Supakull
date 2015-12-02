DROP TABLE "PlaceHolderForSchemaName"."DISAGREEMENT" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."MAPPING" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."MATCHEDTASKS" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."SOURCES" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."TASKMAIN" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."TASKMAIN_TO_USER" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."TEMPLATE" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."TOKEN" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."USER" cascade constraints;
DROP TABLE "PlaceHolderForSchemaName"."USER_LINK" cascade constraints;
DROP SEQUENCE "PlaceHolderForSchemaName"."TASKMAIN_SEQ";
DROP SEQUENCE "PlaceHolderForSchemaName"."SERVICE_ID_SEQ";
DROP SEQUENCE "PlaceHolderForSchemaName"."TEMPLATE_ID_SEQ";
DROP SEQUENCE "PlaceHolderForSchemaName"."TOKEN_ID_SEQ";
DROP SEQUENCE "PlaceHolderForSchemaName"."US_ID_SEQ";
DROP SEQUENCE "PlaceHolderForSchemaName"."LINK_ID_SEQ";
--------------------------------------------------------
--  DDL for Sequence TASKMAIN_SEQ
--------------------------------------------------------
                                                                   
   CREATE SEQUENCE  "PlaceHolderForSchemaName"."TASKMAIN_SEQ"  MINVALUE 1 MAXVALUE 2147483646 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
   CREATE SEQUENCE  "PlaceHolderForSchemaName"."SERVICE_ID_SEQ"  MINVALUE 1 MAXVALUE 2147483646 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
   CREATE SEQUENCE  "PlaceHolderForSchemaName"."TEMPLATE_ID_SEQ"  MINVALUE 1 MAXVALUE 2147483646 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
   CREATE SEQUENCE  "PlaceHolderForSchemaName"."TOKEN_ID_SEQ"  MINVALUE 1 MAXVALUE 2147483646 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
   CREATE SEQUENCE  "PlaceHolderForSchemaName"."US_ID_SEQ"  MINVALUE 1 MAXVALUE 2147483646 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
   CREATE SEQUENCE  "PlaceHolderForSchemaName"."LINK_ID_SEQ"  MINVALUE 1 MAXVALUE 2147483646 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table DISAGREEMENT
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."DISAGREEMENT" 
   (	"DA_TK_ID" NUMBER, 
	"DA_FIELDNAME" VARCHAR2(20 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table MAPPING
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."MAPPING" 
   (	"TEMPLATE_ID" NUMBER, 
	"FIELD_NAME_APP" VARCHAR2(50 BYTE), 
	"FIELD_NAME_SOURCE" VARCHAR2(50 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table MATCHEDTASKS
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."MATCHEDTASKS" 
   (	"MTK_TASKMAINID" NUMBER, 
	"MTK_MATCHEDTASKID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table SERVICE_ACCOUNT
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" 
   (	"SERVICE_ID" NUMBER, 
	"ACCOUNT_NAME" VARCHAR2(50 BYTE), 
	"SOURCE_ID" NUMBER, 
	"MIN_UPDATE_TIME" NUMBER NOT NULL, 
	"ACCOUNT_VERSION" NUMBER NOT NULL
   ) ;
--------------------------------------------------------
--  DDL for Table SOURCES
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."SOURCES" 
   (	"SOURCE_ID" NUMBER, 
	"SOURCE_NAME" VARCHAR2(50 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table TASKMAIN
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."TASKMAIN" 
   (	"TK_ID" NUMBER, 
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
	"TK_PARENT" VARCHAR2(20 BYTE), 
	"TK_TOKEN_ID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table TASKMAIN_TO_USER
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."TASKMAIN_TO_USER" 
   (	"TKU_TK_ID" NUMBER, 
	"TKU_US_ID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table TEMPLATE
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."TEMPLATE" 
   (	"TEMPLATE_ID" NUMBER, 
	"TEMPLATE_NAME" VARCHAR2(50 BYTE), 
	"SERVICE_ID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table TOKEN
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."TOKEN" 
   (	"TOKEN_ID" NUMBER, 
	"KEY" VARCHAR2(50 BYTE), 
	"VALUE" VARCHAR2(3000 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table TOKENS_IN_ACCOUNT
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" 
   (	"ACCOUNT_ID" NUMBER, 
	"TOKEN_ID" NUMBER, 
	"TOKEN_NAME" VARCHAR2(50 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table USER
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."USER" 
   (	"US_ID" NUMBER, 
	"US_USERID" VARCHAR2(20 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table USER_LINK
--------------------------------------------------------

  CREATE TABLE "PlaceHolderForSchemaName"."USER_LINK" 
   (	"LINK_ID" NUMBER, 
	"USER_ID" NUMBER, 
	"SERVICE_ACCOUNT_ID" NUMBER, 
	"OWNER" NUMBER(1,0), 
	"USER_OWNER_ID" NUMBER
   ) ;
REM INSERTING into PlaceHolderForSchemaName.DISAGREEMENT
SET DEFINE OFF;
REM INSERTING into PlaceHolderForSchemaName.MAPPING
SET DEFINE OFF;
REM INSERTING into PlaceHolderForSchemaName.MATCHEDTASKS
SET DEFINE OFF;
REM INSERTING into PlaceHolderForSchemaName.SERVICE_ACCOUNT
SET DEFINE OFF;
Insert into PlaceHolderForSchemaName.SERVICE_ACCOUNT (SERVICE_ID,ACCOUNT_NAME,SOURCE_ID,MIN_UPDATE_TIME,ACCOUNT_VERSION) values ('271','Real Working Account','0','5',null);
REM INSERTING into PlaceHolderForSchemaName.SOURCES
SET DEFINE OFF;
Insert into PlaceHolderForSchemaName.SOURCES (SOURCE_ID,SOURCE_NAME) values ('0','DataBase');
Insert into PlaceHolderForSchemaName.SOURCES (SOURCE_ID,SOURCE_NAME) values ('1','Trello');
Insert into PlaceHolderForSchemaName.SOURCES (SOURCE_ID,SOURCE_NAME) values ('2','Excel');
Insert into PlaceHolderForSchemaName.SOURCES (SOURCE_ID,SOURCE_NAME) values ('3','GoogleSheets');
REM INSERTING into PlaceHolderForSchemaName.TASKMAIN
SET DEFINE OFF;
REM INSERTING into PlaceHolderForSchemaName.TASKMAIN_TO_USER
SET DEFINE OFF;
REM INSERTING into PlaceHolderForSchemaName.TEMPLATE
SET DEFINE OFF;
REM INSERTING into PlaceHolderForSchemaName.TOKEN
SET DEFINE OFF;
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('272','UserName','Dofer');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('272','Password','199110204');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('272','Mapping','<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" assembly="SupakullTrackerServices" namespace="SupakullTrackerServices">
  <class name="DBTask" table="ISSUE_V">
    <id name="TaskID" column="AA_UF_ID" generator="assigned" />
    <property name="Summary" column="ISS_SUMMARY"  />
    <property name="SubtaskType" column="ISS_TYPE" />
    <property name="Status" column="ISS_STATUS" />
    <property name="Priority" column="ISS_PRIORITY" />
  </class>
</hibernate-mapping>');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('272','DataSource','localhost');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('272','DatabaseDriver','OracleClientDriver');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('272','DatabaseDialect','Oracle10gDialect');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('272','ConnectionString','User ID = ''Dofer''; Password = 199110204; Data Source = localhost');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('356','UserName','Dofer');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('356','Password','199110204');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('356','Mapping','<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" assembly="SupakullTrackerServices" namespace="SupakullTrackerServices">
  <class name="DBTask" table="ISSUE_V">
    <id name="TaskID" column="AA_ID" generator="assigned" />
    <property name="Summary" column="ISS_SUMMARY"  />
    <property name="SubtaskType" column="ISS_TYPE" />
    <property name="Status" column="ISS_STATUS" />
    <property name="Priority" column="ISS_PRIORITY" />
  </class>
</hibernate-mapping>');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('356','DataSource','localhost');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('356','DatabaseDriver','OracleClientDriver');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('356','DatabaseDialect','Oracle10gDialect');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('356','ConnectionString','User ID = ''Dofer''; Password = 199110204; Data Source = localhost');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('161','UserName','Dofer');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('161','Password','199110204');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('161','Mapping','<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" assembly="SupakullTrackerServices" namespace="SupakullTrackerServices">
  <class name="DBTask" table="ISSUE_V">
    <id name="TaskID" column="AA_UF_ID" generator="assigned" />
    <property name="Summary" column="ISS_SUMMARY"  />
    <property name="SubtaskType" column="ISS_TYPE" />
    <property name="Status" column="ISS_STATUS" />
    <property name="Priority" column="ISS_PRIORITY" />
  </class>
</hibernate-mapping>');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('161','DataSource','localhost');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('161','DatabaseDriver','OracleClientDriver');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('161','DatabaseDialect','Oracle10gDialect');
Insert into PlaceHolderForSchemaName.TOKEN (TOKEN_ID,KEY,VALUE) values ('161','ConnectionString','User ID = ''Dofer''; Password = 199110204; Data Source = localhost');
REM INSERTING into PlaceHolderForSchemaName.TOKENS_IN_ACCOUNT
SET DEFINE OFF;
Insert into PlaceHolderForSchemaName.TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('271','272','Test DataBase');
Insert into PlaceHolderForSchemaName.TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('271','356','SecondTest DB Token');
Insert into PlaceHolderForSchemaName.TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('271','161','Test');
REM INSERTING into PlaceHolderForSchemaName."USER"
SET DEFINE OFF;
Insert into PlaceHolderForSchemaName."USER" (US_ID,US_USERID) values ('1','supakull');
REM INSERTING into PlaceHolderForSchemaName.USER_LINK
SET DEFINE OFF;
Insert into PlaceHolderForSchemaName.USER_LINK (LINK_ID,USER_ID,SERVICE_ACCOUNT_ID,OWNER,USER_OWNER_ID) values ('270','1','271','1','0');
Insert into PlaceHolderForSchemaName.SERVICE_ACCOUNT (SERVICE_ID,ACCOUNT_NAME,SOURCE_ID,MIN_UPDATE_TIME,ACCOUNT_VERSION) values ('271','Real Working Account','0','5',1);
--------------------------------------------------------
--  DDL for Index US_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."US_PK" ON "PlaceHolderForSchemaName"."USER" ("US_ID") 
  ;
--------------------------------------------------------
--  DDL for Index TASKMAIN_INDEX_ID_TRACKER
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."TASKMAIN_INDEX_ID_TRACKER" ON "PlaceHolderForSchemaName"."TASKMAIN" ("TK_TASKID", "TK_LINK_TO_TRACKER") 
  ;
--------------------------------------------------------
--  DDL for Index USER_LINK_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."USER_LINK_PK" ON "PlaceHolderForSchemaName"."USER_LINK" ("LINK_ID") 
  ;
--------------------------------------------------------
--  DDL for Index TEMPLATE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."TEMPLATE_PK" ON "PlaceHolderForSchemaName"."TEMPLATE" ("TEMPLATE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index SOURCES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."SOURCES_PK" ON "PlaceHolderForSchemaName"."SOURCES" ("SOURCE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index TASKMAIN_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."TASKMAIN_PK" ON "PlaceHolderForSchemaName"."TASKMAIN" ("TK_ID") 
  ;
--------------------------------------------------------
--  DDL for Index USER_INDEX
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."USER_INDEX" ON "PlaceHolderForSchemaName"."USER" ("US_USERID") 
  ;
--------------------------------------------------------
--  DDL for Index TOKENS_IN_ACCOUNT_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT_PK" ON "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" ("TOKEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index SERVICE_ACCOUNT_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PlaceHolderForSchemaName"."SERVICE_ACCOUNT_PK" ON "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" ("SERVICE_ID") 
  ;
--------------------------------------------------------
--  Constraints for Table USER
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."USER" ADD CONSTRAINT "US_PK" PRIMARY KEY ("US_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."USER" MODIFY ("US_USERID" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."USER" MODIFY ("US_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USER_LINK
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."USER_LINK" MODIFY ("USER_ID" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."USER_LINK" ADD CONSTRAINT "USER_LINK_PK" PRIMARY KEY ("LINK_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."USER_LINK" MODIFY ("LINK_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TASKMAIN_TO_USER
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TASKMAIN_TO_USER" MODIFY ("TKU_US_ID" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."TASKMAIN_TO_USER" MODIFY ("TKU_TK_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table MATCHEDTASKS
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."MATCHEDTASKS" MODIFY ("MTK_MATCHEDTASKID" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."MATCHEDTASKS" MODIFY ("MTK_TASKMAINID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TOKENS_IN_ACCOUNT
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" MODIFY ("TOKEN_ID" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" ADD CONSTRAINT "TOKENS_IN_ACCOUNT_PK" PRIMARY KEY ("TOKEN_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" MODIFY ("TOKEN_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SERVICE_ACCOUNT
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" ADD CONSTRAINT "SERVICE_ACCOUNT_PK" PRIMARY KEY ("SERVICE_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" MODIFY ("SOURCE_ID" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" MODIFY ("ACCOUNT_NAME" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" MODIFY ("SERVICE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SOURCES
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."SOURCES" ADD CONSTRAINT "SOURCES_PK" PRIMARY KEY ("SOURCE_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."SOURCES" MODIFY ("SOURCE_NAME" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."SOURCES" MODIFY ("SOURCE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table DISAGREEMENT
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."DISAGREEMENT" MODIFY ("DA_FIELDNAME" NOT NULL ENABLE);
  ALTER TABLE "PlaceHolderForSchemaName"."DISAGREEMENT" MODIFY ("DA_TK_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TASKMAIN
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TASKMAIN" ADD CONSTRAINT "TASKMAIN_PK" PRIMARY KEY ("TK_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."TASKMAIN" MODIFY ("TK_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TEMPLATE
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TEMPLATE" ADD CONSTRAINT "TEMPLATE_PK" PRIMARY KEY ("TEMPLATE_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."TEMPLATE" MODIFY ("TEMPLATE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table MAPPING
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."MAPPING" ADD CONSTRAINT "MAPPING_FK1" FOREIGN KEY ("TEMPLATE_ID")
	  REFERENCES "PlaceHolderForSchemaName"."TEMPLATE" ("TEMPLATE_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table MATCHEDTASKS
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."MATCHEDTASKS" ADD CONSTRAINT "MATCHEDTASKS_FK1" FOREIGN KEY ("MTK_TASKMAINID")
	  REFERENCES "PlaceHolderForSchemaName"."TASKMAIN" ("TK_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TASKMAIN_TO_USER
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TASKMAIN_TO_USER" ADD CONSTRAINT "TASKMAIN_TO_USER_FK1" FOREIGN KEY ("TKU_TK_ID")
	  REFERENCES "PlaceHolderForSchemaName"."TASKMAIN" ("TK_ID") ENABLE;
  ALTER TABLE "PlaceHolderForSchemaName"."TASKMAIN_TO_USER" ADD CONSTRAINT "TASKMAIN_TO_USER_FK2" FOREIGN KEY ("TKU_US_ID")
	  REFERENCES "PlaceHolderForSchemaName"."USER" ("US_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TEMPLATE
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TEMPLATE" ADD CONSTRAINT "TEMPLATE_FK1" FOREIGN KEY ("SERVICE_ID")
	  REFERENCES "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" ("SERVICE_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TOKEN
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TOKEN" ADD CONSTRAINT "TOKEN_FK1" FOREIGN KEY ("TOKEN_ID")
	  REFERENCES "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" ("TOKEN_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TOKENS_IN_ACCOUNT
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."TOKENS_IN_ACCOUNT" ADD CONSTRAINT "TOKENS_IN_ACCOUNT_FK1" FOREIGN KEY ("ACCOUNT_ID")
	  REFERENCES "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" ("SERVICE_ID") DISABLE;
--------------------------------------------------------
--  Ref Constraints for Table USER_LINK
--------------------------------------------------------

  ALTER TABLE "PlaceHolderForSchemaName"."USER_LINK" ADD CONSTRAINT "USER_LINK_FK2" FOREIGN KEY ("SERVICE_ACCOUNT_ID")
	  REFERENCES "PlaceHolderForSchemaName"."SERVICE_ACCOUNT" ("SERVICE_ID") ENABLE;
Commit;
