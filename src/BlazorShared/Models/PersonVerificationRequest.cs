using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class PersonVerificationRequest
{
    public Person Person { get; set; } = new Person();
    public int AnnualAmount { get; set; }
    public CollectionMethod PrimaryCollectionMethod { get; set; }
    public ProductType ProductType { get; set; }

}
public enum CollectionMethod
{
    Cash, DebitOrder, Eft

}

public enum ProductType
{
    Funeral, Life 

}
