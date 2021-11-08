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
    public partial class Shops : Form
    {
        Freddies ShopsFred = new Freddies();

        public Shops()
        {
            InitializeComponent();
        }

        private void Shops_Load(object sender, EventArgs e)
        {
            TxtBShopID.DataBindings.Add("Text", ShopsFred.GetTblShops, "ShopID");
            TxtBShopName.DataBindings.Add("Text", ShopsFred.GetTblShops, "ShopName");
            TxtBAddress.DataBindings.Add("Text", ShopsFred.GetTblShops, "Address");
            TxtBCity.DataBindings.Add("Text", ShopsFred.GetTblShops, "City");
            TxtBRegion.DataBindings.Add("Text", ShopsFred.GetTblShops, "Region");
            TxtBPostalCode.DataBindings.Add("Text", ShopsFred.GetTblShops, "PostalCode");
            TxtBCountry.DataBindings.Add("Text", ShopsFred.GetTblShops, "Country");
            TxtBManager.DataBindings.Add("Text", ShopsFred.GetTblShops, "Manager");
            TxtBEmail.DataBindings.Add("Text", ShopsFred.GetTblShops, "Email");
            TxtBNotes.DataBindings.Add("Text", ShopsFred.GetTblShops, "Notes");

            TxtBShopID.Enabled = false;
            TxtBShopName.Enabled = false;
            TxtBAddress.Enabled = false;
            TxtBCity.Enabled = false;
            TxtBRegion.Enabled = false;
            TxtBPostalCode.Enabled = false;
            TxtBCountry.Enabled = false;
            TxtBManager.Enabled = false;
            TxtBEmail.Enabled = false;
            TxtBNotes.Enabled = false;

            ComBoxShopName.DataSource = ShopsFred.GetTblShops;
            ComBoxShopName.DisplayMember = "ShopName";
            BindingContext[ShopsFred.GetTblShops].PositionChanged += new EventHandler(ComBoxShopName_SelectedIndexChanged);

            LabelPositionChange();
        }

        private void TxtBShopID_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBShopName_TextChanged(object sender, EventArgs e)
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

        private void TxtBManager_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {   /*Save
            BindingContext[ShopsFred.GetTblShops].Position = BindingContext[ShopsFred.GetTblShops].Position + 1;
            BindingContext[ShopsFred.GetTblShops].Position = BindingContext[ShopsFred.GetTblShops].Position - 1;
            ShopsFred.UpdateShops();*/
            
            BindingContext[ShopsFred.GetTblShops].Position = 0;
            LabelPositionChange();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            BindingContext[ShopsFred.GetTblShops].Position--;
            LabelPositionChange();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            BindingContext[ShopsFred.GetTblShops].Position++;
            LabelPositionChange();
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            BindingContext[ShopsFred.GetTblShops].Position = BindingContext[ShopsFred.GetTblShops].Count;
            LabelPositionChange();
        }

        private void LbPosition_Click(object sender, EventArgs e)
        {

        }

        private void Shops_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CBEdit_CheckedChanged(object sender, EventArgs e)
        {
            if(CBEdit.Checked == false)
            {
                TxtBShopID.Enabled = false;
                TxtBShopName.Enabled = false;
                TxtBAddress.Enabled = false;
                TxtBCity.Enabled = false;
                TxtBRegion.Enabled = false;
                TxtBPostalCode.Enabled = false;
                TxtBCountry.Enabled = false;
                TxtBManager.Enabled = false;
                TxtBEmail.Enabled = false;
                TxtBNotes.Enabled = false;
            }
            else if(CBEdit.Checked == true)
            {
                TxtBShopID.Enabled = true;
                TxtBShopName.Enabled = true;
                TxtBAddress.Enabled = true;
                TxtBCity.Enabled = true;
                TxtBRegion.Enabled = true;
                TxtBPostalCode.Enabled = true;
                TxtBCountry.Enabled = true;
                TxtBManager.Enabled = true;
                TxtBEmail.Enabled = true;
                TxtBNotes.Enabled = true;
            }
        }

        private void LabelPositionChange()
        {
            string FormattedPosition;
            FormattedPosition = string.Format("{0} of {1}", BindingContext[ShopsFred.GetTblShops].Position + 1, BindingContext[ShopsFred.GetTblShops].Count);
            LbPosition.Text = FormattedPosition;
        }

        private void ComBoxShopName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog ShopsFileSave = new SaveFileDialog();
            string FileName;
            StreamWriter WriteFile;
            ShopsFileSave.Title = "Export";
            ShopsFileSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ShopsFileSave.DefaultExt = "csv";
            ShopsFileSave.Filter = "(*.csv) | *.csv";
            ShopsFileSave.FilterIndex = 1;
            if (ShopsFileSave.ShowDialog() == DialogResult.OK)
            {
                FileName = ShopsFileSave.FileName;
                try
                {
                    WriteFile = new StreamWriter(FileName, false);
                    WriteFile.WriteLine("ShopID,ShopName,Address,City,Region,PostalCode,Country,Manager,Email,Notes");
                    foreach (DataRow Shops in ShopsFred.GetTblShops.Rows)
                    {
                        WriteFile.Write("{0},", Shops.Field<int>("ShopID"));
                        WriteFile.Write("{0},", Shops.Field<string>("ShopName"));
                        WriteFile.Write("{0},", Shops.Field<string>("Address"));
                        WriteFile.Write("{0},", Shops.Field<string>("City"));
                        WriteFile.Write("{0},", Shops.Field<string>("Region"));
                        WriteFile.Write("{0},", Shops.Field<string>("PostalCode"));
                        WriteFile.Write("{0},", Shops.Field<string>("Country"));
                        WriteFile.Write("{0},", Shops.Field<string>("Manager"));
                        WriteFile.Write("{0},", Shops.Field<string>("Email"));
                        WriteFile.Write("{0},", Shops.Field<string>("Notes"));
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
            ShopsNewRecord Lauch = new ShopsNewRecord();
            Lauch.ShowDialog();
        }
    }
}
































































/*
        ____            ____    ____________          _____________         ___       ___        ______                _______               ____________         _____________       __________________
       / //             / //   /  _________//       /  ________   //      /  //     /  //      /   __  /             /  __    //            /   _________//      / ___________/      /_______    ______/
       / //            / //   /  //                /  //      /  //      /  //     /  //      /  //   / /          / //   /  //            /  //                / /                          /  /
       / //           / //   /  //                /  //______/ _//      /  //     /  //      /  //     / /       / //    /  //            /  //                / /                          /  /
       / //         / //    /  //________        /    _    _//         /  //     /  //      /  //       / /____/ //     /  //            /  //________        / /__________                /  /
       / //       / //     /  __________//      /  //  / //           /  //     /  //      /  //         /_____//      /  //            /  __________//      /___________/ /              /  /
       / //     / //      /  //                /  //    /  //        /  //     /  //      /  //                       /  //            /  //                            / /              /  /
       / //   / //       /  //                /  //      /  //      /  //     /  //      /  //                       /  //            /  //                            / /              /  /
       / //_/ //        /  //_________       /  //       /  //     /  //_____/  //      /  //                       /  //            /  //_________        ___________/ /              /  /        __           
        /__//          /____________//      /__//        /___//   /____________//      /__//                       /__//            /____________//       /____________/              /__/        /_/
 */
