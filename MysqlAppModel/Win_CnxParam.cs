using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Fabrice GARCIA (20290 BORGO, Haute-Corse, France. November 1, 2021)
// You are free to include this code in your programs.
// It is provided to you freely and free of charge without any liability on my part.
// I only ask you to respect my copyright by keeping my name
// You can also send me a thank you email to fab2bprog@outlook.fr that will make me happy.


namespace MysqlAppModel
{
    public partial class Win_CnxParam : Form
    {
        public Win_CnxParam()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void Win_CnxParam_Load(object sender, EventArgs e)
        {

            Text_AdresseIP.Text    = GestParam.Param_Server;
            Text_MainDatabase.Text = GestParam.Param_MainDatabase;
            Text_LoginProg.Text    = GestParam.Param_UserId;
            Text_ProgPassword.Text = GestParam.Param_PassWord;
            Text_Port.Text         = GestParam.Param_MysqlPort;


        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {

            if (Detect_CnxParam_Change())
            {
                DialogResult dialogResult = MessageBox.Show("Appliquer les modifications ?", "Demande de confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }

            GestParam.Param_Server = Text_AdresseIP.Text.Trim();
            GestParam.Param_MainDatabase = Text_MainDatabase.Text.Trim();
            GestParam.Param_UserId = Text_LoginProg.Text.Trim();
            GestParam.Param_PassWord = Text_ProgPassword.Text.Trim();
            GestParam.Param_MysqlPort = Text_Port.Text.Trim();

            GestParam.Save_Param2Setting();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool Detect_CnxParam_Change()
        {

            if (Text_AdresseIP.Text    != GestParam.Param_Server       ) { return true; };
            if (Text_MainDatabase.Text != GestParam.Param_MainDatabase ) { return true; };
            if (Text_LoginProg.Text    != GestParam.Param_UserId       ) { return true; };
            if (Text_ProgPassword.Text != GestParam.Param_PassWord     ) { return true; };
            if (Text_Port.Text         != GestParam.Param_MysqlPort    ) { return true; };

            return false;

        }

        private void Text_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChampEntier monCode = new ChampEntier();
            monCode.ScanCible = (TextBox)sender;
            monCode.eKeyPressEvArg = (KeyPressEventArgs)e;
            monCode.ValMin = 0;
            monCode.ValMax = 65535;
            monCode.Valide_KeyPress();
        }

        private void Text_Port_TextChanged(object sender, EventArgs e)
        {
            ChampEntier monCode = new ChampEntier();
            monCode.ScanCible = (TextBox)sender;
            monCode.ValMin = 0;
            monCode.ValMax = 65535;
            monCode.Valide_TextChanged();
        }

        private void Text_Port_Leave(object sender, EventArgs e)
        {
            ChampEntier monCode = new ChampEntier();
            monCode.ScanCible = (TextBox)sender;
            monCode.ValMin = 0;
            monCode.ValMax = 65535;
            monCode.Valide_Leave();

            if (monCode.ScanCible.Text == string.Empty) { monCode.ScanCible.Text = "3306"; }

        }


    }
}
