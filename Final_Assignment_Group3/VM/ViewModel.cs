using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment_Group3
{
    //this class inherits from the ObservableObject class the implementation of the InotifyPropertyChanged interface
    //and represents the view model.
    public class ViewModel: ObservableObject
    {
        private Paragraph paragraph;
        private Rivers rivers;
        private (int, int) widthAndLength;
        private int width;
        private int length;
        private string[] strings;
        private string paragraphToShow = string.Empty;

        public int Length
        {
            get { return length; }
            set { length = value;
                OnPropertyChanged();
            }
        }

        public int Width
        {
            get { return width; }
            set {
                width = value; 
                OnPropertyChanged();
            }
        }
        public string Text
        {
            get { return paragraph.originalText; }
            set { 
                paragraph.originalText = value; 
                OnPropertyChanged();
            }
        }      

        public string[] Strings
        {
            get { return strings; }
            set { 
                strings = value;
                OnPropertyChanged();
            }
        }

        public string ParagraphToShow
        {
            get { return paragraphToShow; }
            private set
            {
                paragraphToShow = value;
                OnPropertyChanged();
            }
        }

        public ViewModel(string text)
        {
            paragraph = new Paragraph();
            rivers = new Rivers();
            Text = text;
            widthAndLength = rivers.FinalResult(paragraph);
            Width = widthAndLength.Item1;
            Length = widthAndLength.Item2;
            paragraph.adjustStrings(width);
            Strings = paragraph.strings.ToArray();
            
            ParagraphToShow += string.Join("\n", Strings);                     
        }
    }
}
