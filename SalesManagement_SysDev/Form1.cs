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

            SalesManagementContext context = new SalesManagementContext();

            IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction();
            
            dataGridView1.DataSource = context.MMakers.ToList();

        }

    }

}
