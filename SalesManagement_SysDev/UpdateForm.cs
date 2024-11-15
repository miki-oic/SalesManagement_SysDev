﻿using System;
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

    public partial class UpdateForm : Form
    {

        private Form1 form1;
        private MSalesOfficePanel mSalesOfficePanel;
        private List<ShowEventListener> showEventListeners = new List<ShowEventListener>();

        public UpdateForm()
        {

            InitializeComponent();

        }

        public UpdateForm(Form1 form1)
        {

            this.form1 = form1;

            InitializeComponent();

            Initialize();

        }

        private void Initialize()
        {

            mSalesOfficePanel = new MSalesOfficePanel(this);
            mSalesOfficePanel.Location = new Point(2, 5);

            Controls.Add(mSalesOfficePanel);

            form1.AddSelectListener(mSalesOfficePanel);

        }

        public void AddShowEventListener(ShowEventListener showEventListener)
        {

            showEventListeners.Add(showEventListener);

        }

    }

}
