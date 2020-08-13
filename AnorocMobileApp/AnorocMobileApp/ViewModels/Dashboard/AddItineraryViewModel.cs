﻿using System;
using AnorocMobileApp.Models.Dashboard;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using System.Windows.Input;
using AnorocMobileApp.Helpers;
using AnorocMobileApp.Models;
//using AnorocMobileApp.Models;
using AnorocMobileApp.Models.Itinerary;
using Newtonsoft.Json;
//using Itinerary = AnorocMobileApp.Models.Itinerary;
using Xamarin.Forms;

namespace AnorocMobileApp.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for Add Itinerary page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class AddItineraryViewModel : INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="AddItineraryViewModel"/> class.
        /// </summary>
        public AddItineraryViewModel()
        {
        }

        #endregion
        
        #region HttpRequest
        
        private static HttpClient _httpClientInstance;

        public static HttpClient HttpClientInstance
        {
            get
            {
                if (_httpClientInstance == null)
                {
                    var handler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                    };
                    _httpClientInstance = _httpClientInstance ?? (_httpClientInstance = new HttpClient());
                }
                return _httpClientInstance;
            }
        }

        
        #endregion
        
        #region Fields

        private ObservableCollection<Address> addresses;
        private ObservableCollection<Location> locations;
        private string addressText;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a collection of value to be displayed in add itinerary page.
        /// </summary>
        [DataMember(Name = "dailyTimeline")]
        public ObservableCollection<Event> DailyTimeline { get; set; }

        public ObservableCollection<Address> Addresses
        {
            get => addresses ?? (addresses = new ObservableCollection<Address>());
            set
            {
                if (addresses != value)
                {
                    addresses = value;
                    OnPropertyChanged("Addresses");
                }
            }
        }
        
        public ObservableCollection<Location> Locations
        {
            get => locations ?? (locations = new ObservableCollection<Location>());
            set
            {
                if (locations != value)
                {
                    locations = value;
                    OnPropertyChanged("Locations");
                }
            }
        }
        
        public string AddressText 
        {
            get => addressText;
            set 
            {
                if (addressText != value) {
                    addressText = value;
                    OnPropertyChanged("AddressText");
                }
            }
        }

        #endregion
        
        #region Commands

        #endregion
        
        #region Methods

        public async Task GetPlacesPredictonAsync()
        {
            Debug.Print("In GetPlaces function");
            // TODO: Add some logic to slow down requests
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token;

            // TODO: Pass current lon and lat to show areas closer to the user
            var url = string.Format(Constants.AzureFuzzySearchUrl,
                WebUtility.UrlEncode(addressText),
                Secrets.AzureMapsSubscriptionKey);
            using (var message = await HttpClientInstance.GetAsync(url, HttpCompletionOption.ResponseContentRead, cancellationToken))
            {
                if (message.IsSuccessStatusCode)
                {
                    var json = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var wholeResponse = await Task.Run(() => JsonConvert.DeserializeObject<Welcome>(json)).ConfigureAwait(false);
                    
                    // TODO: Maybe check if it converted successfully
                    
                    Addresses.Clear();

                    if (wholeResponse.Summary.TotalResults > 0)
                    {
                        foreach (var result in wholeResponse.Results)
                        {
                            Addresses.Add(result.Address);
                        }
                    }
                }
            }
        }
        
        #endregion

        #region INotifyPropertyChanged
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}