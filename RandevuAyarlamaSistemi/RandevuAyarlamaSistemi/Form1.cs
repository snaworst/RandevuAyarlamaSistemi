using System.Data;
using MySql.Data.MySqlClient;
namespace RandevuAyarlamaSistemi
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=hastane;Uid=root;Pwd=Witcher3.");
        DataTable dt;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
        }

        void VerileriGoster()
        {
            dt = new DataTable();
            adapter = new MySqlDataAdapter("SELECT * FROM randevular", con);
            con.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO randevular(hastaiAdi, tarih, saat, aciklama)" + "VALUES(@ad, @tarih, @saat, @aciklama)";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@tarih", textBox2.Text);
            cmd.Parameters.AddWithValue("@saat", textBox3.Text);
            cmd.Parameters.AddWithValue("@aciklama", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            VerileriGoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM randevular" + " WHERE hastaiAdi=@ad";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            VerileriGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string eskiIsim = textBox1.Text;
            string sql = "UPDATE randevular SET hastaiAdi=@ad, tarih=@tarih, saat=@saat, aciklama=@aciklama WHERE hastaiAdi=@eskiIsim";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@eskiIsim", eskiIsim);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@tarih", textBox2.Text);
            cmd.Parameters.AddWithValue("@saat", textBox3.Text);
            cmd.Parameters.AddWithValue("@aciklama", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            VerileriGoster();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
