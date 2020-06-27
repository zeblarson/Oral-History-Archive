USE MASTER;
GO

IF Exists(select * from sys.databases where name ='OralHistories'
DROP DATABASE OralHistories;
GO

CREATE DATABASE OralHistories;
GO

USE OralHistories;
GO

BEGIN TRANSACTION;

CREATE TABLE interview_descriptions (
interview_id INT IDENTITY PRIMARY KEY,
title nvarchar(100) NOT NULL,
interviewer_name nvarchar(50) NOT NULL,
interviewee_name nvarchar(50) NOT NULL,
date_conducted DateTime NOT NULL,
transcript_available int NOT NULL,
summary nvarchar(255) NOT NULL,
CONSTRAINT transcript_available CHECK ((transcript_available = 0) OR (transcript_available = 1)),
);

CREATE TABLE interview_metadata (
id INT IDENTITY PRIMARY KEY,
recording_format NVARCHAR (50) NOT NULL,
file_size decimal NOT NULL,
codec NVARCHAR (10) NOT NULL,
interview_length TIME NOT NULL,
FOREIGN KEY (id) REFERENCES interview_descriptions (interview_id),
);

CREATE TABLE administrative_metadata (
id INT IDENTITY PRIMARY KEY,
interview_owner NVARCHAR (100) NOT NULL,
permission_obtained INT NOT NULL,
copyright_restrictions NVARCHAR (255) NOT NULL,
FOREIGN KEY (id) REFERENCES interview_descriptions (interview_id),
CONSTRAINT permission_obtained CHECK ((permission_obtained = 0) OR (permission_obtained = 1)),
);

CREATE TABLE user_downloads (
download INT IDENTITY PRIMARY KEY,
interview_id INT NOT NULL,
date_downloaded DATETIME NOT NULL,
FOREIGN KEY (interview_id) REFERENCES interview_descriptions (interview_id),
);

SET IDENTITY_INSERT interview_descriptions ON;

INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (1, 'David Wiley and Chris Root Interview', 'Zeb Larson', 'Chris Root, David Wiley', '2016-08-28', 1, 'This interview covers both of their activities in Michigan and the anti-apartheid movement.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (2, 'John Lind Interview', 'Zeb Larson', 'John Lind', '2016-10-06', 1, 'This interview covers the formation of CANICCOR and the role of Lind in South African banking negotiations.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (3, 'Alex Bagwell Interview', 'Zeb Larson', 'Alex Bagwell', '2016-10-06', 1, 'This interview discusses the anti-apartheid movement in the Bay Area with a focus on ILWU 10.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (4, 'Maddy Oden Interview', 'Zeb Larson', 'Maddy Oden', '2016-10-06', 0, 'This interview discusses the anti-apartheid movement in the Bay Area with a focus on public sector unions.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (5, 'Seidman Family Interview', 'Zeb Larson', 'Zeph Makgetla, Judy Seidman, and Neva Seidman', '2017-06-04', 0, 'This interview discusses activities of the family.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (6, 'Friends of SOMAFCO Interview', 'Zeb Larson', 'Friends of SOMAFCO', '2017-07-11', 0, 'This interview discusses the activities of Philadelphia-based Friends of SOMAFCO.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (7, 'Peggy Helen Johnson Interview', 'Zeb Larson', 'Peggy Helen Johnson', '2017-07-22', 0, 'This interview discusses the anti-apartheid movement in Portland, Maine.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (8, 'Gay Seidman Interview', 'Zeb Larson', 'Gay Seidman', '2017-12-27', 0, 'Interview with Gay Seidman about her scholarship and some of my research activities.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (9, 'Meg Skinner Interview', 'Zeb Larson', 'Meg Skinner', '2016-08-11', 0, 'Interview with Meg Skinner about her work in MACSA.');
INSERT INTO interview_descriptions (interview_id, title, interviewer_name, interviewee_name, date_conducted, transcript_available, summary) VALUES (10, 'Gail Austin', 'Zeb Larson', 'Gail Austin', '2020-01-24', 0, 'Interview with Gail Austin about Pittsburghers Against Apartheid.');

INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 39.90, 'M4A', '01:26:42');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 19.70, 'M4A', '00:42:55');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 133, 'M4A', '01:23:45');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 20.5, 'M4A', '00:44:45');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 68.4, 'M4A', '02:27:53');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 25.2, 'M4A', '00:54:42');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 55, 'M4A', '01:58:52');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 123, 'M4A', '01:15:11');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 14.3, 'MP3', '01:01:59');
INSERT INTO interview_metadata (recording_format, file_size, codec, interview_length) VALUES ('audio', 42.1, 'M4A', '01:31:43');

INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');
INSERT INTO administrative_metadata (interview_owner, permission_obtained, copyright_restrictions) VALUES ('Zeb Larson', 0, 'None');

COMMIT TRANSACTION;