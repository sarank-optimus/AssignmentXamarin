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
    public class DeleteEmployee : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Employee _employee = new Employee();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public DeleteEmployee()
        {
            this.Title = "Delete Employee";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Employee>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;

            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _button_clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _employee = (Employee)e.SelectedItem;
        }
        private async void _button_clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Employee>().Delete(x => x.Id == _employee.Id);
            await Navigation.PopAsync();
        }
    }
}