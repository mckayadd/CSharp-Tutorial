class Program
{
    static void Main(string[] args)
    {
        MediaFile[] playlist =
        {
            new AudioFile {FileName="song.mp3", Artist="Jazz Ensemble", Album="Live Sessions"},
            new VideoFile { FileName="movie.mp4", Resolution="1920x1080", FrameRate=60 }
        };

        System.Console.WriteLine("=== Media Player Demo ===");

        foreach(MediaFile media in playlist)
        {
            System.Console.WriteLine($"Processing: {media.FileName}");
            media.Play();
            Thread.Sleep(500);
            media.Pause();
            Thread.Sleep(250);
            media.Stop();
            System.Console.WriteLine();
        }
    }
}