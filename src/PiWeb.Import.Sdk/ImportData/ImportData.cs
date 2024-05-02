﻿#region copyright

/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss Industrielle Messtechnik GmbH        */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2024                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */

#endregion

namespace Zeiss.PiWeb.Import.Sdk.ImportData;

/// <summary>
/// Represents data to be imported.
/// </summary>
public class ImportData
{
    /// <summary>
    /// The root of the inspection plan data, measurement data and additional data to be imported.
    /// During import this part will be merged with the designated import part as configured by the import plan
    /// and optionally the path rule configuration.
    /// </summary>
    public InspectionPlanPart RootPart { get; set; } = new InspectionPlanPart("root");
}