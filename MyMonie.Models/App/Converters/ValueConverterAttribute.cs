// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;

namespace MyMonie.Models.App.Converters;

/// <summary>
/// This attribute is used to specify the value converter to be used for a property.
/// This is automatically used by the <see cref="ValueConverterAttributeConvention"/>
/// </summary>
/// <param name="converterType"></param>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ValueConverterAttribute(Type converterType) : Attribute
{
    public Type ConverterType { get; } = converterType;
}
