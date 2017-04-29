namespace Task2
{
    using System;

    class MainClass
    {
        enum Gender
        {
            Male,
            Female
        };

        public void MakeHuman(int PersonalIdNumber)
        {
            Human newHuman = new Human();
            newHuman.age = PersonalIdNumber;

            if (PersonalIdNumber % 2 == 0)
            {
                newHuman.humanName = "Batka";
                newHuman.gender = Gender.Male;
            }
            else
            {
                newHuman.humanName = "Matzka";
                newHuman.gender = Gender.Female;
            }
        }

        class Human
        {
            public Gender gender { get; set; }
            public string humanName { get; set; }
            public int age { get; set; }
        }
    }
}
