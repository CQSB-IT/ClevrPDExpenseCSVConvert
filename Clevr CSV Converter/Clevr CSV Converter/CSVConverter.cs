using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
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
                this.Columns.Add("EmployeeID", typeof(string));
                this.Columns.Add("JobCode", typeof(string));
                this.Columns.Add("BeginDate",typeof(DateTime));
                this.Columns.Add("EndDate", typeof(DateTime));

                this.Columns.Add("BudgetCode1", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount1", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter1", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject1", typeof(string));

                this.Columns.Add("BudgetCode2", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount2", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter2", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject2", typeof(string));

                this.Columns.Add("BudgetCode3", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount3", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter3", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject3", typeof(string));

                this.Columns.Add("BudgetCode4", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount4", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter4", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject4", typeof(string));

                this.Columns.Add("BudgetCode5", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount5", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter5", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject5", typeof(string));

                this.Columns.Add("BudgetCode6", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount6", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter6", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject6", typeof(string));

                this.Columns.Add("BudgetCode7", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount7", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter7", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject7", typeof(string));

                this.Columns.Add("BudgetCode8", typeof(string));
                this.Columns.Add("BudgetCodeApprovedAmount8", typeof(decimal));
                this.Columns.Add("BudgetCodeCenter8", typeof(string));
                this.Columns.Add("EndDBudgetCodeProject8", typeof(string));


                this.Columns.Add("TotalApprovedAmount", typeof(decimal));
                this.Columns.Add("PlaceOfWorkCode", typeof(string));
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

        public CSVConverter() 
        { 
        
        }

        private void InitDataTable()
        {
            clevrDataTable.Columns.Add("EmployeeID", typeof(string));
            //    public string EmployeeID;
            //public string JobCode;
            //public DateTime BeginDate;
            //public DateTime EndDate;
            //public string BudgetCode1;
            //public decimal BudgetCodeApprovedAmount1;
            //public string BudgetCodeCenter1;
            //public string BudgetCodeProject1;
            //public string BudgetCode2;
            //public decimal BudgetCodeApprovedAmount2;
            //public string BudgetCodeCenter2;
            //public string BudgetCodeProject2;
            //public string BudgetCode3;
            //public decimal BudgetCodeApprovedAmount3;
            //public string BudgetCodeCenter3;
            //public string BudgetCodeProject3;
            //public string BudgetCode4;
            //public decimal BudgetCodeApprovedAmount4;
            //public string BudgetCodeCenter4;
            //public string BudgetCodeProject4;
            //public string BudgetCode5;
            //public decimal BudgetCodeApprovedAmount5;
            //public string BudgetCodeCenter5;
            //public string BudgetCodeProject5;
            //public string BudgetCode6;
            //public decimal BudgetCodeApprovedAmount6;
            //public string BudgetCodeCenter6;
            //public string BudgetCodeProject6;
            //public string BudgetCode7;
            //public decimal BudgetCodeApprovedAmount7;
            //public string BudgetCodeCenter7;
            //public string BudgetCodeProject7;
            //public string BudgetCode8;
            //public decimal BudgetCodeApprovedAmount8;
            //public string BudgetCodeCenter8;
            //public string BudgetCodeProject8;
            //public decimal TotalApprovedAmount;
            //public string PlaceOfWorkCode;


        }

        public static void Convert(string sourcePath, string destinationPath )
        {
            TextFieldParser parser = new(sourcePath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            String[] currentRow;
            String[] columnName;

            //Read first row to get columns names
            if(!parser.EndOfData)
            {
                try
                {
                    columnName = parser.ReadFields();
                }
                catch (MalformedLineException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            while (!parser.EndOfData)
            {
                try
                {
                    currentRow = parser.ReadFields();  
                    for(int col = 0; col < currentRow.Count();col++)
                    {

                    }
                }
                catch( MalformedLineException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            
        }
    }
}
