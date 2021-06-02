namespace Chataria
{
    // Styles of page aniations for appearing/disappearing
    public enum PageAnimation
    {
        /// <summary>
        /// No animation
        /// </summary>
        None = 0,

        /// <summary>
        /// The page slides in and fades in from the right
        /// </summary>
        SlideAndFadeInFromRigth = 1,

        /// <summary>
        /// The page slides out and fades out to the left
        /// </summary>
        SlideAndFadeOutToLeft = 2,

        /// <summary>
        /// The page slides in and fades in from the right
        /// </summary>
        SlideDownFromTop = 3,

        /// <summary>
        /// The page slides out and fades out to the left
        /// </summary>
        SlideUpToTop = 4,
    }
}
