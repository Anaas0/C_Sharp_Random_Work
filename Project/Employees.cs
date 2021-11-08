using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Freddies
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        Freddies EmFred = new Freddies();

        private void Employees_Load(object sender, EventArgs e)
        {
            TxtBEmployeeID.DataBindings.Add("Text", EmFred.GetTblEmployees, "EmployeeID");
            TxtBTitle.DataBindings.Add("Text", EmFred.GetTblEmployees, "Title");
            TxtBSurname.DataBindings.Add("Text", EmFred.GetTblEmployees, "Surname");
            TxtBForename.DataBindings.Add("Text", EmFred.GetTblEmployees, "Forename");
            TxtBDateOfBirth.DataBindings.Add("Text", EmFred.GetTblEmployees, "DateOfBirth");
            TxtBMobileNumber.DataBindings.Add("Text", EmFred.GetTblEmployees, "MobileNumber");
            TxtBReportsTo.DataBindings.Add("Text", EmFred.GetTblEmployees, "ReportTo");
            TxtBAddress.DataBindings.Add("Text", EmFred.GetTblEmployees, "Address");
            TxtBCity.DataBindings.Add("Text", EmFred.GetTblEmployees, "City");
            TxtBRegion.DataBindings.Add("Text", EmFred.GetTblEmployees, "Region");
            TxtBPostalCode.DataBindings.Add("Text", EmFred.GetTblEmployees, "PostalCode");
            TxtBCountry.DataBindings.Add("Text", EmFred.GetTblEmployees, "Country");
            TxtBHireDate.DataBindings.Add("Text", EmFred.GetTblEmployees, "HireDate");
            TxtBHomePhone.DataBindings.Add("Text", EmFred.GetTblEmployees, "HomePhone");
            TxtBNotes.DataBindings.Add("Text", EmFred.GetTblEmployees, "Notes");

            ComBoxEmployee.DataSource = EmFred.GetTblEmployees;
            ComBoxEmployee.DisplayMember = "Surname";
            BindingContext[EmFred.GetTblEmployees].PositionChanged += new System.EventHandler(ComBoxEmployee_SelectedValueChanged);

            TxtBEmployeeID.Enabled = false;
            TxtBTitle.Enabled = false;
            TxtBSurname.Enabled = false;
            TxtBForename.Enabled = false;
            TxtBDateOfBirth.Enabled = false;
            TxtBMobileNumber.Enabled = false;
            TxtBReportsTo.Enabled = false;
            TxtBAddress.Enabled = false;
            TxtBCity.Enabled = false;
            TxtBRegion.Enabled = false;
            TxtBPostalCode.Enabled = false;
            TxtBCountry.Enabled = false;
            TxtBHireDate.Enabled = false;
            TxtBHomePhone.Enabled = false;
            TxtBNotes.Enabled = false;

            PositionLabelUpdate();

        }

        private void TxtBEmployeeID_TextChanged(object sender, EventArgs e){}

        private void TxtBTitle_TextChanged(object sender, EventArgs e){}

        private void TxtBSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBForename_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBDateOfBirth_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBMobileNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBReportsTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBRegion_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBPostalCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBHireDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBHomePhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void Employees_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            BindingContext[EmFred.GetTblEmployees].Position = 0;//first record
            PositionLabelUpdate();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            BindingContext[EmFred.GetTblEmployees].Position--;//Previous record
            PositionLabelUpdate();
        }

        private void LbPosition_Click(object sender, EventArgs e)
        {

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            BindingContext[EmFred.GetTblEmployees].Position++;//Next Record
            PositionLabelUpdate();
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            BindingContext[EmFred.GetTblEmployees].Position = BindingContext[EmFred.GetTblEmployees].Count - 1;//Last record
            PositionLabelUpdate();
        }

        private void PositionLabelUpdate()
        {
            string FormattedPosition;
            FormattedPosition = string.Format("{0} of {1}", BindingContext[EmFred.GetTblEmployees].Position + 1, BindingContext[EmFred.GetTblEmployees].Count);
            LbPosition.Text = FormattedPosition;
        }

        private void ComBoxEmployee_SelectedIndexChanged(object sender, EventArgs e){}

        private void ComBoxEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRow SelectedCategory;
            int Position;
            string EmployeeSurname;

            Position = BindingContext[EmFred.GetTblEmployees].Position;
            if (Position == -1) Position = 1;
            SelectedCategory = EmFred.GetTblEmployees.Rows[Position];
            EmployeeSurname = SelectedCategory.Field<string>("Surname");

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            /*BindingContext[EmFred.GetTblEmployees].Position = BindingContext[EmFred.GetTblEmployees].Position + 1;
            BindingContext[EmFred.GetTblEmployees].Position = BindingContext[EmFred.GetTblEmployees].Position - 1;
            EmFred.UpdateEmployeeTable();*/
            string outEmployeeID, outSurname, outForename, outTitle, outDateOfBirth, outAddress, outCity, outRegion, outPostalCode, outCountry, outHireDate, outHomePhone, outMobileNumber, outNotes, outReportsTo;
            outEmployeeID = TxtBEmployeeID.Text;
            outSurname = TxtBSurname.Text;
            outForename = TxtBForename.Text;
            outTitle = TxtBTitle.Text;
            outDateOfBirth = TxtBDateOfBirth.Text;
            outAddress = TxtBAddress.Text;
            outCity = TxtBCity.Text;
            outRegion = TxtBRegion.Text;
            outPostalCode = TxtBPostalCode.Text;
            outCountry = TxtBCountry.Text;
            outHireDate = TxtBHireDate.Text;
            outHomePhone = TxtBHomePhone.Text;
            outMobileNumber = TxtBMobileNumber.Text;
            outNotes = TxtBNotes.Text;
            outReportsTo = TxtBReportsTo.Text;
            EmFred.EmployeesUPDATE(outEmployeeID, outSurname, outForename, outTitle, outDateOfBirth, outAddress, outCity, outRegion, outPostalCode, outCountry, outHireDate, outHomePhone, outMobileNumber, outNotes, outReportsTo);
        }

        private void CBEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (CBEdit.Checked == false)
            {                
                TxtBTitle.Enabled = false;
                TxtBSurname.Enabled = false;
                TxtBForename.Enabled = false;
                TxtBDateOfBirth.Enabled = false;
                TxtBMobileNumber.Enabled = false;
                TxtBReportsTo.Enabled = false;
                TxtBAddress.Enabled = false;
                TxtBCity.Enabled = false;
                TxtBRegion.Enabled = false;
                TxtBPostalCode.Enabled = false;
                TxtBCountry.Enabled = false;
                TxtBHireDate.Enabled = false;
                TxtBHomePhone.Enabled = false;
                TxtBNotes.Enabled = false;
            }
            else if (CBEdit.Checked == true)
            {
                TxtBTitle.Enabled = true;
                TxtBSurname.Enabled = true;
                TxtBForename.Enabled = true;
                TxtBDateOfBirth.Enabled = true;
                TxtBMobileNumber.Enabled = true;
                TxtBReportsTo.Enabled = true;
                TxtBAddress.Enabled = true;
                TxtBCity.Enabled = true;
                TxtBRegion.Enabled = true;
                TxtBPostalCode.Enabled = true;
                TxtBCountry.Enabled = true;
                TxtBHireDate.Enabled = true;
                TxtBHomePhone.Enabled = true;
                TxtBNotes.Enabled = true;
            }
        }

        private void BtnNewEntry_Click(object sender, EventArgs e)
        {
            EmployeesNewRecord Lauch = new EmployeesNewRecord();
            Lauch.ShowDialog();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog EmployeeFileSave = new SaveFileDialog();
            string FileName;
            StreamWriter WriteFile;
            EmployeeFileSave.Title = "Export";
            EmployeeFileSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            EmployeeFileSave.DefaultExt = "csv";
            EmployeeFileSave.Filter = "(*.csv) | *.csv";
            EmployeeFileSave.FilterIndex = 1;
            if (EmployeeFileSave.ShowDialog() == DialogResult.OK)
            {
                FileName = EmployeeFileSave.FileName;
                try
                {
                    WriteFile = new StreamWriter(FileName, false);
                    WriteFile.WriteLine("EmployeeID,Surname,Forename,Title,DateOfBirth,Address,Address,City,Region,PostalCode,Country,HireDate,HomePhone,MobilePhone,Notes,ReportTo");
                    foreach (DataRow Employees in EmFred.GetTblEmployees.Rows)
                    {
                        WriteFile.Write("{0},", Employees.Field<int>("EmployeeID"));
                        WriteFile.Write("{0},", Employees.Field<string>("Surname"));
                        WriteFile.Write("{0},", Employees.Field<string>("Forename"));
                        WriteFile.Write("{0},", Employees.Field<string>("Title"));
                        WriteFile.Write("{0},", Employees.Field<DateTime>("DateOfBirth"));
                        WriteFile.Write("{0},", Employees.Field<string>("Address"));
                        WriteFile.Write("{0},", Employees.Field<string>("City"));
                        WriteFile.Write("{0},", Employees.Field<string>("Region"));
                        WriteFile.Write("{0},", Employees.Field<string>("PostalCode"));
                        WriteFile.Write("{0},", Employees.Field<string>("Country"));
                        WriteFile.Write("{0},", Employees.Field<DateTime?>("HireDate"));
                        WriteFile.Write("{0},", Employees.Field<string>("HomePhone"));
                        WriteFile.Write("{0},", Employees.Field<string>("MobileNumber"));
                        WriteFile.Write("{0},", Employees.Field<string>("Notes"));
                        WriteFile.Write("{0},", Employees.Field<string>("ReportTo"));
                        WriteFile.WriteLine();
                    }
                    WriteFile.Close();
                    MessageBox.Show(string.Concat("File exported: ", FileName), "File Export successful", MessageBoxButtons.OK);
                }
                catch (Exception)
                {

                    throw new Exception("Write Error");
                }                   
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string outEmployeeID;

            outEmployeeID = TxtBEmployeeID.Text;  

            EmFred.EmployeesDELETE(outEmployeeID);
        }
    }
}
