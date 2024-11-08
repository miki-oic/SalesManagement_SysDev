using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SalesManagement_SysDev
{

    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();

            Initialize();

        }

        private void Initialize()
        {

            label1.Text = "SoId";
            label2.Text = "SoName";
            button1.Text = "指定内容で検索する";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SalesManagementContext context = new SalesManagementContext();

            IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction();

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {

                dataGridView1.DataSource = (
                    from mMaker in context.MSalesOffices
                    where mMaker.SoId == int.Parse(textBox1.Text)
                    where mMaker.SoName.StartsWith(textBox2.Text)
                    select mMaker
                    ).ToList();

            }
            else if(textBox1.Text.Length > 0)
            {

                dataGridView1.DataSource = (
                    from mMaker in context.MSalesOffices
                    where mMaker.SoId == int.Parse(textBox1.Text)
                    select mMaker
                    ).ToList();

            }
            else if (textBox2.Text.Length > 0)
            {

                dataGridView1.DataSource = (
                    from mMaker in context.MSalesOffices
                    where mMaker.SoName.StartsWith(textBox2.Text)
                    select mMaker
                    ).ToList();

            }
            else
            {

                dataGridView1.DataSource = context.MSalesOffices.ToList();

            }

        }
    }

}
