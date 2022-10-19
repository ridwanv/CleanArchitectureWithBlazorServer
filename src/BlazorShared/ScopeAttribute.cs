using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared;
// Defining a set of attribute
public class ScopedRegistrationAttribute : Attribute { }

public class SingletonRegistrationAttribute : Attribute { }

public class TransientRegistrationAttribute : Attribute { }
