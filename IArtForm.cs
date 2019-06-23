using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestefarsBilder
{
    public interface IArtForm
    {
        List<TextBox> GetTextBoxes();
        NumericUpDown GetTxtBxId();
        TextBox GetTxtBxWarning();
        GroupBox GetGroupBox();
        PictureBox GetPictureBox();
        Button GetButtonSave();
        List<ComboBox> GetComboBoxes();
        List<LinkLabel> GetLinkLabels();
        List<String> GetOrigImagePaths();
        string GetImagesPath();
        Logic GetLogic();
        Graphics GetGraphics();
    }
}
