using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VutureTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //This method is triggered when user click the submit button in Task 1, 
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //Assigning textbox values to strings and making them all lowercase
            string checkString = txt_Function1.Text.ToLower();
            string letterToCount = txt_CountLetter.Text.ToLower();
           
            //Creating an int to count the occurencies
            int noOfOccurences = 0;
            if (String.IsNullOrEmpty(txt_CountLetter.Text) || String.IsNullOrEmpty(txt_Function1.Text))
            {
                
                lbl_Outcome1.Text = "Please enter the string and character to count.";
            }
            else
            {
                //Converting string to char
                char letters = Convert.ToChar(letterToCount);
                //For loop to count the occurencies of any letter provided in a text box
                foreach (char c in checkString)
                {
                    if (c == letters)
                    {
                        noOfOccurences++;
                    }
                }
                //Displaying an outcome
                lbl_Outcome1.Text = noOfOccurences.ToString();
            }
           
        }
        //This method is triggered when user click the submit button in Task 2
        private void btn_Submit2_Click(object sender, EventArgs e)
        {
            //Assigning textbox values to a string and making it lowercase
            string palindrome = txt_Function2.Text.ToLower();
            //Deleting spaces, commas, dots etc from a string
            palindrome = Regex.Replace(palindrome, @"\s", "");
            palindrome = Regex.Replace(palindrome, @"’", "");
            palindrome = Regex.Replace(palindrome, @".", "");
            palindrome = Regex.Replace(palindrome, @",", "");
            palindrome = Regex.Replace(palindrome, @"'", "");
            //Converting string to a array
            char[] reverseString = palindrome.ToCharArray();
            //Reversing the array
            Array.Reverse(reverseString);
            //Assigning new value to a new string
            string compare = new string(reverseString);
            //Comparing the original value to a new value
            bool result = palindrome.Equals(compare, StringComparison.OrdinalIgnoreCase);
            if (result == true)
            {
                lbl_Result2.Text = "true";
            }
            else
            {
                lbl_Result2.Text = "false";
            }


        }
        //This method is triggered when user click the submit button in Task 3 A
        private void btn_Submit3_Click(object sender, EventArgs e)
        {
            //Assigning values from a textboxes to a strings
            string Tags = txt_Censor1.Text.ToLower();
            string stringToCensore = txt_StringToCensure.Text.ToLower();
            //Separating all the words in a string by finding spaces
            string[] words = Tags.Split(' ');
            string[] check = stringToCensore.Split(' ');
            //Creating dictionary
            Dictionary<string, int> oddw = new Dictionary<string, int>();
            //For each loop to add the censured words to a dictionary
            foreach (string item in words)
            {
                oddw.Add(item, 0);
            }
            //For each loop to count the occurences of the censured words in a text
            foreach (string item in check)
            {
                if (item != "")
                {
                    if (oddw.ContainsKey(item))
                    {
                        oddw[item]++;
                        
                    }
                }
            }
            //Displaying the outcome
            var asString = string.Join(";", oddw);
            lbl_Result3A.Text = asString.ToString();
        }
        //This method is triggered when user click the submit button in Task 3 B
        private void btn_Submit4_Click(object sender, EventArgs e)
        {
            //Assigning values from a textboxes to a strings
            string Tags = txt_Censor2.Text.ToLower();
            string stringToCensore = txt_TextToCensor2.Text.ToLower();
            //Separating all the words in a string by finding spaces
            string[] words = Tags.Split(' ');
            string[] check = stringToCensore.Split(' ');
            //Creating dictionary
            Dictionary<string, int> oddw = new Dictionary<string, int>();
            //For each loop to add the censured words to a dictionary
            foreach (string item in words)
            {
                oddw.Add(item, 0);
            }
            String output = "";
            //For each loop to find each word from a black list in a text and censore it
            foreach (string item in check)
            {
                if (item != "")
                {
                    if (oddw.ContainsKey(item))
                    {
                        for (int i = 0; i <= item.Length - 1; i++)
                        {
                            output += "*";
                        }
                        output += " ";
                    }
                    else
                    {
                        output += item + " ";
                    }
                }
            }
            //Displaying the outcome
            lbl_Result3B.Text = output;
        }
        //This method is triggered when user click the submit button in Task 3 C
        private void button1_Click(object sender, EventArgs e)
        {
            //Assigning values from a textboxes to a strings
            string Tags = txt_PalindromeCensor.Text.ToLower();
            string[] words = Tags.Split(' ');
            //Separating all the words in a string by finding spaces
            string inputString = txt_PalindromeCensor.Text.ToLower();
            string resultString = string.Join(" ", inputString.Split(' ').Select(x => new String(x.Reverse().ToArray())));
            string[] check = resultString.Split(' ');
            //Creating dictionary
            Dictionary<string, int> oddw = new Dictionary<string, int>();
            //For each loop to add the censured words to a dictionary
            foreach (string item in words)
            {
                //Checking if a reversed word is found as any word in a text to censure
                if (check.Contains(item))
                {
                    oddw.Add(item, 0);
                }
                    
            }
            String output = "";
            
            foreach (string item in words)
            {
                if (item != "")
                {
                   
                    if (oddw.ContainsKey(item))
                    {
                        for (int i = 0; i <= item.Length - 1; i++)
                        {
                            output += "*";
                        }
                        output += " ";
                    }
                    else
                    {
                        output += item + " ";
                    }
                }
            }

            lbl_Result3C.Text = output;
        }
    }
}
