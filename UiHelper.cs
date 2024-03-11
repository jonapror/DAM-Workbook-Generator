using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aprimo.ConfigurationWorkbookGenerator
{
    internal class UiHelper

    {
        private Main Form;

        internal UiHelper(Main form)
        {
            Form = form;
            Form.txtLog.Text = "";
            Form.progressBarMainProcess.Value = 0;
            Form.progressBarMainProcess.Step = 1;
            Form.progressBarSubProcess.Value = 0;
            Form.progressBarSubProcess.Step = 1;
        }

        internal void LogInfo(string message, bool performStepInMainProgressBar = false, bool performStepInSubProcessProgressBar = false)
        {
            Form.txtLog.AppendText(string.Format("{0}: {1}", DateTime.Now, message + Environment.NewLine));
            if (performStepInMainProgressBar) Form.progressBarMainProcess.PerformStep();
            if (performStepInSubProcessProgressBar) Form.progressBarSubProcess.PerformStep();
        }

        internal void SetMainProcessProgressBarMaximum(int max)
        {
            this.Form.progressBarMainProcess.Maximum = max;
        }

        internal void ResetSubProcessProgressBar()
        {
            this.Form.progressBarSubProcess.Value = 0;
        }
        internal void SetSubProcessProgressBarMaximum(int max)
        {
            this.Form.progressBarSubProcess.Maximum = max;
        }
    }
}
