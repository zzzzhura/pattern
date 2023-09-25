using NUnit.Framework;
using ProductFactoryLib.AbstractModels;
using ProductFactoryLib.Factories;
using System;
using System.IO;

[TestFixture]
public class FoodFactoryTests
{


    [Test]
    public void Milk_Display_ShouldReturnCorrectMessage ()
    {
        // Arrange
        MilkFactory milkFactory = new MilkFactory ();

        //Act
        Food milk = milkFactory.CreateDairyProduct();
        string result = CaptureConsoleOutput(() => milk.Display());

        Assert.AreEqual("Молоко", result.Trim());
    }

    [Test]
    public void MilkChocolate_Display_ShouldReturnCorrectMessage()
    {
        // Arrange
        MilkFactory milkFactory = new MilkFactory();

        //Act
        Food milkChocolate = milkFactory.CreateConfectionery();
        string result = CaptureConsoleOutput(() => milkChocolate.Display());

        Assert.AreEqual("Молочный шоколад", result.Trim());
    }

    [Test]
    public void Yogurt_Display_ShouldReturnCorrectMessage()
    {
        // Arrange
        CandyFactory milkFactory = new CandyFactory();

        //Act
        Food yogurt = milkFactory.CreateDairyProduct();
        string result = CaptureConsoleOutput(() => yogurt.Display());

        Assert.AreEqual("Безлактозный йогурт", result.Trim());
    }

    [Test]
    public void Candy_Display_ShouldReturnCorrectMessage()
    {
        // Arrange
        CandyFactory milkFactory = new CandyFactory();

        //Act
        Food candy = milkFactory.CreateConfectionery();
        string result = CaptureConsoleOutput(() => candy.Display());

        Assert.AreEqual("Конфеты", result.Trim());
    }

    // Вспомогательный метод для перехвата вывода консоли
    private string CaptureConsoleOutput(Action action)
    {
        // Запоминаем стандартный вывод
        var standardOut = Console.Out;
        try
        {
            using (var consoleOutput = new StringWriter())
            {
                // Перенаправляем стандартный вывод в StringWriter
                Console.SetOut(consoleOutput);

                // Вызываем действие
                action.Invoke();

                // Возвращаем захваченный вывод
                return consoleOutput.ToString();
            }
        }
        finally
        {
            // Восстанавливаем стандартный вывод
            Console.SetOut(standardOut);
        }
    }
}
