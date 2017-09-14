using System;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.ViewModels.MyMeemic.Policies;

namespace MeemicMobileApp.ViewModels.MyMeemic.Claims
{
    public class AutoClaimStepOneViewModel : BaseViewModel
    {
        private Policy policy;
        private Property property;



        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        public Property Property
        {
            get { return property; }
            set 
            {
                if(property != value)
                {
                    property = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Gets or sets the policy.
        /// </summary>
        public Policy Policy
        {
            get { return policy; }
            set 
            {
                if(policy != value)
                {
                    policy = value;
                    OnPropertyChanged();
                }

            }
        }


        public AutoClaimStepOneViewModel()
        {
            
        }


    }
}
