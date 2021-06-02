namespace Chataria.Core
{
    /// <summary>
    /// The design-time data for a <see cref="TextEntryViewModel"/>
    /// </summary>
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance
        /// </summary>
        public static TextEntryDesignModel Instance => new();

        #endregion

        #region Constructor

        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Felix Haag";
            EditedText = "Editing :)";
        }



        #endregion
    }
}
