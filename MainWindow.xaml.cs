using CashNinja.Controls;
using CashNinja.Views;
using Dragablz;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CashNinja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            App.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void HamburgerMenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {            
            foreach (var tabContainer in FindVisualChildren<TabablzControl>(this))
            {
                if (tabContainer.Name == "TabContainer")
                {
                    var menuItem = e.ClickedItem as HamburgerMenuItem;
                    TabItem ti = new TabItem();
                    ti.Header = $"{menuItem.Tag} >> {menuItem.Label}";
                    ti.Content = new Settings();
                    tabContainer.Items.Add(ti);
                    //TabablzControl.AddItem(ti,)
                }
            }
        }
    }
}
