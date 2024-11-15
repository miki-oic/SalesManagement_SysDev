using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{

    public class UpdateTextBox : TextBox, ClickEventListener, ShowEventListener
    {

        private Form form;
        private bool required = false;

        public UpdateTextBox()
        {

        }

        public UpdateTextBox(Form form)
        {

            this.form = form;

        }

        public bool Required { get; set; }

        public void OnClick(object sender)
        {

            if (Text.IsNullOrEmpty() && Required)
            {

                BackColor = Color.Red;

            }

        }

        public void OnShow(object sender)
        {

            if (form is RegisterForm)
            {

                Hide();

            }
            else if (form is UpdateForm)
            {

                Show();

            }

        }

    }

}
