using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Equals_ReplacesEqualObjects()
    {

      Venue venueOne = new Venue("CBGB");
      Venue venueTwo = new Venue("CBGB");

      Assert.Equal(venueOne, venueTwo);
    }

    [Fact]
    public void GetAll_RetrievesAllVenuesFromDatabase()
    {
      //Arrange
      Venue venueOne = new Venue("CBGB");
      venueOne.Save();
      Venue venueTwo = new Venue("The Roseland");
      venueTwo.Save();
      // Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(2, result);
    }

    [Fact]
    public void Save_SavesVenueToDatabase()
    {
      //Arrange
      Venue testVenue = new Venue("CBGB");
      testVenue.Save();
      //Act

      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Find_FindsVenueInDatabase()
    {
      //Arrange
      Venue testVenue = new Venue("CBGB");
      testVenue.Save();

      //Act
      Venue foundVenue = Venue.Find(testVenue.GetId());

      //Assert
      Assert.Equal(testVenue, foundVenue);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
