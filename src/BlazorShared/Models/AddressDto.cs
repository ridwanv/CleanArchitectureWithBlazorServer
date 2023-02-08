using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class AddressDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string Code { get; set; }
}
