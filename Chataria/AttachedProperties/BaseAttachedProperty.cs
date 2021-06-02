using System;
using System.Windows;

namespace Chataria
{
    /// <summary>
    /// A base attached prperty replace the vanilla WPF attached Property
    /// </summary>
    /// <typeparam name="Parent">The parent class to be the attached property</typeparam>
    /// <typeparam name="Property">The type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        #region Public Events

        /// <summary>
        /// Fierd when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// Fierd when the value changes, even when the value is the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// A singleton instance of our parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitiopns

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value", 
            typeof(Property), 
            typeof(BaseAttachedProperty<Parent, Property>), 
            new PropertyMetadata(
                default(Property),
                new PropertyChangedCallback(OnValuePropertyChanged),
                new CoerceValueCallback(OnValuePropertyUpdated)
                ));

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <typeparam name="d">The UI element that had it's property changed</typeparam>
        /// <typeparam name="e">The arguments for the event</typeparam>  
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);

            // Call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed, even if it's the same value
        /// </summary>
        /// <typeparam name="d">The UI element that had it's property changed</typeparam>
        /// <typeparam name="e">The arguments for the event</typeparam>  
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // Call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);

            // Call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            return value;
        }

        /// <summary>
        /// Get's the attached property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// set the attached Property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);



        #endregion

        #region Event Methods

        /// <summary>
        /// The method is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">the UI element that this property was changed for</param>
        /// <param name="e">The argument for this event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// The method is called when any attached property of this type is changed, even if the value is the same
        /// </summary>
        /// <param name="sender">the UI element that this property was changed for</param>
        /// <param name="e">The argument for this event</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }


        #endregion
    }

}
