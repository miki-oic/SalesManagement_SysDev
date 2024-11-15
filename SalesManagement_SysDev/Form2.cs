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

    public partial class Form2 : Form
    {

        private Form1 form1;
        private MSalesOfficePanel mSalesOfficePanel;

        /// <summary>
        /// 画面デザイナー表示用コンストラクタ
        /// </summary>
        public Form2()
        {

            InitializeComponent();

        }

        public Form2(Form1 form1)
        {

            this.form1 = form1;

            InitializeComponent();

            Initialize();

        }

        private void Initialize()
        {

            mSalesOfficePanel = new MSalesOfficePanel();
            mSalesOfficePanel.Location = new Point(40, 5);

            Controls.Add(mSalesOfficePanel);

            form1.AddSelectListener(mSalesOfficePanel);

        }

    }

}
