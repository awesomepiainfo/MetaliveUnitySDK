namespace Metalive.Map
{
    /// <summary>
    /// [None] = Content in preparation... 
    /// [Local] = Path -> Application.persistentDataPath
    /// [Label] = Addressable location(label)
    /// [Url] = User web hosting
    /// </summary>
    public enum MapLocation
    {
        None = 0,
        Local = 1,
        Label = 2,
        Url = 3
    }
}