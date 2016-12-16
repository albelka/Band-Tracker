using Nancy;
using System;
using System.Collections.Generic;
using Nancy.ViewEngines.Razor;


namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
      {
        Get["/"] = _ => {
          return View["index.cshtml"];
        };
        Get["/venues"] = _ => {
          var allVenues = Venue.GetAll();
          return View["venues.cshtml", allVenues];
        };
        Get["/bands"] = _ => {
          var allBands = Band.GetAll();
          return View ["bands.cshtml", allBands];
        };
        Get["/venues/new"] = _ => {
          return View["venues_form.cshtml"];
        };
        Post["/venues/new"] = _ => {
          Venue newVenue = new Venue(Request.Form["name"]);
          newVenue.Save();
          var allVenues = Venue.GetAll();
          return View["success.cshtml"];
        };
        Get["/bands/new"] = _ => {
          return View["bands_form.cshtml"];
        };

        Post["/bands/new"] = _ => {
          Band newBand = new Band(Request.Form["name"]);
          newBand.Save();
          return View["success.cshtml"];
        };

        Get["/shows/new"] = _ => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          var allVenues = Venue.GetAll();
          var allBands = Band.GetAll();
          model.Add("venues", allVenues);
          model.Add("bands", allBands);
          return View["shows_form.cshtml", model];
        };

        Post["/shows/new"] = _ => {
          int venueId = Request.Form["venue"];
          Venue selectedVenue = Venue.Find(venueId);
          int bandId = Request.Form["band"];
          Band selectedBand = Band.Find(bandId);
          selectedVenue.AddBand(selectedBand);
          var bands = selectedVenue.GetBands();
          return View["success.cshtml"];
        };

        Get["/shows"] = _ => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          var allVenues = Venue.GetAll();
          var allBands = Band.GetAll();
          model.Add("venues", allVenues);
          model.Add("bands", allBands);
          return View["shows.cshtml", model];
        };

        Get["/venue/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string,object>();
          var selectedVenue = Venue.Find(parameters.id);
          var bands = selectedVenue.GetBands();
          model.Add("venue", selectedVenue);
          model.Add("bands", bands);
          return View["venue.cshtml", model];
        };
        Get["/band/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string,object>();
          var selectedBand = Band.Find(parameters.id);
          var venues = selectedBand.GetVenues();
          model.Add("band", selectedBand);
          model.Add("venues", venues);
          return View["band.cshtml", model];
        };
        Get["/venue/edit/{id}"] = parameters => {
          Venue selectedVenue = Venue.Find(parameters.id);
          return View["venue_edit.cshtml", selectedVenue];
        };
        Patch["/venue/edit/{id}"] = parameters => {
          Venue selectedVenue = Venue.Find(parameters.id);
          selectedVenue.Update(Request.Form["venue-name"]);
          return View["success.cshtml"];
        };

        Get["/venue/delete/{id}"] = parameters => {
          Venue selectedVenue = Venue.Find(parameters.id);
          return View["/venue_delete.cshtml", selectedVenue];
        };
        Delete["venue/delete/{id}"] = parameters => {
          Venue selectedVenue = Venue.Find(parameters.id);
          selectedVenue.Delete();
          return View["success.cshtml"];
        };
      }
  }
}
