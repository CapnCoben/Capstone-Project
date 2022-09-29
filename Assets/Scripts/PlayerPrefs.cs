
using System;

public class PlayerPrefs 
{
    /// <summary>
    /// List of all keys saved on the user's device, be it for settings or selections.
    /// </summary>
    
    /// <summary>
	/// PlayerPrefs key for player name: UserXXXX
	/// </summary>
    public const string playerName = "IBR_playerName";

    /// <summary>
    /// PlayerPrefs key for background music state: true/false
    /// </summary>
    public const string playMusic = "IBR_playMusic";

    /// <summary>
    /// PlayerPrefs key for global audio volume: 0-1 range
    /// </summary>
    public const string appVolume = "IBR_appVolume";

    /// <summary>
    /// PlayerPrefs key for selected player model: 0/1/2 etc.
    /// </summary>
    public const string activeCharacter = "IBR_activeCharacter";

    internal static string GetString(string activeCharacter)
    {
        throw new NotImplementedException();
    }

    internal static void SetString(string activeCharacter)
    {
        throw new NotImplementedException();
    }
}
