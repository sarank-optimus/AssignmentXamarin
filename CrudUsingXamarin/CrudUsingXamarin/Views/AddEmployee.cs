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
    public class AddEmployee : ContentPage
    {

        private Entry _nameEntry;
        private Entry _addressEntry;
        private Entry _genderEntry;
        private Entry _imageEntry;
        private Entry _mobileEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public AddEmployee()
        {
            this.Title = "Add Employee";
            StackLayout stackLayout = new StackLayout();
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

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Employee>();
            var maxPk = db.Table<Employee>().OrderByDescending(c => c.Id).FirstOrDefault();

            Employee employee = new Employee()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = _nameEntry.Text,
                Address = _addressEntry.Text,
                Gender = _genderEntry.Text,
                Image = _imageEntry.Text,
                Mobile = _mobileEntry.Text
            };
            db.Insert(employee);
            await DisplayAlert(null, employee.Name + " Saved", "Ok");
            await Navigation.PopAsync();
        }
    }
}