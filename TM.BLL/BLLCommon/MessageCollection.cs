using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.BLL.BLLCommon
{
    public class MessageCollection
    {
        public static string ValidUser { get { return "User is Valid!"; } }
        public static string InvalidUser { get { return "Invalid User"; } }
        public static string SuccessFullyReg { get { return "Successfully Registered!"; } }
        public static string SuccessSave { get { return "Successfully Saved!"; } }
        public static string SuccessUpdate { get { return "Successfully Update!"; } }
        public static string SuccessDelete { get { return "Data Deleted!"; } }

    }
}
