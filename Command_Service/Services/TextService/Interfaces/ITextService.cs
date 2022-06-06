using Command_Service.Commands;

namespace Command_Service.Services.TextService.Interfaces
{
    /// <summary>
    /// Interface changing text properties (the way how it is formatted and/or displayed).
    /// </summary>
    public interface ITextService
    {
        string GetStyle(ForegroundColorsEnum foregroundColor, BackgroundColorsEnum backgroundColor, bool isFontBold);
    }
}
