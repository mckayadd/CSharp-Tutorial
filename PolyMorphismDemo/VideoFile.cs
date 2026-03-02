public class VideoFile : MediaFile
{
    public string Resolution { get; set; } = string.Empty;
    public double FrameRate { get; set; } 

    public override void Play()
    {
        System.Console.WriteLine($"Playing video: {FileName} ({Resolution}@{FrameRate}fps)");
        System.Console.WriteLine("Initializing decoder and syncing audio...");
    }

    public override void Pause() => System.Console.WriteLine($"Video paused: {FileName}");

    public override void Stop() => System.Console.WriteLine($"Video stopped: {FileName}");
}