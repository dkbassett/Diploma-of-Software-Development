using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*****************************
 * author: Daniel Bassett 
 * year: 2014
 * ***************************/

namespace Pig_Latin_Translator
{
    public partial class frmPigLatinTranslator : Form
    {
        /// <summary>
        /// Store for the English and Pig Latin texts
        /// </summary>
        private String englishText = null;
        private String pigLatin = null;

        /// <summary>
        /// Arrays to store words, vowels, special characters and numbers
        /// </summary>
        private String[] words;
        private char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        private String[] specialCharacters = { "@", "#", "$", "%", "^", "&", "*", "+", "=", "<", ">" };
        private String[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        /// <summary>
        /// Store for the new Pig Latin word once translated from English
        /// </summary>
        private String newWord = null;      

        /// <summary>
        /// Initializes form
        /// </summary>
        public frmPigLatinTranslator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Takes the English input, translates it to Pig Latin 
        /// and outputs it in the Pig Latin textbox
        /// </summary>
        /// <remarks>Creates a new words array with each word separated by space</remarks>
        /// <param name="sender">Translate button</param>
        /// <param name="e">On button click</param>
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            //get English text input from text box
            englishText = txtEnglish.Text.Trim();

            //store all words as array items separated by a space
            words = englishText.Split(' ');

            //translate English to Pig latin
            TranslateEnglishToPigLatin();

            //set Pig Latin text out in text box
            txtPigLatin.Text = pigLatin;  
        }

        /// <summary>
        /// Translate English to Pig Latin method
        /// </summary>
        /// <remarks>
        /// This method will iterate through each word in the words array.
        /// If the word contains a special character or number 
        ///     the word will remain untranslated.
        /// If the word starts with a vowel 
        ///     the new word will be the same with a 'way' on the end.
        /// If the word starts with consonant 
        ///     the new word will take the first sound and append it
        ///     with the addition of 'ay'.
        /// If the word was in upper case 
        ///     the new word will remain in upper case.
        /// The new word will be added to the Pig Latin string separated by a space.
        /// </remarks>
        private void TranslateEnglishToPigLatin()
        {
            foreach (String word in words)
            {
                int indexOfFirstVowel = 0;
                string endPunctuation = Punctuation.GetEnd(word);
                string startPunctuation = Punctuation.GetStart(word);
                newWord = word;
                
                if ( !(HasSpecialChar(newWord) || HasNumber(newWord)) )
                {
                    newWord = Punctuation.RemoveStart(newWord);
                    newWord = Punctuation.RemoveEnd(newWord);
                    indexOfFirstVowel = GetIndexOfFirstVowel(newWord);
                    
                    if (IsVowel(word[0]))
                    {
                        newWord = newWord.Insert(newWord.Length, "way");
                    }
                    else if (checkStartsWithY(word))
                    {
                        indexOfFirstVowel += 1;
                        AppendAy(newWord, indexOfFirstVowel);
                    }
                    else
                    {
                        AppendAy(newWord, indexOfFirstVowel);
                    }
                    
                    newWord = Punctuation.Insert(newWord, startPunctuation, endPunctuation); 
                }
                else
                {
                    newWord = word;
                }
                
                if (IsUpperCase(word))
                {
                    newWord = newWord.ToUpper();
                }

                pigLatin += newWord + " ";
            }
        }

        /// <summary>
        /// Gets the index of the first vowel in the word
        /// </summary>
        /// <param name="word">To take a word from the words array</param>
        /// <returns>The index of the first vowel in the word</returns>
        private int GetIndexOfFirstVowel(String word)
        {
            int vowelIndex = word.ToLower().IndexOfAny(vowels);
            return vowelIndex;
        }

        /// <summary>
        /// Checks if the letter is a vowel
        /// </summary>
        /// <param name="letter">Used to determine if it is a vowel</param>
        /// <returns>True if the letter is a vowel</returns>
        private bool IsVowel(char letter)
        {
            for (int i = 0; i < vowels.Length - 1; i++)
            {
                if (vowels[i].Equals(letter) || vowels[i].Equals(Char.ToLower(letter)))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Append the consonant sound with 'ay' at the end of the word
        /// </summary>
        /// <remarks>
        /// The sound begins with the first consonant and includes 
        /// all other consonants up to the first vowel in the word.
        /// </remarks>
        /// <param name="word">Use as a base to append 'ay'</param>
        /// <param name="indexOfFirstVowel">To take the index from the first vowel in word</param>
        private string AppendAy(String word, int indexOfFirstVowel)
        {
            String suffix = word.Substring(0, indexOfFirstVowel) + "ay";
            String prefix = word.Substring(indexOfFirstVowel);
            if (Char.IsUpper(suffix[0]))
            {
                char suffixFirstLetter = Char.ToLower(suffix[0]);
                char prefixFirstLetter = Char.ToUpper(prefix[0]);

                suffix = suffix.Remove(0, 1);
                suffix = suffix.Insert(0, suffixFirstLetter.ToString());

                prefix = prefix.Remove(0, 1);
                prefix = prefix.Insert(0, prefixFirstLetter.ToString());

                newWord = prefix + suffix;
            }
            else
            {
                newWord = prefix + suffix;               
            }
            return newWord;
        }

        /// <summary>
        /// Checks if the word starts with Y or y
        /// </summary>
        /// <param name="word">Used as base to check if it starts with Y or y</param>
        /// <returns>True if the word starts with Y or y</returns>
        private bool checkStartsWithY(String word)
        {
            if(word[0] == 'y' || word[0] == 'Y')
                return true;

            return false;
        }

        /// <summary>
        /// Checks if the word contains a special character
        /// </summary>
        /// <param name="word">Used as a base to check special characters</param>
        /// <returns>True if the word contains a special character</returns>
        private bool HasSpecialChar(String word)
        {
            foreach (String specialCharacter in specialCharacters)
            {
                if (word.Contains(specialCharacter))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the the word contains a number
        /// </summary>
        /// <param name="word">Used as a base to check numbers</param>
        /// <returns>True if the word contains a number</returns>
        private bool HasNumber(String word)
        {
            foreach (String number in numbers)
            {
                if (word.Contains(number))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the word is all upper case
        /// </summary>
        /// <param name="word">To take a word from the words array</param>
        /// <returns>True if the word is all upper case</returns>
        private bool IsUpperCase(String word)
        {
            foreach (char letter in word)
            {
                if (Char.IsLower(letter))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Resets the variables to null if the English text is changed
        /// </summary>
        /// <param name="sender">English text box</param>
        /// <param name="e">On text changed</param>
        private void txtEnglish_TextChanged(object sender, EventArgs e)
        {
            englishText = null;
            pigLatin = null;
            words = null;
        }

        /// <summary>
        /// Clears both the English and Pig Latin text boxes
        /// </summary>
        /// <param name="sender">Clear button</param>
        /// <param name="e">On button click</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnglish.Clear();
            txtPigLatin.Clear();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender">Exit button</param>
        /// <param name="e">On button click</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
