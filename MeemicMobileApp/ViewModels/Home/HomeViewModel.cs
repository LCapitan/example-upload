using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;

namespace MeemicMobileApp.ViewModels.Home
{
    /// <summary>
    /// Home View Model
    /// 
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        private HomeMeemicViewModel meemicViewModel;
        private HomeFoundationViewModel foundationViewModel;
        private bool isFoundationMember;
        private bool isMeemicMember;


        /// <summary>
        /// Home Meemic ViewModel
        /// </summary>
        public HomeMeemicViewModel MeemicViewModel
        {
            get { return meemicViewModel; }
            set
            {
                if(meemicViewModel != value)
                {
                    meemicViewModel = value;
                    OnPropertyChanged();
                }
            }

        }



        /// <summary>
        /// Foundation ViewModel
        /// </summary>
        public HomeFoundationViewModel FoundationViewModel
        {
            get { return foundationViewModel; }
            set 
            {
                if (foundationViewModel != value)
                {
                    foundationViewModel = value;
                    OnPropertyChanged();
                }
            }

        }



        /// <summary>
        /// Is the user a Foundation Club Member?
        /// </summary>
        public bool IsFoundationMember
        {
            get { return isFoundationMember; }
            set
            {
                if(isFoundationMember != value) 
                {
                    isFoundationMember = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Is the user a Meemic Member?
        /// </summary>
        public bool IsMeemicMember
        {
            get { return isMeemicMember; }
            set 
            {
                if(isMeemicMember != value) 
                {
                    isMeemicMember = value;
                    OnPropertyChanged();
                }
            }
        }
       

        public HomeViewModel()
        {
            IsMeemicMember = true;
            IsFoundationMember = true;
        }

    }
}
