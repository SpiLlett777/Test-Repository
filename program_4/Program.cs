﻿namespace program_4
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
        public double CalculateFuelConsumption(double speed, bool isHighEfficiencyMode)
        {
            // Основной расход топлива на каждый метр погружения
            double baseConsumption = depthCapacity * 0.05;
            // Коррекция расхода в зависимости от скорости
            double speedFactor = speed < 10 ? 1.0 : 1.2;
            // Эффективный режим экономит топливо
            double efficiencyFactor = isHighEfficiencyMode ? 0.85 : 1.0;

            return baseConsumption * speedFactor * efficiencyFactor;
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
        public static double CalculateSafeDepth(double waterTemperature, int depthCapacity, string submarineType, bool isEmergency = false)
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

            if (isEmergency)
            {
                safetyFactor *= 1.1; // В экстренной ситуации безопасная глубина повышена на 10%
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

        public double CalculateAscentTime(int targetDepth)
        {
            // Время подъема пропорционально глубине, но в два раза быстрее, чем погружение
            return targetDepth / 20.0;
        }
        public void DisplaySafetyStatus()
        {
<<<<<<< HEAD
            Console.WriteLine($"Подводная лодка {SubmarineName}: глубина {DepthCapacity} м. " +
                              $"Безопасно ли погружение >25 метров: {(IsWithinSafeDepth ? "Да" : "Нет")}");
=======
            double typeFactor = submarineType.ToLower() == "research" ? 1.2 : 1.0;
            double emergencyFactor = isEmergency ? 0.8 : 1.0;

            // Предупреждение, если запас воздуха меньше определенного значения
            if (airSupply < 10)
            {
                Console.WriteLine("Предупреждение: запас воздуха критически низок!");
            }

            return airSupply / (depthCapacity * 0.1 * typeFactor * emergencyFactor);
>>>>>>> 9a46895 (Добавлена проверка на критический уровень запаса воздуха в метод CalculateRemainingAirTime)
        }
    }
}