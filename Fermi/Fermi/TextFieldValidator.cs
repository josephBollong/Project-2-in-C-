using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fermi {
    class TextFieldValidator {

        private static readonly String DEFAULT_REGEX = "^[0-9]$";
	    private static readonly Color DEFAULT_ERROR_COLOR = Color.Red;
	    private static readonly Color DEFAULT_VALID_COLOR = Color.Green;
	    private String regex = null;
        private Color errorColor;
        private Color validColor;
        

        /**
         * text field validator
         * 
         * creates a validator with the default valid color and regex
         * 
         * @param txtBox
         * @param errorColor
         */
        public void checkText(TextBox txtBox, Color errorColor) {

            this.errorColor = errorColor;
            this.validColor = DEFAULT_VALID_COLOR;
            this.regex = DEFAULT_REGEX;

        }

        public void checkText(TextBox txtBox, bool changeColor) {
            
        }

        /**
         * creates a validator with all default values
         * 
         * @param txtBox
         */
        public Boolean checkText(TextBox txtBox) {

            this.errorColor = DEFAULT_ERROR_COLOR;
            this.validColor = DEFAULT_VALID_COLOR;
            this.regex = DEFAULT_REGEX;


            if (check(txtBox, regex)) {
                txtBox.BackColor = DEFAULT_VALID_COLOR;
                txtBox.ForeColor = Color.White;
                return true;
            } else {
                txtBox.BackColor = DEFAULT_ERROR_COLOR;
                txtBox.ForeColor = Color.White;
                return false;
            }

        }


        public String getRegex() {
            return regex;
        }

        public void setRegex(String regex) {
            this.regex = regex;
        }

        public Color getErrorColor() {
            return errorColor;
        }

        public void setErrorColor(Color errorColor) {
            this.errorColor = errorColor;
        }

        public Color getValidColor() {
            return validColor;
        }

        public void setValidColor(Color validColor) {
            this.validColor = validColor;
        }


        /**
       * check method;
       * 
       * This takes the text matches it to a regex and returns the result
       * 
       * @return isValid
       */


        public Boolean check(TextBox txtInput, String _regex) {

            Regex r = new Regex(_regex);
           
            Boolean isValid = r.IsMatch(txtInput.Text);

            return isValid;
        }
    }
}
