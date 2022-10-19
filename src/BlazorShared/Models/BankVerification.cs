using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class BankVerification:BankVerificationRequest
{
    public BankAccountVerificationResult BankAccountVerificationResult { get; set; }

    public BankVerification()
    {
        
    BankAccountVerificationResult = new BankAccountVerificationResult();
    }
}

public class BankVerificationSearch
{

}

public class BankAccountVerificationResult
{
    public Result AccountDormant { get; set; }
    public Result AccountOpen { get; set; }
    public Result AccountOpenForMoreThanThreeMonths { get; set; }
    public Result AccountAcceptsDebit { get; set; }
    public Result AccountAcceptsCredit { get; set; }
    public Result IdentityNumberMatch { get; set; }
    public Result InitialsMatch { get; set; }
    public Result SurnameMatch { get; set; }
    public Result BankAccountTypeMatch { get; set; }
    public Result BranchCodeMatch { get; set; }
    public Result AccountNumberMatch { get; set; }

    



}


public enum Result
{
    [System.Runtime.Serialization.EnumMemberAttribute()]
    Yes = 1,

    [System.Runtime.Serialization.EnumMemberAttribute()]
    No = 2,

    [System.Runtime.Serialization.EnumMemberAttribute()]
    NoInformationAvailable = 3,

    [System.Runtime.Serialization.EnumMemberAttribute()]
    FailedPreValidation = 4,
}
public class BankAccount
{
    public string BranchCode { get; set; }
    public string AccountNumber { get; set; }


}

public class BankVerificationRequest
{
    public Guid Id { get; set; }
    public string Reference { get; set; }
    public string Initials { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public string EmaillAddress { get; set; }
    public string CellphoneNumber { get; set; }
    public BankAccount BankAccount { get; set; }

    public BankVerificationRequest()
    {
        BankAccount = new BankAccount();
    }

}
