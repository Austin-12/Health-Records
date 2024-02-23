using System;


namespace HealthRecords
{
    class HealthProfile
    {
        //properties
        private string firstName;
        private string lastName;
        private string gender;

        private int birthMonth;
        private int birthDay;
        private int birthYear;
        private int age;
        private int maximumHeartRate;

        private decimal height;
        private decimal weight;
        private decimal bmi;

        //Constructor prompt user to get the patients information
        public HealthProfile()
        {
            Console.Write("Enter the patients firstname: ");
            firstName = Console.ReadLine();

            Console.Write("Enter the patients lastname: ");
            lastName = Console.ReadLine();

            Console.Write("Enter the patients gender: ");
            gender = Console.ReadLine();

            Console.Write("Enter the patients birth month: ");
            birthMonth = int.Parse(Console.ReadLine());

            Console.Write("Enter the patients birth day: ");
            birthDay = int.Parse(Console.ReadLine());

            Console.Write("Enter the patients birth year: ");
            birthYear = int.Parse(Console.ReadLine());

            Console.Write("Enter the patients height in inches: ");
            height = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the patients weight in lbs: ");
            weight = decimal.Parse(Console.ReadLine());

            Console.Write("\n");

            //call calculateAge
            age = calculateAge(birthMonth, birthDay, birthYear);
           
            //callmaxHeartRate
            maximumHeartRate = maxHeartRate(age);

             bmi = calculateBMI(weight, height);

            //print patient info
            patientInfo();
            

        }

        //set and get accessors
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int BirthMonth
        {
            get { return birthMonth; }
            set { birthMonth = value; }
        }

        public int BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public int BirthYear
        {
            get { return birthYear; }
            set { birthYear = value; }
        }

        public decimal Height
        {
            get { return height; }
            set { height = value; }
        }

        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int MaxHeartRate
        {
            get { return maximumHeartRate; }
            set { maximumHeartRate = value; }
        }

        public decimal BMI
        {
            get { return bmi; }
            set { bmi = value; }
        }

        //calculate and return the users age in years method
        private int calculateAge(int month, int day, int year)
        {
            DateTime dt = DateTime.Now; //Datetime struct to get current date

            int years = dt.Year - year;
            int months = dt.Month - month;
            int days = dt.Day - day;

            int ageInDays = (years * 365) + (months * 31) + days;
            int age = ageInDays / 365;
            return age;
        }

        //calculate max heart rate and return method
        private int maxHeartRate(int age)
        {
            return 220 - age;
        }

        //calculate target heart-rate range method print in method
        private void heartRateRange()
        {
            double lowRate = Math.Round(.50 * maximumHeartRate);
            double highRate = Math.Round(.85 * maximumHeartRate);
            Console.WriteLine($"heart rate range is {lowRate} - {highRate}");
        }

        //calculate BMI
        private decimal calculateBMI(decimal lbs, decimal inches)
        {
            decimal BMI = Math.Round((lbs * 703) / (inches * inches), 2);
            return BMI;

        }

        //print patient information method
        private void patientInfo()
        {
            Console.WriteLine($"Patient: {firstName} {LastName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Birthdate: {BirthMonth}/{BirthDay}/{BirthYear}");
            Console.WriteLine($"maximum heart rate in beats: {MaxHeartRate}");
            heartRateRange();
            Console.WriteLine($"BMI: {bmi}");

            if (BMI < (decimal)18.5)
            {
                Console.WriteLine("The patients body mass index falls within the Underweight category");
            }
            else if (BMI > (decimal)18.5 && BMI < (decimal)24.9)
            {
                Console.WriteLine("The patients body mass index falls within the Normal category");
            }
            else if (BMI > (decimal)25 && BMI < (decimal)29.9)
            {
                Console.WriteLine("The patients body mass index falls within the Overweight cateogry");
            }
            else if (BMI >= (decimal)30)
            {
                Console.WriteLine("The patients body mass index falls within the obese category");
            }

        }


    }
}
