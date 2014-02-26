using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        public BackgroundWorker bgWorker;
        public Video video;
        public Size screensize;
        public int fps;
        public int frameDelayMs;
        
        public BackgroundVideoRecorder(int fps)
        {
            this.fps = fps;
            this.frameDelayMs = 1000/fps;
            screensize = EggplantTestBase.Driver.GetScreenshot().Size;
            video = new FlashScreenVideo(new FlashScreenVideoParameters(screensize.Width, screensize.Height, fps));
           bgWorker = new BackgroundWorker();
           bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.RunWorkerAsync();
        }

        void stop()
        {
            bgWorker.CancelAsync();
        }

        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgWorker.CancellationPending)
            {
                video.AddFrame(new BitmapVideoFrame(new Bitmap(EggplantTestBase.Driver.GetScreenshot())));

                Thread.Sleep(frameDelayMs);    
            }
            
        }
    }
}
