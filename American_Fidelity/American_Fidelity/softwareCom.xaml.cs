using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace American_Fidelity
{
    /// <summary>
    /// Interaction logic for softwareCom.xaml
    /// </summary>
    public partial class softwareCom : Window
    {
        private List<object> info = new List<object>();
        public AmericanFInfo softwareStuff { get; set; }
        public softwareCom()
        {
            InitializeComponent();
        }
        public void PopulateData(AmericanFInfo owner)
        {
            info.Add(owner.Software);
            foreach (object item in info)
            {
                txtSTitle.Text = item.ToString();
            }

            txtDescription.Text = owner.description;
            txtWebsite.Text = owner.website;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtSTitle.Clear();
            txtDescription.Clear();
            txtWebsite.Clear();
            info.Clear();
            Close();


        }
    }
}
