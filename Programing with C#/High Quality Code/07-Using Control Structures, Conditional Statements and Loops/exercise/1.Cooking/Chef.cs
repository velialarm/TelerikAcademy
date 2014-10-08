using System;

public class Chef
{
    private Carrot GetCarrot()
    {
        return new Carrot();
    }

    private Potato GetPotato()
    {
        return new Potato();
    }

    private void Cut(Vegetable potato)
    {
        // ...
    }

    private void Peel(Vegetable potato)
    {
        // ...
    }

    private Bowl GetBowl()
    {
        // ...
        return new Bowl();
    }

    public void Cook()
    {
        Potato potato = GetPotato();
        Carrot carrot = GetCarrot();
        Bowl bowl;
        Peel(potato);
                
        Peel(carrot);
        bowl = GetBowl();
        Cut(potato);
        Cut(carrot);
        bowl.Add(carrot);
                
        bowl.Add(potato);

    }
}

internal class Bowl : Vegetable
{
    internal void Add(Carrot carrot)
    {
        throw new NotImplementedException();
    }
}

internal class Vegetable
{
}

internal class Potato : Carrot
{
}

internal class Carrot : Vegetable
{
}
