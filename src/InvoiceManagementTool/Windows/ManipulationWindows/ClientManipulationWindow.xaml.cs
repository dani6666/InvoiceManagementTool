using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model;
using System.Windows;

namespace InvoiceManagementTool.Windows
{
    public partial class ClientManipulationWindow : IParametaisedWindow<Client>
    {
        private readonly IClientsService _clientsService;
        private string _originalClientIdentity = string.Empty;
        public ClientManipulationWindow(IClientsService clientsService)
        {
            InitializeComponent();

            _clientsService = clientsService;
        }

        public void SetParameter(Client parameter)
        {
            Title = "Update client";
            ApplyButton.Content = "Update client";

            _originalClientIdentity = parameter.Identity;

            IdentityTextBox.Text = parameter.Identity;
            NameTextBox.Text = parameter.Name;
            SurnameTextBox.Text = parameter.SurName;
            BirthDatePicker.SelectedDate = parameter.DateOfBirth;
        }

        private void UpdateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (BirthDatePicker.SelectedDate.HasValue)
            {
                var client = new Client
                {
                    Identity = IdentityTextBox.Text,
                    Name = NameTextBox.Text,
                    SurName = SurnameTextBox.Text,
                    DateOfBirth = BirthDatePicker.SelectedDate.Value
                };

                try
                {
                    if (_originalClientIdentity != string.Empty)
                    {
                        _clientsService.UpdateClient(client, _originalClientIdentity);
                    }
                    else
                    {
                        _clientsService.AddClient(client);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid data input");
                }

                Close();
            }
            else
            {
                MessageBox.Show("Invalid data format");
            }
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
    }
}
