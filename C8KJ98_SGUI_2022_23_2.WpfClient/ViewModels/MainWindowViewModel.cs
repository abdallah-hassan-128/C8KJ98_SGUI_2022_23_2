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

        public MainWindowViewModel()
        {
            ManageArtistsCommand = new RelayCommand(OpenArtistsWindow);
        }

        private void OpenArtistsWindow()
        {
            new ArtistsWindow().Show();
        }
    }
    

}
