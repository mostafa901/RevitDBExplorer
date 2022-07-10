﻿using System;
using RevitDBExplorer.Domain.DataModel.ValueTypes.Base;

namespace RevitDBExplorer.Domain.DataModel.ValueTypes
{
    internal sealed class EnumType : Base.ValueType<System.Enum>, IHaveFactoryMethod
    {
        IValueType IHaveFactoryMethod.Create()
        {
            return new EnumType();
        }

        //public override string TypeName => $"{value?.GetType()?.Name}";
        protected override bool CanBeSnoooped(Enum enumValue) => false;
        protected override string ToLabel(Enum enumValue)
        {
            return $"{TypeName}.{enumValue}";
        }
    }
}