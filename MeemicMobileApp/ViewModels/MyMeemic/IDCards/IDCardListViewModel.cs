using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.ViewModels.MyMeemic.Policies;
using MeemicMobileApp.Views.MyMeemic.IDCards;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.MyMeemic.IDCards
{
    public class IDCardListViewModel : BaseViewModel
    {

        /// <summary>
        /// Gets or sets the policy.
        /// </summary>
        public Policy Policy { get; private set; }



        /// <summary>
        /// Gets the view card command.
        /// </summary>
        public ICommand ViewCardCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:MeemicMobileApp.ViewModels.MyMeemic.IDCardViewModel"/> class.
        /// </summary>
        public IDCardListViewModel()
        {
            var veh = new ObservableCollection<Property>
            {
                new Property { ID = "ID878787", Name="Car No 1",Type=Property.PropertyType.Auto},
                new Property { ID = "ID632638", Name="Van No 2",Type=Property.PropertyType.Auto},
                new Property { ID = "ID937w236", Name="Truck Noo 1",Type=Property.PropertyType.Auto}
            };

            Policy = new Policy("PAP0738417", PolicyType.Auto, new DateTime(2017, 2, 1), new DateTime(2018, 2, 1), true, new List<Property>(veh));

            OnPropertyChanged("Policy");

            ViewCardCommand = new Command(async (obj) => await ViewCardCommandExecute(obj));

            OnPropertyChanged("ViewCardCommand");

        }


        private async Task ViewCardCommandExecute(object parm)
        {
            var property = parm as Property;
            await PushModalAsync(new IDCardView(Policy, property), true);
        }
    }
}
