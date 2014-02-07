using System;
using System.Runtime.InteropServices;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct |
    AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)] //this attribute could be appled to classes, structs and interfaces and each could have only one version
    public class VersionAttribute : System.Attribute                        
    {
        public string Version { get; private set; }

        public VersionAttribute(int major, int minor)       //this attribute class has only one constructor with two mandatory arguments
	    {
            if (major <= 0 || minor < 0)
            {
                throw new ArgumentException("The version format is not correct!");
            }
            else
            {
                this.Version = string.Format("{0}.{1}", major, minor);
            }
	    }

        public override string ToString()
        { 
            return this.Version;
        }
    }
}
