USE QuanLyKhachSan;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        user_id INT IDENTITY(1,1) PRIMARY KEY,
        user_code NVARCHAR(10) UNIQUE,
        full_name NVARCHAR(100),
        date_of_birth DATE,
        email NVARCHAR(100) UNIQUE,
        phone NVARCHAR(20),

        role NVARCHAR(20) NOT NULL
            CHECK (role IN ('admin', 'receptionist', 'housekeeping')),

        status NVARCHAR(10) DEFAULT 'active'
            CHECK (status IN ('active', 'inactive')),

    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Customer')
BEGIN
    CREATE TABLE Customer (
        customer_id INT IDENTITY(1,1) PRIMARY KEY,
        full_name NVARCHAR(100) NOT NULL,
        date_of_birth DATE NOT NULL,
        identity_card NVARCHAR(20) NOT NULL UNIQUE,
        phone_number NVARCHAR(15),
        email NVARCHAR(100),
        nationality NVARCHAR(50),
        address NVARCHAR(MAX),
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Room_Types')
BEGIN
    CREATE TABLE Room_Types (
        room_type_id INT IDENTITY(1,1) PRIMARY KEY,
        type_name NVARCHAR(50) NOT NULL,
        base_price DECIMAL(10,2) NOT NULL,
        capacity INT DEFAULT 2,
        description NVARCHAR(MAX)
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Rooms')
BEGIN
    CREATE TABLE Rooms (
        room_id INT IDENTITY(1,1) PRIMARY KEY,
        room_number NVARCHAR(10) NOT NULL UNIQUE,
        room_type_id INT,
        floor INT,
        status NVARCHAR(20) DEFAULT 'available',

        CONSTRAINT CK_Rooms_Status
            CHECK (status IN ('available', 'reserved', 'maintenance')),

        CONSTRAINT FK_Rooms_RoomTypes
            FOREIGN KEY (room_type_id)
            REFERENCES Room_Types(room_type_id)
    );
END