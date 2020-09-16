using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.DAL
{
    public class BaseDAL
    {
        protected PaletteEntities pe;
        public BaseDAL()
        {
            pe = new PaletteEntities();
        }
    }
}
