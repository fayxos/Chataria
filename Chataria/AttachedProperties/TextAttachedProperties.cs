using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Chataria
{

    /// <summary>
    /// Focuses this element on load with keyboard
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we dont have a control, return
            if (!(sender is Control control))
                return;

            // Focus this control once loaded
            control.Loaded += (s, se) => control.Focus();
        }
    }

    /// <summary>
    /// Focuses (keyboard focus) and selects all etxt in this element if true
    /// </summary>
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we dont have a control, return
            if (sender is TextBoxBase control)
            {
                if ((bool)e.NewValue)
                {
                    // Focus this textbox
                    control.Focus();

                    // Select all text
                    control.SelectAll();
                }
            }

            // If we dont have a control, return
            if (sender is PasswordBox password)
            {
                if ((bool)e.NewValue)
                {
                    // Focus this textbox
                    password.Focus();

                    // Select all text
                    password.SelectAll();
                }
            }
        }
    }
}
