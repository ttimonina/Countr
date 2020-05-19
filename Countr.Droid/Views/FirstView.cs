using Android.App;
using Android.OS;

namespace Countr.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "First View", "Tatiana: inside OnCreate() method in FirstView.cs");

            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}
