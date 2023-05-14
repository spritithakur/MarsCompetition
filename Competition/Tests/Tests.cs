using Competition.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Competition.Global.GlobalDefinitions;
using static Competition.Pages.ShareSkill;

namespace Competition.Tests
{

    [TestFixture]
    [Parallelizable]

    internal class Tests : Global.Base
    {

        ManageListings manageListingsObj;
        ShareSkill shareSkillObj;

        public Tests()
        {
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
        }

        [Test, Order(1), Description("Enter skills in Share Skill page")]

        public void EnterShareSkill()
        {
            try
            {

            
            test = extent.CreateTest("Enter Share Skill Test Passed");
                //page object for ShareSkill page
                manageListingsObj.AddListing(2, "ManageListings");
                wait(2);
              
            }
            catch(NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
}




        [Test, Order(2), Description("Listing is created")]

        public void ViewListing()
        {
            try
            {


                test = extent.CreateTest("View Share Skill Test Passed");
                //page object for ShareSkill page
                manageListingsObj.ViewListing(2, "ManageListings");
               // VerifyListingDetails(2, "ManageListings");
                wait(2);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }


        [Test, Order(3), Description("Edit skills in Share Skill page")]

        public void EditShareSkill()
        {
            try
            {


                test = extent.CreateTest("Edit Share Skill Test Passed");
                //page object for Manage listing page
                manageListingsObj.EditListing(2, 3, "ManageListings");
                wait(2);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }



        [Test, Order(4), Description("view the edited information in Manage Listings page")]

        public void EditedShareSkill()
        {
            try
            {


                test = extent.CreateTest("Edited Share Skill Test Passed in Managed Listing");
                //page object for Manage listing page

                manageListingsObj.ViewListing(3, "ManageListings");
               // VerifyListingDetails(3, "ManageListings");
                wait(2);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }




        [Test, Order(5), Description("delete the edited listing on manage listing page")]

        public void DeleteShareSkill()
        {
            try
            {


                test = extent.CreateTest("Delete the share skill listing");
                //page object for Manage listing page
                manageListingsObj.DeleteListing(3, "ManageListings");
                wait(2);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }


        [Test, Order(6), Description("listing would be deleted")]

        public void VerifyDeleteListing()
        {
            try
            {


                test = extent.CreateTest("View the deleted listing");
              
                //page object for Manage listing page
                 manageListingsObj.VerifyDeleteListing(3, "ManageListings");
              
                wait(2);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }




       

      

    }

    }



