using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnipUp.Class
{
    class HotkeyStrings
    {
        private Properties.Settings settings = Properties.Settings.Default;
        private string tmp = "";

        public HotkeyStrings()
        {

        }

        public string getHotkeyStringDefined()
        {
            tmp = "";
            if (settings.ModifierDefined != "None")
            {
                tmp += settings.ModifierDefined.Replace(", ", "+");
                tmp += "+" + settings.KeyDefined;
                tmp = tmp.Replace("Control", "Ctrl");
            }
            else 
            {
                tmp = settings.KeyDefined;
            }
            return tmp;
        }

        public string getHotkeyStringFull()
        {
            tmp = "";
            if (settings.ModifierFull != "None")
            {
                tmp += settings.ModifierFull.Replace(", ", "+");
                tmp += "+" + settings.KeyFull;
                tmp = tmp.Replace("Control", "Ctrl");
            }
            else
            {
                tmp = settings.KeyFull;
            }
            return tmp;
        }

        public string getHotkeyStringActive()
        {
            tmp = "";
            if (settings.ModifierActive != "None")
            {
                tmp += settings.ModifierActive.Replace(", ", "+");
                tmp += "+" + settings.KeyActive;
                tmp = tmp.Replace("Control", "Ctrl");
            }
            else
            {
                tmp = settings.KeyActive;
            }
            return tmp;
        }
    }
}
