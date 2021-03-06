﻿using System;
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
        private static void LogString(string message)
        {
            if (Config.LogStepsDiagnosticOutput)
            {
                if (Config.LogNightshadeCommands)
                {
                    DiagnosticLog.WriteLine(message);
                }
                
            }
            if (Config.LogStepsTestReport)
            {
                if (Config.LogNightshadeCommands)
                {
                    TestLog.WriteLine(message);
                }                 
            }
        }

        private static void LogError(string message)
        {
            //if (Config.LogStepsDiagnosticOutput)
            //{
                DiagnosticLog.WriteLine(message);
            //}
            //if (Config.LogStepsTestReport)
            //{
                TestLog.WriteHighlighted(message + "\r\n");
            //}
        }

        public static void SystemState(string message)
        {
            message = string.Format(">>> {0}", message);

            if (Config.LogStepsDiagnosticOutput)
            {
                if (Config.LogSystemState)
                {
                    DiagnosticLog.WriteLine(message);
                }
            }
            if (Config.LogStepsTestReport)
            {
                if (Config.LogSystemState)
                {
                    TestLog.WriteLine(message);
                }
            }
        }
        
        public static void Info(string message)
        {
            message = string.Format("|   {0}", message);

            if (Config.LogStepsDiagnosticOutput)
            {
                if (Config.LogInfoMessages)
                {
                    DiagnosticLog.WriteLine(message);
                }
            }
            if (Config.LogStepsTestReport)
            {
                if (Config.LogInfoMessages)
                {
                    TestLog.WriteLine(message);
                }
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
