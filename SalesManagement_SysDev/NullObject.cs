using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{

    public interface NullObject
    {

    }

    public class MSalesOfficeNullObject : MSalesOffice, NullObject
    {

        private static MSalesOfficeNullObject mSalesOfficeNullObject = new MSalesOfficeNullObject();

        private MSalesOfficeNullObject()
        {

        }

        public static MSalesOffice GetInstance()
        {

            return mSalesOfficeNullObject;

        }

    }

}
