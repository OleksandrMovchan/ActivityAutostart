using System.Collections.Generic;

namespace Portable.Data
{
    public static class MockDataCollection
    {
        public static List<SomeData> GetCollection()
        {
            return new List<SomeData>()
            {
                new SomeData("Blue", "This is a blue screen", 66, 134, 244),
                new SomeData("Indigo", "This is an indigo screen", 15, 9, 135),
                new SomeData("Light blue", "This is a light blue screen", 66, 223, 255),
                new SomeData("Turquoise", "This is a turquoise screen", 41, 93, 104),
                new SomeData("Hot red", "This is a hot red screen", 221, 15, 15),
                new SomeData("Light red", "This is a light red screen", 229, 146, 146),
                new SomeData("Orange", "This is an orange screen", 255, 148, 0),
                new SomeData("Brown", "This is a brown screen", 96, 56, 0),
                new SomeData("Yellow", "This is a yellow screen", 234, 218, 42),
                new SomeData("Lime", "This is a lime screen", 218, 234, 42),
                new SomeData("Olive", "This is an olive screen", 141, 150, 43),
                new SomeData("Green", "This is a green screen", 169, 244, 78),
                new SomeData("Emerald", "This is an emerald screen", 43, 142, 7),
                new SomeData("Dark green", "This is a dark green screen", 7, 61, 15),
                new SomeData("Violet", "This is a violet screen", 101, 20, 232),
                new SomeData("Purple", "This is a purple screen", 188, 19, 254),
                new SomeData("Pink", "This is a pink screen", 254, 19, 214),
                new SomeData("Cherry", "This is a cherry screen", 112, 8, 94),
                new SomeData("Black", "This is a black screen", 0, 0, 0),
                new SomeData("Gray", "This is a gray screen", 122, 122, 122)
            };
        }
    }
}