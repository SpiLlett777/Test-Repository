namespace program_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OceanResearchSubmarine submarine1 = new OceanResearchSubmarine("Turtle", "Bernard Austin", 20);
            OceanResearchSubmarine submarine2 = new OceanResearchSubmarine("Whale", "Philip Ross", 30);
            OceanResearchSubmarine submarine3 = new OceanResearchSubmarine();

            Console.WriteLine(submarine1.GetInfo(false));
            Console.WriteLine(submarine2.GetInfo());
            Console.WriteLine(submarine3.GetInfo(true));
        }
    }
    class OceanResearchSubmarine
    {
        private string submarineName;
        private string captainLastName;
        private int depthCapacity;
        public string SubmarineName
        {
            get => submarineName;
            set => submarineName = value;
        }
        public string CaptainName
        {
            get { return captainLastName; }
            set { captainLastName = value;  }
        }
        public int DepthCapacity
        {
            get => depthCapacity;
            set
            {
                if (value >= 0) { depthCapacity = value; }
            }
        }
        public bool IsWithinSafeDepth
        {
            get => depthCapacity < 25;
        }
        public OceanResearchSubmarine() : this("Undefined") { }
        public OceanResearchSubmarine(string submarineName) : this(submarineName, "Captain Nemo") { }
        public OceanResearchSubmarine(string submarineName, string captainName) : this(submarineName, captainName, 0) { }
        public OceanResearchSubmarine(string submarineName, string captainName, int depthCapacity)
        {
            SubmarineName = submarineName;
            CaptainName = captainName;
            DepthCapacity = depthCapacity;
        }
        public string GetInfo()
        {
            return $"Название подводной лодки: {SubmarineName}\n" +
                   $"Имя капитана судна: {CaptainName}\n" +
                   $"Максимальная глубина погружения: {DepthCapacity}\n" +
                   $"Безопасны ли погружения >25 метров: {IsWithinSafeDepth}\n";
        }
        public string GetInfo(bool includeIntProperty)
        {
            string result = $"Название подводной лодки: {SubmarineName}\n" + $"Имя капитана судна: {CaptainName}\n";
            if (includeIntProperty) { result += $"Максимальная глубина погружения: {DepthCapacity}\n"; }
            result += $"Безопасны ли погружения >25 метров: {IsWithinSafeDepth}\n";
            return result;
        }
    }
}