using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorksheetPrototype
{
    /// <summary>
    /// Interaction logic for SaveColumnThemeWindow.xaml
    /// </summary>
    public partial class SaveColumnThemeWindow : Window
    {
        public SaveColumnThemeWindow()
        {
            InitializeComponent();
        }

        public override void EndInit()
        {
            base.EndInit();
            themeName.Focus();
        }

        public string ThemeName
        {
            get { return themeName.Text; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
