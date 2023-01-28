﻿using System.Collections.Generic;
using RevitDBExplorer.Domain.RevitDatabaseQuery.Filters;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.RevitDatabaseQuery.Parser.Commands
{
    internal class ElementIdCmdFactory : CommandFactory<ElementIdMatch>
    {
        public override IEnumerable<string> GetClassifiers()
        {
            yield return "i";
            yield return "id";
            yield return "ids";
        }
        public override IEnumerable<string> GetKeywords()
        {
            yield break;
        }
        public override bool CanRecognizeArgument(string argument)
        {
            if (long.TryParse(argument, out long longValue))
            {
                return true;
            }
            return false;
        }


        public override ICommand Create(string cmdText, IList<ILookupResult> arguments)
        {
            return new Command(CmdType.ElementId, cmdText, arguments, null);
        }
        public override IEnumerable<ILookupResult> ParseArgument(string argument)
        {
            return FuzzySearchEngine.Lookup(argument, FuzzySearchEngine.LookFor.ElementId);
        }
    }
}