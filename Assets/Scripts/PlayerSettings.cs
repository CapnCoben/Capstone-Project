
using System;

public class PlayerSettings
{
    /// <summary>
    /// List of all keys saved on the user's device, be it for settings or selections.
    /// </summary>
    
    /// <summary>
	/// PlayerPrefs key for player name: UserXXXX
	/// </summary>
    public string playerName;

    /// <summary>
    /// PlayerPrefs key for background music state: true/false
    /// </summary>
    public string playMusic;

    /// <summary>
    /// PlayerPrefs key for global audio volume: 0-1 range
    /// </summary>
    public float appVolume = 0.5f;

    /// <summary>
    /// PlayerPrefs key for selected player model: 0/1/2 etc.
    /// </summary>
    public string activeCharacter;


}
