using System;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class RoomDialog : Form
    {
        public string RoomName { get => textBox1.Text;  }
        public string RoomOwnerDiskColor { get => DiskColorComboBox.Text; }
        public string RoomBoardSize { get => BoardSizeComboBox.Text; }
        public RoomDialog()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
          if (
             textBox1.Text == String.Empty
          || DiskColorComboBox.SelectedIndex == -1
          || BoardSizeComboBox.SelectedIndex == -1)
			    {
            MessageBox.Show("Please, fill all new group fields");
			    }
			    else
			    {
            this.DialogResult = DialogResult.OK;
            this.Close();
          }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
