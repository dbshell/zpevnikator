using System;
using System.Collections.Generic;
using System.Text;
using DatAdmin;

namespace zp8
{
    public class Core : Framework
    {
        static Core()
        {
            ProgramNeutralName = "Zpěvníkátor";
            ProgramCodeName = "zpevnikator";
        }

        public static void Initialize()
        {
            Instance = new Core();
        }
    }
}
