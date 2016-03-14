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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using System.Windows.Resources;
using Microsoft.Win32;

namespace WorksheetPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Proposal m_proposal;
        private GridLengthConverter m_gridLengthConverter = new GridLengthConverter();

        public MainWindow()
        {
            InitializeComponent();
            dataGrid1.AddHandler(ScrollViewer.ScrollChangedEvent,
                new RoutedEventHandler(dataGridScrollChange));

           

            BindFooterColumns();
            BindColumnContextMenu();
            LoadSampleData();
            LoadColumnThemes();
        }

        private void LoadColumnThemes()
        {
            foreach (var item in ColumnThemeManager.GetThemes())
            {
                columnThemeCombo.Items.Add(item);
            }
        }

        private void LoadSampleData()
        {
            dataGrid1.Items.Clear();

            Uri uri = new Uri("pack://application:,,,/sample.fepx");
            StreamResourceInfo sri = Application.GetResourceStream(uri);
            Load(sri.Stream);
        }

        private void BindColumnContextMenu()
        {
            ContextMenu menu = FindResource("columnHeaderMenu") as ContextMenu;
            Binding binding = new Binding("Columns");
            binding.Source = dataGrid1;
            menu.SetBinding(ItemsControl.ItemsSourceProperty, binding);
        }

        private void BindFooterColumns()
        {
            foreach (var column in dataGrid1.Columns)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                BindingBase binding = GetColumnBinding(column);
                columnDefinition.SetBinding(ColumnDefinition.WidthProperty, binding);
                footerGrid.ColumnDefinitions.Add(columnDefinition);
            }
        }

        private BindingBase GetColumnBinding(DataGridColumn column)
        {
            MultiBinding binding = new MultiBinding();
            binding.Converter = m_gridLengthConverter;

            Binding widthBinding = new Binding("Width.DisplayValue");
            widthBinding.Source = column;
            binding.Bindings.Add(widthBinding);

            Binding visibilityBinding = new Binding("Visibility");
            visibilityBinding.Source = column;
            binding.Bindings.Add(visibilityBinding);

            return binding;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    using (FileStream fs = File.OpenRead(dialog.FileName))
                    {
                        Load(fs);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid file!");
                }
            }
        }

        private void Load(Stream stream)
        {
            m_proposal = new ProposalImporter().Load(stream);
            footerGrid.DataContext = m_proposal.Items;
            GroupItems();
        }

        private void GroupItems()
        {
            if (null == dataGrid1)
            {
                return;
            }
            dataGrid1.CancelEdit();

            switch (groupCombo.SelectedIndex)
            {
                case 0:
                    GroupByMaterial();
                    break;
                case 1:
                    GroupByTrade();
                    break;
                case 2:
                    GroupByRoom();
                    break;
                case 3:
                    GroupByMaterialBreakByRoom();
                    break;
                default:
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupItems();
        }

        private void GroupByTrade()
        {
            GroupByMaterial();

            dataGrid1.Items.GroupDescriptions.Clear();
            dataGrid1.Items.GroupDescriptions.Add(new PropertyGroupDescription("Material.Trade"));
        }

        private void GroupByMaterial()
        {

            dataGrid1.Items.GroupDescriptions.Clear();

            var items = m_proposal.Items.GroupMaterialItem().ToList();
            dataGrid1.ItemsSource = items;
        }

        private void GroupByRoom()
        {

            dataGrid1.ItemsSource = m_proposal.Items;

            dataGrid1.Items.GroupDescriptions.Clear();
            dataGrid1.Items.GroupDescriptions.Add(new PropertyGroupDescription("Layer"));
            dataGrid1.Items.GroupDescriptions.Add(new PropertyGroupDescription("Room"));
        }

        private void GroupByMaterialBreakByRoom()
        {

            dataGrid1.ItemsSource = m_proposal.Items;

            dataGrid1.Items.GroupDescriptions.Clear();
            dataGrid1.Items.GroupDescriptions.Add(new PropertyGroupDescription("Material"));
            dataGrid1.Items.GroupDescriptions.Add(new PropertyGroupDescription("Layer"));
            dataGrid1.Items.GroupDescriptions.Add(new PropertyGroupDescription("Room"));
        }

        private static void dataGridScrollChange(object sender, RoutedEventArgs eBase)
        {
            ScrollChangedEventArgs e = (ScrollChangedEventArgs)eBase;
            ScrollViewer sourceScrollViewer = (ScrollViewer)e.OriginalSource;

            DependencyObject obj = ((FrameworkElement)sender).Parent;
            ScrollViewer sv = (obj as FrameworkElement).FindName("scroller") as ScrollViewer;
            sv.ScrollToHorizontalOffset(sourceScrollViewer.HorizontalOffset);
        }

        private void columnThemeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColumnThemeManager.ApplyTheme(columnThemeCombo.SelectedItem as string, dataGrid1);
        }

        private void dataGrid1_ColumnDisplayIndexChanged(object sender, DataGridColumnEventArgs e)
        {
            ColumnDefinition column = footerGrid.ColumnDefinitions[e.Column.DisplayIndex];
            BindingBase binding = GetColumnBinding(e.Column);
            column.SetBinding(ColumnDefinition.WidthProperty, binding);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveColumnThemeWindow window = new SaveColumnThemeWindow();
            if (window.ShowDialog() == true)
            {
                ColumnThemeManager.Save(window.ThemeName, dataGrid1);
                columnThemeCombo.Items.Add(window.ThemeName);
            }
        }
    }
}
