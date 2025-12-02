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

                FirstName.Text = EditPassports.FirstName;

                LastName.Text = EditPassports.LastName;

                Issued.Text = EditPassports.Issued;

                DateOfIssued.Text = EditPassports.DateOfIssued;

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

            if (string.IsNullOrEmpty(LastName.Text) || !Classes.Common.CheckRegex.Match("^[a-яA-Я]*$", LastName.Text))
            {
                MessageBox.Show("Не правильно указано отчество пользователя");

                return;

            }

            if (string.IsNullOrEmpty(Issued.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я\\s.,-]*$", Issued.Text))
            {
                MessageBox.Show("Не правильно указано поле 'паспорт выдан'");
                return;
            }

            if (string.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match("^\\d{2}\\.\\d{2}\\.\\d{4}$", DateOfIssued.Text))
            {
                MessageBox.Show("Не правильно указано поле 'дата выдачи'");
                return;
            }

            if (string.IsNullOrEmpty(DepartmentCode.Text) || !Classes.Common.CheckRegex.Match("^\\d{3}-\\d{3}$", DepartmentCode.Text))
            {
                MessageBox.Show("Не правильно указано поле 'код подразделения'");
                return;
            }

            if (string.IsNullOrEmpty(SeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match("^\\d{4}\\s\\d{6}$", SeriesAndNumber.Text))
            {
                MessageBox.Show("Не правильно указано поле 'серия и номер'");
                return;
            }

            if (string.IsNullOrEmpty(DateOfBirth.Text) || !Classes.Common.CheckRegex.Match("^\\d{2}\\.\\d{2}\\.\\d{4}$", DateOfBirth.Text))
            {
                MessageBox.Show("Не правильно указано поле 'дата рождения'");
                return;
            }

            if (string.IsNullOrEmpty(PlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-Я\\s.,-]*$", PlaceOfBirth.Text))
            {
                MessageBox.Show("Не правильно указано поле 'место рождения'");
                return;
            }

            if (EditPassports == null) {

                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
           
            }

            EditPassports.Name = Name.Text;
            EditPassports.FirstName = FirstName.Text;
            EditPassports.LastName = LastName.Text;
            EditPassports.Issued = Issued.Text;
            EditPassports.DateOfIssued = DateOfIssued.Text;
            EditPassports.DepartmentCode = DepartmentCode.Text;
            EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassports.DateOfBirth = DateOfBirth.Text;
            EditPassports.PlaceOfBirth = PlaceOfBirth.Text;

            MainWindow.init.LoadPassport();

            this.Close();
        }
    }
}
