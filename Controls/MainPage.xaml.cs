using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

#region Example 6 Image 
using Windows.UI.Xaml.Media.Imaging;
#endregion

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Example 14 AutoSuggestBox

        private string[] selectionItems = new string[] { "Steve", "Ute", "Tom", "Victor", "Eve", "Glen", "Quentin", "David", "Sabrina", "Rachel", "Basil", "Tina", "Kathy", "Ivan", "Liam", "Quincey", "Ralf", "Louis", "Mick", "Gillian", "Nathan", "Ferdinand", "Iggy", "Olivia", "Paul", "Pat", "Mikayla", "Nicole", "James", "Penelope", "Amy", "Frank", "Janette", "Fiona", "Kelly", "Odin", "Ewan", "Fred", "Frida", "Amber", "Hannah", "Sacha", "Ulf", "Yasmin", "Helga", "Zac", "Candy", "Xavier", "Dan", "Nigel", "Yana", "Tag", "Zoe", "Wendy", "Tanya", "Xeon", "Becca", "Vicky", "Tanner", "William", "Todd", "Carmen" };

        #endregion

        public MainPage()
        {
            this.InitializeComponent();
            #region Example 4 ComboBox simple version set of strings

            MyComboBox.Items.Add("Added to the list in C# - Black");
            MyComboBox.Items.Add("Added to the list in C# - Pink");
            MyComboBox.Items.Add("Added to the list in C# - Rose");
            MyComboBox.Items.Add("Added to the list in C# - Gold");

            #endregion

            #region Example 5 ListBox simple version set of strings single selection

            BasicListBox.Items.Add("Added in C# - Fourth");
            BasicListBox.Items.Add("Added in C# - Fifth");
            BasicListBox.Items.Add("Added in C# - Sixth");

            #endregion
        }

        #region Example 1 Buttons

        private void MyButtonTapped_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ButtonTappedResult.Text = "Button Tapped";
        }

        private void MyButtonClicked_Click(object sender, RoutedEventArgs e)
        {
            ButtonClickedResult.Text = "Button Clicked";
        }

        #endregion

        #region Example 2 CheckBox

        // Two-state CheckBox
        private void CheckBoxTwoState_Unchecked(object sender, RoutedEventArgs e)
        {
            TwoStateTextBlock.Text = "Two-state CheckBox unchecked";
        }

        private void CheckBoxTwoState_Checked(object sender, RoutedEventArgs e)
        {
            TwoStateTextBlock.Text = "Two-state CheckBox checked";
        }

        // Three-state CheckBox
        private void CheckBoxThreeState_Unchecked(object sender, RoutedEventArgs e)
        {
            ThreeStateTextBlock.Text = "Three-state CheckBox unchecked";
        }

        private void CheckBoxThreeState_Checked(object sender, RoutedEventArgs e)
        {
            ThreeStateTextBlock.Text = "Three-state CheckBox checked";
        }

        private void CheckBoxThreeState_Indeterminate(object sender, RoutedEventArgs e)
        {
            ThreeStateTextBlock.Text = "Three-state CheckBox indeterminate";
        }

        #endregion

        #region Example 3 RadioButton

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            TopRadioButton.Text = "You chose: " + rb.GroupName + ": " + rb.Name;
            BottomRadioButton.Text = "You chose: " + rb.GroupName + ": " + rb.Name;
        }

        private void SoloButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            SoloRadioButton.Text = "You chose: " + rb.Name;
        }

        #endregion

        #region Example 4 ComboBox simple version set of strings
        private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxResult.Text = MyComboBox.SelectedItem.ToString() + " selected";
        }
        #endregion

        #region Example 4 ComboBox with ComboBoxItems objects 

        private void ExtendedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExtendedComboBoxResult == null) return;

            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            ExtendedComboBoxResult.Text = item.Content.ToString() + " selected";
        }

        #endregion

        #region Example 5 ListBox simple version set of strings single selection
        private void BasicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BasicListBoxResult.Text = BasicListBox.SelectedItem.ToString() + " selected";

        }

        #endregion

        #region Example 5 ListBox with ListBoxItems objects 

        private void MultiListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = MultiListBox.Items.Cast<ListBoxItem>()
                                                  .Where(p => p.IsSelected)
                                                  .Select(t => t.Content.ToString())
                                                  .ToArray();

            MultiListBoxResult.Text = string.Join(", ", selectedItems);
        }

        #endregion

        #region Example 6 Image 
        private void AnImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AnImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/sea.gif", UriKind.RelativeOrAbsolute));

            // The default version
            //AnImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/sea.gif"));

            // The lonhand version
            //BitmapImage bitmapImage = new BitmapImage();
            //Uri uri = new Uri("ms-appx:///Assets/sea.gif");
            //bitmapImage.UriSource = uri;
            //AnImage.Source = bitmapImage;


            // Alternative method
            //BitmapImage bitmapImage = new BitmapImage();
            //bitmapImage.UriSource = new Uri(this.BaseUri, "Assets/sea.gif");
            //AnImage.Source = bitmapImage;
        }
        #endregion

        #region Example 7 ToggleButton 
        private void MyToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyToggleButton.IsChecked == true)
            {
                ToggleButtonResult.Text = "Checked is " + MyToggleButton.IsChecked.ToString();
                ToggleButtonResult.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
            }
            else if (MyToggleButton.IsChecked == false)
            {
                ToggleButtonResult.Text = "Checked is " + MyToggleButton.IsChecked.ToString();
                ToggleButtonResult.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            }
            else
            {
                ToggleButtonResult.Text = "Checked is Indeterminate ";
                ToggleButtonResult.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            }
        }

        #endregion

        #region Example 8 ToggleSwitch 
        private void MyToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (MyToggleSwitch.IsOn == true) ToggleSwitchResult.Text = "Result is true - on";
            else ToggleSwitchResult.Text = "Result is false - off";
        }

        #endregion

        #region Example 9 TimePicker 

        private void MyTimePicker_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            TimePickerResult.Text = "You selected " + e.NewTime.ToString();
        }

        #endregion

        #region Example 10 DatePicker

        private void MyCalendarDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (MyCalendarDatePicker.Date != null)
            {
                DatePickerResult.Text = "You selected " + MyCalendarDatePicker.Date.Value.Day.ToString() + " " +
                                                          MyCalendarDatePicker.Date.Value.Month.ToString() + " " +
                                                          MyCalendarDatePicker.Date.Value.Year.ToString();

                // Can also use this format
                //DatePickerResult.Text = "You selected " + args.NewDate.Value.Day.ToString() + " " +
                //                                          args.NewDate.Value.Month.ToString() + " " +
                //                                          args.NewDate.Value.Year.ToString();

                // Setting a date in code
                //MyCalendarDatePicker.Date = new DateTime(1977, 1, 5);
            }
            else
            {
                DatePickerResult.Text = "Choose a date";
            }
        }
        #endregion

        #region Example 11 CalendarView

        private void MyCalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            var selectedDates = sender.SelectedDates.Select(p => p.Date.Month.ToString() + "/" + p.Date.Day.ToString()).ToArray();
            var values = string.Join(", ", selectedDates);
            CalendarViewResult.Text = values;
        }

        #endregion

        #region Example 12 Flyout Button

        private void InnerFlyoutButton_Click(object sender, RoutedEventArgs e)
        {
            MyFlyout.Hide();
        }


        #endregion

        #region Example 13 Menu Flyout 

        private void Item1_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutResult.Text = "Menu item 1 selected";
        }

        private void Item2_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutResult.Text = "Menu item 2 selected";
        }

        private void Item4_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutResult.Text = "Menu item 4 selected";
        }

        private void Item6_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutResult.Text = "Menu item 6 selected";
        }

        private void Item7_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutResult.Text = "Menu item 7 selected";
        }

        private void Item8_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutResult.Text = "Menu item 8 selected";

            if (Item8.IsChecked == true) MenuFlyoutResult.Text = MenuFlyoutResult.Text + " toggel ticked";
            else MenuFlyoutResult.Text = MenuFlyoutResult.Text + " toggel unticked";
        }

        #endregion

        #region Example 14 AutoSuggestBox

        private void MyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            var filtered = selectionItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;

            AutoSuggestBoxhResult.Text = "You selected " + sender.Text.ToString();
        }

        #endregion

        #region Example 15 Slider        
        private void MySlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SliderhResult.Text = String.Format("Current value: {0}", e.NewValue);
        }

        #endregion

        #region Example 16 ProgressBar            

        private void ProgressBarButton_Click(object sender, RoutedEventArgs e)
        {
            if ((MyProgressBar.Value < MyProgressBar.Maximum) && (MyProgressBar.IsIndeterminate == false))
            {
                MyProgressBar.Value = MyProgressBar.Value + 5;
            }

            if (MyProgressBar.IsIndeterminate == true)
            {
                MyProgressBar.IsIndeterminate = false;
                ProgressBarButton.Content = "Progress Click";
            }

            if (MyProgressBar.Value >= MyProgressBar.Maximum)
            {
                MyProgressBar.Value = MyProgressBar.Minimum;
                MyProgressBar.IsIndeterminate = true;
                ProgressBarButton.Content = "Reset Click";
            }
        }

        #endregion

        #region Example 17 ProgressRing           

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;

            if ((toggleSwitch != null) && (MyProgressRing != null))
            {
                if (toggleSwitch.IsOn == true)
                {
                    MyProgressRing.IsActive = true;
                    MyProgressRing.Visibility = Visibility.Visible;
                }
                else
                {
                    MyProgressRing.IsActive = false;
                    MyProgressRing.Visibility = Visibility.Collapsed;
                }
            }
        }

        #endregion
    }
}

