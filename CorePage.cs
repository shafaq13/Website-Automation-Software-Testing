using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace STProject_21K3198_21K3178_21K3401
{
    public class CorePage
    {
        #region Properties
        public static string pathWithFileNameExecution;
        public static string dirpath;

        public static ExtentReports extentReports;
        public static ExtentTest Test;
        public static ExtentTest Step;
        #endregion

        public static IWebDriver driver;

        public static void SeleniumInit(string browser)
        {
            if (browser == "Chrome")
            {
                IWebDriver chromeDriver = new ChromeDriver();
                driver = chromeDriver;
            }
        }

        public static void CreateReport(string path)
        {
            extentReports = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(path);
            extentReports.AttachReporter(sparkReporter);
        }

        public static void TakeScreenshot(Status status,string StepDetail)
        {
            string path = @"C:\Users\dell\source\repos\STProject_21K3198_21K3178_21K3401\ExtentReport\images\" + DateTime.Now.ToString("yyyyMMddHHmmss"+".png");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);

            Step.Log(status,StepDetail,MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
        }

    }
}
