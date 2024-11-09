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

        // Метод для вычисления безопасной глубины с учетом температуры воды и типа подводной лодки
        public static double CalculateSafeDepth(double waterTemperature, int depthCapacity, string submarineType)
        {
            // Температура воды влияет на безопасную глубину
            double safetyFactor = waterTemperature < 10 ? 1.5 : (waterTemperature < 20 ? 1.2 : 1.0);

            // Учитываем тип подводной лодки: например, для атомных лодок безопасность больше
            if (submarineType == "Nuclear")
            {
                safetyFactor *= 1.3; // Для атомных лодок безопасная глубина увеличена на 30%
            }
            else if (submarineType == "Diesel")
            {
                safetyFactor *= 0.8; // Для дизельных лодок безопасная глубина уменьшена на 20%
            }

            // Максимальная безопасная глубина
            double safeDepth = depthCapacity * safetyFactor;
            return safeDepth;
        }

        // Новый метод для вычисления оптимальной глубины в зависимости от типа подводной лодки
        public int GetOptimalDiveDepth(string submarineType)
        {
            switch (submarineType.ToLower())
            {
                case "research":
                    return 500;  // Для исследовательских лодок максимальная глубина 500 м
                case "tourist":
                    return 100;  // Для туристических лодок максимальная глубина 100 м
                default:
                    return 200;  // Для всех остальных типов лодок — 200 м
            }
        }
        public static double CalculateSafeDepth(double waterTemperature, int depthCapacity, string submarineType)
        {
            // Температура воды влияет на безопасную глубину
            double safetyFactor = waterTemperature < 10 ? 1.5 : (waterTemperature < 20 ? 1.2 : 1.0);

            // Учитываем тип подводной лодки: например, для атомных лодок безопасность больше
            if (submarineType == "Nuclear")
            {
                safetyFactor *= 1.3; // Для атомных лодок безопасная глубина увеличена на 30%
            }
            else if (submarineType == "Diesel")
            {
                safetyFactor *= 0.8; // Для дизельных лодок безопасная глубина уменьшена на 20%
            }

            // Максимальная безопасная глубина
            double safeDepth = depthCapacity * safetyFactor;
            return safeDepth;
        }
    }
}