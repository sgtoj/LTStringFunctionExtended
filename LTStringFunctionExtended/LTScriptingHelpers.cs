using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTPremSvc.LTStringFunctionsExtended
{
    static internal class LTScriptingHelpers
    {
        private static void updateHashTable (string variableName, string variableValue, ref Hashtable ht)
        {
            variableName = variableName.ToLower();
            if (!ht.Contains(variableName))
            {
                ht.Add(variableName, variableValue);
            }
            else
            {
                ht[variableName] = variableValue;
            }
        }

        static internal void UpdateLTUserVariables(string variableName, string variableValue, ref Hashtable userVariableTable)
        {
            var ltUserVariable = string.Format("@{0}@", variableName);
            updateHashTable(ltUserVariable, variableValue, ref userVariableTable);
        }

        static internal void UpdateLTSystemVariables(string variableName, string variableValue, ref Hashtable sysVariableTable)
        {
            var ltSysVariable = string.Format("%{0}%", variableName);
            updateHashTable(ltSysVariable, variableValue, ref sysVariableTable);
        }
    }
}
