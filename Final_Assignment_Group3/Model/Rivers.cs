using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment_Group3
{
    public class Rivers
    {
        //This class is in charge of finding the rivers given an ordered paragraph: ( List<string> strings )

        //This method allows to determine the length of a river given a position in white space.
        //Receives by parameter the position of the string where it is found (row), the position of the character within the string to which it belongs (column)
        //and the ordered paragraph it belongs to.
        //Does not evaluate if the passed position is a space.Does not evaluate if the passed position is the last one in the row. Does not work if the character to evaluate belongs to the last row of 'paragraph'.
        //Requires that the value for the 'paragraph' field has been set
        private int getRiverLengthIn(int row, int column, List<string> paragraph)
        {
            int count = 1, r = row, c = column;
            string sentence, nextSentence;
            while (r < paragraph.Count - 1)
            {
                sentence = paragraph[r];
                nextSentence = paragraph[r + 1];

                if (isStartingPosition(c) && (isSpacePosition(nextSentence, c) || isSpacePosition(nextSentence, c + 1)))
                {
                    count++;
                    r++;
                    if (isSpacePosition(nextSentence, c + 1)) c++;
                }
                else if ((!isLastPosition(nextSentence, c - 1) && isSpacePosition(nextSentence, c - 1)) || (!isLastPosition(nextSentence, c) && isSpacePosition(nextSentence, c)) || (!isLastPosition(nextSentence, c + 1) && isSpacePosition(nextSentence, c + 1)))
                {
                    count++;
                    r++;
                    //to know if the river changes column or stays in the same column.
                    if (isSpacePosition(nextSentence, c - 1)) c--;
                    else if (isSpacePosition(nextSentence, c)) continue;
                    else if (isSpacePosition(nextSentence, c + 1)) c++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }


        //This method returns the longest river given an ordered paragraph (with all its strings the same length). Does not evaluate the paragraph.
        private int getLongestRiverOf(List<string> paragraph)
        {
            int row, column, length = paragraph[0].Length, hight = paragraph.Count;
            string sentence;
            int longestRiver = 0, newRiver;

            for (row = 0; row < hight - 1; row++)
            {
                sentence = paragraph[row];
                if (isLastRow(row, paragraph)) break;
                for (column = 0; column < length; column++)
                {
                    if (!isLastPosition(sentence, column) && isSpacePosition(sentence, column))
                    {
                        newRiver = getRiverLengthIn(row, column, paragraph);
                        if (newRiver > longestRiver) longestRiver = newRiver;
                        else continue;
                    }
                    else continue;
                }
            }
            return longestRiver;
        }

        //this method returns a tuple (int, int) containing the values ​​of the ideal width (idealWidth) and the value of the longest river 'longRiver' in the paragraph 'p'.
        //It is the only public method of the class.
        public (int, int) FinalResult(Paragraph p)
        {
            Paragraph p2;
            int minimunWidth = p.getMinimunWidth();
            int maximumWidth = (int)p.originalText.Length / 2;
            int idealWidth = 0, river, longRiver = 0;
            for (int i = minimunWidth; i <= maximumWidth; i++)
            {
                p2 = new Paragraph();
                p2.originalText = p.originalText;
                p2.adjustStrings(i);
                river = getLongestRiverOf(p2.strings);
                if (river > longRiver)
                {
                    longRiver = river;
                    idealWidth = i;
                }
            }
            return (idealWidth, longRiver);
        }

        //Helper methods
        private bool isLastPosition(string sentence, int position)
        {
            //return position >= cadena.Length - 1;
            if (position >= sentence.Length - 1)
            {
                return true;
            }
            else if (isSpacePosition(sentence, position) && isSpacePosition(sentence, position + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool isStartingPosition(int position)
        {
            return position == 0;
        }
        private bool isLastRow(int row, List<string> paragraph)
        {
            return row == paragraph.Count - 1;

        }
        private bool isSpacePosition(string sentence, int position)
        {
            return sentence[position].Equals(' ');
        }

    }
}
