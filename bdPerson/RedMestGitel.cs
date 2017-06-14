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
    public partial class RedMestGitel : Form
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder cmdbl;
        public RedMestGitel()
        {
            InitializeComponent();
        }

        private void RedMestGitel_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=MSI\sqlexpress;Initial Catalog=ProfileWind1;Integrated Security=True";
                con.Open();
                adap = new SqlDataAdapter("SELECT * FROM dbo.Living_place", con);
                ds = new DataSet();
                adap.Fill(ds, "Lp_Details");
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
                adap = new SqlDataAdapter("SELECT * FROM dbo.Cities_catalog", con);
                ds = new DataSet();
                adap.Fill(ds, "Cc_Details");
                dataGridView2.DataSource = ds.Tables[0];
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
                adap.Update(ds, "Lp_Details");
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
                adap.Update(ds, "Cc_Details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
