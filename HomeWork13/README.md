# Project Title
CinemaDb


# Description
This database is designed for Ukrainian cinema company, which will
help to manage this huge system without any retardations. Everything is 
automatized, users with no experience just cannot break it 💀. Some 
say that this is ultimate protection, but I prefer to name it as UNFAZED SYSTEM.


# Database structure
Database Cinema has next tables:
## Users Booking Halls Seats Movies Showtimes

# Entities
Users
* Id integer
* Name varchar

Booking
* Id integer
* ShowTimeId integer
* UserId integer
* SeatNumber boolean
* Booking Datetime

Showtimes
* Id integer
* MovieId integer
* CinemaHallId integer
* Date Datetime
* Duration integer

Movies
* Id integer
* MovieName varchar
* Price decimal

Halls
* Id integer
* SeatAmount integer

Seats
* SeatNumber integer
* HallId integer
* Available boolean


# Connection tables

#### Users Id (primary key)
#### Booking Id (primary key), UserId (foreign key for Users), ShowTimeId (foreign key for Showtimes)
#### Showtimes Id (primary key), MovieId (foreign key for Movies), CinemaHallId (foreign key for Halls)
#### Movies Id (primary key)
#### Halls Id (foreign key for ShowTimes) & (foreign key for ShowTimes)
#### Seats HallId (foreign key for Halls)


# Decisions

#### Everything is pretty basic except the tables Halls and Seats.
#### The reason for such strange structure is that we had 2 tasks which requires the number of seat and if it's available for each Hall.
#### Of course we won't fill this manually, instead of that we'll use for loops.

# Authors
### Akostakioaie Florian

# Code

Every table was populated with data pretty simple except Seats and Booking
For Seats table I used for loop, which helped a lot.
```
DECLARE @i int = 0
WHILE @i < 40
BEGIN
    SET @i = @i + 1
    INSERT INTO Seats (HallId, SeatNumber, Available)
    VALUES (2, @i, 1)
END;
```

For Booking table it was way more harder, because I implemented some kind of security.
```
DECLARE @seat int = 1;
DECLARE @showId int = 1;
DECLARE @userId int = 2;

IF @seat IN
(
 SELECT Cast(SeatNumber AS int) FROM Showtimes
 INNER JOIN (Halls INNER JOIN Seats ON Halls.Id = Seats.HallId) 
 ON Showtimes.CinemaHallId = Halls.Id
 WHERE Showtimes.Id = @showId AND Available = 1 AND SeatNumber = @seat
)

BEGIN
 INSERT INTO Booking
 (ShowTimeId, UserId, SeatNumber, BookingDate)
 VALUES
 (@showId, @userId, @seat, GETDATE());

 DECLARE @hallId int = (
  SELECT Cast(CinemaHallId AS int) FROM Showtimes
  WHERE Showtimes.Id = @showId
 );

 UPDATE Seats
 SET Available = 0
 WHERE @seat = SeatNumber AND @hallId = HallId 
END

ELSE
 SELECT 'Seat is not available' 
```

## 1 Query
### Select all the showtimes for the current week, including movie name, date and time of the show.
```
SELECT MovieName, Date, Duration From Showtimes
INNER JOIN Movies ON Movies.Id = Showtimes.MovieId
WHERE
(
 SELECT DATEADD(DAY, 2 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) [Week_Start_Date]
) < Date AND
(
 SELECT DATEADD(day, 7, DATEADD(DAY, 2 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))) AS DateAdd
) > Date
```

## 2 Query
#### Select all available seats for the specific show.
```
SELECT SeatNumber, Available FROM Seats
INNER JOIN 
 (Halls INNER JOIN Showtimes ON
  Halls.Id = Showtimes.CinemaHallId)
 ON Seats.HallId = Halls.Id
WHERE 2 = Showtimes.Id AND Available = 1
```

## 3 Query
#### Find seats which were never booked.
```
SELECT SeatNumber, HallId from Seats
WHere Seats.Available = 1
```

## 4 Query
#### Calculate all the money earned by each movie and display in descending order along with movies names.
```
SELECT MovieName, SUM(Price) AS [Total Price] FROM Booking 
INNER JOIN ( Movies INNER JOIN Showtimes ON Movies.Id = Showtimes.MovieId ) 
ON Booking.ShowTimeId = Showtimes.Id 
GROUP BY Movies.MovieName ORDER BY [Total Price] DESC
```

## 5 Query
#### Show top 3 users, who spent most money in the specified dates interval.
```
SELECT TOP 3 Name, SUM(Price) AS [Total spent] FROM Booking
INNER JOIN Users ON Booking.UserId = Users.Id 
INNER JOIN (Showtimes INNER JOIN Movies ON Showtimes.MovieId = Movies.Id)
ON Booking.ShowTimeId = Showtimes.Id
WHERE '2023-01-12' < BookingDate AND '2023-01-15' > BookingDate
GROUP BY Name
ORDER BY [Total spent] DESC
```

## 6 Query
#### Find cinema halls, which received less visitors in the last week (7 days), than in the week (another 7 days) before that.
```
CREATE VIEW WeekAgo AS
SELECT Halls.Id, COUNT(Booking.Id) AS [Total bookings] FROM Booking
INNER JOIN 
    (
        Showtimes INNER JOIN Halls ON
        Showtimes.CinemaHallId = Halls.Id
    ) 
ON Booking.ShowTimeId = Showtimes.Id
WHERE BookingDate <= GETDATE() AND BookingDate >= DATEADD(day, -7, GETDATE())
GROUP BY Halls.Id

CREATE VIEW TwoWeeksAgo AS
SELECT Halls.Id, COUNT(Booking.Id) AS [Total bookings] FROM Booking
INNER JOIN 
    (
        Showtimes INNER JOIN Halls ON
        Showtimes.CinemaHallId = Halls.Id
    ) 
ON Booking.ShowTimeId = Showtimes.Id
WHERE BookingDate <= DATEADD(day, -7, GETDATE()) AND BookingDate >= DATEADD(day, -14, GETDATE())
GROUP BY Halls.Id

SELECT WeekAgo.Id AS HallId, WeekAgo.[Total bookings] 
FROM WeekAgo, TwoWeeksAgo 
WHERE WeekAgo.[Total bookings] < TwoWeeksAgo.[Total bookings]
```