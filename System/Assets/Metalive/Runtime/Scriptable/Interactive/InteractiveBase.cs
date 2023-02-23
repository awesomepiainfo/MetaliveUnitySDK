/*
 * Day : 2023-02-23
 * Writer : phantom(chho1365@gmail.com)
 */

namespace Metalive
{ 

    /// <summary>
    /// [None] = Content in preparation... 
    /// [Local] = Path -> Application.persistentDataPath
    /// [Label] = Addressable location(label)
    /// [Url] = User web hosting
    /// </summary>
    public enum InteractiveLocation
    {
        None = 0,
        Local = 1,
        Label = 2,
        Url = 3
    }

    public enum InteractiveMode
    {
        None = 0,
        Animation = 1,
        Gallery = 2,
        Telescope = 3,
        Market = 4,
        Npc = 5,
        Riding = 6,
        Midea = 7,
    }
}