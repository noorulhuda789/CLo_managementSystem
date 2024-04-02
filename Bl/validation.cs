using Guna.UI2.WinForms;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System;

namespace DBMidProject.Bl
{
    public class GunaTextBoxValidator
    {
        private Guna2TextBox gunaTextBox;
        private ErrorProvider errorProvider;
        public int accuratelen{ get; set; }
        public string ErrorMessage { get; private set; }

        public GunaTextBoxValidator(Guna2TextBox gunaTextBox, string errorMessage)
        {
            this.gunaTextBox = gunaTextBox;
            this.ErrorMessage = errorMessage;

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        public GunaTextBoxValidator(Guna2TextBox gunaTextBox, string errorMessage,int accuratelen )
        {
            this.gunaTextBox = gunaTextBox;
            this.ErrorMessage = errorMessage;
           
            this.accuratelen = accuratelen; 

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public bool IsValid()
        {
            bool isValid = IsInputAlphabetic(gunaTextBox.Text);

            if (!isValid)
            {
                errorProvider.SetError(gunaTextBox, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(gunaTextBox, string.Empty);
            }

            return isValid;
        }

        private bool IsInputAlphabetic(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidInteger()
        {
            bool isValid = long.TryParse(gunaTextBox.Text, out long result);

            if (!isValid)
            {
                errorProvider.SetError(gunaTextBox, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(gunaTextBox, string.Empty);
            }

            return isValid;
        }
        public bool IsValidEmail()
        {
            string email = gunaTextBox.Text.Trim().ToLower(); // Trim and convert to lowercase for case-insensitive comparison

            bool isValid = email.EndsWith("@gmail.com");

            if (!isValid)
            {
                errorProvider.SetError(gunaTextBox, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(gunaTextBox, string.Empty);
            }

            return isValid;
        }

        public bool IsValidLength()
        {
            int currentLength = gunaTextBox.Text.Length;

            bool isValid = currentLength == accuratelen;

            if (!isValid)
            {
                errorProvider.SetError(gunaTextBox, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(gunaTextBox, string.Empty);
            }

            return isValid;
        }
        public bool IsValidAssement()
        {
            var input = gunaTextBox.Text.Trim();


            var pattern = @"^[a-zA-Z]+\d+$";

            Console.WriteLine('m');
            var isValid = Regex.IsMatch(input, pattern);

            if (!isValid)
            {
                
                errorProvider.SetError(gunaTextBox, ErrorMessage);
            }
            else
            {
                
                errorProvider.SetError(gunaTextBox, string.Empty);
            }

            return isValid;
        }
        public bool IsValidRegistrationNumber()
        {
            var input = gunaTextBox.Text.Trim();
            var pattern = @"^\d{4}[a-zA-Z]{2}\d{2}$";
            var isValid = Regex.IsMatch(input, pattern);

            if (!isValid)
            {
                errorProvider.SetError(gunaTextBox, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(gunaTextBox, string.Empty);
            }

            return isValid;
        }

    }
}
