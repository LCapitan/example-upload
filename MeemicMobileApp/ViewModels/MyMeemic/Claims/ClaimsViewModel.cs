using System;
using MeemicMobileApp.ViewModels.Base;

namespace MeemicMobileApp.ViewModels.MyMeemic.Claims
{
    public class ClaimsViewModel : BaseViewModel
    {

        private int selectedButtonIndex = -1;



        /// <summary>
        /// Gets a value indicating whether this <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.ClaimsViewModel"/> is
        /// button1 sleected.
        /// </summary>
        public bool IsButton1Selected => selectedButtonIndex == 0;



        /// <summary>
        /// Gets a value indicating whether this <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.ClaimsViewModel"/> is
        /// button2 selected.
        /// </summary>
        public bool IsButton2Selected => selectedButtonIndex == 1;



        /// <summary>
        /// Gets a value indicating whether this <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.ClaimsViewModel"/> is
        /// button3 selected.
        /// </summary>
        public bool IsButton3Selected => selectedButtonIndex == 2;



        /// <summary>
        /// Gets or sets the index of the selected button.
        /// </summary>
        public int SelectedButtonIndex
        {
            get { return selectedButtonIndex; }
            set 
            {
                if(value != selectedButtonIndex)
                {
                    selectedButtonIndex = value;
                    OnPropertyChanged();

                    OnPropertyChanged("IsButton1Selected");
                    OnPropertyChanged("IsButton2Selected");
                    OnPropertyChanged("IsButton3Selected");
                }

            }
        }



        public ClaimsViewModel()
        {
            SelectedButtonIndex = 0;
        }
    }
}
