using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ABIS_Module
{
    internal class Manager
    {
       public static Employee LoginEmployee { get; set; }
       public static Frame MenuFrame { get; set; }
       public static Frame BaseFrame { get; set; }
       public static string SelectedLib { get; set; }

    }
}
