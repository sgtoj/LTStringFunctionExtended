using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabTech.Interfaces;

namespace LTPremSvc.LTStringFunctionsExtended
{
    public class ConvertStringFromBase64 : LabTech.Interfaces.IFunction
    {
        private LabTech.Interfaces.IControlCenter controlCenter;

        private string _stringToConvert;
        private string _ltVarName;

        public string FunctionGUID 
        {
            get
            {
                return "7709403b-3608-437e-bab3-2edcc1d4ba04";
            }
        }

        public string FunctionName
        {
            get
            {
                return "LTStringFunctionsExtended.ConvertStringFromBase64";
            }
        }

        public string Name
        {
            get
            {
                return "LTStringFunctionsExtended.ConvertStringFromBase64";
            }
        }

        public void Decommision()
        {
            this.controlCenter = null;
        }

        public string Execute(string encodedVariable, string varName, string parameter3, string parameter4, ref Hashtable userVariables, ref Hashtable internalVariables)
        {
            this._stringToConvert = encodedVariable.Trim();
            this._ltVarName = varName.Trim();
            string convertedString = null;

            try
            {
                if (this._stringToConvert.Length > 0)
                {
                    var base64InBytes = System.Convert.FromBase64String(this._stringToConvert);
                    convertedString = System.Text.Encoding.UTF8.GetString(base64InBytes);

                    if (this._ltVarName.Length > 0)
                        LTScriptingHelpers.UpdateLTUserVariables(this._ltVarName, convertedString, ref userVariables);
                }
            }
            catch (Exception ex)
            {
                controlCenter.LogMessage("Plugin Script String Function Extented commited an error in " + ex.TargetSite.Name + " " + ex.Message);
            }

            return convertedString;
        }

        public string[] GetParameterDescriptions()
        {
            return "NotUsed|NotUsed|String to Convert to Base64|Variable to Save the Results|NotUsed".Split('|');
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
