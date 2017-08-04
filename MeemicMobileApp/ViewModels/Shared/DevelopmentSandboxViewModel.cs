using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.CustomControls;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Shared
{
    public class DevelopmentSandboxViewModel : BaseViewModel
    {
        private NavigationHeaderMode navigationMode;

        /// <summary>
        /// Gets the dummy data.
        /// </summary>
        public ObservableCollection<Dummy> DummyData { get; private set; }



        /// <summary>
        /// Gets or sets the navigation mode.
        /// </summary>
        public NavigationHeaderMode NavigationMode
        {
            get { return navigationMode; }
            set 
            {
                if(navigationMode != value)
                {
                    navigationMode = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Gets the set navigation mode command.
        /// </summary>
        public ICommand SetNavigationModeCommand { get; private set; }   



        /// <summary>
        /// Gets the display modal command.
        /// </summary>
        public ICommand DisplayModalCommand { get; private set; }




        /// <summary>
        /// Constructor
        /// </summary>
        public DevelopmentSandboxViewModel ()
        {
            SetNavigationModeCommand = new Command<string>(SetNavigationModeCommandExecute);
            DisplayModalCommand = new Command(async () => await DisplayModalCommandExecute());

            DummyData = new ObservableCollection<Dummy>
            {
                new Dummy() {
                    Name="Name 1",
                    Description="This is a desc",
                    Value = 14
                },

				new Dummy() {
					Name="Name 2",
					Description="This is a desc",
					Value = 344
				},

				new Dummy() {
					Name="Name 3",
					Description="This is a desc",
					Value = 442
				},

				new Dummy() {
					Name="Name 4",
					Description="This is a desc",
					Value = 56
				},

				new Dummy() {
					Name="Name 5",
					Description="This is a desc",
					Value = 43
				},

				new Dummy() {
					Name="Name 6",
					Description="This is a desc",
					Value = 143
				}

            };

            OnPropertyChanged("DummyData");
        }




        private async Task DisplayModalCommandExecute() 
        {
            
        }



        private void SetNavigationModeCommandExecute(string mode)
        {
            if (int.TryParse(mode, out int output) == false)
                return;

            NavigationMode = (NavigationHeaderMode)output;
        }
    }


    public class Dummy 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    }
}
