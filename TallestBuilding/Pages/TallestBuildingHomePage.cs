using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Interactions;

namespace TallestBuilding.PageObjects
{
    public class TallestBuildingHomePage
    {
        private IWebDriver driver;

        //[FindsBy]
        public IWebElement buildingDropdown { get; set; }

        public TallestBuildingHomePage(IWebDriver driver)
        {
            this.driver = driver; 
            
        }
    }
}
