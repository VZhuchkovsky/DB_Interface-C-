using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bdPerson
{
    public partial class RedNomMash : Form
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder cmdbl;
        public RedNomMash()
        {
            InitializeComponent();
        }

        private void RedNomMash_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=MSI\sqlexpress;Initial Catalog=ProfileWind1;Integrated Security=True";
                con.Open();
                adap = new SqlDataAdapter("SELECT brand_of_car FROM dbo.Auto", con);
                ds = new DataSet();
                adap.Fill(ds, "Auto_Details");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=MSI\sqlexpress;Initial Catalog=ProfileWind1;Integrated Security=True";
                con.Open();
                adap = new SqlDataAdapter("SELECT * FROM dbo.Use_Auto", con);
                ds = new DataSet();
                adap.Fill(ds, "UseAuto_Details");
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=MSI\sqlexpress;Initial Catalog=ProfileWind1;Integrated Security=True";
                con.Open();
                adap = new SqlDataAdapter("SELECT * FROM dbo.Doc_Auto", con);
                ds = new DataSet();
                adap.Fill(ds, "DocAuto_Details");
                dataGridView3.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=MSI\sqlexpress;Initial Catalog=ProfileWind1;Integrated Security=True";
                con.Open();
                adap = new SqlDataAdapter("SELECT * FROM dbo.Event", con);
                ds = new DataSet();
                adap.Fill(ds, "EventAuto_Details");
                dataGridView4.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "Auto_Details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "UseAuto_Details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "DocAuto_Details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "EventAuto_Details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
