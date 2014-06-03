public class Shape
{
    private double width;

    private double heigth;

    public Shape(double w, double h)
    {
        this.Width = w;
        this.Heigth = h;
    }

    public double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            this.width = value;
        }
    }

    public double Heigth
    {
        get
        {
            return this.heigth;
        }

        set
        {
            this.heigth = value;
        }
    }
}
