using AppDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class ConfigurationService
    {
        public static void InitializeConfig()
        {
            Initializer.Initialize();
        }
    }
}
