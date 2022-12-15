namespace PracticoDeMatrices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Matrix objMatrix1, objMatrix2, objMatrix3;
        private void Form1_Load(object sender, EventArgs e)
        {
            objMatrix1 = new Matrix();
        }

        public void validateInputs()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                throw new ArgumentException("Introduce las dimensiones de la Matriz.");
            else if (textBox3.Text == "" || textBox4.Text == "")
                throw new ArgumentException("Introduce un rango (Min) y (Max).");
        }

        public void errorHandler(string message)
        {
            MessageBox.Show(message, "Datos incorrectos o faltantes.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                validateInputs();
                int row = int.Parse(textBox1.Text),
                    col = int.Parse(textBox2.Text),
                    min = int.Parse(textBox3.Text),
                    max = int.Parse(textBox4.Text);
                objMatrix1.SetData(row, col, min, max);
            }
            catch (Exception error)
            {
                errorHandler(error.Message);
            }
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (objMatrix1.GetData() == "") throw new ArgumentException("A�n no haz cargado datos a la matriz 1.");
                // txtResult1.Text = objMatrix1.GetData().Replace("\n", Environment.NewLine);
                txtResult1.Text = objMatrix1.GetData();
            }
            catch (Exception error)
            {
                errorHandler(error.Message);
            }
        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                validateInputs();
                int row = int.Parse(textBox1.Text),
                    col = int.Parse(textBox2.Text),
                    min = int.Parse(textBox3.Text),
                    max = int.Parse(textBox4.Text);
                objMatrix2.SetData(row, col, min, max);
            }
            catch (Exception error)
            {
                errorHandler(error.Message);
            }
        }

        private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (objMatrix2.GetData() == "") throw new ArgumentException("A�n no haz cargado datos a la matriz 2.");
                // txtResult1.Text = objMatrix2.GetData().Replace("\n", Environment.NewLine);
                txtResult2.Text = objMatrix2.GetData();
            }
            catch (Exception error)
            {
                errorHandler(error.Message);
            }
        }

        private void conElementosPrimosDeLaMatrizAcumularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtResult2.Text = "F = " + objMatrix1.AccumulatePrimes();
        }

        private void frecuenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtElement.Text == "") throw new ArgumentException("Introduce el elemento.");
                txtFrecuence.Text = objMatrix1.GetFrecuenceOfElement(int.Parse(txtElement.Text)).ToString();
            }
            catch (Exception error)
            {
                errorHandler(error.Message);
            }
        }

        private void contarElementos�nicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countUnique = 0;
            objMatrix1.CountUniqueElements(ref countUnique);
            txtResult2.Text = countUnique.ToString();
        }

        private void transpuestaDeUnaMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objMatrix2 = new Matrix();
            objMatrix1.GetTransposedOfMatrix(ref objMatrix2);
        }
    }
}