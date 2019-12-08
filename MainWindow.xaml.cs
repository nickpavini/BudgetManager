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

    enum Page { Main, NewBudget, EditBudget, AnalyzeBudget }; //refernece to keep track of which page we are on

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() //Constructor
        {
            InitializeComponent();

            LoadPageMainMenu(); //set gui to main menu options
        }

        private void LoadPageMainMenu() //hides all app components except the main menu
        {
            btnAnalyzeBudget.Visibility = Visibility.Visible;
            btnEditBudget.Visibility = Visibility.Visible;
            btnNewBudget.Visibility = Visibility.Visible;

            HidePageNewBudget();

            //hide back button
            btnBackButton.Visibility = Visibility.Hidden;

            //set current and prev pages to main
            pgCurPage = Page.Main;
            pgPrevPage = Page.Main;
        }

        private void HidePageMainMenu() //Hide Main Menu option
        {
            btnAnalyzeBudget.Visibility = Visibility.Hidden;
            btnEditBudget.Visibility = Visibility.Hidden;
            btnNewBudget.Visibility = Visibility.Hidden;
        }

        #region Everything related to New Budget Page... I Will look into seperate files soon
        
        private void btnNewBudget_Click(object sender, RoutedEventArgs e) //Load New Budget Page and hide Main Menu.
        {
            HidePageMainMenu();
            LoadPageNewBudget();

            //we are now on the New Budget Page
            pgPrevPage = Page.Main;
            pgCurPage = Page.NewBudget;
        }

        private void LoadPageNewBudget()  //Load NewBudget GUI Page items
        {
            lblBudgetDir.Visibility = Visibility.Visible;
            lblBudgetName.Visibility = Visibility.Visible;
            txtBudgetName.Visibility = Visibility.Visible;
            txtBudgetDir.Visibility = Visibility.Visible;
            btnFileExplorer.Visibility = Visibility.Visible;
            btnCreateBudget.Visibility = Visibility.Visible;
            btnBackButton.Visibility = Visibility.Visible;
        }

        private void HidePageNewBudget() //Hide NewBudget GUI Page items
        {
            lblBudgetDir.Visibility = Visibility.Hidden;
            lblBudgetName.Visibility = Visibility.Hidden;
            txtBudgetName.Visibility = Visibility.Hidden;
            txtBudgetDir.Visibility = Visibility.Hidden;
            btnFileExplorer.Visibility = Visibility.Hidden;
            btnCreateBudget.Visibility = Visibility.Hidden;
        }

        private void btnFileExplorer_Click(object sender, RoutedEventArgs e) //User directory selection choice
        {
            //open dialog and allow user to select the folder of their choice to save
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result.ToString() == "OK" && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    txtBudgetDir.Text = fbd.SelectedPath;
            }               
        }

        private void btnCreateBudget_Click(object sender, RoutedEventArgs e) //creates and saves the new budget then loads that budget into the editing page
        {
            strBudgetPath = txtBudgetDir.Text + "\\" + txtBudgetName.Text + ".txt";
            //DialogResult result = System.Windows.Forms.MessageBox.Show(strBudgetPath, "path", System.Windows.Forms.MessageBoxButtons.OK);

            /*
             * 
             *  Logic for creating the actual budget
             * 
             */

            btnBackButton.Visibility = Visibility.Hidden;
            HidePageNewBudget();
            LoadPageEditBudget();
            pgCurPage = Page.EditBudget;
            pgPrevPage = Page.NewBudget;
        }

        private void btnBackButton_Click(object sender, RoutedEventArgs e)  //goes to last "page" (set of GUI options) we were on.
        {
            btnBackButton.Visibility = Visibility.Hidden;
            HidePageNewBudget();
            LoadPageMainMenu();

            pgPrevPage = Page.NewBudget;
            pgCurPage = Page.Main;
        }

        #endregion

        #region Everything related to Edit Budget Page... I Will look into seperate files soon

        private void btnEditBudget_Click(object sender, RoutedEventArgs e) // Choose file then load page and hide main menu page
        {
            // Open a file dialog to let them choose a file (.txt)
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                DialogResult result = openFileDialog.ShowDialog();

                if (result.ToString() == "OK" && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                    strBudgetPath = openFileDialog.FileName; //full path to file
                else if (result.ToString() == "Cancel")
                    return; //stay on main menu
            }
            //DialogResult result1 = System.Windows.Forms.MessageBox.Show(strBudgetPath, "path", System.Windows.Forms.MessageBoxButtons.OK);

            HidePageMainMenu();
            LoadPageEditBudget();
            pgPrevPage = Page.Main;
            pgCurPage = Page.EditBudget;
        }

        private void LoadPageEditBudget()
        {
            //budget we are working with can be accessed with strBudgetPath
        }


        #endregion

        #region Member Variables

        private Page pgCurPage;
        private Page pgPrevPage;
        private string strBudgetPath;

        #endregion
    }
}
