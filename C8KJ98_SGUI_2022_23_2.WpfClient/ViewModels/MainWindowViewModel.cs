using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_SGUI_2022_23_2.WpfClient.ViewModels
{
    public class MainWindowViewModel: ObservableRecipient
    {
        public RelayCommand ManageArtistsCommand { get; set; }
        public RelayCommand ManageFansCommand { get; set; }
        public RelayCommand ManageReservationsCommand { get; set; }
        public RelayCommand ManageServicesCommand { get; set; }

        public MainWindowViewModel()
        {
            ManageArtistsCommand = new RelayCommand(OpenArtistsWindow);
            ManageFansCommand = new RelayCommand(OpenFansWindow);
            ManageReservationsCommand = new RelayCommand(OpenReservationsWindow);
            ManageServicesCommand = new RelayCommand(OpenServicesWindow);

        }

        private void OpenServicesWindow()
        {
            new ServicesWindow().Show();
        }

        private void OpenArtistsWindow()
        {
            new ArtistsWindow().Show();
        }
        private void OpenFansWindow()
        {
            new FansWindow().Show();
        }
        private void OpenReservationsWindow()
        {
            new ReservationsWindow().Show();
        }
    }
    

}
