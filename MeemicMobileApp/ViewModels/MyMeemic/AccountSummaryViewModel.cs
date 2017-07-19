using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.MyMeemic
{
    /// <summary>
    /// Account Summary ViewModel
    /// </summary>
    public class AccountSummaryViewModel : BaseViewModel
    {

        /// <summary>
        /// The list of Policies
        /// </summary>
        public ObservableCollection<PolicyGroup> Policies { get; private set; }



        /// <summary>
        /// Gets the policy selected command.
        /// </summary>
        public ICommand PolicySelectedCommand { get; private set; }



        /// <summary>
        /// Constructor
        /// </summary>
        public AccountSummaryViewModel()
        {
            Policies = new ObservableCollection<PolicyGroup>(GeneratePolicies());
            OnPropertyChanged("Policies");

            PolicySelectedCommand = new Command<Policy>(async (p) => await PolicySelectedCommandExecute(p));
        }



        private async Task PolicySelectedCommandExecute(Policy policy)
        {
            await DisplayAlert(policy.Type.ToString(), policy.CurrentDate, policy.Id, "CANCEL");
        }




        private IEnumerable<PolicyGroup> GeneratePolicies() 
        {
            return new List<PolicyGroup>
            {
                new PolicyGroup(PolicyType.Auto)
                {
                    new Policy("PAP0738417", PolicyType.Auto, new DateTime(2017,2,1), new DateTime(2018, 2, 1), true)    
                },

				new PolicyGroup(PolicyType.Home)
				{
					new Policy("HOP1111749", PolicyType.Home, new DateTime(2017,1,1), new DateTime(2018, 1, 1), false),
				    new Policy("HOP1111750", PolicyType.Home, new DateTime(2017,6,1), new DateTime(2018, 6, 1), false),
				},

                new PolicyGroup(PolicyType.Umbrella)
                {
					new Policy("PUP0011610", PolicyType.Umbrella, new DateTime(2016,12,31), new DateTime(2018, 1, 1), false),
                },
                new PolicyGroup(PolicyType.Boat)
                {
					new Policy("PAP0738417", PolicyType.Boat, new DateTime(2017,1,1), new DateTime(2019, 1, 1), true),
					new Policy("BOP01576780", PolicyType.Boat, new DateTime(2017,6,1), new DateTime(2018, 6, 1), false),
                }
            };

        }

    }



    /// <summary>
    /// Policy
    /// </summary>
    public class Policy 
    {
        
        /// <summary>
        /// The Policy Id
        /// </summary>
        public string Id { get; private set; }



        /// <summary>
        /// The Type of the Policy
        /// </summary>
        public PolicyType Type { get; private set; }



        /// <summary>
        /// Current start date of the policy
        /// </summary>
        public DateTime StartDate { get; private set; }



        /// <summary>
        /// Current end date of this policy
        /// </summary>
        public DateTime EndDate { get; private set; }



        /// <summary>
        /// Is this policy past due?
        /// </summary>
        public bool IsPastDue { get; private set; }



        /// <summary>
        /// Current Date range of the policy
        /// </summary>
        public string CurrentDate => $"Current: {StartDate.ToString("MM/dd/yyyy")} - {EndDate.ToString("MM/dd/yyyy")}";



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Policy ID</param>
        /// <param name="type">Policy Type</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="isPastDue">If set to <c>true</c> is past due.</param>
        public Policy(string id, PolicyType type, DateTime startDate, DateTime endDate, bool isPastDue)
        {
            Id = id;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            IsPastDue = isPastDue;
        }

    }



    /// <summary>
    /// Policy group - This enabled us to use grouping in listviews
    /// </summary>
    public class PolicyGroup : List<Policy>
    {
        /// <summary>
        /// What type of policy group is this?
        /// </summary>
        public PolicyType GroupBy { get; private set; }


        /// <summary>
        /// Gets the name and count.
        /// </summary>
        public string NameAndCount => $"{GroupBy.ToString()} ({Count})".ToUpper();


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">The type of the group</param>
        public PolicyGroup(PolicyType type)
        {
            GroupBy = type;
        }


    }

    /// <summary>
    /// Policy Type
    /// </summary>
    public enum PolicyType
    {
        Auto,
        Boat,
        Home,
        Umbrella

    }
}
