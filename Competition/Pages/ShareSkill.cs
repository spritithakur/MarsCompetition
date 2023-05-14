using OpenQA.Selenium;
using Competition.Global;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static Competition.Global.GlobalDefinitions;

using AventStack.ExtentReports.Model;


namespace Competition.Pages
{
    public class ShareSkill
    {
        #region Page Objects for EnterShareSkill
        //Click on the share skill button




        private IWebElement btnShareSkill => driver.FindElement(By.LinkText("Share Skill"));


        //Title textbox
        private IWebElement Title => driver.FindElement(By.Name("title"));

        //Description textbox
        private IWebElement Description => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));

        //Category Dropdown
        private IWebElement CategoryDropDown => driver.FindElement(By.Name("categoryId"));

        //SubCategory Dropdown
        private IWebElement SubCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Tag names textbox
        private IWebElement Tags => driver.FindElement(By.XPath("//form[@class='ui form']/div[4]/div[2]/div/div/div/div/input"));

        //Entered displayed Tags
        private IList<IWebElement> displayedTags => driver.FindElements(By.XPath("//form[@class='ui form']/div[4]/div[2]/div/div/div/span/a"));
        //form[@class='ui form']/div[4]/div[2]/div/div/div/span/a

        //Service type radio button
        private IList<IWebElement> radioServiceType => driver.FindElements(By.Name("serviceType"));

        //Location Type radio button
        private IList<IWebElement> radioLocationType => driver.FindElements(By.Name("locationType"));

        //Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.Name("startDate"));

        //End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.Name("endDate"));

        //Available days
        private IList<IWebElement> AvailableDays => driver.FindElements(By.XPath("//input[@name='Available']"));

        //Starttime
        private IList<IWebElement> StartTime => driver.FindElements(By.Name("StartTime"));

        //EndTime
        private IList<IWebElement> EndTime => driver.FindElements(By.Name("EndTime"));


        //StartTime dropdown
        private IWebElement StartTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //EndTime dropdown
        private IWebElement EndTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));

        //Skill Trade option
        private IList<IWebElement> radioSkillTrade => driver.FindElements(By.Name("skillTrades"));

        //Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@type='text']"));
        private IList<IWebElement> skillExchangeTags => driver.FindElements(By.XPath("//form[@class='ui form']/div[8]/div[4]/div/div/div/div/span/a"));


        //Credit textbox
        private IWebElement CreditAmount => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[4]/div/div/input"));

        //Work Samples button
        private IWebElement btnWorkSamples => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

        //Active option
        private IList<IWebElement> radioActive => driver.FindElements(By.XPath("//input[@name='isActive']"));

        //Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));
        #endregion

        #region Page Objects for VerifyShareSkill
        //Title
        private IWebElement actualTitle => driver.FindElement(By.XPath("//span[@class='skill-title']"));

        //Description
        private IWebElement actualDescription => driver.FindElement(By.XPath("//div[text()='Description']//following-sibling::div"));


        //Category
        private IWebElement actualCategory => driver.FindElement(By.XPath("//div[text()='Category']//following-sibling::div"));

        //Subcategory
        private IWebElement actualSubcategory => driver.FindElement(By.XPath("//div[text()='Subcategory']//following-sibling::div"));

        //Service Type
        private IWebElement actualServiceType => driver.FindElement(By.XPath("//div[text()='Service Type']//following-sibling::div"));

        //Start Date
        private IWebElement actualStartDate => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));

        private IWebElement actualStartDate1 => driver.FindElement(By.XPath("//div[text()='Start Date']//following-sibling::div"));


        // ("//div[text()='Start Date']//following-sibling::div"));;


        //End Date
        private IWebElement actualEndDate => driver.FindElement(By.XPath("html/body/div/div/div[1]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));

        private IWebElement actualEndDate1 => driver.FindElement(By.XPath("//div[text()='End Date']//following-sibling::div"));


        // ("//div[text()='End Date']//following-sibling::div "));


        //Location Type
        private IWebElement actualLocationType => driver.FindElement(By.XPath("//div[text()='Location Type']//following-sibling::div"));

        //Skill Trade
        private IWebElement actualSkillsTrade => driver.FindElement(By.XPath("//div[text()='Skills Trade']//following-sibling::div"));

        //Skill Exchange
        private IWebElement actualSkillExchange => driver.FindElement(By.XPath("//div[text()='Skills Trade']//following-sibling::div/span"));

        //Credit Amount

        private IWebElement actualCreditAmount => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[4]/div/div/input"));
        #endregion

        #region Page Objects for error Messages

        //Title message
        private IWebElement errorTitle => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div"));

        //Description message
        private IWebElement errorDescription => driver.FindElement(By.XPath("//div[@class='tooltip-target ui grid']//div/div[2]/div[2]/div"));

        //Category message
        private IWebElement errorCategory => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div[2]"));

        //Subcategory message
        private IWebElement errorSubcategory => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[2]/div"));

        //Tags message
        private IWebElement errorTags => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div[2]"));

        //StartDate message
        private IWebElement errorStartDate1 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div[2]"));

        //StartDate mesage 2
        private IWebElement errorStartDate2 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div[3]"));

        //Skill-Exchange tag
        private IWebElement errorSkillExchangeTags => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div[2]"));

        //Message
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private string e_message = "//div[@class='ns-box-inner']";


        #endregion

  

            public void EnterShareSkill(int rowNumber, string worksheet)
        {

            Listing excelData = new Listing();
            GetExcel(rowNumber, worksheet, out excelData);

            #region   
            //Enter the valueof title
            Title.SendKeys(excelData.title);
            excelData.title = ExcelLib.ReadData(rowNumber, "Title");
            #endregion

       

            #region
            //Enter the value of Description
            Description.SendKeys(excelData.description);
            excelData.description = ExcelLib.ReadData(rowNumber, "Description");
            #endregion

            #region
            //Select the value for category
            var selectCategory = new SelectElement(CategoryDropDown);
            selectCategory.SelectByText(excelData.category);
            excelData.category = ExcelLib.ReadData(rowNumber, "Category");
            #endregion

            #region
            //Select the value for sub category
            var selectSubCategory = new SelectElement(SubCategoryDropDown);
            selectSubCategory.SelectByText(excelData.subcategory);
            excelData.subcategory = ExcelLib.ReadData(rowNumber, "Sub-category");
            #endregion

            #region
            //enter the tag value
            Tags.SendKeys(excelData.tags + Keys.Return);
            excelData.tags = ExcelLib.ReadData(rowNumber, "Tags");
            #endregion

            #region
            //Select radio button for the Service Type
            SelectServiceType(excelData.serviceType);
            excelData.serviceType = ExcelLib.ReadData(rowNumber, "Service type");
            #endregion

            #region
            //Select radio button for the Location type
            SelectLocationType(excelData.locationType);
            excelData.locationType = ExcelLib.ReadData(rowNumber, "Location type");
            #endregion

            #region
            //Enter Start date
            StartDateDropDown.SendKeys(excelData.startDate);
            excelData.startDate = ExcelLib.ReadData(rowNumber, "Start date");
            #endregion

            #region
            //Enter End Date
            EndDateDropDown.SendKeys(excelData.endDate);

            for (int i = 2; i < 9; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    IWebElement SatrtTime = driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
                    IWebElement EndTime = driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
                    if (i == 2 && j == 2)
                    {
                        SatrtTime.SendKeys(excelData.startTime);
                        EndTime.SendKeys(excelData.endTime);
                    }
                    if (i == 3 && j == 3)
                    {
                        SatrtTime.SendKeys(excelData.startTime);
                        EndTime.SendKeys(excelData.endTime);
                    }
                    if (i == 4 && j == 4)
                    {
                        SatrtTime.SendKeys(excelData.startTime);
                        EndTime.SendKeys(excelData.endTime);
                    }
                    if (i == 5 && j == 5)
                    {
                        SatrtTime.SendKeys(excelData.startTime);
                        EndTime.SendKeys(excelData.endTime);
                    }
                    if (i == 6 && j == 6)
                    {
                        SatrtTime.SendKeys(excelData.startTime);
                        EndTime.SendKeys(excelData.endTime);
                    }
                    if (i == 7 && j == 7)
                    {
                        SatrtTime.SendKeys(excelData.startTime);
                        EndTime.SendKeys(excelData.endTime);
                    }
                    if (i == 8 && j == 8)
                    {
                        SatrtTime.SendKeys(excelData.startTime);
                        EndTime.SendKeys(excelData.endTime);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            excelData.endDate = ExcelLib.ReadData(rowNumber, "end date");
            #endregion

            #region
            //Select radio button for the Skill trade
            SelectSkillTrade(excelData.skillTrade, excelData.skillExchange, excelData.credit);
            excelData.skillTrade = ExcelLib.ReadData(rowNumber, "Skill trade");
            #endregion


            //Click Button upload work sample
            UploadWorkSamples();
            Thread.Sleep(5000);

            #region
            //Click Active or Hidden option
            ClickActiveOption(excelData.ActiveOption);
            excelData.ActiveOption = ExcelLib.ReadData(rowNumber, "active");
            #endregion

            #region
            // Click on save button for share skill
            Save.Click();
            excelData.isClickSaveFirst = ExcelLib.ReadData(rowNumber, "is click Save first");
            #endregion

            #region
            excelData.startTime = ExcelLib.ReadData(rowNumber, "start time");
            #endregion

            #region
            excelData.endTime = ExcelLib.ReadData(rowNumber, "end time");
            #endregion

            #region
            excelData.skillExchange = ExcelLib.ReadData(rowNumber, "skill-exchange");
            #endregion

            #region
            excelData.credit = ExcelLib.ReadData(rowNumber, "credit amount");
            #endregion

        }

    


        //Pass value for the radio button of specific elements Service type, location and skill trade

        #region Sub-methods for EnterShareSkill

        // to Select radio button for the Service Type

        internal void SelectServiceType(string serviveTypeText)

        {
            if (serviveTypeText.Equals(radioServiceType[0].GetAttribute("One-off service")))
            {

                radioServiceType[0].Click();

            }

            else if (serviveTypeText.Equals(radioServiceType[1].GetAttribute("Hourly basis service")))
            {
                radioServiceType[1].Click();
            }

        }

        // to Select radio button for the Location Type

        internal void SelectLocationType(string locationTypeText)
        {
            if (locationTypeText.Equals(radioLocationType[0].GetAttribute("On-site")))
            {
                radioLocationType[0].Click();
            }

            else if (locationTypeText.Equals(radioLocationType[1].GetAttribute("Online")))
            {
                radioLocationType[1].Click();
            }

        }

        // to select radio  button for the skill trade option
        internal void SelectSkillTrade(string skillTradeText, string skillExchangeText, string credittext)
        {
            string elementValue = "true";

            if (skillTradeText.Equals("Credit"))

                elementValue = "false";

            for (int i = 0; i < radioSkillTrade.Count; i++)
            {
                string actualElementValue = radioSkillTrade[i].GetAttribute("value");
                if (actualElementValue.Equals(elementValue))
                {
                    radioSkillTrade[i].Click();
                    wait(1);

                    if (skillTradeText.Equals("Skill-exchange"))
                    {
                        SkillExchange.Click();
                        SkillExchange.SendKeys(skillExchangeText);
                        SkillExchange.SendKeys(Keys.Return);
                    }
                    else
                    {
                        CreditAmount.Click();

                        CreditAmount.SendKeys(credittext);
                    }
                }

            }
        }

        

        //Upload work samples
        internal void UploadWorkSamples()
        {
            btnWorkSamples.Click();
            Thread.Sleep(3000);




            //Run Auto-IT script to execute file uploading

            using (Process exeProcess = Process.Start(Base.AutoScriptPath))
            {
                exeProcess.WaitForExit();
            }

        }


        // Choose the radio button Active or Hidden

        internal void ClickActiveOption(string ActiveOptionText)
        {
            if (ActiveOptionText.Equals(radioLocationType[0].GetAttribute("Active")))
            {
                radioLocationType[0].Click();
            }

            else if (ActiveOptionText.Equals(radioLocationType[1].GetAttribute("Hidden")))
            {
                radioLocationType[1].Click();
            }

        }
        internal string GetSkillTrade(string skillTardeOption)
        {
            if (skillTardeOption == "Credit")
                return actualSkillsTrade.Text;
            else
                return actualSkillsTrade.Text;
        }

       

        #endregion

        // Now, for Editing the share listing skills values
        internal void ClearData()
        {
            //clear the title textbox
            
            Title.SendKeys(Keys.Control + "a" + Keys.Delete);

            //Clear the Description textbox

            Description.SendKeys(Keys.Control + "a" + Keys.Delete);

            //clear the tags 

            Tags.Click();
            Tags.SendKeys(Keys.Backspace);

            //clear the start date

            actualStartDate.Click();
            actualStartDate.SendKeys(Keys.Delete + Keys.Tab + Keys.Delete + Keys.Tab + Keys.Delete);

            //clear the end date

            actualEndDate.Click();
            actualEndDate.SendKeys(Keys.Delete + Keys.Tab + Keys.Delete + Keys.Tab + Keys.Delete);


            //clear the start time
            StartTime[0].SendKeys(Keys.Delete);
            StartTime[1].SendKeys(Keys.Delete);
            StartTime[2].SendKeys(Keys.Delete);
            StartTime[3].SendKeys(Keys.Delete);
            StartTime[4].SendKeys(Keys.Delete);
            StartTime[5].SendKeys(Keys.Delete);
            StartTime[6].SendKeys(Keys.Delete);


            //clear the end time
            EndTime[0].SendKeys(Keys.Delete);
            EndTime[1].SendKeys(Keys.Delete);
            EndTime[2].SendKeys(Keys.Delete);
            EndTime[3].SendKeys(Keys.Delete);
            EndTime[4].SendKeys(Keys.Delete);
            EndTime[5].SendKeys(Keys.Delete);
            EndTime[6].SendKeys(Keys.Delete);

            wait(2);



            // clear the skill trade option

          

            if (radioSkillTrade[0].Selected == true)
            {
                skillExchangeTags[0].Click();
            }
            else if (radioSkillTrade[1].Selected == true)
            {
                CreditAmount.Click();
                CreditAmount.Clear();
            }
        }
    


           




       #region struct and sub-method for assertions
        internal struct Listing
        {
            public string title;
            public string description;
            public string category;
            public string subcategory;
            public string startDate;
            public string endDate;
            public string serviceType;
            public string locationType;
            public string skillTrade;
            public string skillExchange;
            public string tags;
            public string availableDays;
            public string startTime;
            public string endTime;
            public string credit;
            public string ActiveOption;
            public string isClickSaveFirst;

        }


        internal void GetExcel(int rowNumber, string worksheet, out Listing excelData)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);


            excelData.title = ExcelLib.ReadData(rowNumber, "Title");
            excelData.description = ExcelLib.ReadData(rowNumber, "Description");
            excelData.category = ExcelLib.ReadData(rowNumber, "Category");
            excelData.subcategory = ExcelLib.ReadData(rowNumber, "Subcategory");
            excelData.startDate = ExcelLib.ReadData(rowNumber, "StartDate");
            excelData.endDate = ExcelLib.ReadData(rowNumber, "EndDate");
            excelData.serviceType = ExcelLib.ReadData(rowNumber, "ServiceType");
            excelData.locationType = ExcelLib.ReadData(rowNumber, "LocationType");
            excelData.skillTrade = ExcelLib.ReadData(rowNumber, "SkillTradeOption");
            excelData.skillExchange = ExcelLib.ReadData(rowNumber, "SkillExchange");
            excelData.tags = ExcelLib.ReadData(rowNumber, "Tags");
            excelData.availableDays = ExcelLib.ReadData(rowNumber, "Days");
            excelData.startTime = ExcelLib.ReadData(rowNumber, "StartTime");
            excelData.endTime = ExcelLib.ReadData(rowNumber, "EndTime");
            excelData.credit = ExcelLib.ReadData(rowNumber, "CreditAmount");
            excelData.ActiveOption = ExcelLib.ReadData(rowNumber, "ActiveOption");
            excelData.isClickSaveFirst = ExcelLib.ReadData(rowNumber, "isClickSaveFirst");
        }


        internal void GetWeb(out Listing webData)
        {
            webData.title = actualTitle.Text;
            webData.description = actualDescription.Text;
            webData.category = actualCategory.Text;
            webData.subcategory = actualSubcategory.Text;
            webData.startDate = actualStartDate1.Text;
            webData.endDate = actualEndDate1.Text;
            webData.serviceType = actualServiceType.Text;
            webData.locationType = actualLocationType.Text;

            webData.skillTrade = "dummy";
            webData.skillExchange = "dummy";
            webData.tags = "dummy";
            webData.availableDays = "dummy";
            webData.startTime = "dummy";
            webData.endTime = "dummy";
            webData.credit = "dummy";
            webData.ActiveOption = "dummy";
            webData.isClickSaveFirst = "dummy";
        }

     

      


    }
    #endregion
}