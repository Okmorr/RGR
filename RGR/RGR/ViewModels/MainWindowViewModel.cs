using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;

using System.Text;

namespace RGR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;
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
    }
}