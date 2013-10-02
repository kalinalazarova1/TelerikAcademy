using System;

namespace MobilePhone
{
    public class Display
    {
        private float? size = null;
        private int? colors = null;

        public float? Size
        {
            get { return this.size; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Display size could not be zero or less than zero!");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int? Colors 
        {
            get { return this.colors; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Display colors could not be less than zero!");
                }
                else
                {
                    this.colors = value;
                }
            }
        }

        public Display()        //all the fields of the class are optional
            : this(null, null)
        {
        }

        public Display(float? size)
            : this(size, null)
        {
        }

        public Display(float? size, int? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public override string ToString()           //N/A is printed for the fields which are not specified and are null
        {
            if (this.Size == null)
            {
                return string.Format("Display: N/A inches, Colors: N/A\n");
            }
            else if (this.Colors == null)
            {
                return string.Format("Display: {0} inches, Colors: N/A\n", this.Size);
            }
            else
            {
                return string.Format("Display: {0} inches, Colors: {1}\n", this.Size, this.Colors);
            }
        }
    }
}
