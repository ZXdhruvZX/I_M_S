using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ims
{
    public partial class categories : Sample2
    {
        int edit = 0; //this 0 is an indication to save operation and 1 is an indication to update operation
        int catID;
        short stat;
        retrieval r = new retrieval();

        public categories()
        {
            InitializeComponent();
        }

        private void categories_Load(object sender, EventArgs e)
        {
            MainClass.disable(leftPanel);
        }

        public override void addBtn_Click(object sender, EventArgs e)
        {
            MainClass.enable_reset(leftPanel);
            edit = 0;
        }

        public override void editBtn_Click(object sender, EventArgs e)
        {
            edit = 1;
            MainClass.enable(leftPanel);
        }

        public override void saveBtn_Click(object sender, EventArgs e)
        {
            if (catTxt.Text == "") { catErrorLabel.Visible = true; } else { catErrorLabel.Visible = false; }            
            if (activeDD.SelectedIndex == -1) { activeErrorLabel.Visible = true; } else { activeErrorLabel.Visible = false; }


            if (activeErrorLabel.Visible || catErrorLabel.Visible)
            {
                MainClass.ShowMSG("Fields with * are mandatory", "Stop", "Error");      //error is the type of message
            }
            else
            {
                if (activeDD.SelectedIndex == 0)
                {
                    stat = 1;
                }
                else if (activeDD.SelectedIndex == 1)
                {
                    stat = 0;
                }
                if (edit == 0)  //code for save operation
                {
                    insertion i = new insertion();

                    i.insertCat(catTxt.Text, stat);
                    r.showCategories(dataGridView1, catIDGV, NameGV, statusGV);
                    MainClass.disable_reset(leftPanel);

                }
                else if (edit == 1)        //code for update operation
                {
                    DialogResult dr = MessageBox.Show("Are you sure, you want to update the record?", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        updation u = new updation();
                        if (activeDD.SelectedIndex == 0)
                        {
                            stat = 1;
                        }
                        else if (activeDD.SelectedIndex == 1)
                        {
                            stat = 0;
                        }
                        u.updateCat(catID, catTxt.Text, stat);
                        r.showCategories(dataGridView1, catIDGV, NameGV, statusGV);
                        MainClass.disable_reset(leftPanel);
                    }


                }
            }
        }

        public override void deleteBtn_Click(object sender, EventArgs e)
        {
            if (edit == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure, you want to delete the record?", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    deletion d = new deletion();
                    d.delete(catID, "st_deleteCategor", "@id");
                    r.showCategories(dataGridView1, catIDGV, NameGV, statusGV);

                }

            }
        }

        public override void searchTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public override void viewBtn_Click(object sender, EventArgs e)
        {
            r.showCategories(dataGridView1, catIDGV, NameGV, statusGV);

        }

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                edit = 1;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                catID = Convert.ToInt32(row.Cells["catIDGV"].Value.ToString());
                catTxt.Text = row.Cells["NameGV"].Value.ToString();                
                activeDD.SelectedItem = row.Cells["statusGV"].Value.ToString();
                MainClass.disable(leftPanel);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }
    }
}
