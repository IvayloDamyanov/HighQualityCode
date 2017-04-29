// Task 1

public class Chef
    {
        private Potato GetPotato()
        {
            //...
        }

        private Carrot GetCarrot()
        {
            //...
        }

        private Bowl GetBowl()
        {   
            //... 
        }

        private void Peel(Vegetable vegetable)
        {
            //...
        }

        private void Cut(Vegetable vegetable)
        {
            //...
        }
        
        public void Cook()
        {
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl = GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);        
        }
    }
    
// Task 2
    Potato potato;
    //... 
    if (potato != null)
        if(potato.HasBeenPeeled && !potato.IsRotten)
        {
            Cook(potato);
        }
        

// and

    bool isXInRange = (MIN_X <= x && x <= MAX_X);
    bool isYInRange = (MIN_Y <= y && y <= MAX_Y);
    if (
        shouldVisitCell
        && isXInRange
        && isYInRange)
    {
        VisitCell();
    }

// Task 3
    int i = 0;
    while (i < 100) 
    {
        Console.WriteLine(array[i]);
        if ((i % 10) == 0 && array[i] == expectedValue)
        {
            i = 666;
        }
        else
        {
            i++;
        }
    }
    // More code here
    if (i == 666)
    {
        Console.WriteLine("Value Found");
    }