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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;
        CalculationHistory calculationHistory;
        string currentNumber;
       

        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculationHistory = new CalculationHistory();

            NumberSystemComboBox.ItemsSource = Enum.GetValues(typeof(NumSystem));
            NumberSystemComboBox.SelectedItem = NumSystem.Decimal;

            UpdateOperationsHistory();
        }

        private void UpdateOperationsHistory()
        {
            OperationsHistoryListBox.Items.Clear();
            string[] operations = calculationHistory.GetAllOperations();
            for(int i = 0; i < operations.Length; i++)
            {
                string operation = operations[i];
                ListBoxItem item = new ListBoxItem();
                item.Content = operation;
                item.Name = "op";
                OperationsHistoryListBox.Items.Add(item);
            }
        }

        private void NumberSystemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            calculator.SetNumberSystem((NumSystem)NumberSystemComboBox.SelectedValue);

            if((NumSystem)NumberSystemComboBox.SelectedValue == NumSystem.Hex)
            {
                HexNumbersGroup.IsEnabled = true;
            } else
            {
                HexNumbersGroup.IsEnabled = false;
            }

            if((NumSystem)NumberSystemComboBox.SelectedValue == NumSystem.Binary)
            {
                DecimalGroup.IsEnabled = false;
            }
            else
            {
                DecimalGroup.IsEnabled = true;
            }
        }

        private void NumButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            currentNumber += btn.Content;
            SetMainTextBlock(currentNumber);
        }

        private void SetMainTextBlock(string value)
        {
            MainTextBlock.Text = value;
        }

        private void OperationButtonClciked(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.ToString() == "√")
            {
                MainTextBlock.Text = calculator.SetSqrtOperation(currentNumber).ToString();
                UpdateOperationsHistory();
            }
            else if (btn.Content.ToString() == "~")
            {
                MainTextBlock.Text = calculator.SetRoundOperation(currentNumber).ToString();
                UpdateOperationsHistory();
            } else
            {
                calculator.SetOperation(currentNumber, btn.Content.ToString());
                CleanCurrentNumber();
            }           
        }

        private void CleanCurrentNumber()
        {
            currentNumber = string.Empty;
            MainTextBlock.Text = currentNumber;
        }

        private void ScoreButton_Click(object sender, RoutedEventArgs e)
        {
            calculator.SetSecondNumber(double.Parse(currentNumber));
            CleanCurrentNumber();
            MainTextBlock.Text = calculator.Calculate().ToString();
            UpdateOperationsHistory();
        }

        private void RemoveOperation_Click(object sender, RoutedEventArgs e)
        {
            int selectedOperation = OperationsHistoryListBox.SelectedIndex;
            calculationHistory.RemoveOperationFromHistory(selectedOperation);
            UpdateOperationsHistory();
        }
    }
}
