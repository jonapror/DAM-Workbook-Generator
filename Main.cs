using System;
using System.IO;
using System.Windows.Forms;

namespace Aprimo.ConfigurationWorkbookGenerator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;

            UiHelper logger = null;
            try
            {
                logger = new UiHelper(this);

                string SubDomain = txtSubdomain.Text.Trim();
                string ClientId = txtClientId.Text.Trim();
                string UserToken = txtUserToken.Text.Trim();
                string UserName = txtUserName.Text.Trim();

                if ((SubDomain.Length == 0) || (ClientId.Length == 0) || (UserToken.Length == 0) || (UserName.Length == 0))
                {
                    MessageBox.Show("Please input Subdomain, Client ID, User name and User token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    WorkbookHelper helper = new WorkbookHelper(SubDomain, ClientId, UserName, UserToken, logger);
                    helper.ExportConfiguration(txtOutputFilePath.Text, txtInputFilePath.Text);
                    txtInputFilePath.Text = txtOutputFilePath.Text;
                }
            }
            catch (Exception exception)
            {
                logger.LogInfo(exception.ToString());
            }

            btnGenerate.Enabled = true;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            ResetOutputFileName();
        }

        private void BtnBrowseForOutputFile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputFilePath.Text = Path.Combine(folderBrowserDialog1.SelectedPath, GetDefaultOutputFileName());
            }
        }

        private void BtnBrowseForInputFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInputFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void BtnResetOutputFileName_Click(object sender, EventArgs e)
        {
            ResetOutputFileName();
        }

        private void ResetOutputFileName()
        {
            txtOutputFilePath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), GetDefaultOutputFileName());
        }

        private string GetDefaultOutputFileName()
        {
            return string.Format("{0} ConfigWorkbook {1}.xlsx", txtSubdomain.Text.ToUpperInvariant(), DateTime.Now.ToString("yyyyMMdd-HHmmss")).Trim();
        }
    }
}
