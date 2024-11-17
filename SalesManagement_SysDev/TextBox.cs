using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{

    public class DisplayTargetTextBox : TextBox, ClickEventListener, ShowEventListener
    {

        private bool required = false;
        private object target;

        public DisplayTargetTextBox()
        {

            target = this;

        }

        public bool Required { get; set; }

        public DisplayTargetTextBox AddTarget(object target)
        {

            this.target = target;

            return this;

        }

        public void OnClick(object sender)
        {
            
            if (Text.IsNullOrEmpty() && Required)
            {

                BackColor = Color.Red;

                throw new RequiredException();

            }

        }

        public void OnShow(object sender)
        {

            if (sender.Equals(target))
            {

                Show();

            }
            else
            {

                Hide();

            }

        }

    }

}
