using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BlazorShared.Models;
public class CustomResolver : IMemberValueResolver<object, object, decimal, decimal>
{
    public CustomResolver()
    {
    }

    public decimal Resolve(object source, object destination, decimal sourceMember, decimal destinationMember, ResolutionContext context)
    {
        // logic here
    }
}
