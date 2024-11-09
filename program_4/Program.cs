namespace program_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OceanResearchSubmarine submarine1 = new OceanResearchSubmarine("Turtle", "Bernard Austin", 20);
            OceanResearchSubmarine submarine2 = new OceanResearchSubmarine("Whale", "Philip Ross", 30);
            OceanResearchSubmarine submarine3 = new OceanResearchSubmarine();
            OceanResearchSubmarine submarine4 = new OceanResearchSubmarine(15); // Новый объект с использованием нового конструктора

            Console.WriteLine(submarine1.GetInfo(false));
            Console.WriteLine(new string('-', 30)); // Разделитель
            Console.WriteLine(submarine2.GetInfo());
            Console.WriteLine(new string('-', 30)); // Разделитель
            Console.WriteLine(submarine3.GetInfo(true));
            Console.WriteLine(new string('-', 30)); // Разделитель
            Console.WriteLine(submarine4.GetInfo(true));
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
            get => captainLastName;
            set => captainLastName = value;
        }
        public int DepthCapacity
        {
            get => depthCapacity;
            set
            {
                if (value >= 0) { depthCapacity = value; }
            }
        }
        public bool IsWithinSafeDepth => depthCapacity < 25;

        // Новый конструктор
        public OceanResearchSubmarine(int depthCapacity) : this("Explorer", "Unknown Captain", depthCapacity) { }

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
            string result = $"Название подводной лодки: {SubmarineName}\n" +
                            $"Имя капитана судна: {CaptainName}\n";
            if (includeIntProperty)
            {
                result += $"Максимальная глубина погружения: {DepthCapacity}\n";
            }
            result += $"Безопасны ли погружения >25 метров: {(IsWithinSafeDepth ? "Да" : "Нет")}\n"; // Новое сообщение о безопасной глубине
            return result;
        }
        public double CalculateDiveTime(int targetDepth)
        {
            // Время погружения пропорционально глубине (1 минута на каждые 10 метров)
            return targetDepth / 10.0;
        }
    }
}