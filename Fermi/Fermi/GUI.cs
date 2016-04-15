using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fermi {
    public partial class GUI : Form {

        Fermi fermi = new Fermi();
        TextFieldValidator validator = new TextFieldValidator();
        public Boolean isNew;
        private static Boolean isValid;
        

        public GUI() {
            InitializeComponent();
            this.Text = "Fermi";
            fermi.reset();
            txtOutput.Text = fermi.getAnswer();
        }

        private void btnOk_Click(object sender, EventArgs e) {

            TextBox[] _boxs = { txtInput1, txtInput2, txtInput3 };

            bool valid = false;
            foreach (TextBox _box in _boxs) {
                valid = validator.checkText(_box);
                if (!valid) { break; }
            }

            if (valid) {
                getResult();
            } else {
                MessageBox.Show("You have entered invalid input. Please enter valid input.");
            }
        
          
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            dispose();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            reset();
        }
        public void getResult() {

            if (isValid == true) {
                Int32 num1 = Int32.Parse(txtInput1.Text);
                Int32 num2 = Int32.Parse(txtInput2.Text);
                Int32 num3 = Int32.Parse(txtInput3.Text);

                String answer = fermi.guess(num1, num2, num3);
                Int32 guesses = fermi.getGuesses();
                String guessOutput;

                if (answer != null) {
                    if (fermi.gameOverCheck(answer)) {
                        guessOutput = "Congratulations! You Win! Total guesses used: " + guesses;
                        String output = guessOutput + Environment.NewLine + "Guess " + guesses + ": " + num1 + " " + num2 + " " + num3 + " : " + answer + Environment.NewLine + txtOutput.Text.Substring(txtOutput.Text.IndexOf(Environment.NewLine) + 1);
                        txtOutput.Text = output;
                        btnOk.Enabled = false;
                    } else {
                        guessOutput = "Guesses used so far: " + guesses;
                        String output = guessOutput + Environment.NewLine + "Guess " + guesses + ": " + num1 + " " + num2 + " " + num3 + " : " + answer + Environment.NewLine + txtOutput.Text.Substring(txtOutput.Text.IndexOf(Environment.NewLine) + 1);
                        txtOutput.Text = output;
                    }
                } else {
                    MessageBox.Show("You have entered a duplicate guess! Enter a different one.");
                }
            } else {
                MessageBox.Show("You have not entered valid input. Please enter valid input.");
            }

        }
        public void dispose() {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }
        public void reset() {
            fermi.reset();
            txtInput1.Clear();
            txtInput1.BackColor = Color.White;
            txtInput1.ForeColor = Control.DefaultForeColor;
            txtInput2.Clear();
            txtInput2.BackColor = Color.White;
            txtInput2.ForeColor = Control.DefaultForeColor;
            txtInput3.Clear();
            txtInput3.BackColor = Color.White;
            txtInput3.ForeColor = Control.DefaultForeColor;

            txtOutput.Text = fermi.getAnswer();
            btnOk.Enabled = true;

            isNew = true;

            //Console.Write(fermi.getAnswer());
            //System.Diagnostics.Debug.WriteLine(fermi.getAnswer());
            
        }

        

        private void txtInput1_TextChanged(object sender, EventArgs e) {
            isValid = validator.checkText(this.txtInput1);
            isNew = false;
        }

        private void txtInput2_TextChanged(object sender, EventArgs e) {
            isValid = validator.checkText(this.txtInput2);
            isNew = false;
        }

        private void txtInput3_TextChanged(object sender, EventArgs e) {
            isValid = validator.checkText(this.txtInput3);
            isNew = false;
        }

        
        private void txtInput3_FocusLost(object sender, EventArgs e) {
            txtInput3.BackColor = Color.White;
            txtInput3.ForeColor = Control.DefaultForeColor;
        }

        private void txtInput2_FocusLost(object sender, EventArgs e) {
            txtInput2.BackColor = Color.White;
            txtInput2.ForeColor = Control.DefaultForeColor;
        }

        private void txtInput1_FocusLost(object sender, EventArgs e) {
            txtInput1.BackColor = Color.White;
            txtInput1.ForeColor = Control.DefaultForeColor;
        }
    }
}
