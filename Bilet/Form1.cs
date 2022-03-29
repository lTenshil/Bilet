using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bilet
{
    public partial class Form1 : Form
    {
        public static Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            button5.Visible = false;
            textBox2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MyDBContext context = new MyDBContext())
            {
                context.Questions.Add(new Question(comboBox1.Text, textBox1.Text));
                context.SaveChanges();
                MessageBox.Show("Вопрос добавлен.");
            }
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox1.Visible = false;
            comboBox1.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button5.Visible = false;
            textBox2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox1.Visible = false;
            comboBox1.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible=false;
            button5.Visible=false;
            textBox2.Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox1.Visible=false;
            button3.Visible=false;
            button4.Visible=true;
            button5.Visible = true;
            label1.Visible = true;
            comboBox1.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "konstruktorDataSet.Tickets". При необходимости она может быть перемещена или удалена.
            this.ticketsTableAdapter.Fill(this.konstruktorDataSet.Tickets);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "")
            {
                using (MyDBContext context = new MyDBContext())
                {
                    
                    List<Question> questions = new List<Question>();
                    var discipline = comboBox1.Text;
                    string Connection = @"Server=(localdb)\mssqllocaldb;Database=Konstruktor;Trusted_Connection=True;";
                    string query = $"select * from Questions where Discipline = N'{discipline}'";
                    using (SqlConnection connection = new SqlConnection(Connection))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(query, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            questions.Add(new Question(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                        reader.Close();
                        var index = random.Next(1, questions.Count);
                        Ticket ticket = new Ticket();
                        ticket.Number = Convert.ToInt32(textBox2.Text);
                        ticket.Question1 = questions[index].Questionn;
                        index = random.Next(1, questions.Count);
                        ticket.Question2 = questions[index].Questionn;
                        ticket.QuestionId = questions[index].Id;
                        context.Tickets.Add(ticket);
                        context.SaveChanges();
                        connection.Close();
                        Form1_Load(sender, e);
                        dataGridView1.Visible = true;
                    }
                }
            }
            else
                MessageBox.Show("Не все данные были внесены!");
        }

        
    }
}
