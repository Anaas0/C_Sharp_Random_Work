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
    public partial class ShopRotas : Form
    {
        public ShopRotas()
        {
            InitializeComponent();
        }
        bool WakefieldRota;
        bool DoncasterRota;
        string DateTest;
        Freddies ShopRotaFred = new Freddies();

        private void ShopRotas_Load(object sender, EventArgs e)
        {
            CbEdit.Checked = false;
        }

        private void BtnWakeRota_Click(object sender, EventArgs e)
        {
            ClearBindings();
            WakefieldRota = true;
            DoncasterRota = false;
            TxtBDate.DataBindings.Add("Text", ShopRotaFred.GetTblWakefieldRota, "Date");
            TxtBMonday.DataBindings.Add("Text", ShopRotaFred.GetTblWakefieldRota, "Monday");
            TxtBTuesday.DataBindings.Add("Text", ShopRotaFred.GetTblWakefieldRota, "Tuesday");
            TxtBWednesday.DataBindings.Add("Text", ShopRotaFred.GetTblWakefieldRota, "Wednesday");
            TxtBThursday.DataBindings.Add("Text", ShopRotaFred.GetTblWakefieldRota, "Thursday");
            TxtBFriday.DataBindings.Add("Text", ShopRotaFred.GetTblWakefieldRota, "Friday");
            TxtBSaturday.DataBindings.Add("Text", ShopRotaFred.GetTblWakefieldRota, "Saturday");
            DateTest = TxtBDate.Text;
        }

        private void BtnDonRota_Click(object sender, EventArgs e)
        {
            ClearBindings();
            WakefieldRota = false;
            DoncasterRota = true;
            TxtBDate.DataBindings.Add("Text", ShopRotaFred.GetTblDoncasterRota, "Date");
            TxtBMonday.DataBindings.Add("Text", ShopRotaFred.GetTblDoncasterRota, "Monday");
            TxtBTuesday.DataBindings.Add("Text", ShopRotaFred.GetTblDoncasterRota, "Tuesday");
            TxtBWednesday.DataBindings.Add("Text", ShopRotaFred.GetTblDoncasterRota, "Wednesday");
            TxtBThursday.DataBindings.Add("Text", ShopRotaFred.GetTblDoncasterRota, "Thursday");
            TxtBFriday.DataBindings.Add("Text", ShopRotaFred.GetTblDoncasterRota, "Friday");
            TxtBSaturday.DataBindings.Add("Text", ShopRotaFred.GetTblDoncasterRota, "Saturday");

        }


        private void TxtBDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBMonday_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBTuesday_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBWednesday_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBThursday_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBFriday_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBSaturday_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void ShopRotas_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void ClearBindings()
        {
            TxtBDate.DataBindings.Clear();
            TxtBMonday.DataBindings.Clear();
            TxtBTuesday.DataBindings.Clear();
            TxtBWednesday.DataBindings.Clear();
            TxtBThursday.DataBindings.Clear();
            TxtBFriday.DataBindings.Clear();
            TxtBSaturday.DataBindings.Clear();
        }

        private void CbEdit_CheckedChanged(object sender, EventArgs e)
        {

            if (CbEdit.Checked == false)
            {
                TxtBDate.Enabled = false;
                TxtBMonday.Enabled = false;
                TxtBTuesday.Enabled = false;
                TxtBWednesday.Enabled = false;
                TxtBThursday.Enabled = false;
                TxtBFriday.Enabled = false;
                TxtBSaturday.Enabled = false;
            }
            else if (CbEdit.Checked == true)
            {
                TxtBDate.Enabled = true;
                TxtBMonday.Enabled = true;
                TxtBTuesday.Enabled = true;
                TxtBWednesday.Enabled = true;
                TxtBThursday.Enabled = true;
                TxtBFriday.Enabled = true;
                TxtBSaturday.Enabled = true;

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BindingContext[ShopRotaFred.GetTblDoncasterRota].Position = BindingContext[ShopRotaFred.GetTblDoncasterRota].Position + 1;
            BindingContext[ShopRotaFred.GetTblDoncasterRota].Position = BindingContext[ShopRotaFred.GetTblDoncasterRota].Position - 1;
            ShopRotaFred.UpdateDoncasterRota();

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only the SELECTED Rota will be Exported.");

            SaveFileDialog ShopRotaFileSave = new SaveFileDialog();
            string FileName;
            StreamWriter WriteFile;
            ShopRotaFileSave.Title = "Export";
            ShopRotaFileSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ShopRotaFileSave.DefaultExt = "csv";
            ShopRotaFileSave.Filter = "(*.csv) | *.csv";
            ShopRotaFileSave.FilterIndex = 1;
            if (ShopRotaFileSave.ShowDialog() == DialogResult.OK)
            {
                FileName = ShopRotaFileSave.FileName;
                WriteFile = new StreamWriter(FileName, false);
                
                try
                {
                    WriteFile.WriteLine("Date,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday");
                    if (WakefieldRota == true)
                    {
                        foreach (DataRow ShopRota in ShopRotaFred.GetTblWakefieldRota.Rows)
                        {
                            WriteFile.Write("{0},", ShopRota.Field<string>("Date"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Monday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Tuesday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Wednesday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Thursday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Friday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Saturday"));
                            WriteFile.WriteLine();
                        }
                        WriteFile.Close();
                        MessageBox.Show(string.Concat("File exported: ", FileName), "File Export successful", MessageBoxButtons.OK);
                    }
                    else if (DoncasterRota == true)
                    {
                        foreach (DataRow ShopRota in ShopRotaFred.GetTblDoncasterRota.Rows)
                        {
                            WriteFile.Write("{0},", ShopRota.Field<string>("Date"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Monday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Tuesday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Wednesday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Thursday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Friday"));
                            WriteFile.Write("{0},", ShopRota.Field<string>("Saturday"));
                            WriteFile.WriteLine();
                        }
                        WriteFile.Close();
                        MessageBox.Show(string.Concat("File exported: ", FileName), "File Export successful", MessageBoxButtons.OK);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("File Write Error");
                }
            }
        }
    }
}
