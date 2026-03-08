using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayMessagingForms;

public class VisionSystem
{
    private readonly LoggerService _logger;
    public event Action<double> OnDataCaptured;

    public VisionSystem(LoggerService logger)
    {
        _logger = logger;
    }

    public void Run(CancellationToken token)
    {
        Random rnd = new Random();
        try
        {
            while (!token.IsCancellationRequested)
            {
                double detectedPosMm = rnd.Next(50, 200) + rnd.NextDouble();
                _logger.Log($"Part detected at: {detectedPosMm:F2} mm", LogCategory.Camera);

                OnDataCaptured?.Invoke(detectedPosMm);

                Thread.Sleep(4000);
            }
        }
        catch (Exception) { /* Handle or log thread exit */ }
        finally
        {
            _logger.Log("Thread Gracefully Terminated", LogCategory.Camera);
        }
    }
}
