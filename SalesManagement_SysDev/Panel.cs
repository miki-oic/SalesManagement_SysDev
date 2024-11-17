using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;

namespace SalesManagement_SysDev
{

    public class MSalesOfficePanel : Panel, ClickEventListener, ShowEventListener, SelectListener
    {

        private MSalesOffice mSalesOffice = MSalesOfficeNullObject.GetInstance();
        private Label soIdLabel = new Label();
        private Label soNameLabel = new Label();
        private DisplayTargetTextBox soNameTextBox = new DisplayTargetTextBox();
        private Label soAddressLabel = new Label();
        private DisplayTargetTextBox soAddressTextBox = new DisplayTargetTextBox();
        private Label soPhoneLabel = new Label();
        private Label soPostalLabel = new Label();
        private Label soFaxLabel = new Label();
        private Label soFlagLabel = new Label();
        private List<ClickEventListener> clickEventListeners = new List<ClickEventListener>();
        private List<ShowEventListener> showEventListeners = new List<ShowEventListener>();
        private List<SelectListener> selectListeners = new List<SelectListener>();

        /// <summary>
        /// 画面デザイナー表示用コンストラクタ
        /// </summary>
        public MSalesOfficePanel()
        {

            Initialize();

        }

        public MSalesOfficePanel AddRegister(object register)
        {

            soNameTextBox.AddTarget(register).Required = true;

            return this;

        }

        public MSalesOfficePanel AddUpdater(object updater)
        {

            soAddressTextBox.AddTarget(updater);

            return this;

        }

        private void Initialize()
        {

            SuspendLayout();

            /*
             * SoId
             */
            soIdLabel.AutoSize = true;
            soIdLabel.Location = new Point(50, 50);
            soIdLabel.Name = "soIdLabel";
            soIdLabel.Size = new Size(300, 30);
            soIdLabel.TabIndex = 0;
            soIdLabel.Text = "SoId";

            /*
             * SoName
             * 課題：パネル化せよ
             */
            soNameLabel.AutoSize = true;
            soNameLabel.Location = new Point(50, 90);
            soNameLabel.Name = "soNameLabel";
            soNameLabel.Size = new Size(300, 30);
            soNameLabel.TabIndex = 0;
            soNameLabel.Text = "SoName";

            soNameTextBox.Location = new Point(360, 90);
            soNameTextBox.Name = "soNameTextBox";
            soNameTextBox.Size = new Size(300, 30);
            soNameTextBox.TabIndex = 0;

            /*
             * SoAddress
             * 課題：パネル化せよ
             */
            soAddressLabel.AutoSize = true;
            soAddressLabel.Location = new Point(50, 130);
            soAddressLabel.Name = "soAddressLabel";
            soAddressLabel.Size = new Size(300, 30);
            soAddressLabel.TabIndex = 0;
            soAddressLabel.Text = "SoAddress";

            soAddressTextBox.Location = new Point(360, 130);
            soAddressTextBox.Name = "soNameTextBox";
            soAddressTextBox.Size = new Size(300, 30);
            soAddressTextBox.TabIndex = 0;

            /*
             * SoPhone
             */
            soPhoneLabel.AutoSize = true;
            soPhoneLabel.Location = new Point(50, 170);
            soPhoneLabel.Name = "soPhoneLabel";
            soPhoneLabel.Size = new Size(300, 30);
            soPhoneLabel.TabIndex = 0;
            soPhoneLabel.Text = "SoPhone";

            /*
             * SoPostal
             */
            soPostalLabel.AutoSize = true;
            soPostalLabel.Location = new Point(50, 210);
            soPostalLabel.Name = "soPostalLabel";
            soPostalLabel.Size = new Size(300, 30);
            soPostalLabel.TabIndex = 0;
            soPostalLabel.Text = "SoPostal";

            /*
             * SoFax
             */
            soFaxLabel.AutoSize = true;
            soFaxLabel.Location = new Point(50, 250);
            soFaxLabel.Name = "soFaxLabel";
            soFaxLabel.Size = new Size(300, 30);
            soFaxLabel.TabIndex = 0;
            soFaxLabel.Text = "SoFax";

            /*
             * SoFlag
             */
            soFlagLabel.AutoSize = true;
            soFlagLabel.Location = new Point(50, 290);
            soFlagLabel.Name = "soFlagLabel";
            soFlagLabel.Size = new Size(300, 30);
            soFlagLabel.TabIndex = 0;
            soFlagLabel.Text = "SoFlag";

            Name = "panel1";
            Size = new Size(720, 390);
            TabIndex = 0;

            clickEventListeners.Add(soNameTextBox);
            clickEventListeners.Add(soAddressTextBox);

            showEventListeners.Add(soNameTextBox);
            showEventListeners.Add(soAddressTextBox);

            Controls.Add(soIdLabel);
            Controls.Add(soNameLabel);
            Controls.Add(soNameTextBox);
            Controls.Add(soAddressLabel);
            Controls.Add(soAddressTextBox);
            Controls.Add(soPhoneLabel);
            Controls.Add(soPostalLabel);
            Controls.Add(soFaxLabel);
            Controls.Add(soFlagLabel);

            ResumeLayout(false);
            PerformLayout();

        }

        public void OnClick(object sender)
        {

            try
            {

                foreach (ClickEventListener clickEventListener in clickEventListeners)
                {

                    clickEventListener.OnClick(sender);

                }
            }
            catch (RequiredException e)
            {

                // 課題：必要な実装をせよ

            }

        }

        public void OnShow(object sender)
        {

            foreach (ShowEventListener showEventListener in showEventListeners)
            {

                showEventListener.OnShow(sender);

            }

        }

        public void OnSelect(object target)
        {

            if (target is MSalesOffice)
            {

                AddMSalesOffice(target as MSalesOffice).UpdateData();

            }

        }

        public MSalesOfficePanel AddMSalesOffice(MSalesOffice mSalesOffice)
        {

            this.mSalesOffice = mSalesOffice;

            return this;

        }

        private void UpdateData()
        {

            /*
             * MSalesOffice
             */
            // public int SoId { get; set; }
            soIdLabel.Text = mSalesOffice.SoId.ToString();
            // public string SoName { get; set; } = null!;
            soNameLabel.Text = mSalesOffice.SoName;
            // public string SoAddress { get; set; } = null!;
            soAddressLabel.Text = mSalesOffice.SoAddress;
            // public string SoPhone { get; set; } = null!;
            soPhoneLabel.Text = mSalesOffice.SoPhone;
            // public string SoPostal { get; set; } = null!;
            soPostalLabel.Text = mSalesOffice.SoPostal;
            // public string SoFax { get; set; } = null!;
            soFaxLabel.Text = mSalesOffice.SoFax;
            // public int SoFlag { get; set; }
            soFlagLabel.Text = mSalesOffice.SoFlag.ToString();

        }

    }

}
