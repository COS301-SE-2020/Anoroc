﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AnorocMobileApp.Models.Itinerary;
using AnorocMobileApp.Views.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AnorocMobileApp.ViewModels.Itinerary
{
    /// <summary>
    /// ViewModel for location denied page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ItineraryPageViewModel : BaseViewModel
    {
        #region Fields

        private string imagePath;

        private string header;

        private string content;

        private ObservableCollection<Models.Itinerary.Itinerary> itineraries;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ItineraryPageViewModel" /> class.
        /// </summary>
        public ItineraryPageViewModel(INavigation navigation)
        {
            ImagePath = "EmptyItinerary.svg";
            Header = "EMPTY ITINERARY";
            Content = "You currently have no itineraries";
            GoBackCommand = new Command(GoBack);
            Navigation = navigation;

            AddItineraryCommand = new Command(async () => await AddItinerary());
            
            
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Go back button is clicked.
        /// </summary>
        public ICommand GoBackCommand { get; set; }
        
        public ICommand AddItineraryCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ImagePath.
        /// </summary>
        public string ImagePath
        {
            get => this.imagePath;

            set
            {
                this.imagePath = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        public string Header
        {
            get => this.header;

            set
            {
                this.header = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        public string Content
        {
            get => this.content;

            set
            {
                this.content = value;
                this.NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Models.Itinerary.Itinerary> Itineraries
        {
            get => itineraries;
            set
            {
                itineraries = value;
                NotifyPropertyChanged();
            }
        }

        public INavigation Navigation { get; set;}
        
        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Go back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void GoBack(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Add Itinerary button is clicked
        /// </summary>
        /// <returns></returns>
        private async Task AddItinerary()
        {
            await Navigation.PushAsync(new AddItineraryPage());
        }

        private void PopulateItineraries()
        {
            
        }

        #endregion      
    }
}
