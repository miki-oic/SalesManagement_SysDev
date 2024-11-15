using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{

    public interface ClickEventListener
    {

        void OnClick(object sender);

    }

    public interface ShowEventListener
    {

        void OnShow(object sender);

    }

}
