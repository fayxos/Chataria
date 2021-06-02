using System.Windows.Controls;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System;
using System.Windows.Media.Animation;
using System.Threading.Tasks;

namespace Chataria
{
    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slides a page in from the right
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">time of animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            // Create the Storyboard
            var sb = new Storyboard();

            // Add slide from rigth animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start Animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Slides a page out to the left
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">time of animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float seconds)
        {
            // Create the Storyboard
            var sb = new Storyboard();

            // Add slide from rigth animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            // Add fade in animation
            sb.AddFadeOut(seconds);

            // Start Animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page down from top
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">time of animation</param>
        /// <returns></returns>
        public static async Task SlideDownFromTopAsync(this Page page, float seconds)
        {
            // Create the Storyboard
            var sb = new Storyboard();

            // Add slide from rigth animation
            sb.AddSlideFromTop(seconds, page.ActualHeight);

            // Start Animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page down from top
        /// </summary>
        /// <param name="page">page to animate</param>
        /// <param name="seconds">time of animation</param>
        /// <returns></returns>
        public static async Task SlideUpToTopAsync(this Page page, float seconds)
        {
            // Create the Storyboard
            var sb = new Storyboard();

            // Add slide from rigth animation
            sb.AddSlideToTop(seconds, page.ActualHeight);

            // Start Animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
