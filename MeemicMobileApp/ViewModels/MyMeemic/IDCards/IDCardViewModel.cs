using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.MyMeemic.IDCards
{
    public class IDCardViewModel : BaseViewModel
    {
        private bool digitalAutoIDCardVisibility;
        private bool officialAutoIDCardVisibility;
        private bool whatToDoVisibility;
        private int selectedIndex = -1;



        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set 
            {
                if(selectedIndex != value)
                {
                    selectedIndex = value;
                    HandleIndexChange();
                    OnPropertyChanged();
                }

            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.IDCards.IDCardViewModel"/> digital auto IDC ard visibility.
        /// </summary>
        public bool DigitalAutoIDCardVisibility
        {
            get { return digitalAutoIDCardVisibility; }
            set 
            {
                if(digitalAutoIDCardVisibility != value)
                {
                    digitalAutoIDCardVisibility = value;
                    OnPropertyChanged();
                }

            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.IDCards.IDCardViewModel"/> official auto IDC ard visibility.
        /// </summary>
		public bool OfficialAutoIDCardVisibility
		{
			get { return officialAutoIDCardVisibility; }
			set
			{
				if (officialAutoIDCardVisibility != value)
				{
					officialAutoIDCardVisibility = value;
					OnPropertyChanged();
				}

			}
		}



        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.IDCards.IDCardViewModel"/> what to do visibility.
        /// </summary>
		public bool WhatToDoVisibility
		{
			get { return whatToDoVisibility; }
			set
			{
				if (whatToDoVisibility != value)
				{
					whatToDoVisibility = value;
					OnPropertyChanged();
				}

			}
		}



		/// <summary>
		/// Gets the rotate display command.
		/// </summary>
		public ICommand RotateDisplayCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.IDCards.IDCardViewModel"/> class.
        /// </summary>
        public IDCardViewModel()
        {
            SelectedIndex = 0;

            RotateDisplayCommand = new Command(async (obj) => await RotateDisplayCommandExecute(obj));
        }


        private void HandleIndexChange() 
        {
            switch(selectedIndex)
            {
                case 0:
                    {
                        DigitalAutoIDCardVisibility = true;
                        OfficialAutoIDCardVisibility = false;
                        WhatToDoVisibility = false;
                    }break;

                case 1:
                    {
                        DigitalAutoIDCardVisibility = false;
						OfficialAutoIDCardVisibility = true;
						WhatToDoVisibility = false;
                    }break;

                case 2:
                    {
                        DigitalAutoIDCardVisibility = false;
						OfficialAutoIDCardVisibility = false;
						WhatToDoVisibility = true;
                    }break;

                default:
                    {
                        SelectedIndex = 0; // this will retrigger this func
                    }break;



            }
        }



        private async Task RotateDisplayCommandExecute(object parms) 
        {
            MessagingCenter.Send(this, "forcePortait");

            await Navigation.PopModalAsync();;
        }

    }
}
