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
    public partial class BankingLog : Form
    {
        public BankingLog()
        {
            InitializeComponent();
        }

        Freddies FredRobbedABank = new Freddies();
        private void BankingLog_Load(object sender, EventArgs e)
        {
            TxtBShopID.DataBindings.Add("Text", FredRobbedABank.GetBanking, "ShopID");
            TxtBDate.DataBindings.Add("Text", FredRobbedABank.GetBanking, "Date");
            TxtBOneOClock.DataBindings.Add("Text", FredRobbedABank.GetBanking, "OneOClock");
            TxtBAverage.DataBindings.Add("Text", FredRobbedABank.GetBanking, "Average");
            TxtBTotal.DataBindings.Add("Text", FredRobbedABank.GetBanking, "Total");
            CNBanked.DataBindings.Add("Checked", FredRobbedABank.GetBanking, "BankedQ");
            TxtBManager.DataBindings.Add("Text", FredRobbedABank.GetBanking, "Manager");
            TxtBNotes.DataBindings.Add("Text", FredRobbedABank.GetBanking, "Notes");
            PositionLabelUpdate();
        }

        private void TxtBNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void CNBanked_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TxtBManager_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBAverage_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBOneOClock_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBShopID_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            BindingContext[FredRobbedABank.GetBanking].Position = 0;
            PositionLabelUpdate();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            BindingContext[FredRobbedABank.GetBanking].Position = BindingContext[FredRobbedABank.GetBanking].Position - 1;
            PositionLabelUpdate();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            BindingContext[FredRobbedABank.GetBanking].Position = BindingContext[FredRobbedABank.GetBanking].Position + 1;
            PositionLabelUpdate();
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            BindingContext[FredRobbedABank.GetBanking].Position = BindingContext[FredRobbedABank.GetBanking].Count -1;
            PositionLabelUpdate();
        }

        private void LBPosition_Click(object sender, EventArgs e)
        {

        }

        private void PositionLabelUpdate()
        {
            string FormattedPosition;
            FormattedPosition = string.Format("{0} of {1}", BindingContext[FredRobbedABank.GetBanking].Position + 1, BindingContext[FredRobbedABank.GetBanking].Count);
            LBPosition.Text = FormattedPosition;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog BankFileSave = new SaveFileDialog();
            StreamWriter WriteFile;
            string FileName;
            BankFileSave.Title = "Export";
            BankFileSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            BankFileSave.DefaultExt = "csv";
            BankFileSave.Filter = "(*.csv) | *.csv";
            BankFileSave.FilterIndex = 1;
            if (BankFileSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = BankFileSave.FileName;

                    WriteFile = new StreamWriter(FileName, false);
                    WriteFile.WriteLine("ShopID,Date,OneOClock,Average,Total,BankedQ,Manager,Notes");
                    foreach (DataRow Bank in FredRobbedABank.GetBanking.Rows)
                    {
                        WriteFile.Write("{0},", Bank.Field<int>("ShopID"));
                        WriteFile.Write("{0},", Bank.Field<DateTime>("Date"));
                        WriteFile.Write("{0},", Bank.Field<decimal>("OneOClock").ToString("0:00"));
                        WriteFile.Write("{0},", Bank.Field<decimal>("Average").ToString("0:00"));
                        WriteFile.Write("{0},", Bank.Field<decimal>("Total").ToString("0:00"));
                        WriteFile.Write("{0},", Bank.Field<bool>("BankedQ"));
                        WriteFile.Write("{0},", Bank.Field<string>("Manager"));
                        WriteFile.Write("{0},", Bank.Field<string>("Notes"));
                        WriteFile.WriteLine();
                    }
                    WriteFile.Close();
                    MessageBox.Show(string.Concat("File exported: ", FileName), "File Export successful", MessageBoxButtons.OK);
                }
                catch 
                {

                    throw new Exception("Write Error");
                }
                

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BankingLog Lauch = new BankingLog();
            Lauch.ShowDialog();
        }
    }
}
