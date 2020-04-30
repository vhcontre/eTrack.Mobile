using Xamarin.Forms;

namespace eTrack.Mobile.Services
{
    public class NumberValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            int result;

            bool isValid = int.TryParse(args.NewTextValue, out result);

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }

    public class MaxLengthValidatorBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidatorBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }
        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= MaxLength)
                ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }
    }
}
