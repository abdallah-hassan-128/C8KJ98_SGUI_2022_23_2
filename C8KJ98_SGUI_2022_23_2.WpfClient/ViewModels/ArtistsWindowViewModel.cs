using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_SGUI_2022_23_2.WpfClient.Clients;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace C8KJ98_SGUI_2022_23_2.WpfClient.ViewModels
{
    public class ArtistsWindowViewModel: ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();

        public ObservableCollection<Artists> Artists { get; set; }
        private Artists _selectedArtist;

        public Artists SelectedArtist
        {
            get => _selectedArtist;
            set
            {
                SetProperty(ref _selectedArtist, value);
            }
        }
        private int _selectedArtistIndex;

        public int SelectedArtistIndex
        {
            get => _selectedArtistIndex;
            set
            {
                SetProperty(ref _selectedArtistIndex, value);
            }
        }
        public RelayCommand AddArtistCommand { get; set; }
        public RelayCommand EditArtistCommand { get; set; }
        public RelayCommand DeleteArtistCommand { get; set; }
        public RelayCommand ArtistsEarningCommand { get; set; }

        public ArtistsWindowViewModel()
        {
            Artists = new ObservableCollection<Artists>();

            _apiClient
                .GetAsync<List<Artists>>("http://localhost:37793/artists")
                .ContinueWith((artists) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        artists.Result.ForEach((artist) =>
                        {
                            Artists.Add(artist);
                        });
                    });
                });

            AddArtistCommand = new RelayCommand(AddArtist);
            EditArtistCommand = new RelayCommand(EditArtist);
            DeleteArtistCommand = new RelayCommand(DeleteArtist);

        }
        private void AddArtist()
        {
            Artists n = new Artists
            {
                Name = SelectedArtist.Name,
                Price = _selectedArtist.Price,
                Category = SelectedArtist.Category,
                Duration = SelectedArtist.Duration

            };

            _apiClient
                .PostAsync(n, "http://localhost:37793/artists")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Artists.Add(n);
                    });
                });
        }
        private void EditArtist()
        {
            _apiClient
                .PutAsync(SelectedArtist, "http://localhost:37793/artists")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        int i = SelectedArtistIndex;
                        Artists a = SelectedArtist;
                        Artists.Remove(SelectedArtist);
                        Artists.Insert(i, a);
                    });
                });
        }
        private void DeleteArtist()
        {
            _apiClient
                .DeleteAsync(SelectedArtist.Id, "http://localhost:37793/artists")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Artists.Remove(SelectedArtist);
                    });
                });
        }
    }
}
