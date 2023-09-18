using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace перевод_чисел_в_различные_системы_исчислений
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InputIntTextBox.Select();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void InputIntTextBox_TextChanged(object sender, EventArgs e) 
        { 
        }
        private void Form1_Load(object sender, EventArgs e) 
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void marker()
        {
            OutputTextBox2.Text = "Здесь будет полученное значение";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                long number = Convert.ToInt64(InputIntTextBox.Text);
                if (comboBox1.Text == "") // если сиситема счисления не указана
                {
                    MessageBox.Show("Данная ячейка не может быть пустая, " +
                        "по умолчанию была установлена двоичная система счисления",
                        "Не указана система счисления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.Text = "2";
                }
                int NumSys = Convert.ToInt32(comboBox1.Text);
                if (number == 0)
                {
                    MessageBox.Show("0 во всех системах счисления будет равен 0",
                        "Введен 0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InputIntTextBox.Text = "";
                    marker();
                }

                else if (number < 0)
                {
                    number *= -1;
                    MessageBox.Show("Было введено отрицательное значение числа," +
                        "ошибка была исправлена автоматически, минус заменен на плюс",
                        "Введено число меньше 0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    marker();
                }

                else if (number > 0)
                {
                    ConvertNumber CN = new ConvertNumber(number);
                    OutputTextBox2.Text = CN.ConvertTo(NumSys);
                   
                }

            }
            catch
            {
                if (InputIntTextBox.Text == "") // если ячейка числа пуста
                {
                    MessageBox.Show("Ошибка: ничего не введено",
                                      "Не верный формат числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InputIntTextBox.Text = "";
                }
                else // если введены не числа
                {
                    MessageBox.Show("Ошибка: исходное число является некорректной" +
                    " записью для системы с основанием 10. В 10-ой системе допустимы " +
                    "только следующие символы: 0,1,2,3,4,5,6,7,8,9",
                    "Не верный формат числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InputIntTextBox.Text = "";
                }                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {           
                this.Close(); // кнопка закрытия окна
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // обработка закрытия формы именно на крестик красный,
            // предварительно в свойствах нужно включить FormClosing
            DialogResult result = MessageBox.Show("Вы точно хотите выйти?",
                "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // пользователь не хочет выходить
                // то мы должны прервать событие закрытия
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1_Click(new object(), new EventArgs());
            }
        }

}
   
}
