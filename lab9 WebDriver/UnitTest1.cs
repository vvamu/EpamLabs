


using lab9_WebDriver.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static lab9_WebDriver.Tests;


namespace lab9_WebDriver;

public class Tests 
{
    private string pathToDriver = @"C:\\software\\drivers";
    private string _url = "https://pastebin.com";


    private Workspace workspace;
    private IWebDriver driver => Workspace.driver;
    private IWebElement findElementByXPath(string path) => workspace.findElementByXPath(path); //TODO


    private By btCreateNewPaste = By.XPath("//button[text()='Create New Paste']");
    private By msgError = By.XPath("//div[@class='error-summary']");




    private string codeValue = "Hello from WebDriver";
    private string titleValue = "helloweb";


    [SetUp]
    public void Setup() 
    {

        workspace = new Workspace(pathToDriver);
        workspace.OpenBrowserWithUrl(_url);

    }




    [Test]
    public void Test1()
    {
        Actions actions = new Actions(driver);
        var btPaste = driver.FindElement(btCreateNewPaste);

        actions.MoveToElement(btPaste);
        actions.Perform();

        /*----*/
        Thread.Sleep(1000);

        
        var selectExpiration = driver.FindElements(By.XPath(("//span[@id='select2-postform-expiration-container']"))).First();

        selectExpiration.Click();


        Thread.Sleep(1000);
        var selectExpirationValue = driver.FindElements(By.XPath(($"//li[text()='10 Minutes']"))).First();
        selectExpirationValue.Click();

        var selectInputTitle = driver.FindElement(By.XPath(("//input[@id='postform-name']"))); 
        selectInputTitle.SendKeys(titleValue);


        var selectInputCodeArea = driver.FindElement(By.XPath(("//textarea"))); 
        selectInputCodeArea.SendKeys(codeValue);



        actions.MoveToElement(btPaste);
        actions.Perform();
        btPaste.Click();
        Thread.Sleep(2000);


        //var errorMsg = driver.FindElement(msgError);

        var currentUrl = driver.Url;
        Assert.IsTrue(currentUrl != _url);
        //driver.Quit();




    }

    [TearDown]
    public void TearDown()
    {
        
    }
}