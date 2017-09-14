using MeemicMobileApp.ViewModels.MyMeemic;
using MeemicMobileApp.ViewModels.MyMeemic.IDCards;
using MeemicMobileApp.ViewModels.MyMeemic.Policies;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic.IDCards
{
    public partial class IDCardView : ContentPage
    {
        
        /// <summary>
        /// Gets the policy.
        /// </summary>
        /// <value>The policy.</value>
        public Policy Policy { get; private set; }



        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <value>The property.</value>
        public Property Property { get; private set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:MeemicMobileApp.Views.MyMeemic.IDCards.IDCardView"/> class.
        /// </summary>
        public IDCardView()
        {
            MessagingCenter.Send(this, "forceLandscape");
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<IDCardViewModel>();
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:MeemicMobileApp.Views.MyMeemic.IDCards.IDCardView"/> class.
        /// </summary>
        /// <param name="policy">Policy.</param>
        /// <param name="property">Property.</param>
        public IDCardView(Policy policy, Property property) : this()
        {

        }


    }
}
