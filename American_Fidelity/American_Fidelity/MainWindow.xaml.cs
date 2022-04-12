using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace American_Fidelity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] linesOfFile = File.ReadAllLines("ARIS_SoftwareCatalog_OUProject.csv");

            for (int i = 1; i < linesOfFile.Length; i++)
            {
                Software entries = new Software(linesOfFile[i], i);

                lst_Softwares.Items.Add(entries.Name);
            }
            string[] ReadingFile = File.ReadAllLines("American Fidelity_SoftwareFunctionList.csv");

            for (int i = 1; i < ReadingFile.Length; i++)
            {
                MTerms Terms = new MTerms(ReadingFile[i], i);

               lst_Filter.Items.Add(Terms.Software_Function);
            }

            //private void lst_Attributes_SelectionChanged(object sender, SelectionChangedEventArgs e)
            // {

        }

        private void lst_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
                if (lst_Terms.Items.Contains(lst_Filter.SelectedItem))//checks to see if the item being selected is already in the list of sorted items
                {
                //Messagebox wasnt working...
                }
                else
                {
                    string movement = lst_Filter.SelectedItem.ToString();
                    lst_Terms.Items.Add(movement);
                }

                 
        
            //lst_Filter.Items.Remove(lst_Filter.SelectedItem);

        }

        private void lst_Terms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            lst_Terms.Items.Remove(lst_Terms.SelectedItem);//removes selected item from the terms section.
        }

        private void Search(object sender, MouseEventArgs e)
        {
            txt_FilterTerms.Text = "";
        }
    }
}
