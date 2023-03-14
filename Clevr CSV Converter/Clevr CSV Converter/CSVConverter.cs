using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clevr_CSV_Converter
{
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
                this.Columns.Add("LIEU_TRAV", typeof(string));

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
                this.Columns.Add("Matr", typeof(string));
                this.Columns.Add("NoSEQ", typeof(int));
                this.Columns.Add("CodePmnt", typeof(string));
                this.Columns.Add("RefEmpl", typeof(string));
                this.Columns.Add("DateDeb", typeof(DateTime));
                this.Columns.Add("DateFin", typeof(DateTime));
                this.Columns.Add("Mode", typeof(string));
                this.Columns.Add("NbUnit", typeof(decimal));
                this.Columns.Add("MntUnit", typeof(decimal));
                this.Columns.Add("Mnt", typeof(decimal));
                this.Columns.Add("NoCmpt", typeof(string));
                this.Columns.Add("LieuTrav", typeof(string));
                this.Columns.Add("Prov", typeof(string));
                this.Columns.Add("Note", typeof(string));
                this.Columns.Add("CodeUtil", typeof(string));
                this.Columns.Add("NoTypePmnt", typeof(int));
                this.Columns.Add("CntrePrjt", typeof(string));
                this.Columns.Add("NoPrjt", typeof(string));
                this.Columns.Add("DateTX", typeof(DateTime));
                this.Columns.Add("TypeTX", typeof(string));
                this.Columns.Add("Statut", typeof(int));
            }
        }

        //private ClevrDataTable clevrDT;

        public CSVConverter() 
        { 
        
        }

        //private void InitDataTable()
        //{
        //    clevrDT.Columns.Add("EmployeeID", typeof(string));
        //    //    public string EmployeeID;
        //    //public string JobCode;
        //    //public DateTime BeginDate;
        //    //public DateTime EndDate;
        //    //public string BudgetCode1;
        //    //public decimal BudgetCodeApprovedAmount1;
        //    //public string BudgetCodeCenter1;
        //    //public string BudgetCodeProject1;
        //    //public string BudgetCode2;
        //    //public decimal BudgetCodeApprovedAmount2;
        //    //public string BudgetCodeCenter2;
        //    //public string BudgetCodeProject2;
        //    //public string BudgetCode3;
        //    //public decimal BudgetCodeApprovedAmount3;
        //    //public string BudgetCodeCenter3;
        //    //public string BudgetCodeProject3;
        //    //public string BudgetCode4;
        //    //public decimal BudgetCodeApprovedAmount4;
        //    //public string BudgetCodeCenter4;
        //    //public string BudgetCodeProject4;
        //    //public string BudgetCode5;
        //    //public decimal BudgetCodeApprovedAmount5;
        //    //public string BudgetCodeCenter5;
        //    //public string BudgetCodeProject5;
        //    //public string BudgetCode6;
        //    //public decimal BudgetCodeApprovedAmount6;
        //    //public string BudgetCodeCenter6;
        //    //public string BudgetCodeProject6;
        //    //public string BudgetCode7;
        //    //public decimal BudgetCodeApprovedAmount7;
        //    //public string BudgetCodeCenter7;
        //    //public string BudgetCodeProject7;
        //    //public string BudgetCode8;
        //    //public decimal BudgetCodeApprovedAmount8;
        //    //public string BudgetCodeCenter8;
        //    //public string BudgetCodeProject8;
        //    //public decimal TotalApprovedAmount;
        //    //public string PlaceOfWorkCode;


        //}

        public static void Convert(string sourcePath, string destinationPath )
        {
            using (ClevrDataTable clevrDataTable = new())
            {
                using (GricsPaieGRHDataTable gricsDataTable = new())
                {
                    // Use OLEDB to read CSV file and import it in DataTable
                    bool isFirstRowHeader = true;
                    string header = isFirstRowHeader ? "Yes" : "No";

                    string pathOnly = Path.GetDirectoryName(sourcePath);
                    string fileName = Path.GetFileName(sourcePath);

                    string sql = @"SELECT * FROM [" + fileName + "]";

                    using (OleDbConnection connection = new OleDbConnection(
                              @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                              ";Extended Properties=\"Text;HDR=" + header + "\""))
                    using (OleDbCommand command = new(sql, connection))
                    using (OleDbDataAdapter adapter = new(command))
                    {

                        clevrDataTable.Locale = CultureInfo.CurrentCulture;
                        adapter.Fill(clevrDataTable);
                    }

                    // Transfer information to GricsPaieGRHDataTable            
                    foreach (DataRow row in clevrDataTable.Rows)
                    {
                        // For each Budget code, create a new transaction row in GricsPaieGRHDataTable
                        for (int n = 1; n < 9; n++)
                        {
                            // If Budget code exist, create transaction
                            string? v = row["NO_CMPT" + n.ToString()].ToString();
                            if (v is not null)
                            {
                                DataRow newRow = gricsDataTable.NewRow();
                                newRow["Matr"] = row["MATR"];

                                newRow["NoSEQ"] = n.ToString();
                                newRow["CodePmnt"] = "'302005";
                                newRow["RefEmpl"] = row["REF_EMPL"].ToString().Substring(0, 1);
                                object dateDeb = row["DATE_DEB"];
                                newRow["DateDeb"] = DateTime.ParseExact((string)dateDeb, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                object dateFin = row["DATE_FIN"];
                                newRow["DateFin"] = DateTime.ParseExact((string)dateFin, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                newRow["Mode"] = String.Empty;
                                newRow["NbUnit"] = 0;
                                newRow["MntUnit"] = 0;
                                newRow["Mnt"] = row["MNT" + n.ToString()];
                                newRow["NoCmpt"] = row["NO_CMPT" + n.ToString()].ToString().Trim('-');
                                newRow["LieuTrav"] = String.Concat("'", row["LIEU_TRAV"].ToString());
                                newRow["Prov"] = "S";
                                newRow["Note"] = String.Empty;
                                newRow["CodeUtil"] = "'AUCLAIRY";
                                newRow["NoTypePmnt"] = 0;
                                newRow["CntrePrjt"] = row["CNTRE_PRJT" + n.ToString()];
                                newRow["NoPrjt"] = row["NO_PRJT" + n.ToString()];
                                newRow["DateTX"] = DateTime.Now.ToString("yyyy-MM-dd");
                                newRow["TypeTX"] = "I";
                                newRow["Statut"] = "0";

                                gricsDataTable.Rows.Add(newRow);
                            }
                        }
                    }
                    //Export GricsDataTable to CSV
                    gricsDataTable.ToCSV(destinationPath);
                }
            }
        }
    }
    public static class CSVUtility
    {
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
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
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }

}
