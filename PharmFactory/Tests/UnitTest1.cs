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

        Assert.AreEqual("������", result.Trim());
    }

    [Test]
    public void MilkChocolate_Display_ShouldReturnCorrectMessage()
    {
        // Arrange
        MilkFactory milkFactory = new MilkFactory();

        //Act
        Food milkChocolate = milkFactory.CreateConfectionery();
        string result = CaptureConsoleOutput(() => milkChocolate.Display());

        Assert.AreEqual("�������� �������", result.Trim());
    }

    [Test]
    public void Yogurt_Display_ShouldReturnCorrectMessage()
    {
        // Arrange
        CandyFactory milkFactory = new CandyFactory();

        //Act
        Food yogurt = milkFactory.CreateDairyProduct();
        string result = CaptureConsoleOutput(() => yogurt.Display());

        Assert.AreEqual("������������ ������", result.Trim());
    }

    [Test]
    public void Candy_Display_ShouldReturnCorrectMessage()
    {
        // Arrange
        CandyFactory milkFactory = new CandyFactory();

        //Act
        Food candy = milkFactory.CreateConfectionery();
        string result = CaptureConsoleOutput(() => candy.Display());

        Assert.AreEqual("�������", result.Trim());
    }

    // ��������������� ����� ��� ��������� ������ �������
    private string CaptureConsoleOutput(Action action)
    {
        // ���������� ����������� �����
        var standardOut = Console.Out;
        try
        {
            using (var consoleOutput = new StringWriter())
            {
                // �������������� ����������� ����� � StringWriter
                Console.SetOut(consoleOutput);

                // �������� ��������
                action.Invoke();

                // ���������� ����������� �����
                return consoleOutput.ToString();
            }
        }
        finally
        {
            // ��������������� ����������� �����
            Console.SetOut(standardOut);
        }
    }
}
