using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabTech.Interfaces;

namespace LTPremSvc.LTStringFunctionsExtended
{
    public class ConvertStringToBase64 : LabTech.Interfaces.IFunction
    {
        private LabTech.Interfaces.IControlCenter controlCenter;

        private string _stringToConvert;
        private string _ltVarName;

        public string FunctionGUID 
        {
            get
            {
                return "2792b2c0-f96b-4c8b-9350-527e9c7dc1a8";
            }
        }

        public string FunctionName
        {
            get
            {
                return "LTStringFunctionsExtended.ConvertStringToBase64";
            }
        }

        public string Name
        {
            get
            {
                return "LTStringFunctionsExtended.ConvertStringToBase64";
            }
        }

        public void Decommision()
        {
            this.controlCenter = null;
        }

        public string Execute(string strToEncode, string varName, string parameter3, string parameter4, ref Hashtable userVariables, ref Hashtable internalVariables)
        {
            this._stringToConvert = strToEncode.Trim();
            this._ltVarName = varName.Trim();
            string convertedString = null;

            try
            {
                var txtInBytes = System.Text.Encoding.UTF8.GetBytes(this._stringToConvert);
                convertedString = System.Convert.ToBase64String(txtInBytes);

                if (this._ltVarName.Length > 0)
                    LTScriptingHelpers.UpdateLTUserVariables(this._ltVarName, convertedString, ref userVariables);
            }
            catch (Exception ex)
            {
                controlCenter.LogMessage("Plugin Script String Function Extented commited an error in " + ex.TargetSite.Name + " " + ex.Message);
            }

            return convertedString;
        }

        public string[] GetParameterDescriptions()
        {
            return "NotUsed|NotUsed|String to Convert to Base64|Variable to Save the Results|NotUsed|NotUsed".Split('|');
        }

        public string[] GetParameterNames()
        {
            return "NotUsed|Input Value|Output Variable|NotUsed".Split('|');
        }

        public void Initialize(IControlCenter host)
        {
            this.controlCenter = host;
        }

    }
}
