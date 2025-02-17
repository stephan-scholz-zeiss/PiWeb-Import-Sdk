﻿#region copyright

/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss Industrielle Messtechnik GmbH        */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2024                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */

#endregion

#region usings

using System;

#endregion

namespace Zeiss.PiWeb.Import.Sdk.ImportData;

/// <summary>
/// Represents a value of an entity variable.
/// </summary>
public readonly struct VariableValue
{
    #region members

    /// <summary>
    /// The null value.
    /// </summary>
    public static readonly VariableValue Null = new VariableValue();

    private readonly object? _Value;

    #endregion

    #region constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="VariableValue"/> struct.
    /// </summary>
    public VariableValue()
    {
        _Value = null;
    }

    private VariableValue(object value)
    {
        _Value = value;
    }

    #endregion

    #region properties

    /// <summary>
    /// The type of the value.
    /// </summary>
    public VariableValueType ValueType =>
        _Value switch
        {
            null => VariableValueType.Null,
            int => VariableValueType.Integer,
            double => VariableValueType.Double,
            string => VariableValueType.String,
            DateTime => VariableValueType.DateTime,
            CatalogEntry => VariableValueType.CatalogEntry,
            _ => VariableValueType.Null
        };

    #endregion

    #region methods

    /// <summary>
    /// Creates a new variable value from the given integer value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The variable value.</returns>
    public static VariableValue From(int value)
    {
        return new VariableValue(value);
    }

    /// <summary>
    /// Creates a new variable value from the given double value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The variable value.</returns>
    public static VariableValue From(double value)
    {
        return new VariableValue(value);
    }

    /// <summary>
    /// Creates a new variable value from the given string value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The variable value.</returns>
    public static VariableValue From(string value)
    {
        return new VariableValue(value);
    }

    /// <summary>
    /// Creates a new variable value from the given date and time value. The value must have a specified date time kind.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The variable value.</returns>
    /// <exception cref="ImportDataException">Thrown when the given date time value has an unspecified date time kind.</exception>
    public static VariableValue From(DateTime value)
    {
        if (value.Kind == DateTimeKind.Unspecified)
            throw new ImportDataException("Date time values must not have an unspecified date time kind.");

        return new VariableValue(value);
    }

    /// <summary>
    /// Creates a new variable value from the given catalog entry.
    /// </summary>
    /// <param name="catalogEntry">The catalog entry.</param>
    /// <returns>The variable value.</returns>
    public static VariableValue From(CatalogEntry catalogEntry)
    {
        return new VariableValue(catalogEntry);
    }

    /// <summary>
    /// Gets the variable value as object.
    /// </summary>
    /// <returns>The variable value.</returns>
    public object? GetValue()
    {
        return _Value;
    }

    /// <summary>
    /// Checks whether the variable value is null.
    /// </summary>
    /// <returns>True if the variable value is null; otherwise, false.</returns>
    public bool IsNull()
    {
        return _Value is null;
    }

    /// <summary>
    /// Gets the variable value as integer. When the variable value is null or not an integer, null is returned.
    /// Note: This will never convert non-integer variable values like doubles or strings to integers.
    /// </summary>
    /// <returns>The variable value.</returns>
    public int? AsInteger()
    {
        return _Value as int?;
    }

    /// <summary>
    /// Gets the variable value as double. When the variable value is null or not a double, null is returned.
    /// Note: This will never convert non-double variable values like integers or strings to doubles.
    /// </summary>
    /// <returns>The variable value.</returns>
    public double? AsDouble()
    {
        return _Value as double?;
    }

    /// <summary>
    /// Gets the variable value as string. When the variable value is null or not a string, null is returned.
    /// Note: This will never convert non-string variable values to string.
    /// </summary>
    /// <returns>The variable value.</returns>
    public string? AsString()
    {
        if (_Value is string stringValue)
            return stringValue;

        return null;
    }

    /// <summary>
    /// Gets the variable value as DateTime. When the variable value is null or not a DateTime, null is returned.
    /// Note: This will never convert non-DateTime variable values to DateTime.
    /// </summary>
    /// <returns>The variable value.</returns>
    public DateTime? AsDateTime()
    {
        return _Value as DateTime?;
    }

    /// <summary>
    /// Gets the variable value as catalog entry. When the variable value is null or not a catalog entry, null is returned.
    /// Note: This will never convert non-ICatalogEntry variable values to catalog entries.
    /// </summary>
    /// <returns>The variable value.</returns>
    public CatalogEntry? AsCatalogEntry()
    {
        return _Value as CatalogEntry;
    }

    #endregion
}