using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Gallio.Common.Media;
using Gallio.Framework;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    class BackgroundVideoRecorder : IDisposable
    {
        public static string ScreenshotDirectory = Directory.GetCurrentDirectory() + "\\Screenshots";
        public BackgroundWorker writer;
        public BackgroundWorker reader;
        public Video video;
        public Size screensize;
        public int fps;
        public int frameDelayMs;
        private Bitmap lastFrame;
        
        public BackgroundVideoRecorder(int fps)
        {
            ClearScreenshots();
            this.fps = fps;
            this.frameDelayMs = 1000/fps;
            var image = EggplantTestBase.Driver.GetScreenshot();
            screensize = image.Size;
            video = new FlashScreenVideo(new FlashScreenVideoParameters(screensize.Width, screensize.Height, fps));
            reader = new BackgroundWorker();
            reader.DoWork += ReaderDoWork;
            writer = new BackgroundWorker();
            writer.DoWork += writer_DoWork;
            reader.WorkerSupportsCancellation = true;
            writer.WorkerSupportsCancellation = true;  
            
        }




        public void Start()
        {
            ClearScreenshots();
            EggplantTestBase.Log("Starting recording");
            reader.RunWorkerAsync();
            writer.RunWorkerAsync();
        }

        private void ClearScreenshots()
        {
            if(Directory.Exists(ScreenshotDirectory))
                Directory.Delete(ScreenshotDirectory,true);
            Directory.CreateDirectory(ScreenshotDirectory);
        }

        public void Stop()
        {
            DiagnosticLog.WriteLine("Video had " + video.FrameCount + " Frames");
            reader.CancelAsync();
            writer.CancelAsync();
            reader.Dispose();
            writer.Dispose();
        }

        void ReaderDoWork(object sender, DoWorkEventArgs e)
        {
            while (!reader.CancellationPending)
            {
                ReadFrame();
                Thread.Sleep(frameDelayMs);    
            }
           
        }

        void writer_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!writer.CancellationPending)
            {
                WriteFrame();
                Thread.Sleep(frameDelayMs);
            }
        }

        private void ReadFrame()
        {
            var newFrame = new Bitmap(EggplantTestBase.Driver.GetScreenshot(string.Format("{0}\\Screenshot_{1}.png", ScreenshotDirectory, DateTime.Now.ToString("FFFF"))));
            if (newFrame != null)
            {
                   lastFrame = newFrame;
            }
        }

        private void WriteFrame()
        {
            if (lastFrame != null)
            {
                 video.AddFrame(new BitmapVideoFrame(lastFrame));
            }
              

        }

        public void Dispose()
        {
            lastFrame = null;
            reader.Dispose();
            writer.Dispose();
        }
    }
}
