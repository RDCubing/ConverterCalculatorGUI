using System;
using System.Data;
using System.Windows.Forms;

namespace ConverterCalculatorGUI
{
    public partial class Form1 : Form
    {
        // Calculator buttons
        private Button btnSqrt, btnSquare, btnSin, btnCos, btnTan, btnLog, btnEval, btnClear;

        // Currency buttons
        private Button btnUSD, btnPHP, btnEUR, btnEURtoUSD, btnPHPtoUSD;

        public Form1()
        {
            InitializeComponent();
            SetupCalculatorButtons();
            SetupCurrencyButtons();
        }

        private void SetupCalculatorButtons()
        {
            int top = 50;
            int left = 10;
            int width = 60;
            int spacing = 70;

            btnSqrt = new Button { Text = "√", Left = left, Top = top, Width = width };
            btnSquare = new Button { Text = "x²", Left = left + spacing, Top = top, Width = width };
            btnSin = new Button { Text = "sin", Left = left + spacing * 2, Top = top, Width = width };
            btnCos = new Button { Text = "cos", Left = left + spacing * 3, Top = top, Width = width };
            btnTan = new Button { Text = "tan", Left = left + spacing * 4, Top = top, Width = width };
            btnLog = new Button { Text = "log", Left = left + spacing * 5, Top = top, Width = width };
            btnEval = new Button { Text = "=", Left = left + spacing * 6, Top = top, Width = width };
            btnClear = new Button { Text = "C", Left = left + spacing * 7, Top = top, Width = width };

            btnSqrt.Click += (s, e) => ApplyCalc(x => Math.Sqrt(x));
            btnSquare.Click += (s, e) => ApplyCalc(x => Math.Pow(x, 2));
            btnSin.Click += (s, e) => ApplyCalc(x => Math.Sin(x));
            btnCos.Click += (s, e) => ApplyCalc(x => Math.Cos(x));
            btnTan.Click += (s, e) => ApplyCalc(x => Math.Tan(x));
            btnLog.Click += (s, e) => ApplyCalc(x => Math.Log10(x));
            btnEval.Click += (s, e) =>
            {
                try { textBox1.Text = new DataTable().Compute(textBox1.Text, null).ToString(); }
                catch { textBox1.Text = "Error"; }
            };
            btnClear.Click += (s, e) => textBox1.Clear();

            Controls.AddRange(new Control[] { btnSqrt, btnSquare, btnSin, btnCos, btnTan, btnLog, btnEval, btnClear });
        }

        private void ApplyCalc(Func<double, double> func)
        {
            if (double.TryParse(textBox1.Text, out double num))
                textBox1.Text = func(num).ToString();
            else
                textBox1.Text = "Invalid input";
        }

        private void SetupCurrencyButtons()
        {
            int top = 120;
            int left = 10;
            int width = 120;
            int spacing = 130;

            btnUSD = new Button { Text = "USD → PHP", Left = left, Top = top, Width = width };
            btnPHP = new Button { Text = "PHP → USD", Left = left + spacing, Top = top, Width = width };
            btnEUR = new Button { Text = "USD → EUR", Left = left + spacing * 2, Top = top, Width = width };
            btnEURtoUSD = new Button { Text = "EUR → USD", Left = left + spacing * 3, Top = top, Width = width };
            btnPHPtoUSD = new Button { Text = "PHP → USD", Left = left + spacing * 4, Top = top, Width = width };

            btnUSD.Click += (s, e) => ConvertCurrency("USD");
            btnPHP.Click += (s, e) => ConvertCurrency("PHP");
            btnEUR.Click += (s, e) => ConvertCurrency("EUR");
            btnEURtoUSD.Click += (s, e) => ConvertCurrency("EURtoUSD");
            btnPHPtoUSD.Click += (s, e) => ConvertCurrency("PHPtoUSD");

            Controls.AddRange(new Control[] { btnUSD, btnPHP, btnEUR, btnEURtoUSD, btnPHPtoUSD });
        }

        private void ConvertCurrency(string type)
        {
            if (!double.TryParse(textBox1.Text, out double amount))
            {
                textBox1.Text = "Invalid input";
                return;
            }

            double result = 0;
            switch (type)
            {
                case "USD": result = amount * 56.0; break;
                case "PHP": result = amount / 56.0; break;
                case "EUR": result = amount * 0.92; break;
                case "EURtoUSD": result = amount * 1.09; break;
                case "PHPtoUSD": result = amount / 56.0; break;
            }

            textBox1.Text = result.ToString("F2");
        }
    }
}
