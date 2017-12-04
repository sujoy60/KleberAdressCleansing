using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

using LinqToExcel;
using LinqToExcel.Attributes;

using TextExcel.KleberServicePostCode;

using Excel=Microsoft.Office.Interop.Excel;


namespace TextExcel
{

    //public sealed class OpenFileDialog : FileDialog

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        public static string destinationFile;// = txt_SourceFileLocation.Text.ToString();// @"C:\Kleber\AcquisitionFileUpload.xlsx";
        public static string sourceFile;
        //public static BindingList<Address> AddressList = new BindingList<Address>();
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        private static int lastRow = 0;
        public string msg_Success = "Job completed succesfully";
        public string msg_Failure = "Job couldnt be completed . Encountered errors";
        public string msg_InProgress = "Job in progress";
        public static ExcelQueryFactory excel;

        int counter = 1;
        string DtResponseXml = null;
        string FinalDtResponseXml = null;
        string DtRequestXml = null;

        public static void InitializeExcel()
        {
            try
            {

                //open the source file
                excel = new ExcelQueryFactory(sourceFile)
                {
                    DatabaseEngine = LinqToExcel.Domain.DatabaseEngine.Ace,
                    TrimSpaces = LinqToExcel.Query.TrimSpacesType.Both,
                    UsePersistentConnection = true,
                    ReadOnly = true
                };

                /// open the destination file
                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(destinationFile);
                MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explict cast is not required here
                lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            }
            catch (Exception ex)
            {

                MyBook.Close();
                //MySheet.Unprotect();
                MyApp.Quit();
            }

        }

