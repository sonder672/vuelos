CREATE DATABASE newShore
GO
USE newShore
GO
CREATE TABLE journey(
    id INT PRIMARY KEY IDENTITY NOT NULL,
    origin VARCHAR(3) NOT NULL,
    destination VARCHAR(3) NOT NULL,
    price FLOAT NOT NULL
)
GO
CREATE TABLE flight(
    id VARCHAR(4) PRIMARY KEY NOT NULL,
    origin VARCHAR(3) NOT NULL,
    destination VARCHAR(3) NOT NULL,
    price FLOAT NOT NULL
)
GO
CREATE TABLE journey_has_flight(
    journey_id INT FOREIGN KEY REFERENCES journey(id),
    flight_id VARCHAR(4) FOREIGN KEY REFERENCES flight(id)
)
GO
CREATE TABLE transport(
    id INT PRIMARY KEY IDENTITY NOT NULL,
    flight_carrier VARCHAR(2) NOT NULL,
    flight_number VARCHAR(4) FOREIGN KEY REFERENCES flight(id)
)
GO