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

    public partial class RegisterForm : Form
    {

        private Form1 form1;
        private MSalesOfficePanel mSalesOfficePanel;
        private List<ShowEventListener> showEventListeners = new List<ShowEventListener>();

        /// <summary>
        /// 画面デザイナー表示用コンストラクタ
        /// </summary>
        public RegisterForm()
        {

            InitializeComponent();

        }

        public RegisterForm(Form1 form1)
        {

            this.form1 = form1;

            InitializeComponent();

            Initialize();

        }

        private void Initialize()
        {

            mSalesOfficePanel = new MSalesOfficePanel().AddRegister(this);
            mSalesOfficePanel.Location = new Point(2, 5);

            AddShowEventListener(mSalesOfficePanel);

            Controls.Add(mSalesOfficePanel);

            form1.AddSelectListener(mSalesOfficePanel);

            button1.Text = "新規に登録する";
            button1.Size = new Size(300, 30);

            Text = "RegisterForm";

        }

        protected override void OnVisibleChanged(EventArgs e)
        {

            if (Visible)
            {

                foreach (ShowEventListener showEventListener in showEventListeners)
                {

                    showEventListener.OnShow(this);

                }

            }

            base.OnVisibleChanged(e);

        }

        public void AddShowEventListener(ShowEventListener showEventListener)
        {

            showEventListeners.Add(showEventListener);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            mSalesOfficePanel.OnClick(this);

        }

    }

}
