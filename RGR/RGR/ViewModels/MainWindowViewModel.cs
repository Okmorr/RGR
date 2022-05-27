using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Reactive;
using System.Text;
using System.Data;

namespace RGR.ViewModels
{ 
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;

        public F1Context db_context = new F1Context();
        public ViewModelBase Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public ObservableCollection<Championship> Championships { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }
        public ObservableCollection<ResultDriver> ResultDrivers { get; set; }
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<Track> Tracks { get; set; }

        public MainWindowViewModel()
        {
            Championships = new ObservableCollection<Championship>();
            Drivers = new ObservableCollection<Driver>();
            ResultDrivers = new ObservableCollection<ResultDriver>();
            Teams = new ObservableCollection<Team>();
            Tracks = new ObservableCollection<Track>();

            using (var db = new F1Context())
            {
                foreach (var record in db.Championships) Championships.Add(record);
                foreach (var record in db.Drivers) Drivers.Add(record);
                foreach (var record in db.ResultDrivers) ResultDrivers.Add(record);
                foreach (var record in db.Teams) Teams.Add(record);
                foreach (var record in db.Tracks) Tracks.Add(record);
            }

            Content = new DataBaseViewModel();
        }
        public void Delete(object e)
        {
            if (e as Championship != null)
            {
                Championships.Remove(e as Championship);
            }

            if (e as Driver != null)
            {
                Drivers.Remove(e as Driver);
            }

            if (e as ResultDriver != null)
            {
                ResultDrivers.Remove(e as ResultDriver);
            }

            if (e as Team != null)
            {
                Teams.Remove(e as Team);
            }

            if (e as Track != null)
            {
                Tracks.Remove(e as Track);
            }
        }

        public void Create(string name)
        {
            switch (name)
            {
                case "Championship":
                    Championship championship = new Championship();
                    Championships.Add(championship);
                    break;
                case "Driver":
                    Driver driver = new Driver();
                    Drivers.Add(driver);
                    break;
                case "ResultDriver":
                    ResultDriver resultDriver = new ResultDriver();
                    ResultDrivers.Add(resultDriver);
                    break;
                case "Team":
                    Team team = new Team();
                    Teams.Add(team);
                    break;
                case "Track":
                    Track track = new Track();
                    Tracks.Add(track);
                    break;
                default:
                    break;
            }
        }

        public void Save()
        {
            db_context.SaveChanges();
        }
    }
}