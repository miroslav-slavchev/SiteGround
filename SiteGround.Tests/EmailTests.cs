using SiteGround.Tests.Infrastructure.Assertions;

namespace SiteGround.Tests
{
    public class EmailTests : BaseTest
    {
        [Test]
        public async Task TC_1_Add_Email_Account()
        {
            //Arrange
            const string domain = "site-tools-demo.net";
            const string accountName = "test_account";
            const string email = $"{accountName}@{domain}";

            //Act
            await App.DashBoard.PinnedTools.EmailAccounts.ClickAsync();
            await App.EmailPage.Accounts.SelectDomain.DropDown.SelectOptionAsync(domain);
            string accountAddOn = await App.EmailPage.Accounts.CreateNewEmailAccount.AccountName.AddOn.TextContentAsync();
            await App.EmailPage.Accounts.CreateNewEmailAccount.AccountName.Input.FillAsync(accountName);

            await App.EmailPage.Accounts.CreateNewEmailAccount.Password.GenerateButton.ClickAsync();
            string filledPassword = await App.EmailPage.Accounts.CreateNewEmailAccount.Password.Input.InputValueAsync();

            await App.EmailPage.Accounts.CreateNewEmailAccount.ClickCreateButtonAsync();

            //Assert
            Verify.All(async () =>
            {
                //Account AddOn
                accountAddOn.Should().Be($"@{domain}", because: "AddOn should match the selected domain");

                //Password
                filledPassword.Should().NotBeNullOrEmpty(because: "Clicking on 'Generate' button should fill the password input");

                //Notification
                var notification = await App.EmailPage.Accounts.CreateNewEmailAccount.Notification.PresentAsync();
                notification.Should().NotBeNull(because: "notification presence is expected");
                if (notification is not null)
                {
                    (await notification.Icon.IsSuccessAsync()).Should().BeTrue(because: "notification icon should be success");
                    (await notification.Heading.Emphasis.TextContentAsync()).Should().Be(email, because: "account name presence is expected in notification text");
                }

                //Manage Email Accounts
                var targetAccountRow = await App.EmailPage.Accounts.ManageEmailAccounts.Table.Rows.FirstOrDefaultAsync(async row => await row.AccountName.TextContentAsync() == email);
                targetAccountRow.Should().NotBeNull(because: $"Account for {email} row should be present in the table after creation");
            });
        }

        [Test]
        public async Task TC_2_Add_Empty_Email_Forwarder()
        {
            //Arrange
            const string domain = "site-tools-demo.net";
            List<string> expectedOptions = ["qa-automation-tools.com", "store.qa-automation-tools.com", "parked-qa-automation-tools.com", "site-tools-demo.net"];

            //Act
            await App.SideNavigation.Email.ClickForwardersAsync();
            var options = await App.EmailPage.Forwarders.SelectDomain.DropDown.OptionsTextContentAsync();
            await App.EmailPage.Forwarders.SelectDomain.DropDown.SelectOptionAsync(domain);
            await App.EmailPage.Forwarders.CreateNewRule.CreateButton.ClickAsync();
            var validationError = await App.EmailPage.Forwarders.CreateNewRule.ForwardAllMessagesSentTo.ValidationError.PresentAsync();

            //Assert
            Verify.All(async () =>
            {
                //Options
                options.Should().BeEquivalentTo(expectedOptions, because: $"these are the expected options: {string.Join(",", expectedOptions)}");

                //Validation Error
                validationError.Should().NotBeNull(because: "Validation error should be present after clicking on 'Create' button with empty fields");
                if (validationError is not null)
                {
                    (await validationError.Message.TextContentAsync()).Should().Be("Required field.", because: "Validation error message should match the expected text");
                    (await validationError.Icon.IsErrorAttentionAsync()).Should().BeTrue(because: "Validation error icon should be 'error-attention' type");
                }
            });

        }
    }
}