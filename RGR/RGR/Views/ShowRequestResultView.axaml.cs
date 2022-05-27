using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RGR.Views
{
    public partial class ShowRequestResultView : UserControl
    {
        static public Championship;
        public ShowRequestResultView()
        {
            InitializeComponent();

            using (var db = new F1Context())
            {
                string t = F.TableName;
                string l = F.Field1;
                var s = this.Find<DataGrid>("Result").Items;
                switch (t)
                {
                    case "Championship":
                        switch (l)
                        {
                            case "YearId":
                                s = db.Championships.Select(x => x).ToList();
                                break;
                        }
                        break;
                    case "Driver":
                        switch (l)
                        {
                            case "NumId":
                                s = db.Drivers.Select(x => x).ToList();
                                break;
                            case "Name":
                                s = db.Drivers.Select(x => x.StatisticId).ToList();
                                break;
                        }
                        break;
                    case "ResultDriver":
                        switch (l)
                        {
                            case "PosId":
                                s = db.ResultDrivers.Select(x => x).ToList();
                                break;
                            case "NumDriver":
                                s = db.ResultDrivers.Select(x => x.Name).ToList();
                                break;
                            case "NameTrack":
                                s = db.ResultDrivers.Select(x => x.TeamId).ToList();
                                break;
                            case "Time":
                                s = db.ResultDrivers.Select(x => x.TeamId).ToList();
                                break;
                            case "Interval":
                                s = db.ResultDrivers.Select(x => x.TeamId).ToList();
                                break;
                            case "KpH":
                                s = db.ResultDrivers.Select(x => x.TeamId).ToList();
                                break;
                            case "Best":
                                s = db.ResultDrivers.Select(x => x.TeamId).ToList();
                                break;
                            case "Laps":
                                s = db.ResultDrivers.Select(x => x.TeamId).ToList();
                                break;


                            default:
                                break;
                        }
                        break;
                    case "Team":
                        switch (l)
                        {
                            case "NameId":
                                s = db.Teams.Select(x => x).ToList();
                                break;
                            case "TrackName":
                                s = db.Teams.Select(x => x.Name).ToList();
                                break;
                                break;
                            case "Track":
                                switch (l)
                                {
                                    case "NameId":
                                        s = db.Tracks.Select(x => x).ToList();
                                        break;
                                    case "Year":
                                        s = db.Players.Select(x => x.Name).ToList();
                                        break;
                                    case "Lap":
                                        s = db.Players.Select(x => x.Age).ToList();
                                        break;
                                }
                                break;
                        }

                        this.Find<DataGrid>("Result").Items = s;

                }



            }

            private void InitializeComponent()
            {
                AvaloniaXamlLoader.Load(this);
            }
        }
    }
}