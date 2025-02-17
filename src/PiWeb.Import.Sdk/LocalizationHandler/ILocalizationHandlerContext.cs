#region copyright

/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss Industrielle Messtechnik GmbH        */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2024                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */

#endregion

#region usings

using Zeiss.PiWeb.Import.Sdk.Logging;

#endregion

namespace Zeiss.PiWeb.Import.Sdk.LocalizationHandler;

/// <summary>
/// Represents the context for creating an <see cref="ILocalizationHandler"/> instance.
/// </summary>
public interface ILocalizationHandlerContext
{
    /// <summary>
    /// A logger that can be used to write log entries. Written entries are usually forwarded to the log file of the
    /// hosting application.
    /// </summary>
    ILogger Logger { get; }
}