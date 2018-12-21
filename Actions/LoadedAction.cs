#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;

using System.Windows.Controls;
using System.Windows.Threading;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Net;
using System.Xml.Linq;


namespace DataBindingDemo
{
    public class LoadedAction : TargetedTriggerAction<UserControl>
    {
        private DispatcherTimer timer;      
        protected override void Invoke(object parameter)
        {           
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();           
        }

        private TileViewItem tileItem;

        public TileViewItem TileItem
        {
            get
            {
                if (tileItem == null)
                {
                    tileItem = VisualUtils.FindAncestor(this.Target, typeof(TileViewItem)) as TileViewItem;
                }
                return tileItem;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                if (TileItem != null && TileItem.TileViewItemState == TileViewItemState.Maximized)
                {
                     
                }
            }), DispatcherPriority.ApplicationIdle);
        }


        public ListBox TweetList
        {
            get { return (ListBox)GetValue(tweetsProperty); }
            set { SetValue(tweetsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for tweets.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tweetsProperty =
            DependencyProperty.Register("TweetList", typeof(ListBox), typeof(LoadedAction), new UIPropertyMetadata(null));



        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(LoadedAction), new UIPropertyMetadata(null));

        

        

        
    }
}
