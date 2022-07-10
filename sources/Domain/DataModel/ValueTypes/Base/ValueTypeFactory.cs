﻿using System;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.DataModel.ValueTypes.Base
{
    internal static class ValueTypeFactory
    {
        private static readonly IHaveFactoryMethod[] ValueTypeFactories = new IHaveFactoryMethod[]
        {
            // System primitives
            new BoolType(),
            new IntType(),
            new StringType(),
            new DoubleType(),
            new GuidType(),
            new EnumType(),

            // APIObjects primitives
            new BoundingBoxXYZType(),
            new CategoryType(),
            new XYZType(),
            new UVType(),
            new ColorType(),

            //
            new ParameterType(),
            new FamilyParameterType(),
            new ParameterSetType(),
            new ParameterMapType(),       
            new ElementIdType(),
            new ElementType(),
        };


        public static IValueType Create(Type type)
        {
            foreach (var factory in ValueTypeFactories)
            {
                if (factory.Type.IsAssignableFrom(type))
                {
                    var result = factory.Create();                   
                    return result;
                }
            }
            return new ObjectType(type);
        }
    }
}