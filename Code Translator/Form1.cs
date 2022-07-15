using System;
using System.Windows.Forms;

namespace Code_Translator
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        //convert J to I cipher
        static string ConvertJtoI(string userInput)
        {
            string cipher = userInput.Replace('J', 'I');

            return cipher;
        }

        //remove duplicate data from cipher
        static string RemoveDupes(string cipher)
        {
            
            string dupeString = string.Empty;
            for (int i = 0; i < cipher.Length; i++)
            {
                if (!dupeString.Contains(cipher[i]))
                {
                    dupeString += cipher[i];
                }

            }
            return dupeString;
        }

        //set user input to all capitals
        static string SetUpper(string userInput)
        {
            string upperData = userInput.ToUpper();

            return upperData;
        }

        //add alpha through zeta to cipher
        static string PrepCipher(string userInput)
        {
            string cipher = userInput.ToUpper();
            string newcipher = cipher.Replace("J","I");
            newcipher += "ABCDEFGHIKLMNOPQRSTUVWXYZ";

         return newcipher;
        }

        //remove spaces from cipher
        static string RemoveSpace(string userInput)
        {
            string cipher = userInput.Replace(" ", "");

            return cipher;
        }

        //runs all methods on cipher
        static string ConfigureCipher(string userInput)
        {
            string cipher = SetUpper(userInput);
            cipher = ConvertJtoI(cipher);
            cipher = PrepCipher(cipher);
            cipher = RemoveDupes(cipher);
            cipher = RemoveSpace(cipher);
            cipher = cipher.Substring(0, 25);

            return cipher;
        }

        //add cipher to matrix
        static string[,] LoadMatrix(string userInput)
        {
            string[,] matrix = new string[5, 5];
            int counter = 0;
            char index;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    index = userInput[counter];
                    matrix[x, y] = Convert.ToString(index);
                    counter++;
                }
            }

            return matrix;
        }

        //create encrypted string with cipher
        private static string EncryptInput(string userInput, string[,] matrix, string cipher)
        {
            string encryption = "";
            

            string[,] encryptingMatrix = new string[5, 5];

            encryptingMatrix = matrix;
            
            for (int index = 0; index < userInput.Length; ++index)
            {                
                for (int y = 0; y < 5; ++y)
                {                    
                    for (int x = 0; x < 5; ++x)
                    {
                        try
                        {
                            if (Convert.ToString(userInput[index]) == matrix[x, y])
                            {
                                encryption += matrix[y, x];
                            }
                            if (cipher.Contains(userInput[index]) == false)

                            {
                                encryption += userInput[index];
                                index++;
                            }
                        } 
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                }
            }

            return encryption;
        }


        private void translateButton_Click(object sender, EventArgs e)
        {
            var matrix = new string[5, 5];
            if (secretBox.Text == "")
            {
                MessageBox.Show("User must input cipher info", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (outputBox.Text == "" && inputBox.Text == "")
            {
                MessageBox.Show("User must input data into either Output Text or Input Text", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (outputBox.Text != "" && inputBox.Text != "")
            {
                MessageBox.Show("Data cannot be entered within both the input and output box", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(outputBox.Text != "")
            {
                //string cipher = PrepCipher(secretBox.Text);
                string cipher = secretBox.Text;
                cipher = SetUpper(cipher);
                cipher = ConvertJtoI(cipher);
                cipher = PrepCipher(cipher);
                cipher = RemoveDupes(cipher);
                cipher = RemoveSpace(cipher);
                cipher = cipher.Substring(0, 25);

                string userInput = outputBox.Text;
                userInput = ConvertJtoI(SetUpper(userInput));

                var loadedMatrix = new string[5,5];
                loadedMatrix = LoadMatrix(cipher);
                inputBox.Text = EncryptInput(userInput, loadedMatrix,cipher);

            }
            else if (inputBox.Text != "")
            {
                //string cipher = PrepCipher(secretBox.Text);
                string cipher = secretBox.Text;
                cipher = SetUpper(cipher);
                cipher = ConvertJtoI(cipher);
                cipher = PrepCipher(cipher);
                cipher = cipher.Replace("J", "I");
                cipher = RemoveDupes(cipher);
                cipher = RemoveSpace(cipher);
                cipher = cipher.Substring(0, 25);

                string userInput = inputBox.Text;
                userInput = ConvertJtoI(SetUpper(userInput));

                var loadedMatrix = new string[5, 5];
                loadedMatrix = LoadMatrix(cipher);
                outputBox.Text = EncryptInput(userInput, loadedMatrix, cipher);

            }

            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            secretBox.Text = "";
            inputBox.Text = "";
            outputBox.Text = "";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
