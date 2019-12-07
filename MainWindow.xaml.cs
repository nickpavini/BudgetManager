using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeMainMenu(); //set gui to main menu options
        }

        //hides all app components except the main menu
        private void InitializeMainMenu()
        {
            btnAnalyzeBudget.Visibility = Visibility.Visible;
            btnEditBudget.Visibility = Visibility.Visible;
            btnNewBudget.Visibility = Visibility.Visible;

            //hide new budget info gui
            lblBudgetDir.Visibility = Visibility.Hidden;
            lblBudgetName.Visibility = Visibility.Hidden;
            txtBudgetName.Visibility = Visibility.Hidden;
            txtBudgetDir.Visibility = Visibility.Hidden;
            btnFileExplorer.Visibility = Visibility.Hidden;
            btnCreateBudget.Visibility = Visibility.Hidden;

            //hide back button
            btnBackButton.Visibility = Visibility.Hidden;
        }

        #region Everything related to New Budget Page... I Will look into seperate files soon
        //Load New Budget info GUI.
        private void btnNewBudget_Click(object sender, RoutedEventArgs e)
        {
            //Hide Main Menu options
            btnAnalyzeBudget.Visibility = Visibility.Hidden;
            btnEditBudget.Visibility = Visibility.Hidden;
            btnNewBudget.Visibility = Visibility.Hidden;

            //NewBudget info GUI Items
            lblBudgetDir.Visibility = Visibility.Visible;
            lblBudgetName.Visibility = Visibility.Visible;
            txtBudgetName.Visibility = Visibility.Visible;
            txtBudgetDir.Visibility = Visibility.Visible;
            btnFileExplorer.Visibility = Visibility.Visible;
            btnCreateBudget.Visibility = Visibility.Visible;
            btnBackButton.Visibility = Visibility.Visible;
        }

        private void btnFileExplorer_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", "/select, " + @"c:\Users\"); //starts windows processes with command line args

            //open dialog and allow user to select the folder of their choice to save
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result.ToString() == "OK" && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    txtBudgetDir.Text = fbd.SelectedPath;
                }
            }               
        }

        //creates and saves the new budget
        private void btnCreateBudget_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        //goes to last "page" (set of GUI options) we were on.
        private void btnBackButton_Click(object sender, RoutedEventArgs e)
        {

        }


        #region Member Variables

        #endregion
    }
}
