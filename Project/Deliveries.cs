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
    public partial class Deliveries : Form
    {
        public Deliveries()
        {
            InitializeComponent();
        }

        Freddies DeliverFred = new Freddies();

        private void Deliveries_Load(object sender, EventArgs e)
        {
            TxtBDeliveryID.DataBindings.Add("Text", DeliverFred.GetDeliveries, "DeliveryID");
            TxtBShopName.DataBindings.Add("Text", DeliverFred.GetDeliveries, "ShopName");
            TxtBDate.DataBindings.Add("Text", DeliverFred.GetDeliveries, "Date");
            TxtBETA.DataBindings.Add("Text", DeliverFred.GetDeliveries, "DeliveryArrivalTime");
            TxtBType.DataBindings.Add("Text", DeliverFred.GetDeliveries, "Type");
            TxtBNotes.DataBindings.Add("Text", DeliverFred.GetDeliveries, "Notes");
            PositionLabelUpdate();
        }

        private void TxtBNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBETA_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBShopName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBDeliveryID_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBType_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            BindingContext[DeliverFred.GetDeliveries].Position = 0;
            PositionLabelUpdate();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            BindingContext[DeliverFred.GetDeliveries].Position = BindingContext[DeliverFred.GetDeliveries].Position - 1;
            PositionLabelUpdate();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            BindingContext[DeliverFred.GetDeliveries].Position = BindingContext[DeliverFred.GetDeliveries].Position + 1;
            PositionLabelUpdate();
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            BindingContext[DeliverFred.GetDeliveries].Position = BindingContext[DeliverFred.GetDeliveries].Count - 1;
            PositionLabelUpdate();
        }

        private void LBPosition_Click(object sender, EventArgs e)
        {

        }

        private void PositionLabelUpdate()
        {
            string FormattedPosition;
            FormattedPosition = string.Format("{0} of {1}", BindingContext[DeliverFred.GetDeliveries].Position + 1, BindingContext[DeliverFred.GetDeliveries].Count);
            LBPosition.Text = FormattedPosition;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog DeliveriesFileSave = new SaveFileDialog();
            string FileName;
            StreamWriter WriteFile;
            DeliveriesFileSave.Title = "Export";
            DeliveriesFileSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DeliveriesFileSave.DefaultExt = "csv";
            DeliveriesFileSave.Filter = "(*.csv) | *.csv";
            DeliveriesFileSave.FilterIndex = 1;
            if (DeliveriesFileSave.ShowDialog() == DialogResult.OK)
            {
                FileName = DeliveriesFileSave.FileName;
                try
                {
                    WriteFile = new StreamWriter(FileName, false);
                    WriteFile.WriteLine("DeliveryID,ShopName,Date,DeliveryArrivalTime,Type,Notes");
                    foreach (DataRow Employees in DeliverFred.GetDeliveries.Rows)
                    {
                        WriteFile.Write("{0},", Employees.Field<int>("DeliveryID"));
                        WriteFile.Write("{0},", Employees.Field<string>("ShopName"));
                        WriteFile.Write("{0},", Employees.Field<DateTime>("Date"));
                        WriteFile.Write("{0},", Employees.Field<string>("DeliveryArrivalTime"));
                        WriteFile.Write("{0},", Employees.Field<string>("Type"));
                        WriteFile.Write("{0},", Employees.Field<string>("Notes"));
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            DeliveriesNewRecord Lauch = new DeliveriesNewRecord();
            Lauch.ShowDialog();
        }
    }
}













































//John Wick did nothing wrong