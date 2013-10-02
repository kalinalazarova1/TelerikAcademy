using System;

namespace School
{
    public abstract class SchoolObject
    {
        public string Comment { get; set; } //no custom constructor because the comments are optional and could be set in the descendants
    }
}
