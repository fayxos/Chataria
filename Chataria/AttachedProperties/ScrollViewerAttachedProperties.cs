﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Chataria
{

    /// <summary>
    /// Scroll an scroll viewer to the bottom when the data context changes
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we dont have a scrollviewer, return
            if (!(sender is ScrollViewer control))
                return;

            // Scroll content to bottom when cintext changes
            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged; 
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Scroll to bottom
            (sender as ScrollViewer).ScrollToBottom();
        }
    }

    /// <summary>
    /// Automatically keep the scroll at the bottom of the screen when we are already close to the bottom
    /// </summary>
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we dont have a scrollviewer, return
            if (!(sender is ScrollViewer control))
                return;

            // Scroll content to bottom when cintext changes
            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            // If we are close enough to the bottom...
            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                // Scroll to the bottom
                scroll.ScrollToBottom();
        }
    }
}
