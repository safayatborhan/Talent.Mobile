using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Common
{
    public class Messages
    {
        public static string Ok = "OK";
        public static string Yes = "YES";
        public static string No = "NO";

        public class Login
        {
            public static string UsernamePasswordRequired = "Username and password are required";
            public static string ValidUsernamePassword = "Please enter valid username and password";
        }

        public class Register
        {
            public static string EmailAddressExist = "Email Address already exist, please try with another email address.";
            public static string UserRegistered = "Thank you for registering with us.";
            public static string FieldsRequired = "All fields are mandatory.";
            public static string ConfirmPasswordMatch = "Password and confirm password must be same.";
            public static string ValidEmailAddress = "Please enter valid email address.";
        }
        public class MyProfile
        {
            public static string RequiredFields = "Please enter your title and type of transactions.";
            public static string SaveSuccess = "Profile updated successfully.";
            public static string InvalidPhoneNumber = "Please enter valid phone number. i.e. 425 555 0123.";
            public static string InvalidZipCode = "Please enter valid zip code. i.e. 12345.";
        }
        public class Escrow
        {
            public static string ConfirmSubmitTitle = "Everything Correct?";
            public static string EscrowSaved = "Escrow saved successfully.";
            public static string ErrorOccured = "Some error occurred.";
            public static string RequiredFields = "Please enter client last name, address and agent title.";
            public static string ConfirmSubmit = "Ready to submit?";
            public static string SaveSuccessfully = "Escrow saved successfully.";
            public static string EditEscrowTitle = "Are you sure?";
            public static string EditEscrowContent = "Who is canceling?";
            public static string Buyer = "Buyer";
            public static string Seller = "Seller";
            public static string EscrowCaneled = "The escrow has \n been canceled";
        }

        public class Contingency
        {
            public static string ValidAddContingency = "Please add at least one contingency.";
            public static string AddedSuccessfully = "Contingency added successfully.";
            public static string ValidContingency = "Please input all required fields.";
            public static string SaveSuccessfully = "Contingency saved successfully.";
            public static string ValidContingencyName = "Please insert contingency name.";
            public static string SelectContingnecyType = "Please select cotingency type.";
        }

        public class Invite
        {
            public static string InvitePOPupTitle = "Invite";
            public static string InvitePOPupContent = "Send an invitation to view this escrow?";
            public static string eMailValidation = "Please insert eMail address.";
            public static string SendValidation = "Please select a role and add valid email address.";
            public static string eMailSentSuccessfully = "Invitation sent successfully.";
        }

        public class PackageSubscription
        {
            //After first transaction popup title and content
            public static string UpgradeSubscriptionTitle = "Let's get Started";
            public static string UpgradeSubscriptionContent = "Upgrade your account?";
            //After three transaction popup title and content
            public static string UpgradeProOrUnlimitedTitle = "Pick Your Plan";
            public static string UpgradeProOrUnlimitedContent = "Pro or Unlimited";

            public static string Pay = "Pay";
            public static string Cancel = "Cancel";
        }
    }
}
