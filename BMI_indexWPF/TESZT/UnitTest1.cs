using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace TESZT
{
    public class Tests
    { 
     protected const string windowsApplicationDriverURL = "http://127.0.0.1:4723";
    private const string WPFprogramID = @"C:\Users\fullstack\source\repos\BMI_indexWPF\BMI_indexWPF\bin\Debug\BMI_indexWPF.exe";
    private const string WPFprogramPath = @"C:\Users\fullstack\source\repos\BMI_indexWPF\BMI_indexWPF\bin\Debug";

    protected static WindowsDriver<WindowsElement> driver;
    protected static ExtentReports extReport;
    protected static ExtentTest extTest;

    [OneTimeSetUp]
    public static void Setup()
    {
        if (driver == null)
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", WPFprogramID);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
            driver = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverURL), appiumOptions);
        }

    }

    [OneTimeSetUp]
    public static void ReportSetup()
    {
        extReport = new ExtentReports();
        var htmlReporter = new ExtentHtmlReporter(@"C:\Users\fullstack\source\repos\BMI_indexWPF\BMI_indexWPF\bin\Debug\report.html");
        extReport.AddSystemInfo("BMI számítás teszt", "BMI számítás automatizált teszt");
        extReport.AddSystemInfo("Tesztelõ", "Laci");
        extReport.AttachReporter(htmlReporter);
        htmlReporter.Config.DocumentTitle = "HTML teszt riport";
        htmlReporter.Config.ReportName = "BMI számítás teszt";
        htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;


    }

        //  Nem- és ideális testsúly tesztelése folyamatban
        //  Egyelõre testsúly, magasság, illetve az eredmény tesztelése lehetséges
    [Test]
    [TestCase(75,188,21.22, "Normális testsúly")]
    [TestCase(52, 171, 17.78,"Enyhe soványság")]

        public void Test1(double testsulyPar, double magassagPar, double elvartPar, string elvartErtekeles)
    {
        extTest = extReport.CreateTest("BMIindex teszt");

        //var gender = driver.FindElementByAccessibilityId("gender");
        //gender.Clear();
        var testsuly = driver.FindElementByAccessibilityId("TestSuly");
        testsuly.Clear();
        var magassag= driver.FindElementByAccessibilityId("TestMagassag");
        magassag.Clear();


        //gender.SendKeys(genderPar);
        testsuly.SendKeys(testsulyPar.ToString());
        magassag.SendKeys(magassagPar.ToString());

        driver.FindElementByAccessibilityId("BMIszamol").Click();

        var eredmeny = driver.FindElementByAccessibilityId("sulyEredmeny");
        var ertekeles = driver.FindElementByAccessibilityId("ertekelesEredmeny");


        Assert.AreEqual(Math.Round(elvartPar,2), Convert.ToDouble(eredmeny.Text));
        Assert.AreEqual(elvartErtekeles, ertekeles.Text);
        extTest.Log(Status.Pass, "Számítás teszt rendben");
    }

    [TearDown]
    public static void CloseReport()
    {
        //var genderPar = TestContext.CurrentContext.Test.Arguments.GetValue(0);
        var testsulyPar = TestContext.CurrentContext.Test.Arguments.GetValue(0);
        var magassagPar = TestContext.CurrentContext.Test.Arguments.GetValue(1);
        var elvartPar = TestContext.CurrentContext.Test.Arguments.GetValue(2);
        //   + genderPar + "_"
        var filename = "error_" + testsulyPar + "kg_" + magassagPar + "cm_" + elvartPar + ".png";
        var Status = TestContext.CurrentContext.Result.Outcome.Status;
        var stackTrace = TestContext.CurrentContext.Result.StackTrace;
        var errorMessage = TestContext.CurrentContext.Result.Message;


        if (Status == TestStatus.Failed)
        {
            ITakesScreenshot shot = (ITakesScreenshot)driver;
            Screenshot screenshot = shot.GetScreenshot();
            screenshot.SaveAsFile(WPFprogramPath + filename, ScreenshotImageFormat.Png);
            //extTest.Log(Status.Fail, stackTrace + errorMessage);
            //extTest.Log(Status.Fail, "Képernyõ");
            extTest.AddScreenCaptureFromPath("ErrPng.png");
        }

    }


    [OneTimeTearDown]
    public void Endtest()
    {
        driver.Close();
        driver.Quit();
        extReport.Flush();
    }
}
}