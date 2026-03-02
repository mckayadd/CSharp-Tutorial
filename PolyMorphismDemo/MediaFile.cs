public class MediaFile
{
    public string FileName {get; set; } = string.Empty;
    public double Duration { get; set; }


    public virtual void Play() => System.Console.WriteLine($"Playing {FileName}");
    public virtual void Pause() => System.Console.WriteLine($"Pausing {FileName}");
    public virtual void Stop() => System.Console.WriteLine($"Stopping {FileName}");
}