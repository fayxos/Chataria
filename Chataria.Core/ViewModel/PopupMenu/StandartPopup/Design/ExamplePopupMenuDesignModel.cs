namespace Chataria.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class ExamplePopupMenuDesignModel : BasePopupViewModel
    {
        #region Singleton

        /// <summary>-
        /// A single instance of the design model
        /// </summary>
        public static ExamplePopupMenuDesignModel Instance => new();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ExamplePopupMenuDesignModel()
        {

        }

        #endregion
    }
}
