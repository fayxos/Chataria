﻿using Chataria.Core;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Chataria
{
    /// <summary>
    /// Interaktionslogik für LoginPage.xaml
    /// </summary>
    public partial class MainPage : BasePage<ChatMessageListViewModel>
    {
        #region Public Properties

        public string[] EmojiStringList { get; set; } = new string[]
        {
            "😀", "😂", "😎", "😋", "😍", "🙄", "😴", "🤐", "🤑", "🥱", "😭", "😡", "🤢", "😇", "🥺", "😕"
        };

        public static ChatMessageListViewModel PersonViewModel { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel"></param>
        public MainPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
            PersonViewModel = specificViewModel;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Change emoji button icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            bool isSame = true;
            while (isSame)
            {
                string oldEmoji = (string)AA.Content;
                Random rand = new(); //Random
                string newEmoji = (string)EmojiStringList.GetValue(rand.Next(0, 16));
                if (oldEmoji != newEmoji)
                {
                    isSame = false;
                    AA.Content = newEmoji;
                }
            }
        }

        /// <summary>
        /// Preview the input into the message box and respond as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Check if we have pressed enter
            if (e.Key == Key.Enter)
            {
                // Check if we have pressed ctrl + enter or shift + enter
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control) || Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                {
                    // Get the textbox
                    var textbox = sender as TextBox;

                    // Add a new line at textbox
                    var index = textbox.CaretIndex;

                    // Insert the new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    // Shift the caret forward to the new line
                    textbox.CaretIndex = index + Environment.NewLine.Length;

                    // Mark this key as handled by us
                    e.Handled = true;
                }
                else
                    // Send the message
                    ViewModel.Send();

                // Mark this key as handled by us
                e.Handled = true;
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            // Make sure UI exists first
            if (ChatMessageList == null)
                return;

            // Fade in chat message list
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);

            // Make the message box focused
            MessageText.Focus();
        }



        #endregion

        private void MessageText_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string fileName = Path.GetFullPath(files[0]);

                string[] items = fileName.Split(@"\");
                string lastItem = items[items.Length - 1];
                string projectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Split(@"bin")[0];
                string savePath = projectPath + "/Storage/Images/" + lastItem;

                try
                {
                    File.Copy(fileName, savePath);
                }
                catch { }
                finally
                {
                    // Temporal fix (remove later)
                    if (IoC.Application.CurrentPageViewModel == null)
                        IoC.Application.CurrentPageViewModel = new ChatMessageListViewModel();

                    // Set Local Storage Path
                    (IoC.Application.CurrentPageViewModel as ChatMessageListViewModel).LocalImagePath = savePath;
                    (IoC.Application.CurrentPageViewModel as ChatMessageListViewModel).SendImageOverlayVisible = true;
                }

            }
        }
    }
}
