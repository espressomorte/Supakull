create table users (
  USER_ID number,
  USER_LOGIN varchar2(20),
  USER_PINCODE varchar2(20),
  constraint users_pk primary key (USER_ID)  
);



SET DEFINE OFF

INSERT INTO USERS (USER_ID, USER_LOGIN, USER_PINCODE) 
VALUES (1, 'supakull', '');

INSERT INTO USERS (USER_ID, USER_LOGIN, USER_PINCODE) 
VALUES (2, 'user1', '1234');

commit;