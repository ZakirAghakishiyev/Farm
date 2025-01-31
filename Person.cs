namespace Farm
{
    internal class Person : Base
    {
        private static int AutoIncremendId = 1;
        public string Name { set; get; }
        public string UserType { set; get; }

        public Person(string name, string userType)
        {
            Name = name;
            UserType = userType;
            Id= AutoIncremendId++;
        }
    }
}
