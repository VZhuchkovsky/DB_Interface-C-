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
    public partial class RedProfess : Form
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder cmdbl;
        public RedProfess()
        {
            InitializeComponent();
        }

        private void RedProfess_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=MSI\sqlexpress;Initial Catalog=ProfileWind1;Integrated Security=True";
                con.Open();
                adap = new SqlDataAdapter("SELECT * FROM dbo.Positions_catalog", con);
                ds = new DataSet();
                adap.Fill(ds, "Profession_Details");
                dataGridView1.DataSource = ds.Tables[0];
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
                adap.Update(ds, "Profession_Details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
