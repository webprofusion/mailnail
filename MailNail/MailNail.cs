using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace MailNail
{
    public partial class MailNail : Form
    {
        public MailNail()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage(txtFrom.Text, txtTo.Text);
                message.Subject = txtSubject.Text;
                message.Body = txtMessage.Text;

                SmtpClient client = new SmtpClient(txtSMTPServer.Text);
                // Credentials are necessary if the server requires the client
                // to authenticate before it will send e-mail on the client's behalf.
                if (!String.IsNullOrEmpty(txtPort.Text))
                {
                    client.Port = Int32.Parse(txtPort.Text);
                }

                if (!String.IsNullOrEmpty(txtUsername.Text))
                {
                    client.Credentials = new System.Net.NetworkCredential(txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    client.UseDefaultCredentials = true;
                }

                client.Send(message);

                MessageBox.Show("Mail sent ok.");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Send Failed:" + exp.ToString());
            }
        }
    }
}