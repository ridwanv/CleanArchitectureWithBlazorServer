namespace BlazorShared.Models;


public class PersonIdentification : Person
{
    public Person Spouse { get; set; } = new Person();
    public List<Person> Children { get; set; } = new List<Person>();
    public List<Address> Addresses { get; set; } = new List<Address>();

    public string RiskRating { get; set; }

}


public class Person
{
    public string Initials { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Photo { get; set; }



}

public class Address
{
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string Code { get; set; }
}
