using System;
using MeemicMobileApp.ViewModels.MyMeemic;
using Xamarin.Forms;

namespace MeemicMobileApp.Behaviors
{
    public class TabbedPageSelectionBehavior : Behavior<TabbedPage>
    {
        
        private TabbedPage tabbedPage;


        protected override void OnAttachedTo(TabbedPage bindable)
        {
            base.OnAttachedTo(bindable);

            tabbedPage = bindable;

            MessagingCenter.Subscribe<AccountSummaryViewModel>(this, "policy_details", HandlePolicyDetailsMessage);
        }



        private void HandlePolicyDetailsMessage(AccountSummaryViewModel vm)
        {
            tabbedPage.CurrentPage = tabbedPage.Children[1];

            // Setup the binding context - maybe its the SelectedItem in the VM?
        }



        protected override void OnDetachingFrom(TabbedPage bindable)
        {
            base.OnDetachingFrom(bindable);
            MessagingCenter.Unsubscribe<AccountSummaryViewModel>(this, "policy_details");
            tabbedPage = null;
        }


    }
}
