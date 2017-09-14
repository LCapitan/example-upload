using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.ViewModels.MyMeemic.Policies;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.MyMeemic.Claims
{
    /// <summary>
    /// Select policy view model.
    /// </summary>
    public class SelectPolicyViewModel : BaseViewModel
    {

        /// <summary>
        /// Gets the policy.
        /// </summary>
        public Policy Policy { get; private set; }



        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title => $"Select {Policy?.Type} Policy";



        /// <summary>
        /// Gets the select policy command.
        /// </summary>
        public ICommand SelectPolicyCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.Claims.SelectPolicyViewModel"/> class.
        /// </summary>
        public SelectPolicyViewModel()
        {
			var veh = new ObservableCollection<Property>
			{
				new Property { ID = "ID878787", Name="Car No 1",Type=Property.PropertyType.Auto},
				new Property { ID = "ID632638", Name="Van No 2",Type=Property.PropertyType.Auto},
				new Property { ID = "ID937w236", Name="Truck Noo 1",Type=Property.PropertyType.Auto}
			};

			Policy = new Policy("PAP0738417", PolicyType.Auto, new DateTime(2017, 2, 1), new DateTime(2018, 2, 1), true, new List<Property>(veh));

			OnPropertyChanged("Policy");
            OnPropertyChanged("Title");

            SelectPolicyCommand = new Command(async (obj) => await SelectPolicyCommandExecute(obj));

		}



        private async Task SelectPolicyCommandExecute(object parms)
        {
            // @NOTE(sjv): Things here...
            await new Task(() => {});
        }

    }
}
