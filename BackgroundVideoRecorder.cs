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
    class BackgroundVideoRecorder
    {
        public BackgroundWorker writer;
        public BackgroundWorker reader;
        public Video video;
        public Size screensize;
        public int fps;
        public int frameDelayMs;
        private Bitmap lastFrame;
        
        public BackgroundVideoRecorder(int fps)
        {
            this.fps = fps;
            this.frameDelayMs = 1000/fps;
            screensize = EggplantTestBase.Driver.GetScreenshot().Size;
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
            DiagnosticLog.WriteLine("Starting recording");
            reader.RunWorkerAsync();
            writer.RunWorkerAsync();
        }

        public void Stop()
        {
            DiagnosticLog.WriteLine("Video had " + video.FrameCount + " Frames");
            reader.CancelAsync();
            writer.CancelAsync();
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
            var newFrame = new Bitmap(EggplantTestBase.Driver.GetScreenshot());
            if (newFrame != null)
            {
                lastFrame = newFrame;
            }
        }

        private void WriteFrame()
        {
            if (lastFrame != null)
                video.AddFrame(new BitmapVideoFrame(lastFrame));

        }
    }
}
