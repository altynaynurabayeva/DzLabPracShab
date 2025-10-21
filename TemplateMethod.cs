using System;

// Template Method Pattern
public abstract class Beverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
            AddCondiments();
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();
    protected virtual bool CustomerWantsCondiments() => true;

    private void BoilWater() => Console.WriteLine("Кипятим воду");
    private void PourInCup() => Console.WriteLine("Наливаем в чашку");
}

public class Tea : Beverage
{
    protected override void Brew() => Console.WriteLine("Завариваем чай");
    protected override void AddCondiments() => Console.WriteLine("Добавляем лимон");
}

public class Coffee : Beverage
{
    private readonly bool _wantsCondiments;
    public Coffee(bool wantsCondiments = true)
    {
        _wantsCondiments = wantsCondiments;
    }

    protected override void Brew() => Console.WriteLine("Завариваем кофе через фильтр");
    protected override void AddCondiments() => Console.WriteLine("Добавляем сахар и молоко");
    protected override bool CustomerWantsCondiments() => _wantsCondiments;
}

public static class TemplateDemo
{
    public static void Run()
    {
        Console.WriteLine("Готовим чай:");
        var tea = new Tea();
        tea.PrepareRecipe();

        Console.WriteLine("\nГотовим кофе (без добавок):");
        var coffee1 = new Coffee(false);
        coffee1.PrepareRecipe();

        Console.WriteLine("\nГотовим кофе (с добавками):");
        var coffee2 = new Coffee(true);
        coffee2.PrepareRecipe();
    }
}
