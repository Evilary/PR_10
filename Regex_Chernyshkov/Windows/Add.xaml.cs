using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Regex_Chernyshkov.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {

        Classes.Passport EditPassports;
        public Add(Classes.Passport EditPassports)
        {
            InitializeComponent();

            if (EditPassports != null)
            {

                Name.Text = EditPassports.Name;

                FirstName.Text = EditPassports.Firstname;

                LastName.Text = EditPassports.Lastname;

                Issued.Text = EditPassports.Issued;

                DateOfIssued.Text = EditPassports.DateOFIssued;

                DepartmentCode.Text = EditPassports.DepartmentCode;

                SeriesAndNumber.Text = EditPassports.SeriesAndNumber;

                DateOfBirth.Text = EditPassports.DateOfBirth;

                PlaceOfBirth.Text = EditPassports.PlaceOfBirth;

                this.EditPassports = EditPassports;

                BtnAdd.Content = "Изменить";



            }

        }

        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", Name.Text))
            {
                MessageBox.Show("Не правильно указано имя пользователя");

                return;

            }

            if (string.IsNullOrEmpty(FirstName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", FirstName.Text))
            {
                MessageBox.Show("Не правильно указана фамилия пользователя");

                return;

            }

            if (string.IsNullOrEmpty(LastName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", LastName.Text))
            {
                MessageBox.Show("Не правильно указано отчество пользователя");

                return;

            }

            if (EditPassports == null) {

                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
           
            }

            EditPassports.Name = Name.Text;
            EditPassports.Firstname = FirstName.Text;
            EditPassports.Lastname = LastName.Text;
            EditPassports.Issued = Issued.Text;
            EditPassports.DateOFIssued = DateOfIssued.Text;
            EditPassports.DepartmentCode = DepartmentCode.Text;
            EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassports.DateOfBirth = DateOfBirth.Text;
            EditPassports.PlaceOfBirth = PlaceOfBirth.Text;

            MainWindow.init.LoadPassport();

            this.Close();
        }
    }
}
