namespace Chataria.Core
{
    /// <summary>
    /// The design-time data for a <see cref="MessageBoxDialogViewModel"/>
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new();

        #endregion

        #region Constructor

        public MessageBoxDialogDesignModel()
        {
            OkText = "OKI";
            Message = "Design time messages are fun :)";
        }



        #endregion
    }
}
