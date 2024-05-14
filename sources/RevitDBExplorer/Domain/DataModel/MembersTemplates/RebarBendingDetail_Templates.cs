﻿using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using RevitDBExplorer.Domain.DataModel.Members;
using RevitDBExplorer.Domain.DataModel.Members.Base;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.DataModel.MembersTemplates
{
    internal class RebarBendingDetail_Templates : IHaveMemberTemplates
    {
        private static readonly IEnumerable<ISnoopableMemberTemplate> templates = Enumerable.Empty<ISnoopableMemberTemplate>();

        static RebarBendingDetail_Templates()
        {
            templates = new ISnoopableMemberTemplate[]
            {
              
#if R2025_MIN
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.IsBendingDetail(target), kind: MemberKind.StaticMethod),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.GetHost(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.GetHosts(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.GetPosition(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.GetRotation(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.GetTagRelativeRotation(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.IsRealisticBendingDetail(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.GetTagRelativePosition(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
                MemberTemplate<IndependentTag>.Create((doc, target) =>  RebarBendingDetail.IsSchematicBendingDetail(target), kind: MemberKind.StaticMethod, canBeUsed: x => RebarBendingDetail.IsBendingDetail(x)),
#endif
                
            };
        }


        public IEnumerable<ISnoopableMemberTemplate> GetTemplates()
        {
            return templates;
        }
    }
}