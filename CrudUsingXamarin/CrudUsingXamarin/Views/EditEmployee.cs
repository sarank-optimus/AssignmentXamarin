using CrudUsingXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CrudUsingXamarin.Views
{
    public class EditEmployee : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Entry _genderEntry;
        private Entry _imageEntry;
        private Entry _mobileEntry;
        private Button _button;

        Employee _employee = new Employee();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public EditEmployee()
        {
            this.Title = "Edit Employee";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Employee>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;

            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Name";
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(_addressEntry);

            _genderEntry = new Entry();
            _genderEntry.Keyboard = Keyboard.Text;
            _genderEntry.Placeholder = "Gender";
            stackLayout.Children.Add(_genderEntry);

            _imageEntry = new Entry();
            _imageEntry.Keyboard = Keyboard.Text;
            _imageEntry.Placeholder = "Image";
            stackLayout.Children.Add(_imageEntry);

            _mobileEntry = new Entry();
            _mobileEntry.Keyboard = Keyboard.Text;
            _mobileEntry.Placeholder = "Mobile No.";
            stackLayout.Children.Add(_mobileEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void _button_clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Employee employee = new Employee()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Address = _addressEntry.Text,
                Gender = _genderEntry.Text,
                Image = _imageEntry.Text,
                Mobile = _mobileEntry.Text
            };
            db.Update(employee);
            await Navigation.PopAsync();
        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _employee = (Employee)e.SelectedItem;
            _idEntry.Text = _employee.Id.ToString();
            _nameEntry.Text = _employee.Name;
            _addressEntry.Text = _employee.Address;
            _genderEntry.Text = _employee.Gender;
            _imageEntry.Text = _employee.Image;
            _mobileEntry.Text = _employee.Mobile;
        }
    }
}