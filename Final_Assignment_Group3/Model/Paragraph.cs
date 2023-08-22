using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment_Group3
{
    public class Paragraph
    {
        public string originalText;
        public int width;
        public List<string> strings = new List<string>();

        //Get the minimum width based on the length of the longest word
        public int getMinimunWidth()
        {   
            int maximum = 0;
            int count = 0;
            int i = 0;
            while (i < originalText.Length)
            {
                if (!originalText[i].Equals(' '))
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                if (maximum < count)
                {
                    maximum = count;
                }
                i++;
            }
            width = maximum;
            return maximum;
        }

        //returns a list of strings grouping the words according to the width parameter of type int
        private List<string> getStrings(int width)
        {
            string subString;
            int starting, end, limit;
            limit = originalText.Length - 1;
            starting = 0;
            end = starting + width - 1;

            //the condition of the while loop defines the segment of values ​​of the substring
            while (starting + width < limit)
            { //if the substring starts with a space character, move the segment up one position
                if (originalText[starting].Equals(' '))
                {
                    starting++;
                    end++;
                }
                subString = originalText.Substring(starting, width); //the original string is cut and we obtain the subString with the method, passing the start position 'starting' and 'width' as parameters
                if (isValidPosition(end))
                {
                    strings.Add(subString); //if the position is valid, the substring is added to the subString attribute
                }
                else
                {
                    end = backToSpace(subString) + starting;
                    subString = originalText.Substring(starting, (end - starting));
                    strings.Add(subString);
                }
                starting = end + 1; //the position of 'starting' and 'end' are defined for the following substring
                end = starting + width - 1;
            }
            end = limit; //outside the while loop there is a remainder of the 'originalText' string to be added as a substring to the 'strings' list
            if (originalText[starting].Equals(' '))
            {
                starting++;
                subString = originalText.Substring(starting, (end - starting + 1));
                strings.Add(subString);
            }
            else
            {
                subString = originalText.Substring(starting, (end - starting + 1));
                strings.Add(subString);
            }
            return strings;
        }

        //this method must be executed to adjust the strings of the class attribute 'strings' to the desired width      
        public void adjustStrings(int ancho)
        {
            getMinimunWidth();
            getStrings(ancho);

            for (int i = 0; i < strings.Count; i++)
            {
                strings[i] = getFilledString(strings[i], ancho);
            }
        }


        //Helper methods

        private int backToSpace(string text)
        {
            int index = text.Length - 1;

            while (!text[index].Equals(' '))
            {
                index--;
            }
            return index;
        }

        private bool isValidPosition(int position)
        {

            // this method evaluates if the text string passed by parameter contains whole words from the originalText attribute
            //the parameter is needed which is text: string trimmed from originalText.

            if (originalText[position].Equals(' '))
            {
                return true;
            }
            else
            {
                if (originalText[position + 1].Equals(' '))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string getFilledString(string subtexto, int ancho)
        {
            //this method fills the empty spaces of a string until its length is equal to width
            //returns a string padded according to the given width

            int lengthSub = subtexto.Length;
            int diferencia;
            string nuevoString = subtexto;
            if (lengthSub < ancho)
            {
                diferencia = ancho - lengthSub;

                for (int i = 1; i <= diferencia; i++)
                {
                    nuevoString += ' ';
                }
            }
            return nuevoString;
        }

    }
}
