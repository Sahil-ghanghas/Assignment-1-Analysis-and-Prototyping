using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public class CustomerEditorForm : Form
    {
        private readonly TextBox textBoxCustomerNumber;
        private readonly TextBox textBoxName;
        private readonly TextBox textBoxContact;
        private readonly Button buttonSave;
        private readonly Button buttonCancel;

        public string CustomerNumberValue
        {
            get { return textBoxCustomerNumber.Text.Trim(); }
        }

        public string CustomerNameValue
        {
            get { return textBoxName.Text.Trim(); }
        }

        public string CustomerContactValue
        {
            get { return textBoxContact.Text.Trim(); }
        }

        public CustomerEditorForm(string title, Customer existing = null)
        {
            Text = title;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(430, 235);
            BackColor = Color.FromArgb(250, 250, 250);
            Font = new Font("Segoe UI", 9F);

            var panelHeader = new Panel
            {
                BackColor = Color.FromArgb(15, 32, 66),
                Dock = DockStyle.Top,
                Height = 55
            };

            var labelTitle = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 14)
            };

            panelHeader.Controls.Add(labelTitle);

            var labelNumber = new Label { Text = "Customer Number", AutoSize = true, Location = new Point(20, 72) };
            var labelName = new Label { Text = "Full Name", AutoSize = true, Location = new Point(20, 112) };
            var labelContact = new Label { Text = "Contact Details", AutoSize = true, Location = new Point(20, 152) };

            textBoxCustomerNumber = new TextBox { Location = new Point(145, 69), Width = 260 };
            textBoxName = new TextBox { Location = new Point(145, 109), Width = 260 };
            textBoxContact = new TextBox { Location = new Point(145, 149), Width = 260 };

            buttonSave = new Button
            {
                Text = "Save",
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(223, 191),
                Width = 85
            };

            buttonCancel = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(320, 191),
                Width = 85
            };

            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += delegate { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(panelHeader);
            Controls.Add(labelNumber);
            Controls.Add(labelName);
            Controls.Add(labelContact);
            Controls.Add(textBoxCustomerNumber);
            Controls.Add(textBoxName);
            Controls.Add(textBoxContact);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);

            if (existing != null)
            {
                textBoxCustomerNumber.Text = existing.CustomerNumber;
                textBoxCustomerNumber.Enabled = false;
                textBoxName.Text = existing.Name;
                textBoxContact.Text = existing.ContactDetails;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustomerNumberValue) || string.IsNullOrWhiteSpace(CustomerNameValue) || string.IsNullOrWhiteSpace(CustomerContactValue))
            {
                MessageBox.Show("All customer fields are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
