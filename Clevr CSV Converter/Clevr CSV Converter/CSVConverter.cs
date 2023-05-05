using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Clevr_CSV_Converter.CSVConverter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clevr_CSV_Converter
{
    class ClevrDataException : Exception
    {
        private List<string> errors;
        public ClevrDataException() 
        { 
            errors = new List<string>();
        }

        public ClevrDataException(List<string> errors)
        {
            this.errors = errors;
        }
        public List<string> GetErrors()
        { return this.errors; }
    }

    internal class CSVConverter
    {
        struct ClevrCSV
        {
            public string EmployeeID;
            public string JobCode;
            public DateTime BeginDate;
            public DateTime EndDate;
            public string BudgetCode1;
            public decimal BudgetCodeApprovedAmount1;
            public string BudgetCodeCenter1;
            public string BudgetCodeProject1;
            public string BudgetCode2;
            public decimal BudgetCodeApprovedAmount2;
            public string BudgetCodeCenter2;
            public string BudgetCodeProject2;
            public string BudgetCode3;
            public decimal BudgetCodeApprovedAmount3;
            public string BudgetCodeCenter3;
            public string BudgetCodeProject3;
            public string BudgetCode4;
            public decimal BudgetCodeApprovedAmount4;
            public string BudgetCodeCenter4;
            public string BudgetCodeProject4;
            public string BudgetCode5;
            public decimal BudgetCodeApprovedAmount5;
            public string BudgetCodeCenter5;
            public string BudgetCodeProject5;
            public string BudgetCode6;
            public decimal BudgetCodeApprovedAmount6;
            public string BudgetCodeCenter6;
            public string BudgetCodeProject6;
            public string BudgetCode7;
            public decimal BudgetCodeApprovedAmount7;
            public string BudgetCodeCenter7;
            public string BudgetCodeProject7;
            public string BudgetCode8;
            public decimal BudgetCodeApprovedAmount8;
            public string BudgetCodeCenter8;
            public string BudgetCodeProject8;
            public decimal TotalApprovedAmount;
            public string PlaceOfWorkCode;
        }

        struct GricsPaieGRHCSV
        {
            public string Matr;
            public int NoSEQ;
            public string CodePmnt;
            public string RefEmpl;
            public DateTime DateDeb;
            public DateTime DateFin;
            public string Mode;
            public decimal NbUnit;
            public decimal MntUnit;
            public decimal Mnt;
            //EXP_RECON;
            public string NoCmpt;
            //MATR_REMP;NO_PIECE;
            public String LieuTrav;
            //ADM_AE;ADM_CSST;ADM_FED;ADM_FPSQ;ADM_PROV;ADM_RR;ADM_RREGOP;ADM_RRQ;ADM_RRL;ADM_RRP;NB_JRS_PRES;NB_MIN_AUT;NB_MIN_EDUC;NB_SEM_REP;NB_SEM_RET;REPAR_AE;ADM_HEUR;
            public string Prov;
            public string Note;
            public string CodeUtil;
            public int NoTypePmnt;
            public string CntrePrjt;
            public string NoPrjt;
            //ACT_CMPT;MOTIF_CMPT;IND_PMNT_INAC_REGR;IND_PMNT_INAC_GEST;ECO;GRP_DEP;RANG_ELE_EXC;
            public DateTime DateTX;
            //ADM_RQAP;NO_PIECE_SYST;
            public string TypeTX;
            public int Statut;
        }
        internal class ClevrDataTable:DataTable
        {
            public ClevrDataTable() 
            {
                this.Columns.Add("MATR", typeof(string));
                this.Columns.Add("REF_EMPL", typeof(string));
                this.Columns.Add("DATE_DEB", typeof(DateTime));
                this.Columns.Add("DATE_FIN", typeof(DateTime));
                this.Columns.Add("LIEU_TRAV", typeof(string));
                this.Columns.Add("PDRequest", typeof(string));

                this.Columns.Add("NO_CMPT1", typeof(string));
                this.Columns.Add("MNT1", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT1", typeof(string));
                this.Columns.Add("NO_PRJT1", typeof(string));

                this.Columns.Add("NO_CMPT12", typeof(string));
                this.Columns.Add("MNT2", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT2", typeof(string));
                this.Columns.Add("NO_PRJT2", typeof(string));

                this.Columns.Add("NO_CMPT13", typeof(string));
                this.Columns.Add("MNT3", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT3", typeof(string));
                this.Columns.Add("NO_PRJT3", typeof(string));

                this.Columns.Add("NO_CMPT14", typeof(string));
                this.Columns.Add("MNT4", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT4", typeof(string));
                this.Columns.Add("NO_PRJT4", typeof(string));

                this.Columns.Add("NO_CMPT15", typeof(string));
                this.Columns.Add("MNT5", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT5", typeof(string));
                this.Columns.Add("NO_PRJT5", typeof(string));

                this.Columns.Add("NO_CMPT16", typeof(string));
                this.Columns.Add("MNT6", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT6", typeof(string));
                this.Columns.Add("NO_PRJT6", typeof(string));

                this.Columns.Add("NO_CMPT17", typeof(string));
                this.Columns.Add("MNT7", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT7", typeof(string));
                this.Columns.Add("NO_PRJT7", typeof(string));

                this.Columns.Add("NO_CMPT18", typeof(string));
                this.Columns.Add("MNT8", typeof(decimal));
                this.Columns.Add("CNTRE_PRJT8", typeof(string));
                this.Columns.Add("NO_PRJT8", typeof(string));               
            }
        }
        internal class GricsPaieGRHDataTable : DataTable
        {
            public GricsPaieGRHDataTable()
            {
                this.Columns.Add("MATR", typeof(string));
                this.Columns.Add("NO_SEQ", typeof(string));
                this.Columns.Add("CODE_PMNT", typeof(string));
                this.Columns.Add("REF_EMPL", typeof(string));
                this.Columns.Add("DATE_DEB", typeof(string));
                this.Columns.Add("DATE_FIN", typeof(string));
                this.Columns.Add("MODE", typeof(string));
                this.Columns.Add("NB_UNIT", typeof(decimal));
                this.Columns.Add("MNT_UNIT", typeof(decimal));
                this.Columns.Add("MNT", typeof(decimal));
                this.Columns.Add("NO_CMPT", typeof(string));
                this.Columns.Add("LIEU_TRAV", typeof(string));
                this.Columns.Add("PROV", typeof(string));
                this.Columns.Add("NOTE", typeof(string));
                this.Columns.Add("CODE_UTIL", typeof(string));
                this.Columns.Add("NO_TYPE_PMNT", typeof(int));
                this.Columns.Add("CNTRE_PRJT", typeof(string));
                this.Columns.Add("NO_PRJT", typeof(string));
                this.Columns.Add("DATE_TX", typeof(string));
                this.Columns.Add("TYPE_TX", typeof(string));
                this.Columns.Add("STATUT", typeof(int));
            }
        }

        //private ClevrDataTable clevrDT;

        public CSVConverter() 
        { 
        
        }

        public static List<string> ValidateClevrData(ClevrDataTable clevrDataTable)
        {
            List<string> errors = new List<string>();
            // Transfer information to GricsPaieGRHDataTable            
            foreach (DataRow row in clevrDataTable.Rows)
            {
                if (row["MATR"] == DBNull.Value)
                {
                    errors.Add("MATR");
                }
                for(int n = 1;n< 9;n++)
                {
                    // We validate NO_CMPT, CNTRE_PRJt and NO_PRJT only if MNT is not DBNull.  If DBNull, we go to the next row
                    if (row[$"MNT{n}"] != DBNull.Value)
                    {
                        //if (row[$"NO_CMPT{n}"] == DBNull.Value)
                        //{
                        //    errors.Add($"NO_CMPT{n}");
                        //}

                        //if (row[$"CNTRE_PRJT{n}"] == DBNull.Value)
                        //{
                        //    errors.Add($"CNTRE_PRJT{n}");
                        //}
                        //if (row[$"NO_PRJT{n}"] == DBNull.Value)
                        //{
                        //    errors.Add($"NO_PRJT{n}");
                        //}
                    }               
                }
                

                if (row["REF_EMPL"] == DBNull.Value)
                {
                    errors.Add("REF_EMPL");
                }

                if (row["DATE_DEB"] == DBNull.Value)
                {
                    errors.Add("DATE_DEB");
                }
                if (row["DATE_FIN"] == DBNull.Value)
                {
                    errors.Add("DATE_FIN");
                }

                int lieuTrav;
                if (!int.TryParse(row["LIEU_TRAV"].ToString(), out lieuTrav))
                {
                    errors.Add("LIEU_TRAV");
                }
            }
            return errors;
        }

        public static ClevrDataTable ReadClevrCSV(string clevrCSVPath)
        {
            using (ClevrDataTable clevrDataTable = new())
            {
                // Use OLEDB to read CSV file and import it in DataTable
                bool isFirstRowHeader = true;
                string header = isFirstRowHeader ? "Yes" : "No";

                string pathOnly = Path.GetDirectoryName(clevrCSVPath);
                string fileName = Path.GetFileName(clevrCSVPath);

                string sql = @"SELECT * FROM [" + fileName + "]";

                using (OleDbConnection connection = new OleDbConnection(
                            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathOnly +
                            ";Extended Properties=\"Text;HDR=" + header + "\""))

                //Microsoft.Jet.OLEDB.4.0
                using (OleDbCommand command = new(sql, connection))
                using (OleDbDataAdapter adapter = new(command))
                {

                    clevrDataTable.Locale = CultureInfo.CurrentCulture;
                    adapter.Fill(clevrDataTable);
                }
                return clevrDataTable;
             }
        }

        public static GricsPaieGRHDataTable FillGricsPaieGRHDataTable(ClevrDataTable clevrDataTable,string paymentCode, string paieGRHAuthenticationCode)
        {   
            if(string.IsNullOrWhiteSpace(paymentCode))
            {
                throw new ArgumentNullException(nameof(paymentCode));
            }

            if (string.IsNullOrWhiteSpace(paieGRHAuthenticationCode))
            {
                throw new ArgumentNullException(nameof(paieGRHAuthenticationCode));
            }

            // If ClevrDataTable value are not valid for what we need, throw an exception
            List<string> error = ValidateClevrData(clevrDataTable);
            if (error.Count > 0)
                throw new ClevrDataException(error);

            GricsPaieGRHDataTable paieGRHDataTable = new GricsPaieGRHDataTable();

            // Transfer information to GricsPaieGRHDataTable            
            foreach (DataRow row in clevrDataTable.Rows)
            {
                // For each Budget code, create a new transaction row in GricsPaieGRHDataTable
                // All non empty string must begin by ' in the destination CSV
                for (int n = 1; n < 9; n++)
                {
                    // If Budget code exist, create transaction
                    string? v = row["NO_CMPT" + n.ToString()].ToString();
                    if (!string.IsNullOrEmpty(v))
                    {
                        //TODO: Add validation for empty values
                        DataRow newRow = paieGRHDataTable.NewRow();
                        newRow["MATR"] = string.Concat("'",row["MATR"]);
                        newRow["NO_SEQ"] = String.Empty;// Must stay empty for importation
                        newRow["CODE_PMNT"] = $"'{paymentCode}";
                        newRow["REF_EMPL"] = row["REF_EMPL"].ToString().Substring(0, 1);// Only the letter linked to job reference
                        newRow["DATE_DEB"] = ((DateTime)row["DATE_DEB"]).ToString("yyyy-MM-dd");
                        newRow["DATE_FIN"] = ((DateTime)row["DATE_FIN"]).ToString("yyyy-MM-dd");
                        newRow["MODE"] = String.Empty;
                        newRow["NB_UNIT"] = 0;
                        newRow["MNT_UNIT"] = 0;
                        newRow["MNT"] = row["MNT" + n.ToString()];//MNT1 to MNT8
                        newRow["NO_CMPT"] = (row["NO_CMPT" + n.ToString()].ToString()).Replace("-","");//NO_CMPT1 to NO_CMPT8
                        int lieuTrav;
                        int.TryParse(row["LIEU_TRAV"].ToString(), out lieuTrav);
                        newRow["LIEU_TRAV"] = string.Format("'{0,3:D3}", lieuTrav);                        
                        newRow["PROV"] = "S";// TODO: To verify if it is the good code
                        newRow["NOTE"] = String.Empty;
                        newRow["CODE_UTIL"] = $"'{paieGRHAuthenticationCode}";// TODO: Determine if this must be an existing user code in Paie et GRH
                        newRow["NO_TYPE_PMNT"] = 0;
                        newRow["CNTRE_PRJT"] = row["CNTRE_PRJT" + n.ToString()];// CNTRE_PRJT1 to CNTRE_PRJT8
                        newRow["NO_PRJT"] = row["NO_PRJT" + n.ToString()];// NO_PRJT1 to NO_PRJT8
                        newRow["DATE_TX"] = DateTime.Now.ToString("yyyy-MM-dd");
                        newRow["TYPE_TX"] = "I";
                        newRow["STATUT"] = "0";
                        paieGRHDataTable.Rows.Add(newRow);
                    }
                }
            }
            return paieGRHDataTable;
        }

        public static void Convert(string sourcePath, string destinationPath, string paymentCode, string paieGRHAuthenticationCode)
        {
            if (string.IsNullOrWhiteSpace(paymentCode))
                throw new ArgumentNullException(nameof(paymentCode));

            if (string.IsNullOrWhiteSpace(paieGRHAuthenticationCode))
                throw new ArgumentNullException(nameof(paieGRHAuthenticationCode));

            using (ClevrDataTable clevrDataTable = ReadClevrCSV(sourcePath))
            {
                using (GricsPaieGRHDataTable gricsDataTable = FillGricsPaieGRHDataTable(clevrDataTable, paymentCode, paieGRHAuthenticationCode))
                {
                    //Export GricsDataTable to CSV
                    gricsDataTable.ToCSV(destinationPath,';');
                }
            }
        }

        public static bool CompareExportedCSVToPaieGRHPaiement(string sourcePath, string paymentCode, string paieGRHAuthenticationCode)
        {
            if (string.IsNullOrWhiteSpace(paymentCode))
                throw new ArgumentNullException(nameof(paymentCode));

            string query = "";
            using (OleDbConnection conPaieGRH = new OleDbConnection(@"Provider=sqloledb;Data Source=sql.cqsb.board\sql;Initial Catalog=myDataBase;Integrated Security=SSPI;"))
            using (OleDbCommand cmdPaieGRH = new(query, conPaieGRH))
            using (OleDbDataAdapter adaptPaieGRH = new(cmdPaieGRH))
            using (ClevrDataTable clevr = ReadClevrCSV(sourcePath))// Read Clevr CSV file
            using (GricsPaieGRHDataTable clevrConverted = FillGricsPaieGRHDataTable(clevr, paymentCode, paieGRHAuthenticationCode)) // Convert Clevr CSV to Paie et GRH format
            using (GricsPaieGRHDataTable paymentsForPaieGRH = new())
            {
                adaptPaieGRH.Fill(paymentsForPaieGRH);
                // Validate if both datatables have the same rows and columns count
                if (clevrConverted.Rows.Count != paymentsForPaieGRH.Rows.Count || clevrConverted.Columns.Count != paymentsForPaieGRH.Columns.Count)
                    return false;

                // Validate that each column of each row has the same value in both datatable
                for (int i = 0; i < clevrConverted.Rows.Count; i++)
                {
                    for (int c = 0; c < clevrConverted.Columns.Count; c++)
                    {
                        if (!Equals(clevrConverted.Rows[i][c], paymentsForPaieGRH.Rows[i][c]))
                            return false;
                    }
                }
                return true;
            }
        }
    }
    public static class CSVUtility
    {
        public static void ToCSV(this DataTable dtDataTable, string strFilePath, char cSeparator=',')
        {
            StreamWriter sw = new(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(cSeparator);
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!System.Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(cSeparator))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(cSeparator);
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }

}
