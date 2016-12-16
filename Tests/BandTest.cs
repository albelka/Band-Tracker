using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Equals_ReplacesEqualObjects()
    {

      Band bandOne = new Band("Wilco");
      Band bandTwo = new Band("Wilco");

      Assert.Equal(bandOne, bandTwo);
    }

    [Fact]
    public void GetAll_RetrievesAllBandsFromDatabase()
    {
      //Arrange
      Band bandOne = new Band("Wilco");
      bandOne.Save();
      Band bandTwo = new Band("John Prine");
      bandTwo.Save();
      // Act
      int result = Band.GetAll().Count;

      //Assert
      Assert.Equal(2, result);
    }

    [Fact]
    public void Find_FindsBandInDatabase_true()
    {
      //Arrange
      Band testBand = new Band("Wilco");
      testBand.Save();

      //Act
      Band foundBand = Band.Find(testBand.GetId());

      //Assert
      Assert.Equal(testBand, foundBand);
    }

    [Fact]
    public void Save_SavesBandToDatabase()
    {
      //Arrange
      Band testBand = new Band("Wilco");
      testBand.Save();
      //Act

      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{testBand};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void GetVenues_RetrievesVenuesOfAGivenBand()
    {
      Band newBand = new Band("Wilco");
      newBand.Save();
      Venue newVenue = new Venue("CBGB");
      newVenue.Save();
      newVenue.AddBand(newBand);
      List<Venue> expected = new List<Venue>{newVenue};
      List<Venue> result = newBand.GetVenues();

      Assert.Equal(expected, result);
    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
