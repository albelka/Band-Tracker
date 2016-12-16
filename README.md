# Band Tracker

#### The program tracks bands and the venues where they've played shows, 12.15.16.

#### By **Anne Belka**

### Specifications

* Behavior: The program can add a venue to a list.
* Input: "CBGB"
* Output: "CBGB"

* Behavior: The program can display a list of bands.
* Input: "CBGB", "The Roseland"
* Output: "CBGB, The Roseland"

* Behavior: The program can display a particular band.
* Input: "CBGB", "The Roseland" Find: CBGB
* Output: ""CBGB"

* Behavior: The program can update a Band's information.
* Input: "The Roseland"
* Output: "The Roseland Theatre"

* Behavior: The program can delete a band.
* Input: "CBGB, The Roseland" Delete: CBGB
* Output: "The Roseland"

* Behavior: The program can create bands.
* Input: "Wilco"
* Output: "WIlco""

* Behavior: The program can assign a band to a venue.
* Input: "Wilco"
* Output: "Played at: CBGB. The Roseland"


## Setup/Installation Requirements
* Used the following commands to create the database for this app:
* In SQLCMD:
* >CREATE DATABASE band_tracker;
* >GO
* >USE band_tracker;
* >GO
* >CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));
* >CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));
* >CREATE TABLE shows (id INT IDENTITY(1,1), band_id int, venue_id int);
* >GO

* Clone this repository or download it to your computer.
* Navigate to the project directory in the terminal.
* Use the command > dnu restore to download any necessary dependencies.
* Use the command > dnx kestrel to run the project on the local server.
* Navigate to localhost:5004 in your browser to view the app.

* To see BDD tests run dnx test in PowerShell.

### License

GPL

Copyright (c) 2016 **_Anne Belka_**
