--------------------------------------------------------
--  File created - �������-��������-25-2015   
--------------------------------------------------------
DROP TABLE "DOFER"."ISSUE" cascade constraints;
DROP TABLE "DOFER"."ISSUE_TO_USERS" cascade constraints;
DROP TABLE "DOFER"."USERS_LIST" cascade constraints;
--------------------------------------------------------
--  DDL for Table ISSUE
--------------------------------------------------------

  CREATE TABLE "DOFER"."ISSUE" 
   (	"IS_ID" VARCHAR2(20 BYTE), 
	"IS_SUMMARY" VARCHAR2(200 BYTE), 
	"IS_DESCRIPTION" VARCHAR2(1000 BYTE), 
	"IS_SUB_TYPE" VARCHAR2(30 BYTE), 
	"IS_STATUS" VARCHAR2(30 BYTE), 
	"IS_PRIORITY" VARCHAR2(30 BYTE), 
	"PRODUCT" VARCHAR2(30 BYTE), 
	"PROJECT" VARCHAR2(30 BYTE), 
	"IS_CR_DATE" VARCHAR2(30 BYTE), 
	"IS_CR_BY" VARCHAR2(40 BYTE), 
	"IS_LINK_TO_TRACKER" VARCHAR2(30 BYTE), 
	"IS_TARG_VERSION" VARCHAR2(30 BYTE), 
	"IS_ESTIMATION" VARCHAR2(30 BYTE), 
	"IS_COMENTS" VARCHAR2(2000 BYTE), 
	"IS_PARENT" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table ISSUE_TO_USERS
--------------------------------------------------------

  CREATE TABLE "DOFER"."ISSUE_TO_USERS" 
   (	"IS_ID" VARCHAR2(20 BYTE), 
	"US_ID" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table USERS_LIST
--------------------------------------------------------

  CREATE TABLE "DOFER"."USERS_LIST" 
   (	"USERS_ID" VARCHAR2(20 BYTE), 
	"USER_NAME" VARCHAR2(30 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into DOFER.ISSUE
SET DEFINE OFF;
Insert into DOFER.ISSUE (IS_ID,IS_SUMMARY,IS_DESCRIPTION,IS_SUB_TYPE,IS_STATUS,IS_PRIORITY,PRODUCT,PROJECT,IS_CR_DATE,IS_CR_BY,IS_LINK_TO_TRACKER,IS_TARG_VERSION,IS_ESTIMATION,IS_COMENTS,IS_PARENT) values ('1','xzc','sdv','zczv','sdvsdv','svsdv',null,'sdvsdv','sdvsdv','sddvsdv','sdvcsdv','sdvsv','sdv','adsfdf',null);
Insert into DOFER.ISSUE (IS_ID,IS_SUMMARY,IS_DESCRIPTION,IS_SUB_TYPE,IS_STATUS,IS_PRIORITY,PRODUCT,PROJECT,IS_CR_DATE,IS_CR_BY,IS_LINK_TO_TRACKER,IS_TARG_VERSION,IS_ESTIMATION,IS_COMENTS,IS_PARENT) values ('2','adsc','hdgsvc','hdvh','shvyhdshg','udhvsyusdhv','uhdvuhdsv','udhvuysdhv','hdvhsdvh','hdvhhshv','hduvhshv','hdhvudshv','duhvush','ssduhvushv','1');
REM INSERTING into DOFER.ISSUE_TO_USERS
SET DEFINE OFF;
Insert into DOFER.ISSUE_TO_USERS (IS_ID,US_ID) values ('1','2');
Insert into DOFER.ISSUE_TO_USERS (IS_ID,US_ID) values ('2','1');
REM INSERTING into DOFER.USERS_LIST
SET DEFINE OFF;
Insert into DOFER.USERS_LIST (USERS_ID,USER_NAME) values ('1','hsbvh');
Insert into DOFER.USERS_LIST (USERS_ID,USER_NAME) values ('2','sgnjsf');
--------------------------------------------------------
--  DDL for Index ISSUE_GLOBAL_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "DOFER"."ISSUE_GLOBAL_PK" ON "DOFER"."ISSUE" ("IS_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index USERS_LIST_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "DOFER"."USERS_LIST_PK" ON "DOFER"."USERS_LIST" ("USERS_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index USERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "DOFER"."USERS_PK" ON "DOFER"."USERS_PERSONAL_DATA" ("USER_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table ISSUE
--------------------------------------------------------

  ALTER TABLE "DOFER"."ISSUE" ADD CONSTRAINT "ISSUE_GLOBAL_PK" PRIMARY KEY ("IS_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "DOFER"."ISSUE" MODIFY ("IS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ISSUE_TO_USERS
--------------------------------------------------------

  ALTER TABLE "DOFER"."ISSUE_TO_USERS" MODIFY ("US_ID" NOT NULL ENABLE);
  ALTER TABLE "DOFER"."ISSUE_TO_USERS" MODIFY ("IS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USERS_LIST
--------------------------------------------------------

  ALTER TABLE "DOFER"."USERS_LIST" MODIFY ("USERS_ID" NOT NULL ENABLE);
  ALTER TABLE "DOFER"."USERS_LIST" ADD CONSTRAINT "USERS_LIST_PK" PRIMARY KEY ("USERS_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ISSUE_TO_USERS
--------------------------------------------------------

  ALTER TABLE "DOFER"."ISSUE_TO_USERS" ADD CONSTRAINT "ISSUE_TO_USERS_FK1" FOREIGN KEY ("IS_ID")
	  REFERENCES "DOFER"."ISSUE" ("IS_ID") ENABLE;
  ALTER TABLE "DOFER"."ISSUE_TO_USERS" ADD CONSTRAINT "ISSUE_TO_USERS_FK2" FOREIGN KEY ("US_ID")
	  REFERENCES "DOFER"."USERS_LIST" ("USERS_ID") ENABLE;
