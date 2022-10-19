using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;

public class PolicyRiskRequirementRequest
{
    public Contract Policy { get; set; }


}

public class PolicyRiskRequirement
{
    public Contract Policy { get; set; }

    public List<PersonResult> PersonResults { get; set; }

}

public class Contract
{
    public string PolicyNumber { get; set; }
    public ProductType ProductType { get; set; }
    public CollectionMethod CollectionMethod { get; set; }

    public int AnnualPremium { get; set; }
    public List<Person> Parties { get; set; }

}

public class PersonResult
{

    public Person Person { get; set; }

    public RiskResult RiskResult { get; set; }

    public List<Requirement> Requirements { get; set; }
}

public class PersonVerification
{
    public Person VerifiedPerson { get; set; } = new Person();

    public Address VerifiedAddress { get; set; } = new Address();
    public List<Address> OtherAddresses { get; set; } = new List<Address>();
    public List<Requirement> Requirements { get; set; } = new List<Requirement>();
    public RiskResult RiskResult { get; set; } = new RiskResult();
}

public enum VerificationResult
{


    None = 0,


    Verified = 1,

    NotVerified = 2,

}

public enum RiskRating
{

    [System.Runtime.Serialization.EnumMember(Value = @"None")]
    None = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"Low")]
    Low = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"Medium")]
    Medium = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"High")]
    High = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"VeryHigh")]
    VeryHigh = 4,

}

public enum Requirement
{


    None = 0,


    ProofOfIdentity = 1,


    ProofOfAddress = 2,


    ProofOfSourceOfIncome = 3,


    ProofOfSourceOfWealth = 4,

}

public class RiskResult
{

    public RiskRating RiskRating { get; set; }


    public string RiskRatingReason { get; set; }



}