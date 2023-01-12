using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.BLL.BLLCommon
{
    public class StringFormatCollection
    {
        public static string AccessTokenFormat
        {
            get
            {
                return "{0},uid:{1},uname:{2},rightId:{3},rightname:{4},roleid:{5},rolename:{6},teamid:{7}";
            }
        }

        public static string[] AccessTokenPropertyArray
        {
            get
            {
                return new string[] { ",uid:", ",uname:", ",rightId:", ",rightname:", ",roleid:", ",rolename:", ",teamid:" };
            }
        }
    }
}
