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
    public partial class Main : Form
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder cmdbl;
        private BindingSource profileBindingSource = new BindingSource();
        private BindingSource telephoneBindingSource = new BindingSource();
        private BindingSource professionBindingSource = new BindingSource();
        private BindingSource passportNumberBindingSource = new BindingSource();
        private BindingSource licensePlateBindingSource = new BindingSource();
        private BindingSource nicknameBindingSource = new BindingSource();
        private BindingSource workPlaceBindingSource = new BindingSource();
        private BindingSource livingPlaceBindingSource = new BindingSource();

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = profileBindingSource;
            dataGridView2.DataSource = telephoneBindingSource;
            dataGridView4.DataSource = professionBindingSource;
            dataGridView5.DataSource = passportNumberBindingSource;
            dataGridView6.DataSource = licensePlateBindingSource;
            dataGridView7.DataSource = nicknameBindingSource;
            dataGridView8.DataSource = workPlaceBindingSource;
            dataGridView9.DataSource = livingPlaceBindingSource;
            GetData1();
            dataGridView2.Columns["id_profile"].Visible = false;
            dataGridView4.Columns["id"].Visible = false;
            dataGridView5.Columns["id_Profile"].Visible = false;
            dataGridView6.Columns["id_Profile"].Visible = false;
            dataGridView7.Columns["id_Profile"].Visible = false;
            dataGridView8.Columns["id"].Visible = false;
            dataGridView8.Columns["id_profile"].Visible = false;
            dataGridView8.Columns["id_position"].Visible = false;
            dataGridView9.Columns["id"].Visible = false;
            dataGridView9.Columns["id_Profile"].Visible = false;

            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            timer6.Start();
            timer7.Start();
            timer8.Start();


        }
        private void GetData1()
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.

                /* "Integrated Security=True;Persist Security Info=False;" +
                     @"Initial Catalog=Project1_AV131;Data Source = MSI\sqlexpress; ";*/
                String connectionString = @"Data Source=MSI\sqlexpress;Initial Catalog=ProfileWind1;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);

                // Create a DataSet.
                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;


                SqlDataAdapter profileDataAdapter = new
                    SqlDataAdapter("SELECT * from dbo.Profile", connection);
                profileDataAdapter.Fill(data, "Profile");

                SqlDataAdapter telephoneDataAdapter = new
                    SqlDataAdapter("SELECT phone_number,id_profile FROM dbo.Telephone", connection);
                telephoneDataAdapter.Fill(data, "Telephone");

                SqlDataAdapter professionDataAdapter = new
                    SqlDataAdapter("SELECT position,Profile.id FROM(((dbo.Positions_catalog INNER JOIN dbo.Position_in_department ON dbo.Positions_catalog.id = dbo.Position_in_department.id_Position) INNER JOIN dbo.Department ON dbo.Department.id = dbo.Position_in_department.id_Department) INNER JOIN dbo.Department_info ON dbo.Department.id = dbo.Department_info.id_Department) INNER JOIN dbo.Profile ON  dbo.Department_info.id_profile_who_controls = dbo.Profile.id", connection);
                professionDataAdapter.Fill(data, "Positions_catalog");

                SqlDataAdapter passportNumberDataAdapter = new
                                                    SqlDataAdapter("SELECT code,id_Profile FROM dbo.Passport", connection);
                passportNumberDataAdapter.Fill(data, "Passport_Numbers");

                SqlDataAdapter licensePlateDataAdapter = new
                                                    SqlDataAdapter("SELECT number_of_car,id_Profile FROM dbo.Auto", connection);
                licensePlateDataAdapter.Fill(data, "License_Plates");

                SqlDataAdapter nicknameDataAdapter = new
                                                   SqlDataAdapter("SELECT nickname,id_Profile FROM dbo.Nickname", connection);
                nicknameDataAdapter.Fill(data, "Nicknames");

                SqlDataAdapter workPlaceDataAdapter = new
                                                   SqlDataAdapter("SELECT * FROM dbo.Workplace", connection);
                workPlaceDataAdapter.Fill(data, "Work_Places");

                SqlDataAdapter livingPlaceDataAdapter = new
                                                   SqlDataAdapter("SELECT * FROM dbo.Living_place", connection);
                livingPlaceDataAdapter.Fill(data, "Living_Places");


                // Establish a relationship between the two tables.
                DataRelation relation1 = new DataRelation("ProfileTelephone",
                    data.Tables["Profile"].Columns["id"],
                    data.Tables["Telephone"].Columns["id_profile"]);
                data.Relations.Add(relation1);

                DataRelation relation2 = new DataRelation("ProfessionProfile",
                    data.Tables["Profile"].Columns["id"],
                    data.Tables["Positions_catalog"].Columns["id"]);
                data.Relations.Add(relation2);

                DataRelation relation3 = new DataRelation("ProfilePassport",
                    data.Tables["Profile"].Columns["id"],
                    data.Tables["Passport_Numbers"].Columns["id_Profile"]);
                data.Relations.Add(relation3);

                DataRelation relation4 = new DataRelation("ProfileLicensePlate",
                    data.Tables["Profile"].Columns["id"],
                    data.Tables["License_Plates"].Columns["id_Profile"]);
                data.Relations.Add(relation4);

                DataRelation relation5 = new DataRelation("ProfileNickname",
                    data.Tables["Profile"].Columns["id"],
                    data.Tables["Nicknames"].Columns["id_Profile"]);
                data.Relations.Add(relation5);

                DataRelation relation6 = new DataRelation("ProfileWorkplace",
                    data.Tables["Profile"].Columns["id"],
                    data.Tables["Work_Places"].Columns["id_profile"]);
                data.Relations.Add(relation6);

                DataRelation relation7 = new DataRelation("ProfileLivingPlace",
                   data.Tables["Profile"].Columns["id"],
                   data.Tables["Living_Places"].Columns["id_Profile"]);
                data.Relations.Add(relation7);

                // Bind the master data connector to the Customers table.
                profileBindingSource.DataSource = data;
                profileBindingSource.DataMember = "Profile";

                // Bind the details data connector to the master data connector,
                // using the DataRelation name to filter the information in the 
                // details table based on the current row in the master table. 
                telephoneBindingSource.DataSource = profileBindingSource;
                telephoneBindingSource.DataMember = "ProfileTelephone";

                professionBindingSource.DataSource = profileBindingSource;
                professionBindingSource.DataMember = "ProfessionProfile";

                passportNumberBindingSource.DataSource = profileBindingSource;
                passportNumberBindingSource.DataMember = "ProfilePassport";

                licensePlateBindingSource.DataSource = profileBindingSource;
                licensePlateBindingSource.DataMember = "ProfileLicensePlate";

                nicknameBindingSource.DataSource = profileBindingSource;
                nicknameBindingSource.DataMember = "ProfileNickname";

                workPlaceBindingSource.DataSource = profileBindingSource;
                workPlaceBindingSource.DataMember = "ProfileWorkplace";

                livingPlaceBindingSource.DataSource = profileBindingSource;
                livingPlaceBindingSource.DataMember = "ProfileLivingPlace";
            }
            catch (SqlException)
            {
                MessageBox.Show("Error.");
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {   
            //тут писать условия для поиска P.S.: Задача снята


            /*if (checkBo1.Checked == false && checkBo2.Checked == false && checkBo3.Checked == false && checkBo4.Checked == false && checkBo5.Checked == false && checkBo6.Checked == false && checkBo7.Checked == false)
                button4.Enabled = false;
            else
                button4.Enabled = true*/
        }
       

        private void button12_Click_1(object sender, EventArgs e)
        {
            Form ForRedProf = new ForRedProf();
            ForRedProf.Show();
            //редактирование профиля
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form RedTel = new RedTel();
            RedTel.Show();
            //редактирование телефон
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form RedProfess = new RedProfess();
            RedProfess.Show();
            //редактирование профессия
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form RedPasprt = new RedPasprt();
            RedPasprt.Show();
            //редактирование номер паспорта
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form RedNomMash = new RedNomMash();
            RedNomMash.Show();
            //редактирование номерной знак
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form RedKlich = new RedKlich();
            RedKlich.Show();
            //редактирование кличка
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form RedMestRab = new RedMestRab();
            RedMestRab.Show();
            //редактирование место работы
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form RedMestGitel = new RedMestGitel();
            RedMestGitel.Show();
            //редактирование место жительства
        }
        //счёт записей
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count = telephoneBindingSource.Count;
            label15.Text = count.ToString();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            count = professionBindingSource.Count;
            label22.Text = count.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            count = passportNumberBindingSource.Count;
            label21.Text = count.ToString();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            count = licensePlateBindingSource.Count;
            label23.Text = count.ToString();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            count = nicknameBindingSource.Count;
            label24.Text = count.ToString();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            count = workPlaceBindingSource.Count;
            label25.Text = count.ToString();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            count = livingPlaceBindingSource.Count;
            label26.Text = count.ToString();
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            count = professionBindingSource.Count;
            label27.Text = count.ToString();
        }
    }
}
