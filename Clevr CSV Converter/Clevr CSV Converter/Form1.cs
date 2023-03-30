namespace Clevr_CSV_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg= new OpenFileDialog();
            opendlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            opendlg.Multiselect = false;
            opendlg.CheckFileExists=true;
            opendlg.CheckPathExists=true;
            SaveFileDialog savedlg= new SaveFileDialog();
            savedlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            savedlg.OverwritePrompt = true;
            savedlg.CheckPathExists = true;

            if(opendlg.ShowDialog() == DialogResult.OK) 
            {
                if (savedlg.ShowDialog() == DialogResult.OK)
                {
                    CSVConverter.Convert(opendlg.FileName, savedlg.FileName);
                }
            }
        }
    }
}