public class AudioFile : MediaFile
{
    public string Artist { get; set; } = string.Empty;
    public string Album { get; set; } = string.Empty;

    public override void Play()
    {
        System.Console.WriteLine($"Playing audio: {FileName} by {Artist}");
        System.Console.WriteLine("Initializing audio codec...");
    }

    public override void Pause() => System.Console.WriteLine($"Audio paused: {FileName}");

    public override void Stop()
    {
        System.Console.WriteLine($"Audio stopped: {FileName}");
        System.Console.WriteLine("Audio codec released");
    }
}