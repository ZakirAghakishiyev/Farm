namespace Farm
{
    internal class Person : Base
    {
        private static int AutoIncremendId = 1;
        public string Name { set; get; }

        public Person(string name)
        {
            Name = name;
            Id= AutoIncremendId++;
        }
    }
}
