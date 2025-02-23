using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnlineHaine
{
    public class ValidationBehavior : Behavior<Entry>
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

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender is Entry entry)
            {
                if (string.IsNullOrEmpty(args.NewTextValue) || !double.TryParse(args.NewTextValue, out _))
                {
                    entry.BackgroundColor = Color.FromRgba("#AA4A44");
                }
                else
                {
                    entry.BackgroundColor = Colors.Transparent;
                }
            }
        }
    }
}
