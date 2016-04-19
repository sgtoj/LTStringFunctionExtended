using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabTech.Interfaces;

namespace LTPremSvc.LTStringFunctionsExtended
{
    public class GetStringLength : LabTech.Interfaces.IFunction
    {
        private LabTech.Interfaces.IControlCenter controlCenter;
        private string _stringToEval;
        private string _ltVarName;

        public string FunctionGUID 
        {
            get
            {
                return "ad782bc3-1dde-43ce-b305-c1e5055ea795";
            }
        }

        public string FunctionName
        {
            get
            { 
                return "LTStringFunctionsExtended.GetStringLength";
            }
        }

        public string Name
        {
            get
            {
                return "LTStringFunctionsExtended.GetStringLength";
            }
        }

        public void Decommision()
        {
            this.controlCenter = null;
        }

        public string Execute(string strToEval, string varName, string parameter3, string parameter4, ref Hashtable userVariables, ref Hashtable internalVariables)
        {
            this._stringToEval= strToEval;
            this._ltVarName = varName; 

            string stringLength = null;

            try
            {
                stringLength = Convert.ToString(this._stringToEval.Length);

                if (varName.Length > 0)
                    LTScriptingHelpers.UpdateLTUserVariables(this._ltVarName, stringLength, ref userVariables);

            }
            catch (Exception ex)
            {
                controlCenter.LogMessage("Plugin Script String Function Extented commited an error " + ex.TargetSite.Name + " " + ex.Message);
            }

            return stringLength;
        }

        public string[] GetParameterDescriptions()
        {
            return "NotUsed|NotUsed|String to Measure Length|Variable to Save the Results|NotUsed|NotUsed".Split('|');
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
