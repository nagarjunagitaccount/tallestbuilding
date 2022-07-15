using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TallestBuilding.Entities;

namespace TallestBuilding.Tests
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"https:\\www.skyscrapercenter.com/buildings?list=tallest100-construction");
        }

        [Test]
        public void VerifyTallestBuilding()
        {
            List<BuildingTableEntity> buildingTableEntity = new List<BuildingTableEntity>();

            IWebElement dropDownElement = driver.FindElement(By.Name("list"));

            SelectElement dropDownValue = new SelectElement(dropDownElement);
            dropDownValue.SelectByText("100 Tallest Completed Buildings in the World");


            IWebElement table = driver.FindElement(By.Id("buildingsTable"));

            List<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));

            var dataRows = rows.Skip(1).ToList();

            foreach(var row in dataRows)
            {
                List<IWebElement> columns = new List<IWebElement>(row.FindElements(By.TagName("td")));

                buildingTableEntity.Add(new BuildingTableEntity
                {
                    Rank = Convert.ToInt32(columns[0].Text),
                    Name = columns[1].Text,
                    City = columns[2].Text,
                    Status = columns[3].Text,
                    Completion = columns[4].Text,
                    Height = columns[5].Text,
                    Floors = columns[6].Text,
                    Materials = columns[7].Text,
                    Function = columns[8].Text
                });
            }
            //verify there are exactly 100 buildings in the list
            Assert.AreEqual(buildingTableEntity.Count, 100);

            //Verify that the Lotte World builing in Seoul has 123 floors
            Assert.AreEqual(buildingTableEntity.Where(p => p.Name == "Lotte World Tower" && p.Floors == "123").Count(), 1);

            //Give us the building with maximum number of floors
            var maxFloorBuilding = buildingTableEntity.Where(p => p.Floors != "N/A");

            var max = maxFloorBuilding.Max(p=>int.Parse(p.Floors));

            var maxFloorBuildingRecord = buildingTableEntity.Where(p => p.Floors == max.ToString());     

            Assert.Pass();
        }
        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }

    }
}