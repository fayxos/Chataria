using Chataria.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Chataria
{
    /// <summary>
    /// Converts the <see cref="MainContent"/> to an actual view/page
    /// </summary>
    public static class MainContentHelpers
    {
        /// <summary>
        /// Takes a <see cref="MainContent"/> and a view model, if any, and creates the desired page
        /// </summary>
        /// <param name="content"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePageMain ToBasePageMain(this MainContent content, object viewModel = null)
        {
            // Find the appropriate page
            switch (content)
            {
                case MainContent.Person:
                    return new PersonPage(viewModel as ChatMessageListViewModel);

                case MainContent.Group:
                    return new GroupPage();

                case MainContent.Globe:
                    return new GlobusPage();

                case MainContent.Profile:
                    return new ProfilePage(viewModel as ProfileViewModel);

                case MainContent.Settings:
                    return new SettingsPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="BasePageMain"/> to the specific <see cref="MainContent"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static MainContent ToMainContent(this BasePageMain page)
        {
            // Find main content that matches the base page main
            if (page is PersonPage)
                return MainContent.Person;

            if (page is GroupPage)
                return MainContent.Group;

            if (page is GlobusPage)
                return MainContent.Globe;

            if (page is ProfilePage)
                return MainContent.Profile;

            if (page is SettingsPage)
                return MainContent.Settings;

            // Alert developer of issue
            Debugger.Break();
            return default(MainContent);
        }

    }
}

