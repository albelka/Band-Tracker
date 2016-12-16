using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest// : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void ReplacesEqualObjects_True()
    {

      Venue venueOne = new Venue("Bobby");
      Venue venueTwo = new Venue("Bobby");

      Assert.Equal(venueOne, venueTwo);
    }

    [Fact]
    public void GetAll_true()
    {
      //Arrange
      Venue venueOne = new Venue("Daniel");
      venueOne.Save();
      Venue venueTwo = new Venue("Ryan");
      venueTwo.Save();
      // Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(2, result);
    }
  }
}
