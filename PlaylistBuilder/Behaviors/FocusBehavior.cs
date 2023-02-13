using System;
using System.Runtime.CompilerServices;

namespace PlaylistBuilder.Behaviors
{
    public class FocusBehavior : Behavior<View>
    {
        private View currentView;

        public static BindableProperty IsFocusedProperty = BindableProperty.Create(nameof(IsFocused), typeof(bool), typeof(FocusBehavior));

        public bool IsFocused
        {
            get => (bool)GetValue(IsFocusedProperty);
            set => SetValue(IsFocusedProperty, value);
        }

        public FocusBehavior()
        {
        }

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);

            currentView = bindable;
            currentView.Unfocused += CurrentView_Unfocused;
        }

        private void CurrentView_Unfocused(object sender, FocusEventArgs e)
        {
            IsFocused = false;
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);

            currentView.Unfocused -= CurrentView_Unfocused;
            currentView = null;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == nameof(IsFocused) && IsFocused && currentView != null)
            {
                currentView.Focus();
            }
        }
    }
}

