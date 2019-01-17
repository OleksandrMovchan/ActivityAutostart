namespace Portable.Data
{
    public class SomeData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public SomeData(string id, string name, int red, int green, int blue)
        {
            Id = id;
            Name = name;
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}