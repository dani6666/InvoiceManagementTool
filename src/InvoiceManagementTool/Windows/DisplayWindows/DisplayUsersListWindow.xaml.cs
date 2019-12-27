﻿using InvoiceManagementTool.Core.Model.Enums;
using InvoiceManagementTool.WindowManagers.DisplayUsersList;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InvoiceManagementTool.Windows.DisplayWindows
{
    /// <summary>
    /// Interaction logic for DisplayUsersListWindow.xaml
    /// </summary>
    public partial class DisplayUsersListWindow : Window
    {
        private readonly IDisplayUsersListWindowManager _displayUsersListWindowManager;
        public DisplayUsersListWindow(IDisplayUsersListWindowManager displayUsersListWindowManager)
        {
            InitializeComponent();

            _displayUsersListWindowManager = displayUsersListWindowManager;

            foreach (var user in _displayUsersListWindowManager.GetAllUsers())
            {
                var panel = new StackPanel();
                panel.Children.Add(new TextBlock()
                {
                    Text = user.Login
                });
                panel.Children.Add(new TextBlock()
                {
                    Text = Enum.GetName(typeof(Roles), user.Role)
                });
                panel.MouseLeftButtonDown += Row_Click;

                UsersStackPanel.Children.Add(panel);
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            var userLogin = ((TextBlock)((StackPanel) sender).Children[0]).Text;

            _displayUsersListWindowManager.OpenEditUserWindow(userLogin);
        }
    }
}
