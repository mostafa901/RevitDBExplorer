﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Autodesk.Revit.DB;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.DataModel.MemberAccessors
{
    internal class Element_GetPhaseStatus : MemberAccessorByType<Element>, IHaveFactoryMethod
    {
        protected override IEnumerable<LambdaExpression> HandledMembers { get { yield return (Element x, ElementId i) => x.GetPhaseStatus(i); } }      
        IMemberAccessor IHaveFactoryMethod.Create() => new Element_GetPhaseStatus();


        protected override bool CanBeSnoooped(Document document, Element element) => !document.Phases.IsEmpty;
        protected override string GetLabel(Document document, Element element) => "[ElementOnPhaseStatus]";
        protected override IEnumerable<SnoopableObject> Snooop(Document document, Element element)
        {
            var elementOnPhaseStatuses = document.Phases.OfType<Phase>().Select(x => new SnoopableObject(element.GetPhaseStatus(x.Id), document, $"Phase: {x.Name}"));
            return elementOnPhaseStatuses;
        }
    }
}