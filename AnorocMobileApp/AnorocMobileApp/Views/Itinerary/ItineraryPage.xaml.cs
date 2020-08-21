﻿using AnorocMobileApp.ViewModels.Itinerary;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AnorocMobileApp.Views.Itinerary
{
    /// <summary>
    /// Page to show the location denied
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItineraryPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItineraryPage" /> class.
        /// </summary>
        public ItineraryPage()
        {
            InitializeComponent();
            BindingContext = new ItineraryPageViewModel(Navigation);
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    EmptyItinerary.IsVisible = false;
                }
            }
            else
            {
                EmptyItinerary.IsVisible = true;
            }
        }
    }
}