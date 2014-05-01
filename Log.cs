using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Gallio.Common.Markup;
using Gallio.Framework;

namespace ProtoTest.Nightshade
{
    public static class Log
    {
        private static bool diagnosticMessages = Config.DiagnosticMessages;
        private static bool logMessages = Config.LogMessages;

        private static void LogString(string message)
        {
            if (diagnosticMessages)
            {
                DiagnosticLog.WriteLine(message);
            }
            if (logMessages)
            {
                TestLog.WriteLine(message);
            }
        }

        private static void LogError(string message)
        {
            if (diagnosticMessages)
            {
                DiagnosticLog.WriteLine(message);
            }
            if (logMessages)
            {
                TestLog.WriteHighlighted(message + "\r\n");
            }
        }

        public static void Message(string message)
        {
            LogString(message);
        }

        public static void Failure(string message)
        {
            TestLog.Failures.WriteLine(message);
        }

        public static void Warning(string message)
        {
            TestLog.Warnings.WriteLine(message);
        }

        public static void Message(string message, Image image)
        {
            TestLog.BeginSection("");
            Log.Message(message);
            if(image!=null)
                TestLog.EmbedImage(null,image);
            TestLog.End();
        }

        public static void Failure(string message, Image image)
        {
            LogError(message);
            TestLog.Failures.BeginSection("");
            TestLog.Failures.WriteLine(message);
            if (image != null)
                TestLog.Failures.EmbedImage(null, image);
            TestLog.Failures.End();
        }

        public static void Warning(string message, Image image)
        {
            LogError(message);
            TestLog.Warnings.BeginSection("");
            TestLog.Warnings.WriteLine(message);
            if (image != null)
                TestLog.Warnings.EmbedImage(null, image);
            TestLog.Warnings.End();
        }
    }
}
