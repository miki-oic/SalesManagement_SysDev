using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SalesManagement_SysDev
{

    public partial class Form1 : Form
    {

        private RegisterForm form2;
        private UpdateForm form3;
        private List<SelectListener> selectListeners = new List<SelectListener>();

        public Form1()
        {

            InitializeComponent();

            Initialize();

            form2 = new RegisterForm(this);
            form3 = new UpdateForm(this);

            form2.Show();
            form3.Show();

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

        public void AddSelectListener(SelectListener selectListener)
        {

            selectListeners.Add(selectListener);

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

            MSalesOffice selectedMSalesOffice = new MSalesOffice();

            foreach (DataGridViewRow dataGridViewRow in dataGridView1.SelectedRows)
            {

                int index = 0;

                foreach (DataGridViewTextBoxCell dataGridViewTextBoxCell in dataGridViewRow.Cells)
                {

                    // public int SoId { get; set; }
                    if (index is 0)
                    {

                        selectedMSalesOffice.SoId = AcquireIntegerValue(dataGridViewTextBoxCell);

                    }
                    // public string SoName { get; set; } = null!;
                    else if (index is 1)
                    {
                        
                        selectedMSalesOffice.SoName = AcquireStringValue(dataGridViewTextBoxCell);

                    }
                    // public string SoAddress { get; set; } = null!;
                    else if (index is 2)
                    {

                        selectedMSalesOffice.SoAddress = AcquireStringValue(dataGridViewTextBoxCell);

                    }
                    // public string SoPhone { get; set; } = null!;
                    else if (index is 3)
                    {

                        selectedMSalesOffice.SoPhone = AcquireStringValue(dataGridViewTextBoxCell);

                    }
                    // public string SoPostal { get; set; } = null!;
                    else if (index is 4)
                    {

                        selectedMSalesOffice.SoPostal = AcquireStringValue(dataGridViewTextBoxCell);

                    }
                    // public string SoFax { get; set; } = null!;
                    else if (index is 5)
                    {

                        selectedMSalesOffice.SoFax = AcquireStringValue(dataGridViewTextBoxCell);

                    }
                    // public int SoFlag { get; set; }
                    else if (index is 6)
                    {

                        selectedMSalesOffice.SoFlag = AcquireIntegerValue(dataGridViewTextBoxCell);

                    }

                    index++;

                }

            }

            foreach (SelectListener listener in selectListeners)
            {

                listener.OnSelect(selectedMSalesOffice);

            }

        }

        private int AcquireIntegerValue(DataGridViewTextBoxCell dataGridViewTextBoxCell)
        {

            return int.Parse(dataGridViewTextBoxCell.EditedFormattedValue.ToString());

        }

        private string AcquireStringValue(DataGridViewTextBoxCell dataGridViewTextBoxCell)
        {

            return dataGridViewTextBoxCell.EditedFormattedValue.ToString();

        }

    }

}
