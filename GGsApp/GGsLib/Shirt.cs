namespace GGsLib
{
    public class Shirt : Product
    {
        public Size ShirtSize{get; set;}
        public string Brand{get; set;}
        public Shirt()
        {
            ShirtSize = Size.S;
            Brand = "";
        }

        
    }
    public enum Size {
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL
    }
}