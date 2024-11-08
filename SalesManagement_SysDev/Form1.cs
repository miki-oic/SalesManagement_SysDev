﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            /*
             * 参考サイト：
             * https://learn.microsoft.com/ja-jp/dotnet/api/system.windows.forms.datagridview.multiselect?view=windowsdesktop-8.0
             */
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        /// <summary>
        /// 参考サイト：
        /// https://learn.microsoft.com/ja-jp/ef/ef6/querying/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            SalesManagementContext context = new SalesManagementContext();

            IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction();

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {

                dataGridView1.DataSource = (
                    from mSalesOffice in context.MSalesOffices
                    where mSalesOffice.SoId == int.Parse(textBox1.Text)
                    where mSalesOffice.SoName.StartsWith(textBox2.Text)
                    select mSalesOffice
                    ).ToList();

            }
            else if (textBox1.Text.Length > 0)
            {

                dataGridView1.DataSource = (
                    from mSalesOffice in context.MSalesOffices
                    where mSalesOffice.SoId == int.Parse(textBox1.Text)
                    select mSalesOffice
                    ).ToList();

            }
            else if (textBox2.Text.Length > 0)
            {

                dataGridView1.DataSource = (
                    from mSalesOffice in context.MSalesOffices
                    where mSalesOffice.SoName.StartsWith(textBox2.Text)
                    select mSalesOffice
                    ).ToList();

            }
            else
            {

                dataGridView1.DataSource = context.MSalesOffices.ToList();

            }

        }

        private void DataGridView1Click(object sender, System.EventArgs e)
        {

            foreach (DataGridViewRow dataGridViewRow in dataGridView1.SelectedRows)
            {

                int index = 0;

                foreach (DataGridViewTextBoxCell dataGridViewTextBoxCell in dataGridViewRow.Cells)
                {

                    if (index++ < 5)
                    {

                        Debug.WriteLine("Value:[{0}] FormattedValue[{1}] EditedFormattedValue[{2}]",
                            dataGridViewTextBoxCell.Value,
                            dataGridViewTextBoxCell.FormattedValue,
                            dataGridViewTextBoxCell.EditedFormattedValue);

                    }

                }

            }

        }
    }

}
