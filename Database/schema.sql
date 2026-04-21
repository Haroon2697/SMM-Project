-- ============================================================
--  FAST Societies Management System  –  SQL Server Schema
--  Target: (localdb)\MSSQLLocalDB   DB: SocietiesMS
-- ============================================================

USE master;
GO

IF DB_ID('SocietiesMS') IS NOT NULL
BEGIN
    ALTER DATABASE SocietiesMS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SocietiesMS;
END
GO

CREATE DATABASE SocietiesMS;
GO

USE SocietiesMS;
GO

-- ============================================================
-- 1. USERS
-- ============================================================
CREATE TABLE Users (
    UserID      INT IDENTITY(1,1) PRIMARY KEY,
    FullName    NVARCHAR(100)  NOT NULL,
    Email       NVARCHAR(150)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,          -- SHA-256 hex
    Role        NVARCHAR(20)   NOT NULL            -- 'Student','SocietyHead','Admin'
        CHECK (Role IN ('Student','SocietyHead','Admin')),
    IsActive    BIT            NOT NULL DEFAULT 1,
    CreatedAt   DATETIME       NOT NULL DEFAULT GETDATE()
);

-- ============================================================
-- 2. SOCIETIES
-- ============================================================
CREATE TABLE Societies (
    SocietyID   INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(500),
    HeadUserID  INT           REFERENCES Users(UserID) ON DELETE SET NULL,
    Status      NVARCHAR(20)  NOT NULL DEFAULT 'Pending'
        CHECK (Status IN ('Pending','Active','Suspended','Deleted')),
    LogoPath    NVARCHAR(300),
    CreatedAt   DATETIME      NOT NULL DEFAULT GETDATE()
);

-- ============================================================
-- 3. SOCIETY MEMBERS
-- ============================================================
CREATE TABLE SocietyMembers (
    MemberID    INT IDENTITY(1,1) PRIMARY KEY,
    SocietyID   INT NOT NULL REFERENCES Societies(SocietyID) ON DELETE CASCADE,
    UserID      INT NOT NULL REFERENCES Users(UserID)        ON DELETE CASCADE,
    Role        NVARCHAR(30) NOT NULL DEFAULT 'Member'
        CHECK (Role IN ('Head','Member','Volunteer')),
    Status      NVARCHAR(20) NOT NULL DEFAULT 'Pending'
        CHECK (Status IN ('Pending','Approved','Rejected')),
    JoinedAt    DATETIME     NOT NULL DEFAULT GETDATE(),
    CONSTRAINT UQ_SocietyMember UNIQUE (SocietyID, UserID)
);

-- ============================================================
-- 4. EVENTS
-- ============================================================
CREATE TABLE Events (
    EventID        INT IDENTITY(1,1) PRIMARY KEY,
    SocietyID      INT           NOT NULL REFERENCES Societies(SocietyID) ON DELETE CASCADE,
    Title          NVARCHAR(150) NOT NULL,
    Description    NVARCHAR(1000),
    EventDate      DATETIME      NOT NULL,
    Venue          NVARCHAR(200),
    MaxCapacity    INT           NOT NULL DEFAULT 100,
    ApprovalStatus NVARCHAR(20)  NOT NULL DEFAULT 'Pending'
        CHECK (ApprovalStatus IN ('Pending','Approved','Rejected','Cancelled')),
    CreatedAt      DATETIME      NOT NULL DEFAULT GETDATE()
);

-- ============================================================
-- 5. EVENT REGISTRATIONS  (Student tickets)
-- ============================================================
CREATE TABLE EventRegistrations (
    RegistrationID INT IDENTITY(1,1) PRIMARY KEY,
    EventID        INT  NOT NULL REFERENCES Events(EventID)  ON DELETE CASCADE,
    UserID         INT  NOT NULL REFERENCES Users(UserID)    ON DELETE CASCADE,
    RegisteredAt   DATETIME NOT NULL DEFAULT GETDATE(),
    TicketCode     NVARCHAR(20) NOT NULL UNIQUE,
    CONSTRAINT UQ_EventUser UNIQUE (EventID, UserID)
);

-- ============================================================
-- 6. TASKS
-- ============================================================
CREATE TABLE Tasks (
    TaskID        INT IDENTITY(1,1) PRIMARY KEY,
    SocietyID     INT           NOT NULL REFERENCES Societies(SocietyID) ON DELETE CASCADE,
    AssignedTo    INT           NOT NULL REFERENCES Users(UserID),
    AssignedBy    INT           NOT NULL REFERENCES Users(UserID),
    Title         NVARCHAR(200) NOT NULL,
    Description   NVARCHAR(1000),
    DueDate       DATETIME,
    Status        NVARCHAR(20)  NOT NULL DEFAULT 'Pending'
        CHECK (Status IN ('Pending','InProgress','Completed','Cancelled')),
    CreatedAt     DATETIME      NOT NULL DEFAULT GETDATE()
);

