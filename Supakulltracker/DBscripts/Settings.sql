--------------------------------------------------------
--  File created - четверг-но€бр€-19-2015   
--------------------------------------------------------
DROP TABLE "TEMPLATE" cascade constraints;
DROP TABLE "MAPPING" cascade constraints;
DROP TABLE "SERVICE_ACCOUNT" cascade constraints;
DROP TABLE "TOKEN" cascade constraints;
DROP TABLE "TOKENS_IN_ACCOUNT" cascade constraints;
DROP TABLE "USER_LINK" cascade constraints;
--------------------------------------------------------
--  DDL for Table TEMPLATE
--------------------------------------------------------

  CREATE TABLE "TEMPLATE" 
   (	"TEMPLATE_ID" NUMBER, 
	"TEMPLATE_NAME" VARCHAR2(50 BYTE), 
	"SERVICE_ID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table MAPPING
--------------------------------------------------------

  CREATE TABLE "MAPPING" 
   (	"TEMPLATE_ID" NUMBER, 
	"FIELD_NAME_APP" VARCHAR2(50 BYTE), 
	"FIELD_NAME_SOURCE" VARCHAR2(50 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table SERVICE_ACCOUNT
--------------------------------------------------------

  CREATE TABLE "SERVICE_ACCOUNT" 
   (	"SERVICE_ID" NUMBER, 
	"ACCOUNT_NAME" VARCHAR2(50 BYTE), 
	"SOURCE_ID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table TOKEN
--------------------------------------------------------

  CREATE TABLE "TOKEN" 
   (	"TOKEN_ID" NUMBER, 
	"KEY" VARCHAR2(50 BYTE), 
	"VALUE" VARCHAR2(3000 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table TOKENS_IN_ACCOUNT
--------------------------------------------------------

  CREATE TABLE "TOKENS_IN_ACCOUNT" 
   (	"ACCOUNT_ID" NUMBER, 
	"TOKEN_ID" NUMBER, 
	"TOKEN_NAME" VARCHAR2(50 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table USER_LINK
--------------------------------------------------------

  CREATE TABLE "USER_LINK" 
   (	"LINK_ID" NUMBER, 
	"USER_ID" NUMBER, 
	"SERVICE_ACCOUNT_ID" NUMBER, 
	"OWNER" NUMBER(1,0), 
	"USER_OWNER_ID" NUMBER
   ) ;
REM INSERTING into TEMPLATE
SET DEFINE OFF;
REM INSERTING into MAPPING
SET DEFINE OFF;
REM INSERTING into SERVICE_ACCOUNT
SET DEFINE OFF;
Insert into SERVICE_ACCOUNT (SERVICE_ID,ACCOUNT_NAME,SOURCE_ID) values ('271','Real Working Account','0');
Insert into SERVICE_ACCOUNT (SERVICE_ID,ACCOUNT_NAME,SOURCE_ID) values ('182','New Account for test','0');
Insert into SERVICE_ACCOUNT (SERVICE_ID,ACCOUNT_NAME,SOURCE_ID) values ('150','Oracle account','0');
REM INSERTING into TOKEN
SET DEFINE OFF;
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('185','UserName','sdf');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('185','Password','sdf');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('185','Mapping','dfxgvbhrtfhrth');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('185','DataSource','dfg');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('185','DatabaseDriver','OracleClientDriver');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('185','DatabaseDialect','Oracle8iDialect');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('185','ConnectionString','User ID = ''sdf''; Password = sdf; Data Source = dfg');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('183','UserName','sdffsd');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('183','Password','dfgdf');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('183','Mapping','dfgdfgdfgdfg');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('183','DataSource','dfgdfg');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('183','DatabaseDriver','OracleClientDriver');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('183','DatabaseDialect','Oracle9iDialect');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('183','ConnectionString','User ID = ''sdffsd''; Password = dfgdf; Data Source = dfgdfg');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('184','UserName','fgn');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('184','Password','fgnf');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('184','Mapping','fgmnm');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('184','DataSource','fn');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('184','DatabaseDriver','SqlClientDriver');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('184','DatabaseDialect','Oracle9iDialect');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('184','ConnectionString','User ID = ''fgn''; Password = fgnf; Data Source = fn');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('151','UserName','fgh');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('151','Password','fgh');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('151','Mapping','sdfsdfsdf');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('151','DataSource','gh');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('151','DatabaseDriver','OracleClientDriver');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('151','DatabaseDialect','Oracle9iDialect');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('151','ConnectionString','User ID = ''fgh''; Password = fgh; Data Source = gh');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('164','UserName','sdf');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('164','Password','dfgdf');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('164','Mapping','<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" assembly="SupakullTrackerServices" namespace="SupakullTrackerServices">
  <class name="TaskMainDAO" table="TASKMAIN">
    <id name="ID" type="Int32" column="TK_ID" >
      <generator class="sequence">
        <param name="sequence">taskmain_seq</param>
      </generator>
    </id>
    <property name="TaskID" column="TK_TASKID" />
    <property name="SubtaskType" column="TK_SUB_TYPE" />
    <property name="Summary" column="TK_SUMMARY"  />
    <property name="Description" column="TK_DESCRIPTION" />
    <property name="Status" column="TK_STATUS" />
    <property name="Product" column="TK_PRODUCT" />
    <property name="Project" column="TK_PROJECT" />
    <property name="Priority" column="TK_PRIORITY"/>
    <property name="CreatedDate" column="TK_CR_DATE" />
    <property name="CreatedBy" column="TK_CR_BY" />
    <property name="LinkToTracker" column="TK_LINK_TO_TRACKER" />
    <property name="Estimation" column="TK_ESTIMATION" />
    <property name="TargetVersion" column="TK_TARG_VERSION" />
    <property name="Comments" column="TK_COMENTS" />
    <bag cascade="all-delete-orphan" inverse="false" name="Assigned" table="TASKMAIN_TO_USER">
      <key column="TKU_TK_ID" />
      <many-to-many class="UserDAO" column="TKU_US_ID"/>
    </bag>
    <many-to-one cascade="all-delete-orphan" name ="TaskParent" class="TaskMainDAO" column="TK_PARENT" />
    <bag cascade="all-delete-orphan" inverse="false" name="MatchedTasks" table="MATCHEDTASKS">
      <key column="MTK_TASKMAINID" />
      <many-to-many class="TaskMainDAO" column="MTK_MATCHEDTASKID"/>
    </bag>
    <bag cascade="all-delete-orphan" inverse="false" name="Disagreements" table="DISAGREEMENT">
      <key column="DA_TK_ID" />
      <one-to-many class="DisagreementDAO" />
    </bag>
  </class>
</hibernate-mapping>');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('164','DataSource','dsfg');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('164','DatabaseDriver','SqlClientDriver');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('164','DatabaseDialect','Oracle8iDialect');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('164','ConnectionString','User ID = ''sdf''; Password = dfgdf; Data Source = dsfg');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('356','UserName','Dofer');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('356','Password','199110204');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('356','Mapping','<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" assembly="SupakullTrackerServices" namespace="SupakullTrackerServices">
  <class name="DBTask" table="ISSUE_V">
    <id name="TaskID" column="AA_ID" generator="assigned" />
    <property name="Summary" column="ISS_SUMMARY"  />
    <property name="SubtaskType" column="ISS_TYPE" />
    <property name="Status" column="ISS_STATUS" />
    <property name="Priority" column="ISS_PRIORITY" />
  </class>
</hibernate-mapping>');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('356','DataSource','localhost');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('356','DatabaseDriver','OracleClientDriver');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('356','DatabaseDialect','Oracle10gDialect');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('356','ConnectionString','User ID = ''Dofer''; Password = 199110204; Data Source = localhost');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('272','UserName','Dofer');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('272','Password','199110204');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('272','Mapping','<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" assembly="SupakullTrackerServices" namespace="SupakullTrackerServices">
  <class name="DBTask" table="ISSUE_V">
    <id name="TaskID" column="AA_UF_ID" generator="assigned" />
    <property name="Summary" column="ISS_SUMMARY"  />
    <property name="SubtaskType" column="ISS_TYPE" />
    <property name="Status" column="ISS_STATUS" />
    <property name="Priority" column="ISS_PRIORITY" />
  </class>
</hibernate-mapping>');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('272','DataSource','localhost');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('272','DatabaseDriver','OracleClientDriver');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('272','DatabaseDialect','Oracle10gDialect');
Insert into TOKEN (TOKEN_ID,KEY,VALUE) values ('272','ConnectionString','User ID = ''Dofer''; Password = 199110204; Data Source = localhost');
REM INSERTING into TOKENS_IN_ACCOUNT
SET DEFINE OFF;
Insert into TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('182','185','dfgdgn');
Insert into TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('182','183','dfgdfg');
Insert into TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('182','184','fdn');
Insert into TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('271','272','Test DataBase');
Insert into TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('271','356','SecondTest DB Token');
Insert into TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('150','151','Oracle DB');
Insert into TOKENS_IN_ACCOUNT (ACCOUNT_ID,TOKEN_ID,TOKEN_NAME) values ('150','164','sgsdhd');
REM INSERTING into USER_LINK
SET DEFINE OFF;
Insert into USER_LINK (LINK_ID,USER_ID,SERVICE_ACCOUNT_ID,OWNER,USER_OWNER_ID) values ('270','1','271','1','0');
Insert into USER_LINK (LINK_ID,USER_ID,SERVICE_ACCOUNT_ID,OWNER,USER_OWNER_ID) values ('181','1','182','0','0');
Insert into USER_LINK (LINK_ID,USER_ID,SERVICE_ACCOUNT_ID,OWNER,USER_OWNER_ID) values ('149','1','150','1','0');
--------------------------------------------------------
--  DDL for Index TEMPLATE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TEMPLATE_PK" ON "TEMPLATE" ("TEMPLATE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index MAPPING_PK
--------------------------------------------------------


--------------------------------------------------------

  CREATE UNIQUE INDEX "SERVICE_ACCOUNT_PK" ON "SERVICE_ACCOUNT" ("SERVICE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index TOKENS_IN_ACCOUNT_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TOKENS_IN_ACCOUNT_PK" ON "TOKENS_IN_ACCOUNT" ("TOKEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index USER_LINK_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "USER_LINK_PK" ON "USER_LINK" ("LINK_ID") 
  ;
--------------------------------------------------------
--  Constraints for Table TEMPLATE
--------------------------------------------------------

  ALTER TABLE "TEMPLATE" ADD CONSTRAINT "TEMPLATE_PK" PRIMARY KEY ("TEMPLATE_ID") ENABLE;
  ALTER TABLE "TEMPLATE" MODIFY ("TEMPLATE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table MAPPING
--------------------------------------------------------

  ALTER TABLE "MAPPING" ADD CONSTRAINT "MAPPING_PK" PRIMARY KEY ("AA_ID") ENABLE;
  ALTER TABLE "MAPPING" MODIFY ("AA_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SERVICE_ACCOUNT
--------------------------------------------------------

  ALTER TABLE "SERVICE_ACCOUNT" ADD CONSTRAINT "SERVICE_ACCOUNT_PK" PRIMARY KEY ("SERVICE_ID") ENABLE;
  ALTER TABLE "SERVICE_ACCOUNT" MODIFY ("SOURCE_ID" NOT NULL ENABLE);
  ALTER TABLE "SERVICE_ACCOUNT" MODIFY ("ACCOUNT_NAME" NOT NULL ENABLE);
  ALTER TABLE "SERVICE_ACCOUNT" MODIFY ("SERVICE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TOKENS_IN_ACCOUNT
--------------------------------------------------------

  ALTER TABLE "TOKENS_IN_ACCOUNT" MODIFY ("TOKEN_ID" NOT NULL ENABLE);
  ALTER TABLE "TOKENS_IN_ACCOUNT" ADD CONSTRAINT "TOKENS_IN_ACCOUNT_PK" PRIMARY KEY ("TOKEN_ID") ENABLE;
  ALTER TABLE "TOKENS_IN_ACCOUNT" MODIFY ("TOKEN_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table USER_LINK
--------------------------------------------------------

  ALTER TABLE "USER_LINK" MODIFY ("USER_ID" NOT NULL ENABLE);
  ALTER TABLE "USER_LINK" ADD CONSTRAINT "USER_LINK_PK" PRIMARY KEY ("LINK_ID") ENABLE;
  ALTER TABLE "USER_LINK" MODIFY ("LINK_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table TEMPLATE
--------------------------------------------------------

  ALTER TABLE "TEMPLATE" ADD CONSTRAINT "TEMPLATE_FK1" FOREIGN KEY ("SERVICE_ID")
	  REFERENCES "SERVICE_ACCOUNT" ("SERVICE_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table MAPPING
--------------------------------------------------------

  ALTER TABLE "MAPPING" ADD CONSTRAINT "MAPPING_FK1" FOREIGN KEY ("TEMPLATE_ID")
	  REFERENCES "TEMPLATE" ("TEMPLATE_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TOKEN
--------------------------------------------------------

  ALTER TABLE "TOKEN" ADD CONSTRAINT "TOKEN_FK1" FOREIGN KEY ("TOKEN_ID")
	  REFERENCES "TOKENS_IN_ACCOUNT" ("TOKEN_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table TOKENS_IN_ACCOUNT
--------------------------------------------------------

  ALTER TABLE "TOKENS_IN_ACCOUNT" ADD CONSTRAINT "TOKENS_IN_ACCOUNT_FK1" FOREIGN KEY ("ACCOUNT_ID")
	  REFERENCES "SERVICE_ACCOUNT" ("SERVICE_ID") DISABLE;
--------------------------------------------------------
--  Ref Constraints for Table USER_LINK
--------------------------------------------------------

  ALTER TABLE "USER_LINK" ADD CONSTRAINT "USER_LINK_FK2" FOREIGN KEY ("SERVICE_ACCOUNT_ID")
	  REFERENCES "SERVICE_ACCOUNT" ("SERVICE_ID") ENABLE;
