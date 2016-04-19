using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabTech.Interfaces;

namespace LTPremSvc.LTStringFunctionsExtended
{
    class PluginMain : LabTech.Interfaces.IPlugin
    {

        string fileName;
        string md5;

        public string About
        {
            get
            {
                return string.Format("LabTech {0} Plugin. This plugin extends string functions available in the script editor. Created by {1} of the ConnectWise's LabTech Premium Service department.", "Script String Funtions Extented", this.Author);
            }
        }

        public string Author
        {
            get
            {
                return "Brian Ojeda";
            }
        }

        public string Filename
        {
            get
            {
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        public string hMD5
        {
            get
            {
                return this.md5;
            }

            set
            {
                this.md5 = value;
            }
        }

        public string Name
        {
            get
            {
                return "Script String Functions Extended";
            }
        }

        public int Version
        {
            get
            {
                return 1;
            }
        }

        public bool Install(IControlCenter host)
        {
            return true;
        }

        public bool IsCompatible(IControlCenter host)
        {
            return true;
        }

        public bool IsLicensed()
        {
            return true;
        }

        public bool IsLicensed(IControlCenter host)
        {
            return true;
        }

        public bool Remove(IControlCenter host)
        {
            return true;
        }
    }
}