        public void useKleber( int lLimit,int uLimit)// This is the metod used for calling the kleber web service
        {

            var address = from p in excel.Worksheet<Address>(0) select p;

                XmlWriterSettings XmlWriterSettings = new XmlWriterSettings();
                XmlWriterSettings.Indent = true;
                XmlWriterSettings.OmitXmlDeclaration = true;
                StringBuilder XmlStringBuilder = new StringBuilder();
                XmlWriter XmlWriter = XmlWriter.Create(XmlStringBuilder, XmlWriterSettings);

                XmlWriter.WriteStartElement("DtRequests");

                for (int i = lLimit; i <= uLimit; i++)
                {

                    var add = new Address();
                    add = address.First(h => h.RequestId == i);
                    // Create DtRequest Query XML
                    XmlWriter.WriteStartElement("DtRequest");
                    XmlWriter.WriteAttributeString("Method", "DataTools.Verify.Address.AuPaf.VerifyAddress");
                    XmlWriter.WriteAttributeString("AddressLine1", add.Street1);
                    XmlWriter.WriteAttributeString("AddressLine2", add.Street2);
                    XmlWriter.WriteAttributeString("AddressLine3", add.Street3);
                    XmlWriter.WriteAttributeString("AddressLine4", "");
                    XmlWriter.WriteAttributeString("AddressLine5", "");
                    XmlWriter.WriteAttributeString("AddressLine6", "");
                    XmlWriter.WriteAttributeString("Locality", add.City);
                    XmlWriter.WriteAttributeString("State", add.State);
                    XmlWriter.WriteAttributeString("Postcode", add.Postcode);
                    XmlWriter.WriteAttributeString("RequestId", add.RequestId.ToString());
                    XmlWriter.WriteAttributeString("RequestKey", "RK-5C026-D8FBF-E2B0C-20FF4-EE767-D7BF8-1F1CE-EA29F");
                    XmlWriter.WriteAttributeString("DepartmentCode", "");
                    XmlWriter.WriteEndElement();

                }
                
                XmlWriter.WriteEndElement();
                XmlWriter.Close();
                DtRequestXml = XmlStringBuilder.ToString();
                XmlWriter.Dispose();

                //---------------------------------------------------------------------------------------------
                //Send DtRequest to Kleber Server for processing
                DtKleberServiceClient KleberServer = new DtKleberServiceClient("BasicHttpBinding_IDtKleberService");
                DtResponseXml = KleberServer.ProcessXmlRequest(DtRequestXml);
                FinalDtResponseXml = FinalDtResponseXml + DtResponseXml;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //useKleber(1, 200);
            lbl_Result.Text = msg_InProgress;
            var excel = new ExcelQueryFactory(sourceFile)
            {
                DatabaseEngine = LinqToExcel.Domain.DatabaseEngine.Ace,
                TrimSpaces = LinqToExcel.Query.TrimSpacesType.Both,
                UsePersistentConnection = true,
                ReadOnly = true
            };
            var address = from p in excel.Worksheet<Address>(0) select p;
            int combi = 0;
            int lowerLimit = 1;
            int CountOfRecords = address.Count();//get count of records in excell sheet

            //the records require to be divide by 50 - as Kleber can process only 50 records at a time.
            
            int remainder = CountOfRecords % 20;

            int quotient = CountOfRecords / 20;

            try
            {
                InitializeExcel();
            }
            catch (Exception ex)
            {
                lbl_Result.Text = msg_Failure;
            }

            if (quotient > 0) //the quotitent is more than 1 -meaning the number of cycles loop
            {
                
                for (int j = 1; j <= quotient; j++)
                {
                    useKleber(counter, (counter + 19));
                    counter = counter + 20;
                }

                if (remainder > 0)
                {
                    useKleber(((quotient * 20) + 1), ((quotient * 20) + remainder));

                }

            }
            else
            {
                useKleber(1, remainder);
            }

            FinalDtResponseXml = "<EmbeddedByVinnies>" + FinalDtResponseXml + "</EmbeddedByVinnies>";

            StringBuilder XmlResponseStringBuilder = new StringBuilder();
            int ResultCounter = 0;
            string responseFetchedReqId = null;
            string responseFetchedValue = null;
            string resultFetchedName = null;
            string resultFetchedValue = null;

            int position = 1;

                    XmlReader XmlReader = XmlReader.Create(new StringReader(FinalDtResponseXml));
            try
            {
                while (XmlReader.Read())
                {
                    lastRow += 1;
                    if (XmlReader.IsStartElement())
                    {
                        switch (XmlReader.Name)
                        {
                            case "DtResponse":
                                //Console.WriteLine("DT RESPONSE");
                                if (XmlReader.HasAttributes)
                                {
                                    position = 1;
                                    while (XmlReader.MoveToNextAttribute())
                                    {
                                        switch (XmlReader.Name)
                                        {
                                            case "RequestId":
                                                responseFetchedReqId = XmlReader.Value;

                                                break;
                                        }
                                    }
                                    XmlReader.MoveToElement();
                                }
                                //Console.WriteLine(DisplayDoubleDividerString);
                                break;
                            case "Result":
                                
                                //Console.WriteLine("RESULT " + ResultCounter);
                                position = Convert.ToInt32(responseFetchedReqId); position++;
                                if (XmlReader.HasAttributes)
                                {
                                    //position = 1 ;
                                    while (XmlReader.MoveToNextAttribute())
                                    {
                                        string DPIDFetched = XmlReader["DPID"].ToString(); ;

                                        if (DPIDFetched != String.Empty)
                                        { 

                                            switch (XmlReader.Name)
                                            {

                                                case "AddressLine":

                                                    resultFetchedName = XmlReader.Name;
                                                    resultFetchedValue = XmlReader.Value;

                                                    MySheet.Cells[position, 10] = resultFetchedValue;
                                                    break;

                                                case "City":

                                                    resultFetchedName = XmlReader.Name;
                                                    resultFetchedValue = XmlReader.Value;

                                                    MySheet.Cells[position, 13] = resultFetchedValue;
                                                    break;

                                                case "Postcode":

                                                    resultFetchedName = XmlReader.Name;
                                                    resultFetchedValue = XmlReader.Value;

                                                    MySheet.Cells[position, 15] = resultFetchedValue;
                                                    break;

                                                case "State":

                                                    resultFetchedName = XmlReader.Name;
                                                    resultFetchedValue = XmlReader.Value;

                                                    MySheet.Cells[position, 14] = resultFetchedValue;
                                                    break;

                                                case "DPID":

                                                    resultFetchedName = XmlReader.Name;
                                                    resultFetchedValue = XmlReader.Value;
                                                    MySheet.Cells[position, 16] = resultFetchedValue;
                                                    ResultCounter++;
                                                    break;
                                            }
                                        }


                                    }
                                    XmlReader.MoveToElement();
                                }
                                //Console.WriteLine(DisplayDividerString);
                                break;

                        }

                    }
                    MyBook.Save();
                    ResultCounter++;
                }

                MyBook.Save();
                string XMLReaderDump = XmlReader.ToString();
                XmlReader.Dispose();

                MyBook.Saved = true;
                MyBook.Close();
                //MySheet.Unprotect();
                MyApp.Quit();
                lbl_Result.Text = msg_Success;//"Job completed succesfully";
            }
            catch (Exception ex)
            {
                XmlReader.Dispose();

                //MyBook.Saved = true;
                MyBook.Close();
                //MySheet.Unprotect();
                MyApp.Quit();
                lbl_Result.Text = msg_Failure;// "Job couldnt be completed . Encountered errors";

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_BrowseDestinationFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                txt_DestinationFileLocation.Text = file;
                destinationFile = file;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                    lbl_Result.Text = msg_Failure;
                }
            }

        }

        private void btn_BrowseSourceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                txt_SourceFileLocation.Text = file;
                sourceFile = file;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                    lbl_Result.Text = msg_Failure;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    internal class Address
    {

        [ExcelColumn("Street 1")]
        public string Street1 { get; set; }

        [ExcelColumn("Street 2")]
        public string Street2 { get; set; }

        [ExcelColumn("Street 3")]
        public string Street3 { get; set; }

        [ExcelColumn("City")]
        public string City { get; set; }

        [ExcelColumn("State")]
        public string State { get; set; }

        [ExcelColumn("Postcode")]
        public string Postcode { get; set; }

        [ExcelColumn("RequestId")]
        public int RequestId { get; set; }

    }
}
