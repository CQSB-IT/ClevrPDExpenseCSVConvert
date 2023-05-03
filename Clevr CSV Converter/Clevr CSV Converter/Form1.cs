namespace Clevr_CSV_Converter
{
    public partial class Form1 : Form
    {
        private const string LOG_PATH = @".\logs";
        private string lastErrorFilePath = @"";

        public Form1()
        {
            if (!Directory.Exists(LOG_PATH))
                Directory.CreateDirectory(LOG_PATH);

            InitializeComponent();
            ResetLabel();
        }

        /// <summary>
        /// When clicked, gets the source file path and the destination file path. Once both paths are obtained, 
        /// converts the file using a <see cref="CSVConverter"/> and outputs the result at the selected destionation path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            ResetLabel();
            string? sourceFilePath = GetCsvFilePath();

            if (sourceFilePath == null)
            {
                DisplayError("Sélection de fichier source abortée.");
                return;
            }

            string? destinationFilePath = GetCsvSaveLocation();

            if (destinationFilePath == null)
            {
                DisplayError("Sélection d'emplacement de sauvegarde abortée.");
                return;
            }


            // Happy path
            try
            {
                CSVConverter.Convert(sourceFilePath, destinationFilePath);
                DisplaySuccess("Conversion du fichier CSV réussi!");
            }
            catch(ClevrDataException clevrEx)
            {
                foreach(string error in clevrEx.GetErrors())
                {
                    AppendToLog($"Il y a une erreur dans le fichier CSV de Clevr avec la colone{error}");
                }
            }
            catch (Exception ex)
            {
                // Possiblement implémenter une classe pour faire des logs.

                string logFilePath = AppendToLog(ex.Message);
                DisplayError($"Erreur lors de la conversion du fichier CSV. Voir fichier de log ({logFilePath}) pour les détails.");
            }
        }

        /// <summary>
        /// Appends text to a log file with the current date.
        /// </summary>
        /// <param name="text">The text to append to the log file.</param>
        /// <returns>The path to the file where the text was appended.</returns>
        private string AppendToLog(string text)
        {
            string filePath = $@"{LOG_PATH}\{DateTime.Today.Date.ToString("yyyy-MM-dd HH_mm")}.txt";
            lastErrorFilePath = Path.GetFullPath( filePath);
            lbLogLink.Text = "Log file";
            using var writer = File.AppendText(filePath);
            writer.WriteLine(text);

            return filePath;
        }

        /// <summary>
        /// Opens a <see cref="OpenFileDialog"/> prompting the user to select a CSV file.
        /// </summary>
        /// <returns>The file path of the CSV file selected, or <see langword="null"/> if the user does not select a path.</returns>
        private static string? GetCsvFilePath()
        {
            OpenFileDialog opendlg = new OpenFileDialog()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true
            };

            var openDlgResult = opendlg.ShowDialog();

            return openDlgResult == DialogResult.OK
                ? opendlg.FileName
                : null;
        }

        /// <summary>
        /// Opens a <see cref="SaveFileDialog"/> prompting the user to select a destination to save a CSV file.
        /// </summary>
        /// <returns>The folder path of the selected destination, or <see langword="null"/> if the user does not select a path.</returns>
        private static string? GetCsvSaveLocation()
        {
            SaveFileDialog savedlg = new SaveFileDialog()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                OverwritePrompt = true,
                CheckPathExists = true
            };

            var saveDlgResult = savedlg.ShowDialog();

            return saveDlgResult == DialogResult.OK
                ? savedlg.FileName
                : null;
        }

        /// <summary>
        /// Displays a red error message in <see cref="convertBtnResult"/> <see cref="Label"/>.
        /// </summary>
        /// <param name="message">The message to display in the label.</param>
        private void DisplayError(string message)
        {
            convertBtnResult.ForeColor = Color.Red;
            convertBtnResult.Text = message;
        }

        /// <summary>
        /// Displays a green success message in <see cref="convertBtnResult"/> <see cref="Label"/>.
        /// </summary>
        /// <param name="message">The message to display in the label.</param>
        private void DisplaySuccess(string message)
        {
            convertBtnResult.ForeColor = Color.Green;
            convertBtnResult.Text = message;
        }

        /// <summary>
        /// Resets <see cref="convertBtnResult"/> <see cref="Label"/> status to blank with black text.
        /// </summary>
        private void ResetLabel()
        {
            convertBtnResult.ForeColor = Color.Black;
            convertBtnResult.Text = string.Empty;
            lbLogLink.Text = string.Empty;
            lastErrorFilePath = string.Empty;
        }

        private void lbLogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            { 
                if(!String.IsNullOrEmpty(lastErrorFilePath) )
                {
                    System.Diagnostics.Process.Start(@lastErrorFilePath);
                }                
            }
            catch { }            
        }

        //public Form1()
        //{
        //    InitializeComponent();
        //}

        //private void btnConvert_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog opendlg= new OpenFileDialog();
        //    opendlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        //    opendlg.Multiselect = false;
        //    opendlg.CheckFileExists=true;
        //    opendlg.CheckPathExists=true;
        //    SaveFileDialog savedlg= new SaveFileDialog();
        //    savedlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        //    savedlg.OverwritePrompt = true;
        //    savedlg.CheckPathExists = true;

        //    if(opendlg.ShowDialog() == DialogResult.OK) 
        //    {
        //        if (savedlg.ShowDialog() == DialogResult.OK)
        //        {
        //            CSVConverter.Convert(opendlg.FileName, savedlg.FileName);
        //        }
        //    }
        //}
    }
}