//11. Create a [Version] attribute that can be applied to structures, classes, interfaces, 
//enumerations and methods and holds a version in the format major.minor (e.g. 2.11). 
//Apply the version attribute to a sample class and display its version at runtime.

using System;
using System.Runtime.InteropServices;

namespace VersionAttributeTest
{
    [VersionAttribute.Version(12, 0)]
    class VersionAttributeTest
    {
        static void Main()      //prints the VersionAttributeTest version on the console
        {
            Type type = typeof(VersionAttributeTest);
            Console.WriteLine();
            object[] attributes = type.GetCustomAttributes(false);
            foreach (var versionAttr in attributes)
            {
                Console.WriteLine("Class {0} is version: {1}", type, versionAttr);
            }
        }
    }
}
