using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NTPapp
{
    public class DisplayTime : ContentPage
    {
        Label label = new Label();
        Button button = new Button() { Text = "refresh" };
        public DisplayTime()
        {
            button.Clicked += Button_Clicked;
            var stacklayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical
                
            };
            stacklayout.Children.Add(label);
            stacklayout.Children.Add(button);
            this.Content = stacklayout;
            LoadLabel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            label.Text = "";
            LoadLabel();
        }

        private void LoadLabel()
        {
            for (int i = 0; i < 10; i++)
            {
                var ntpTime = GetNtpTime.GetNetworkTime();
                var skew = DateTime.Now - ntpTime;

                label.Text = label.Text + ntpTime.ToString() + "." + ntpTime.Millisecond +
                    " skew(ms) = " + skew.TotalMilliseconds + Environment.NewLine;
            }
        }
    }
}
