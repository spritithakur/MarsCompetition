using Competition.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Competition.Global.GlobalDefinitions;

namespace Competition.Pages
{
    internal class ManageListings
    {
        #region Manage listing's page objects
        //ShareSkill Button
        private IWebElement btnShareSkill => driver.FindElement(By.LinkText("Share Skill"));

        //Manage Listings
        private IWebElement manageListingsLink => driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));

        //Message warning no listing
        private IWebElement warningMessage => driver.FindElement(By.XPath("//h3[contains(text(),'You do not have any service listings!')]"));

        //Title
        private IList<IWebElement> Titles => driver.FindElements(By.XPath("//div[@id='listing-management-section']//tbody/tr/td[3]"));

        //View button
        private IWebElement view => driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));

        //Edit button
        private IWebElement edit => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));

        //Yes/No button
        private IList<IWebElement> clickActionsButton => driver.FindElements(By.XPath("//div[@class='actions']/button"));

        //Save button
        private IWebElement btnSave => driver.FindElement(By.XPath("//input[@value='Save']"));
        #endregion
        ShareSkill shareSkillObj;

        internal void AddListing(int rowNumber, string worksheet)
        {
            //define the object of share skill page here to fetch the data 
            shareSkillObj = new ShareSkill();

            //click on the share skill button
            btnShareSkill.Click();

            //wait after driver clicks on the button
            wait(2);

            shareSkillObj.EnterShareSkill(rowNumber, worksheet);
            wait(2);

        }


        internal void GotoManageListings()
        {
            try
            {
                //Click on Manage listing
                manageListingsLink.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Manage listing link is not found", ex.Message);
            }

        }

       
        //Edit the created Listing on share skill page

        internal void EditListing(int rowNumber1, int rowNumber2, string worksheet)
        {
            shareSkillObj = new ShareSkill();


            //click on manageListing
            GotoManageListings();


            //wait after driver click on the edit action button on manage listing page
            wait(2);

            //getting the values of title and description before editing
            IWebElement titleofManage = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr/td[3]"));
            IWebElement descriptionofManage = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr/td[4]"));

            string TitleBeforeEdit = titleofManage.Text;
            string DescriptionBeforeEdit = descriptionofManage.Text;



            //click on the edit button
            IWebElement editBtn = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
            editBtn.Click();


            //create page object of share skill and call EnterShareSkill function 

            shareSkillObj.ClearData();
            wait(2);
            shareSkillObj.EnterShareSkill(rowNumber2, worksheet);
            wait(2);

            //Getting the values of title and description after editing 

            //for that, we need to go on manage listing page
            GotoManageListings();


            //wait until driver finds the manage lisitng page for us
            wait(2);

            IWebElement titleofManage1 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr/td[3]"));
            IWebElement descriptionofManage1 = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr/td[4]"));


            string TitleAfterEdit = titleofManage1.Text;
            string DescriptionAfterEdit = descriptionofManage1.Text;

            Console.WriteLine(TitleBeforeEdit);
            Console.WriteLine(TitleAfterEdit);
            Console.WriteLine(DescriptionBeforeEdit);
            Console.WriteLine(DescriptionAfterEdit);

            try
            {
                //Assert that text from Befor Edit and After Edit dose not have to match
                Assert.AreNotEqual(TitleBeforeEdit, TitleAfterEdit);
                Assert.AreNotEqual(DescriptionBeforeEdit, DescriptionAfterEdit);
                Console.WriteLine("pass");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fail");
            }
        }

        internal void ViewListing(int rowNumber, string worksheet)
        {
            //click on the manage list
            GotoManageListings();


            //wait until driver finds the view button
            wait(2);

            //click on thw view button

            IWebElement viewOption = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]/i"));
            viewOption.Click();

            //wait until driver opens the view listing page 
            wait(2);

        }


        internal void DeleteListing(int rowNumber, string worksheet)
        {

            //click on the manage list
            GotoManageListings();


            //wait until driver finds the delete button to click
            wait(2);

            //click on the delete button
            IWebElement btnDelete = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
            btnDelete.Click();

            //wait for the popup message to delete the listing
            IWebElement popUpMessage = driver.FindElement(By.XPath("/html/body/div[2]/div"));


            try
            {

                //Assert that popUp will open and has not to be null(or Emplty)
                Assert.NotNull(popUpMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //and then finally click on the yes action button to delete the listing
            IWebElement optionYes = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
            optionYes.Click();
            wait(2);
        }

        //Verify the delete listing

        internal void VerifyDeleteListing(int rowNumber, string worksheet)
        {
            GotoManageListings();

            wait(2);

            IWebElement displayMessage = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/h3"));

            try
            {
                Assert.IsNotNull("displayMessage");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fail");
            }


        }







    }
}

