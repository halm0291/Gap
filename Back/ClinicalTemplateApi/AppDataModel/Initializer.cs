using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataModel
{
    public class Initializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new NullDatabaseInitializer<ClinicalTemplateContext>());
        }
    }
}
