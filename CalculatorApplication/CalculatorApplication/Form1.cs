namespace CalculatorApplication
{
    public partial class Form1 : Form
    {

        public delegate T1 Formula<T1>(T1 arg1, T1 arg2);
        CalculatorClass calculate;
        double first, second;

        public Form1()
        {
            InitializeComponent();
            calculate = new CalculatorClass();
        }

        class CalculatorClass
        {
            public Formula<double> num;

            public double GetSum(double first, double second)
            {
                return first + second;
            }
            public double GetDifference(double first, double second)
            {
                return first - second;
            }
            public double GetProduct(double first, double second)
            {
                return first * second;
            }
            public double GetQuotient(double first, double second)
            {
                return first / second;
            }
            public event Formula<double> CalculateEvent
            {
                add
                {
                    Console.WriteLine("Added the Delegate"); ;
                    num += value;
                }
                remove
                {
                    Console.WriteLine("Removed the Delegate");
                    num -= value;
                }
            }

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            first = Convert.ToDouble(txtBoxInput1.Text);
            second = Convert.ToDouble(txtBoxInput2.Text);
            if (cbOperator.SelectedItem == "+")
            {
                calculate.CalculateEvent += new Formula<double>(calculate.GetSum);
                lblDisplayTotal.Text = calculate.GetSum(first, second).ToString();
                calculate.CalculateEvent -= new Formula<double>(calculate.GetSum);
            }
            if (cbOperator.SelectedItem == "-")
            {
                calculate.CalculateEvent += new Formula<double>(calculate.GetDifference);
                lblDisplayTotal.Text = calculate.GetDifference(first, second).ToString();
                calculate.CalculateEvent -= new Formula<double>(calculate.GetDifference);
            }
            if (cbOperator.SelectedItem == "*")
            {
                calculate.CalculateEvent += new Formula<double>(calculate.GetProduct);
                lblDisplayTotal.Text = calculate.GetProduct(first, second).ToString();
                calculate.CalculateEvent -= new Formula<double>(calculate.GetProduct);
            }
            if (cbOperator.SelectedItem == "/")
            {
                calculate.CalculateEvent += new Formula<double>(calculate.GetQuotient);
                lblDisplayTotal.Text = calculate.GetQuotient(first, second).ToString();
                calculate.CalculateEvent -= new Formula<double>(calculate.GetQuotient);
            }
        }
    }
}