-- ============================================================
-- 7. ANNOUNCEMENTS
-- ============================================================
CREATE TABLE Announcements (
    AnnouncementID INT IDENTITY(1,1) PRIMARY KEY,
    SocietyID      INT           REFERENCES Societies(SocietyID) ON DELETE CASCADE, -- NULL = global
    PostedBy       INT           NOT NULL REFERENCES Users(UserID),
    Title          NVARCHAR(200) NOT NULL,
    Body           NVARCHAR(2000),
    PostedAt       DATETIME      NOT NULL DEFAULT GETDATE()
);

-- ============================================================
-- SEED DATA
-- ============================================================

-- Admin account  (password: Admin@123  → SHA-256)
INSERT INTO Users (FullName, Email, PasswordHash, Role)
VALUES
('System Admin',      'admin@fast.edu',    'e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7', 'Admin'),
('Ali Hassan',        'ali@fast.edu',      'e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7', 'SocietyHead'),
('Sara Khan',         'sara@fast.edu',     'e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7', 'Student'),
('Usman Tariq',       'usman@fast.edu',    'e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7', 'Student'),
('Fatima Noor',       'fatima@fast.edu',   'e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7', 'SocietyHead');

-- Societies (HeadUserID 2 = Ali, 5 = Fatima)
INSERT INTO Societies (Name, Description, HeadUserID, Status)
VALUES
('Gaming Society',    'For gamers and e-sports enthusiasts',      2, 'Active'),
('Developers Club',   'Coding, hackathons, and tech workshops',   5, 'Active'),
('Sports Society',    'Cricket, football, and athletics',         NULL, 'Pending'),
('Literary Society',  'Debates, poetry, and creative writing',    NULL, 'Active'),
('Media Society',     'Photography, journalism, and media arts',  NULL, 'Active');

-- Society members
INSERT INTO SocietyMembers (SocietyID, UserID, Role, Status)
VALUES
(1, 2, 'Head',    'Approved'),   -- Ali heads Gaming
(2, 5, 'Head',    'Approved'),   -- Fatima heads Dev Club
(1, 3, 'Member',  'Pending'),    -- Sara applied to Gaming
(2, 4, 'Member',  'Approved');   -- Usman in Dev Club

-- Events
INSERT INTO Events (SocietyID, Title, Description, EventDate, Venue, MaxCapacity, ApprovalStatus)
VALUES
(1, 'LAN Gaming Night',     'Annual LAN party with prizes',       '2026-05-15 18:00', 'CC Auditorium',  80, 'Approved'),
(2, 'Hackathon 2026',       '24-hour coding competition',          '2026-05-22 09:00', 'CS Block Lab 1', 60, 'Pending'),
(4, 'Urdu Debate Night',    'National-level debate competition',   '2026-06-01 17:00', 'Main Hall',     120, 'Approved');

-- Announcements
INSERT INTO Announcements (SocietyID, PostedBy, Title, Body)
VALUES
(NULL, 1, 'Welcome to Semester 2026!', 'All societies are now active. Apply for membership through the portal.'),
(1,    2, 'Gaming Night Registrations Open', 'Register before May 10 to secure your spot!'),
(2,    5, 'Hackathon Team Formation', 'Form teams of 3. Deadline: May 18.');

GO
-- ============================================================
-- Useful views for reporting
-- ============================================================

CREATE VIEW vw_SocietyMemberCount AS
SELECT s.SocietyID, s.Name, COUNT(sm.MemberID) AS TotalMembers
FROM Societies s
LEFT JOIN SocietyMembers sm ON s.SocietyID = sm.SocietyID AND sm.Status = 'Approved'
GROUP BY s.SocietyID, s.Name;
GO

CREATE VIEW vw_EventRegistrationCount AS
SELECT e.EventID, e.Title, s.Name AS SocietyName,
       COUNT(er.RegistrationID) AS Registrations, e.MaxCapacity
FROM Events e
JOIN Societies s ON e.SocietyID = s.SocietyID
LEFT JOIN EventRegistrations er ON e.EventID = er.EventID
GROUP BY e.EventID, e.Title, s.Name, e.MaxCapacity;
GO
