
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static lab9_WebDriver.Tests;


namespace lab9_WebDriver;


public class HurtMePlenty : TestsClass
{
    protected override string? Url => "https://cloud.google.com/";


    private By btSearchx = By.XPath("//button[@class='devsite-search-button devsite-header-icon-button button-flat material-icons']");
    private By inputSeacrhBox = By.XPath("//input[@placeholder='Search']");

    private By linkToCalculatorPage = By.XPath("//a[@data-ctorig='https://cloud.google.com/products/calculator']");


    private By chapterComputerEngine = By.XPath("//div[@title='Compute Engine']");
    private string searchValue = "Google Cloud Platform Pricing Calculator";






    [Test]
    public void Test1()
    {
        var btSearch = findElement(btSearchx);
        ClickToElement(btSearch);

        findElement(inputSeacrhBox).SendKeys(searchValue);
        findElement(inputSeacrhBox).SendKeys(Keys.Enter);
        Thread.Sleep(5000);
        findElement(linkToCalculatorPage).Click();
        Thread.Sleep(5000);
        //findElement(chapterComputerEngine).Click(); //


       
        var element = findElement(By.XPath("//iframe[contains(@name,'goog_')]"));
        driver.SwitchTo().Frame(element);
        driver.SwitchTo().Frame("myFrame");
        var numberOfInstancesField = findElement(By.XPath("//md-input-container/child::input[@ng-model='listingCtrl.computeServer.quantity']"));
        numberOfInstancesField.SendKeys("4");
        Thread.Sleep(2000);
        var Series = findElement(By.XPath("//*[@id=\"select_value_label_85\"]"));
        Series.Click();
        Thread.Sleep(2000);
        findElement(By.XPath("//md-option[@id='select_option_201']")).Click();
        Thread.Sleep(2000);
        var Machine_Family = findElement(By.XPath("//*[@id=\"select_value_label_86\"]"));
        Machine_Family.Click();
        Thread.Sleep(2000);
        findElement(By.XPath("//md-option[@value='CP-COMPUTEENGINE-VMIMAGE-N1-STANDARD-8']")).Click();

        Thread.Sleep(2000);
        findElement(By.XPath("//md-checkbox[@aria-label='Add GPUs']")).Click();
        Thread.Sleep(2000);
        findElement(By.XPath("//md-select[@placeholder='GPU type']")).Click();
        findElement(By.XPath("//md-option[@id='select_option_474']")).Click();

        Thread.Sleep(2000);
        findElement(By.XPath("//md-select[@placeholder='Number of GPUs']")).Click();
        findElement(By.XPath("//md-option[@id='select_option_477']")).Click();
        Thread.Sleep(2000);
        findElement(By.XPath("//md-select[@placeholder='Local SSD']")).Click();
        findElement(By.XPath("//md-option[@id='select_option_450']")).Click();
        findElement(By.XPath("//md-option[@id='select_option_450']")).SendKeys(Keys.Enter);

        //findElement(By.XPath("//md-select[@placeholder='Datacenter location']")).Click();
        // findElement(By.XPath("//md-option[@id='select_option_229']")).Click();

        //
        findElement(By.XPath("//md-select[@placeholder='Committed usage']")).Click();
        findElement(By.XPath("//md-option[@id='select_option_128']")).Click();

        findElement(By.XPath("//button[@aria-label='Add to Estimate']")).Click();


        //check

    }

    //public void InsertValues()
    //{
    //    DefineInsertValues();

    //    foreach (var item in inputValues)
    //    {
    //        findElement(item.Value).SendKeys(item.Key);
    //    }
    //}

    //public void DefineInsertValues()
    //{
    //    var valueNumberOfInstance = "4";
    //    var NumberOfInstance = By.XPath("//input[@class='md-input ng-valid-min ng-not-empty ng-dirty ng-valid-number ng-valid ng-valid-required ng-touched']");


    //    inputValues = new Dictionary<string, By>();
    //    inputValues.Add(valueNumberOfInstance, NumberOfInstance);
    //}
}