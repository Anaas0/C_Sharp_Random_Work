using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Freddies
{
    class Freddies
    {
        private OleDbDataAdapter _daTbleEmployees, _daTbleWakefieldRota, _daTbleDoncasterRota, _daTbleShops, _daTblePayRoll, _daTbleSuppliers, _daTbleDeliveries, _daTbleBanking, _daTbleTillFlow, _daTbleCreditNotes;
        private DataTable _tblEmployees, _tblWakefieldRota, _tblDoncasterRota, _tblShops, _tblPayRoll, _tblSupliers, _tblDeliveries, _tblBanking, _tblTillFlow, _tblCreditNotes;
        private OleDbCommand INSERTCMD, UPDATECMD, DELETECMD, AGGCMD;
        private OleDbConnection CMDExeCon;
        //Queries
        static string CONNECTION = @"Provider=SQLOLEDB";


        const string EMPLOIYEESTABLE = @"SELECT EmployeeID, Surname, Forename, Title, DateOfBirth, Address, City, Region, PostalCode, Country, HireDate, HomePhone, MobileNumber, Photo, Notes, ReportTo FROM Employees";
        const string WAKEFIELDROTATABLE = @"SELECT Date, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM WakefieldRota";
        const string DONCASTERROTATABLE = @"SELECT Date, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM DoncasterRota";
        const string SHOPSTABLE = @"SELECT ShopID, ShopName, Address, City, Region, PostalCode, Country, Manager, Email, Notes FROM Shops";
        const string PAYROLLTABLE = @"SELECT NationalInsurance, EmployeeID, Date, Surname, Forename, Title, HourlyRate, Hours, PayRecived, PaidQ, PaidBy, Notes FROM EmployeesCONFIDENTIAL";
        const string SUPPLIERSTABLE = @"SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, MobileNumber FROM Suppliers";
        const string DELIVERIESTABLE = @"SELECT DeliveryID, ShopName, Date, DeliveryArrivalTime, Type, Notes FROM Deliveries";
        const string BANKINGTABLE = @"SELECT ShopID, Date, OneOClock, Average, Total, BankedQ, Manager, Notes FROM BankingCONFIDENTIAL";
        const string TILLLOGTABLE = @"SELECT ShopID, Date, AmountOut, AmountIn, Manager, Notes FROM TillFlowCONFIDENTIAL";
        const string CREDITNOTESTABLE = @"SELECT CreditNoteID, ShopID, IssuedBy, IssuedTo, Date, Value, Void, Notes FROM CreditNotes";

        //AGGREGATE FUNCTIONS START

        const string MINAGEEMPLOYEE = @"SELECT MIN(DateOfBirth) FROM Employees";//Oldest
        const string MAXAGEEMPLOYEE = @"SELECT MAX(DateOfBirth) FROM Employees";//Youngest
        const string MOSTHOURS = @"";

        //AGGREGATE FUNCTIONS END

        public Freddies()//constructor
        {
            //Get Data
            _daTbleEmployees = new OleDbDataAdapter(EMPLOIYEESTABLE, CONNECTION);
            _daTbleWakefieldRota = new OleDbDataAdapter(WAKEFIELDROTATABLE, CONNECTION);
            _daTbleDoncasterRota = new OleDbDataAdapter(DONCASTERROTATABLE, CONNECTION);
            _daTbleShops = new OleDbDataAdapter(SHOPSTABLE, CONNECTION);
            _daTblePayRoll = new OleDbDataAdapter(PAYROLLTABLE, CONNECTION);
            _daTbleSuppliers = new OleDbDataAdapter(SUPPLIERSTABLE, CONNECTION);
            _daTbleDeliveries = new OleDbDataAdapter(DELIVERIESTABLE, CONNECTION);
            _daTbleBanking = new OleDbDataAdapter(BANKINGTABLE, CONNECTION);
            _daTbleTillFlow = new OleDbDataAdapter(TILLLOGTABLE, CONNECTION);
            _daTbleCreditNotes = new OleDbDataAdapter(CREDITNOTESTABLE, CONNECTION);


            //Initialise Tables
            _tblEmployees = new DataTable();
            _tblWakefieldRota = new DataTable();
            _tblDoncasterRota = new DataTable();
            _tblShops = new DataTable();
            _tblPayRoll = new DataTable();
            _tblSupliers = new DataTable();
            _tblDeliveries = new DataTable();
            _tblBanking = new DataTable();
            _tblTillFlow = new DataTable();
            _tblCreditNotes = new DataTable();


            //Fill Tables
            _daTbleEmployees.Fill(_tblEmployees);
            _daTbleWakefieldRota.Fill(_tblWakefieldRota);
            _daTbleDoncasterRota.Fill(_tblDoncasterRota);
            _daTbleShops.Fill(_tblShops);
            _daTblePayRoll.Fill(_tblPayRoll);
            _daTbleSuppliers.Fill(_tblSupliers);
            _daTbleDeliveries.Fill(_tblDeliveries);
            _daTbleBanking.Fill(_tblBanking);
            _daTbleTillFlow.Fill(_tblTillFlow);
            _daTbleCreditNotes.Fill(_tblCreditNotes);


        }

        public Freddies(string inUsername, string inPassword)
        {
            string TESTSQLCONNECTION = @"";
            if (SQLCONTestConnection(TESTSQLCONNECTION))
            {
                CONNECTION = @"";
                //Get Data
                _daTbleEmployees = new OleDbDataAdapter(EMPLOIYEESTABLE, CONNECTION);
                _daTbleWakefieldRota = new OleDbDataAdapter(WAKEFIELDROTATABLE, CONNECTION);
                _daTbleDoncasterRota = new OleDbDataAdapter(DONCASTERROTATABLE, CONNECTION);
                _daTbleShops = new OleDbDataAdapter(SHOPSTABLE, CONNECTION);
                _daTblePayRoll = new OleDbDataAdapter(PAYROLLTABLE, CONNECTION);
                _daTbleSuppliers = new OleDbDataAdapter(SUPPLIERSTABLE, CONNECTION);
                _daTbleDeliveries = new OleDbDataAdapter(DELIVERIESTABLE, CONNECTION);
                _daTbleBanking = new OleDbDataAdapter(BANKINGTABLE, CONNECTION);
                _daTbleTillFlow = new OleDbDataAdapter(TILLLOGTABLE, CONNECTION);
                _daTbleCreditNotes = new OleDbDataAdapter(CREDITNOTESTABLE, CONNECTION);

                //Initialise Tables
                _tblEmployees = new DataTable();
                _tblWakefieldRota = new DataTable();
                _tblDoncasterRota = new DataTable();
                _tblShops = new DataTable();
                _tblPayRoll = new DataTable();
                _tblSupliers = new DataTable();
                _tblDeliveries = new DataTable();
                _tblBanking = new DataTable();
                _tblTillFlow = new DataTable();
                _tblCreditNotes = new DataTable();

                //Fill Tables
                _daTbleEmployees.Fill(_tblEmployees);
                _daTbleWakefieldRota.Fill(_tblWakefieldRota);
                _daTbleDoncasterRota.Fill(_tblDoncasterRota);
                _daTbleShops.Fill(_tblShops);
                _daTblePayRoll.Fill(_tblPayRoll);
                _daTbleSuppliers.Fill(_tblSupliers);
                _daTbleDeliveries.Fill(_tblDeliveries);
                _daTbleBanking.Fill(_tblBanking);
                _daTbleTillFlow.Fill(_tblTillFlow);
                _daTbleCreditNotes.Fill(_tblCreditNotes);
            }

        }

        public DataTable GetTblEmployees
        {
            get { return _tblEmployees; }
            set { value = GetTblEmployees; }
        }

        public DataTable GetTblWakefieldRota
        {
            get { return _tblWakefieldRota; }
        }

        public DataTable GetTblDoncasterRota
        {
            get { return _tblDoncasterRota; }
        }

        public DataTable GetTblShops
        {
            get { return _tblShops; }
        }

        public DataTable GetTblPayRoll
        {
            get { return _tblPayRoll; }
        }

        public DataTable GetTblSuppliers
        {
            get { return _tblSupliers; }
        }

        public DataTable GetDeliveries
        {
            get { return _tblDeliveries; }
        }

        public DataTable GetBanking
        {
            get { return _tblBanking; }
        }

        public DataTable GetTillLog
        {
            get { return _tblTillFlow; }
        }

        public DataTable GetCreditNotes
        {
            get { return _tblCreditNotes; }
        }

        public void UpdateWakefieldRota()
        {
            _daTbleWakefieldRota.Update(_tblWakefieldRota);
        }

        public void UpdateDoncasterRota()
        {
            _daTbleDoncasterRota.Update(_tblDoncasterRota);
        }

        public void UpdateEmployeeTable()
        {
            _daTbleEmployees.Update(_tblEmployees);
        }

        public void UpdatePayRollTable()
        {
            _daTblePayRoll.Update(_tblPayRoll);
        }

        public void UpdateShops()
        {
            _daTbleShops.Update(_tblShops);
        }

        public void UpdateSuppliers()
        {
            _daTbleSuppliers.Update(_tblSupliers);
        }

        public void UpdateDeliveries()
        {
            _daTbleDeliveries.Update(_tblDeliveries);
        }

        public void UpdateBanking()
        {
            _daTbleBanking.Update(_tblBanking);
        }

        public void UpdateTillLog()
        {
            _daTbleTillFlow.Update(_tblTillFlow);
        }

        public void UpdateCreditNotes()
        {
            _daTbleCreditNotes.Update(_tblCreditNotes);
        }

        public void FillEmployeeTable()
        {
            _daTbleEmployees.Fill(_tblEmployees);

        }

        public void ClearEmployeesTable()
        {
            _tblEmployees.Clear();
        }

        public void EmployeesINSERT(string inEmployeeID, string inSurname, string inForename, string inTitle, string inDateOfBirth, string inAddress, string inCity, string inRegion, string inPostalCode, string inCountry, string inHireDate, string inHomePhone, string inMobileNumber, string inNotes, string inReportsTo)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = "INSERT INTO Employees(EmployeeID, Surname, Forename, Title, DateOfBirth, Address, City, Region, PostalCode, Country, HireDate, HomePhone, MobileNumber, Notes, ReportsTo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@EmployeeID", OleDbType.Integer).Value = Convert.ToInt32(inEmployeeID);
                INSERTCMD.Parameters.Add("@Surname", OleDbType.VarChar).Value = Convert.ToString(inSurname);
                INSERTCMD.Parameters.Add("@Forename", OleDbType.VarChar).Value = Convert.ToString(inForename);
                INSERTCMD.Parameters.Add("@Title", OleDbType.VarChar).Value = Convert.ToString(inTitle);
                INSERTCMD.Parameters.Add("@DateOfBirth", OleDbType.DBDate).Value = Convert.ToDateTime(inDateOfBirth);
                INSERTCMD.Parameters.Add("@Address", OleDbType.VarChar).Value = Convert.ToString(inAddress);
                INSERTCMD.Parameters.Add("@City", OleDbType.VarChar).Value = Convert.ToString(inCity);
                INSERTCMD.Parameters.Add("@Region", OleDbType.VarChar).Value = Convert.ToString(inRegion);
                INSERTCMD.Parameters.Add("@PostalCode", OleDbType.VarChar).Value = Convert.ToString(inPostalCode);
                INSERTCMD.Parameters.Add("@Country", OleDbType.VarChar).Value = Convert.ToString(inCountry);
                INSERTCMD.Parameters.Add("@HireDate", OleDbType.VarChar).Value = Convert.ToString(inHireDate);
                INSERTCMD.Parameters.Add("@HomePhone", OleDbType.VarChar).Value = Convert.ToString(inHomePhone);
                INSERTCMD.Parameters.Add("@MobileNumber", OleDbType.VarChar).Value = Convert.ToString(inMobileNumber);
                INSERTCMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                INSERTCMD.Parameters.Add("@ReportTo", OleDbType.VarChar).Value = Convert.ToString(inReportsTo);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void ShopsINSERT(string inShopID, string inShopName, string inAddress, string inCity, string inRegion, string inPostalCode, string inCountry, string inManager, string inEmail, string inNotes)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = @"INSERT INTO Shops(ShopID, ShopName, Address, City, Region, PostalCode, Country, Manager, Email, Notes) VALUES(?,?,?,?,?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                INSERTCMD.Parameters.Add("@ShopName", OleDbType.VarChar).Value = Convert.ToString(inShopName);
                INSERTCMD.Parameters.Add("@Address", OleDbType.VarChar).Value = Convert.ToString(inAddress);
                INSERTCMD.Parameters.Add("@City", OleDbType.VarChar).Value = Convert.ToString(inCity);
                INSERTCMD.Parameters.Add("@Region", OleDbType.VarChar).Value = Convert.ToString(inRegion);
                INSERTCMD.Parameters.Add("@PostalCode", OleDbType.VarChar).Value = Convert.ToString(inPostalCode);
                INSERTCMD.Parameters.Add("@Country", OleDbType.VarChar).Value = Convert.ToString(inCountry);
                INSERTCMD.Parameters.Add("@Manager", OleDbType.VarChar).Value = Convert.ToString(inManager);
                INSERTCMD.Parameters.Add("@Email", OleDbType.VarChar).Value = Convert.ToString(inEmail);
                INSERTCMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void PayRollINSERT(string inNationalInsurance, string inEmployeeID, string inDate, string inSurname, string inForename, string inTitle, string inHourlyRate, string inHours, string inPayRecived, string inPaidQ, string inPaidBy, string inNotes)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = @"INSERT INTO EmployessCONFIDENTIAL(NationalInsurance, EmployeeID, Date, Surname, Forename, Title, HourlyRate, Hours, PayRecived, PaidQ, PaidBy, Notes) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@NationalInsurance", OleDbType.VarChar).Value = Convert.ToString(inNationalInsurance);
                INSERTCMD.Parameters.Add("@EmployeeID", OleDbType.Integer).Value = Convert.ToInt32(inEmployeeID);
                INSERTCMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                INSERTCMD.Parameters.Add("@Surname", OleDbType.VarChar).Value = Convert.ToString(inSurname);
                INSERTCMD.Parameters.Add("@Forename", OleDbType.VarChar).Value = Convert.ToString(inForename);
                INSERTCMD.Parameters.Add("@Title", OleDbType.VarChar).Value = Convert.ToString(inTitle);
                INSERTCMD.Parameters.Add("@HourlyRate", OleDbType.Currency).Value = Convert.ToDecimal(inHourlyRate);
                INSERTCMD.Parameters.Add("@Hours", OleDbType.Decimal).Value = Convert.ToDecimal(inHours);
                INSERTCMD.Parameters.Add("@PayRecived", OleDbType.Currency).Value = Convert.ToDecimal(inPayRecived);
                INSERTCMD.Parameters.Add("@PaidQ", OleDbType.Boolean).Value = Convert.ToBoolean(inPaidQ);
                INSERTCMD.Parameters.Add("@PaidBy", OleDbType.VarChar).Value = Convert.ToString(inPaidBy);
                INSERTCMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void TillFlowINSERT(string inShopID, string inDate, string inAmountIn, string inAmountOut, string inManager, string inNotes)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = @"INSERT INTO TillFlowCONFIDENTIAL(ShopID, Date, AmountOut, AmountIn, Manager, Notes) VALUES(?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                INSERTCMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                INSERTCMD.Parameters.Add("@AmountOut", OleDbType.Currency).Value = Convert.ToDecimal(inAmountOut);
                INSERTCMD.Parameters.Add("@AmountIn", OleDbType.Currency).Value = Convert.ToDecimal(inAmountIn);
                INSERTCMD.Parameters.Add("@Manager", OleDbType.VarChar).Value = Convert.ToString(inManager);
                INSERTCMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }

        }

        public void CreditNoteINSERT(string inCreditNoteID, string inShopID, string inIssuedBy, string inIssuedTo, string inDate, string inValue, string inVoid, string inNotes)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = @"INSERT INTO CreditNotes(CreditNoteID, ShopID, IssuedBy, IssuedTo, Date, Value, Void, Notes) VALUES(?,?,?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@CreditNoteID", OleDbType.Integer).Value = Convert.ToInt32(inCreditNoteID);
                INSERTCMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                INSERTCMD.Parameters.Add("@IssuedBy", OleDbType.VarChar).Value = Convert.ToString(inIssuedBy);
                INSERTCMD.Parameters.Add("@IssuedTo", OleDbType.VarChar).Value = Convert.ToString(inIssuedTo);
                INSERTCMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                INSERTCMD.Parameters.Add("@Value", OleDbType.Currency).Value = Convert.ToDecimal(inValue);
                INSERTCMD.Parameters.Add("@Void",OleDbType.Boolean).Value = Convert.ToBoolean(inVoid);
                INSERTCMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void DeliveriesINSERT(string inDeliveryID, string inShopName, string inDate, string inDeliveryArrivalTime, string inType, string inNotes)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = @"INSERT INTO Deliveries(DeliveryID, ShopName, Date, DeliveryArrivalTime, Type, Notes) VALUES(?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@DeliveryID", OleDbType.Integer).Value = Convert.ToInt32(inDeliveryID);
                INSERTCMD.Parameters.Add("@ShopName", OleDbType.VarChar).Value = Convert.ToString(inShopName);
                INSERTCMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                INSERTCMD.Parameters.Add("@DeliveryArrivalTime", OleDbType.VarChar).Value = Convert.ToString(inDeliveryArrivalTime);
                INSERTCMD.Parameters.Add("@Type", OleDbType.VarChar).Value = Convert.ToString(inType);
                INSERTCMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void SuppliersINSERT(string inSupplierID, string inCompanyName, string inContactName, string inContactTitle, string inAddress, string inCity, string inRegion, string inPostalCode, string inCountry, string inMobileNumber)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = @"INSERT INTO Suppliers(SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, MobileNumber) VALUES(?,?,?,?,?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@SupplierID", OleDbType.Integer).Value = Convert.ToInt32(inSupplierID);
                INSERTCMD.Parameters.Add("@CompanyName", OleDbType.VarChar).Value = Convert.ToString(inCompanyName);
                INSERTCMD.Parameters.Add("@ContactName", OleDbType.VarChar).Value = Convert.ToString(inContactName);
                INSERTCMD.Parameters.Add("@ContactTitle", OleDbType.VarChar).Value = Convert.ToString(inContactTitle);
                INSERTCMD.Parameters.Add("@Address", OleDbType.VarChar).Value = Convert.ToString(inAddress);
                INSERTCMD.Parameters.Add("@City", OleDbType.VarChar).Value = Convert.ToString(inCity);
                INSERTCMD.Parameters.Add("@Region", OleDbType.VarChar).Value = Convert.ToString(inRegion);
                INSERTCMD.Parameters.Add("@PostalCode", OleDbType.VarChar).Value = Convert.ToString(inPostalCode);
                INSERTCMD.Parameters.Add("@Country", OleDbType.VarChar).Value = Convert.ToString(inCountry);
                INSERTCMD.Parameters.Add("@MobileNumber", OleDbType.VarChar).Value = Convert.ToString(inMobileNumber);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void BankingLogINSERT(string inShopID, string inDate, string inOneOClock, string inAverage, string inTotal, string inBankedQ, string inManager, string inNotes)
        {
            INSERTCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                INSERTCMD.CommandType = CommandType.Text;
                INSERTCMD.CommandText = @"INSERT INTO BankingCONFIDENTIAL(ShopID, Date, OneOClock, Average, Total, BankedQ, Manager, Notes) VALUES(?,?,?,?,?,?,?,?)";
                INSERTCMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                INSERTCMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                INSERTCMD.Parameters.Add("@OneOClock", OleDbType.Currency).Value = Convert.ToDecimal(inOneOClock);
                INSERTCMD.Parameters.Add("@Average", OleDbType.Currency).Value = Convert.ToDecimal(inAverage);
                INSERTCMD.Parameters.Add("@Total", OleDbType.Currency).Value = Convert.ToDecimal(inTotal);
                INSERTCMD.Parameters.Add("@Banked", OleDbType.Boolean).Value = Convert.ToBoolean(inBankedQ);
                INSERTCMD.Parameters.Add("@Manager", OleDbType.VarChar).Value = Convert.ToString(inManager);
                INSERTCMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                INSERTCMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                INSERTCMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void EmployeesUPDATE(string inEmployeeID, string inSurname, string inForename, string inTitle, string inDateOfBirth, string inAddress, string inCity, string inRegion, string inPostalCode, string inCountry, string inHireDate, string inHomePhone, string inMobileNumber, string inNotes, string inReportsTo)
        {
            int AffectedRows;
            UPDATECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                UPDATECMD.CommandType = CommandType.Text;
                UPDATECMD.CommandText = @"UPDATE Employees SET Surname = ?, Forename = ?, Title = ?, DateOfBirth = ?, Address = ?, City = ?, Region = ?, PostalCode = ?, Country = ?, HireDate = ?, HomePhone = ?, MobileNumber = ?, Notes = ?, ReportTo = ? WHERE EmployeeID = ?";                               
                UPDATECMD.Parameters.Add("@Surname", OleDbType.VarChar).Value = Convert.ToString(inSurname);
                UPDATECMD.Parameters.Add("@Forename", OleDbType.VarChar).Value = Convert.ToString(inForename);
                UPDATECMD.Parameters.Add("@Title", OleDbType.VarChar).Value = Convert.ToString(inTitle);
                UPDATECMD.Parameters.Add("@DateOfBirth", OleDbType.DBDate).Value = Convert.ToDateTime(inDateOfBirth);
                UPDATECMD.Parameters.Add("@Address", OleDbType.VarChar).Value = Convert.ToString(inAddress);
                UPDATECMD.Parameters.Add("@City", OleDbType.VarChar).Value = Convert.ToString(inCity);
                UPDATECMD.Parameters.Add("@Region", OleDbType.VarChar).Value = Convert.ToString(inRegion);
                UPDATECMD.Parameters.Add("@PostalCode", OleDbType.VarChar).Value = Convert.ToString(inPostalCode);
                UPDATECMD.Parameters.Add("@Country", OleDbType.VarChar).Value = Convert.ToString(inCountry);
                UPDATECMD.Parameters.Add("@HireDate", OleDbType.VarChar).Value = Convert.ToString(inHireDate);
                UPDATECMD.Parameters.Add("@HomePhone", OleDbType.VarChar).Value = Convert.ToString(inHomePhone);
                UPDATECMD.Parameters.Add("@MobileNumber", OleDbType.VarChar).Value = Convert.ToString(inMobileNumber);
                UPDATECMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                UPDATECMD.Parameters.Add("@ReportTo", OleDbType.VarChar).Value = Convert.ToString(inReportsTo);
                UPDATECMD.Parameters.Add("@EmployeeID", OleDbType.Integer).Value = Convert.ToInt32(inEmployeeID);
                UPDATECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                UPDATECMD.ExecuteNonQuery();
                AffectedRows = UPDATECMD.ExecuteNonQuery();
                CMDExeCon.Close();
                if(AffectedRows > 0 ) MessageBox.Show("Updated Succesfully");
            }
        }

        public void ShopsUPDATE(string inShopID, string inShopName, string inAddress, string inCity, string inRegion, string inPostalCode, string inCountry, string inManager, string inEmail, string inNotes)
        {
            int AffectedRows;
            UPDATECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                UPDATECMD.CommandType = CommandType.Text;
                UPDATECMD.CommandText = @"UPDATE Shops SET ShopName = ?, Address = ?, City = ?, Region = ?, PostalCode = ?, Country = ?, Manager = ?, Email = ?, Notes = ? WHERE ShopID = ?";
                UPDATECMD.Parameters.Add("@ShopName", OleDbType.VarChar).Value = Convert.ToString(inShopName);
                UPDATECMD.Parameters.Add("@Address", OleDbType.VarChar).Value = Convert.ToString(inAddress);
                UPDATECMD.Parameters.Add("@City", OleDbType.VarChar).Value = Convert.ToString(inCity);
                UPDATECMD.Parameters.Add("@Region", OleDbType.VarChar).Value = Convert.ToString(inRegion);
                UPDATECMD.Parameters.Add("@PostalCode", OleDbType.VarChar).Value = Convert.ToString(inPostalCode);
                UPDATECMD.Parameters.Add("@Country", OleDbType.VarChar).Value = Convert.ToString(inCountry);
                UPDATECMD.Parameters.Add("@Manager", OleDbType.VarChar).Value = Convert.ToString(inManager);
                UPDATECMD.Parameters.Add("@Email", OleDbType.VarChar).Value = Convert.ToString(inEmail);
                UPDATECMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                UPDATECMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                UPDATECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                UPDATECMD.ExecuteNonQuery();
                AffectedRows = UPDATECMD.ExecuteNonQuery();
                CMDExeCon.Close();
                if (AffectedRows > 0) MessageBox.Show("Updated Succesfully");
            }
        }

        public void PayRollUPDATE(string inEmployeeID, string inDate, string inSurname, string inForename, string inTitle, string inHourlyRate, string inHours, string inPayRecived, string inPaidQ, string inPaidBy, string inNotes)
        {
            int AffectedRows;
            UPDATECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                UPDATECMD.CommandType = CommandType.Text;
                UPDATECMD.CommandText = @"UPDATE EmployeesCONFIDENTIAL SET Date = ?, Surname = ?, Forename = ?, Title = ?, HourlyRate = ?, Hours = ?, PayRecived = ?, PaidQ = ?, PaidBy = ?, Notes = ? WHERE EmployeeID = ?";
                UPDATECMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                UPDATECMD.Parameters.Add("@Surname", OleDbType.VarChar).Value = Convert.ToString(inSurname);
                UPDATECMD.Parameters.Add("@Forename", OleDbType.VarChar).Value = Convert.ToString(inForename);
                UPDATECMD.Parameters.Add("@Title", OleDbType.VarChar).Value = Convert.ToString(inTitle);
                UPDATECMD.Parameters.Add("@HourlyRate", OleDbType.Currency).Value = Convert.ToDecimal(inHourlyRate);
                UPDATECMD.Parameters.Add("@Hours", OleDbType.Decimal).Value = Convert.ToDecimal(inHours);
                UPDATECMD.Parameters.Add("@PayRecived", OleDbType.Currency).Value = Convert.ToDecimal(inPayRecived);
                UPDATECMD.Parameters.Add("@PaidQ", OleDbType.Boolean).Value = Convert.ToBoolean(inPaidQ);
                UPDATECMD.Parameters.Add("@PaidBy", OleDbType.VarChar).Value = Convert.ToString(inPaidBy);
                UPDATECMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                UPDATECMD.Parameters.Add("@EmployeeID", OleDbType.Integer).Value = Convert.ToInt32(inEmployeeID);
                UPDATECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                UPDATECMD.ExecuteNonQuery();
                AffectedRows = UPDATECMD.ExecuteNonQuery();
                CMDExeCon.Close();
                if (AffectedRows > 0) MessageBox.Show("Updated Succesfully");
            }
        }

        public void CreditNoteUPDATE(string inCreditNoteID, string inShopID, string inIssuedBy, string inIssuedTo, string inDate, string inValue, string inVoid, string inNotes)
        {
            int AffectedRows;
            UPDATECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                UPDATECMD.CommandType = CommandType.Text;
                UPDATECMD.CommandText = @"UPDATE CreditNotes SET ShopID =?, IssuedBy = ?, IssuedTo = ?, Date = ?, Value = ?, Void = ?, Notes = ? WHERE CreditNoteID = ?";

                UPDATECMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                UPDATECMD.Parameters.Add("@IssuedBy", OleDbType.VarChar).Value = Convert.ToString(inIssuedBy);
                UPDATECMD.Parameters.Add("@IssuedTo", OleDbType.VarChar).Value = Convert.ToString(inIssuedTo);
                UPDATECMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                UPDATECMD.Parameters.Add("@Value", OleDbType.Currency).Value = Convert.ToDecimal(inValue);
                UPDATECMD.Parameters.Add("@Void", OleDbType.Boolean).Value = Convert.ToBoolean(inVoid);
                UPDATECMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                UPDATECMD.Parameters.Add("@CreditNoteID", OleDbType.Integer).Value = Convert.ToInt32(inCreditNoteID);
                UPDATECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                UPDATECMD.ExecuteNonQuery();
                UPDATECMD.ExecuteNonQuery();
                AffectedRows = UPDATECMD.ExecuteNonQuery();
                CMDExeCon.Close();
                if (AffectedRows > 0) MessageBox.Show("Updated Succesfully");
            }
        }

        public void DeliveriesUPDATE(string inDeliveryID, string inShopName, string inDate, string inDeliveryArrivalTime, string inType, string inNotes)
        {
            int AffectedRows;
            UPDATECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                UPDATECMD.CommandType = CommandType.Text;
                UPDATECMD.CommandText = @"UPDATE Deliveries SET ShopName = ?, Date = ?, DeliveryArrivalTime = ?, Type = ?, Notes = ? WHERE DeliveryID = ?";

                UPDATECMD.Parameters.Add("@ShopName", OleDbType.VarChar).Value = Convert.ToString(inShopName);
                UPDATECMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                UPDATECMD.Parameters.Add("@DeliveryArrivalTime", OleDbType.VarChar).Value = Convert.ToString(inDeliveryArrivalTime);
                UPDATECMD.Parameters.Add("@Type", OleDbType.VarChar).Value = Convert.ToString(inType);
                UPDATECMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                UPDATECMD.Parameters.Add("@DeliveryID", OleDbType.Integer).Value = Convert.ToInt32(inDeliveryID);
                UPDATECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                UPDATECMD.ExecuteNonQuery();
                AffectedRows = UPDATECMD.ExecuteNonQuery();
                CMDExeCon.Close();
                if (AffectedRows > 0) MessageBox.Show("Updated Succesfully");
            }
        }

        public void SuppliersUPDATE(string inSupplierID, string inCompanyName, string inContactName, string inContactTitle, string inAddress, string inCity, string inRegion, string inPostalCode, string inCountry, string inMobileNumber)
        {
            int AffectedRows;
            UPDATECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                UPDATECMD.CommandType = CommandType.Text;
                UPDATECMD.CommandText = @"UPDATE Suppliers SET CompanyName = ?, ContactName = ?, ContactTitle = ?, Address = ?, City = ?, Region = ?, PostalCode = ?, Country = ?, MobileNumber = ? WHERE SupplierID = ?";

                UPDATECMD.Parameters.Add("@CompanyName", OleDbType.VarChar).Value = Convert.ToString(inCompanyName);
                UPDATECMD.Parameters.Add("@ContactName", OleDbType.VarChar).Value = Convert.ToString(inContactName);
                UPDATECMD.Parameters.Add("@ContactTitle", OleDbType.VarChar).Value = Convert.ToString(inContactTitle);
                UPDATECMD.Parameters.Add("@Address", OleDbType.VarChar).Value = Convert.ToString(inAddress);
                UPDATECMD.Parameters.Add("@City", OleDbType.VarChar).Value = Convert.ToString(inCity);
                UPDATECMD.Parameters.Add("@Region", OleDbType.VarChar).Value = Convert.ToString(inRegion);
                UPDATECMD.Parameters.Add("@PostalCode", OleDbType.VarChar).Value = Convert.ToString(inPostalCode);
                UPDATECMD.Parameters.Add("@Country", OleDbType.VarChar).Value = Convert.ToString(inCountry);
                UPDATECMD.Parameters.Add("@MobileNumber", OleDbType.VarChar).Value = Convert.ToString(inMobileNumber);
                UPDATECMD.Parameters.Add("@SupplierID", OleDbType.Integer).Value = Convert.ToInt32(inSupplierID);
                UPDATECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                UPDATECMD.ExecuteNonQuery();
                AffectedRows = UPDATECMD.ExecuteNonQuery();
                CMDExeCon.Close();
                if (AffectedRows > 0) MessageBox.Show("Updated Succesfully");
            }
        }

        public void BankingLogUPDATE(string inShopID, string inDate, string inOneOClock, string inAverage, string inTotal, string inBankedQ, string inManager, string inNotes)
        {
            int AffectedRows;
            UPDATECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                UPDATECMD.CommandType = CommandType.Text;
                UPDATECMD.CommandText = @"UPDATE BankingCONFIDENTIAL SET Date = ?, OneOClock = ?, Average = ?, Total = ?, BankedQ = ?, Manager = ?, Notes = ? WHERE ShopID = ?";

                UPDATECMD.Parameters.Add("@Date", OleDbType.DBDate).Value = Convert.ToDateTime(inDate);
                UPDATECMD.Parameters.Add("@OneOClock", OleDbType.Currency).Value = Convert.ToDecimal(inOneOClock);
                UPDATECMD.Parameters.Add("@Average", OleDbType.Currency).Value = Convert.ToDecimal(inAverage);
                UPDATECMD.Parameters.Add("@Total", OleDbType.Currency).Value = Convert.ToDecimal(inTotal);
                UPDATECMD.Parameters.Add("@Banked", OleDbType.Boolean).Value = Convert.ToBoolean(inBankedQ);
                UPDATECMD.Parameters.Add("@Manager", OleDbType.VarChar).Value = Convert.ToString(inManager);
                UPDATECMD.Parameters.Add("@Notes", OleDbType.VarChar).Value = Convert.ToString(inNotes);
                UPDATECMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                UPDATECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                UPDATECMD.ExecuteNonQuery();
                AffectedRows = UPDATECMD.ExecuteNonQuery();
                CMDExeCon.Close();
                if (AffectedRows > 0) MessageBox.Show("Updated Succesfully");
            }
        }

        public void EmployeesDELETE(string inEmployeeID)
        {
            DELETECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                DELETECMD.CommandType = CommandType.Text;
                DELETECMD.CommandText = @"DELETE FROM Employees WHERE EmployeeID = ?";
                DELETECMD.Parameters.Add("@EmployeeID", OleDbType.Integer).Value = Convert.ToInt32(inEmployeeID);
                /*
                Changes take effect after relauch
                problem with position lablel
                */
                DELETECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                DELETECMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }

        public void ShopsDELETE(string inShopID)
        {
            DELETECMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                DELETECMD.CommandType = CommandType.Text;
                DELETECMD.CommandText = @"DELETE FROM Shops WHERE ShopID = ?";
                DELETECMD.Parameters.Add("@ShopID", OleDbType.Integer).Value = Convert.ToInt32(inShopID);
                DELETECMD.Connection = CMDExeCon;
                CMDExeCon.Open();
                DELETECMD.ExecuteNonQuery();
                CMDExeCon.Close();
            }
        }


        //AGGREGATE FUNK START
        public void CalculatePay(string inEmployeeID)//needs logical work. Calculates pay and factors NI BUT reduces everytime it is executed.
        {
            AGGCMD = new OleDbCommand();
            using (CMDExeCon = new OleDbConnection(CONNECTION))
            {
                AGGCMD.CommandType = CommandType.Text;
                AGGCMD.CommandText = @"UPDATE EmployeesCONFIDENTIAL SET PayRecived = CASE WHEN DateDiff(Year, DateOfBirth, GetDate()) >= 16 THEN HourlyRate * Hours * 0.88 WHEN DateDiff(year, DateOfBirth, GetDate()) < 16 THEN  HourlyRate * Hours END FROM EmployeesCONFIDENTIAL INNER JOIN Employees ON EmployeesCONFIDENTIAL.EmployeeID = Employees.EmployeeID WHERE EmployeesCONFIDENTIAL.EmployeeID = ?";
                AGGCMD.Parameters.Add("@EmployeeID", OleDbType.Integer).Value = Convert.ToInt32(inEmployeeID);
            }            
        }


        //AGGREGATE FUNK END

        public bool SQLCONTestConnection(string CONNECTIONSTRING)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
                /*try
                {
                    
                }
                catch (SqlException)
                {
                    return false;
                }*/
            }
        }

        public bool OLEDBTestConnection(string CONNECTIONSTRING)
        {
            using (OleDbConnection test = new OleDbConnection(CONNECTIONSTRING))
            {
                try
                {
                    test.Open();
                    return true;
                }
                catch (OleDbException)
                {

                    return false;
                }
            }
        }
        //CONNECTION SHIT END

    }
}



/*
 *
 *
 *_________ ______________ ______________ ______________ __>_____
 *=========|==============|==============|==============|=======`)
 *------oo-^-oo--------oo-^-oo--------oo-^-oo--------oo-^o-o--o-o=
 *   
 *   
 *
 *
 */
