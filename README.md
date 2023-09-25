# "Абстрактная фабрика" - Паттерн проектирования 

Содержание включает в себя примеры реализации паттерна 
проектирования "Абстрактная фабрика" при помощи языка программирования С#. 

### Содержание папок проектов:
* Реализация паттерна в библиотеке классов
* Демострирование работы в консольном приложении
* Тестирование методов классов и проверка корректности реализации паттерна

Абстрактная фабрика (Abstract Factory) -  это второй по 
популярности паттерн после паттерна «Синглтон». Является одним 
из порождающих паттернов проектирования, который предоставляет 
интерфейс для создания семейства связанных или зависимых объектов
без указания их конкретных классов. Позволяет создавать 
объекты, которые взаимодействуют друг с другом и поддерживают 
одну общую тему, при этом избегая прямой зависимости между 
клиентским кодом и конкретными классами.

Данный паттерн необходимо использовать, когда система не должна 
зависеть от способа создания и компоновки новых объектов и когда 
создаваемые объекты должны использоваться вместе и являются взаимосвязанными.

>___Преимущества___  паттерна Abstract Factory: упрощение добавления новых 
>продуктов, их сочетаемость, а также избавление кода от привязки 
>к конкретным классам продуктов. 
>Недостатки: возможное усложнение кода из-за создания огромного 
>количества вспомогательных классов.

## Оглавление

1. [Пример реализации паттерна в области Фарм.Компании](#реализация-паттерна-на-примере-Фарм.Компании)
2. [Пример реализации паттерна в области ...](#реализация-паттерна-на-примере-)
3. [Пример реализации паттерна в области ...](#реализация-паттерна-на-примере-)

### Пример реализации паттерна в области Фарм.Компании

Фармакологические компании занимаются производством лекарственных средств. 
Препараты же в свою очередь можно разделить на 2 категории: рецептурные и безрецептурные.

___Пункт___ ___1___
Первое, что мы делаем - создаем абстрактный класс Pharm, он содержать 
абстрактный метод Display, который будет показывать,
какой продукт выбран и будет реализован в дочерних классах.

Абстрактный класс ___Pharm___

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmFactoryLib.AbstractModels
{
    public abstract class Pharm
    {
        public abstract void Display();
    }
}
```

___Пункт___ ___2___
Далее, создаем классы-наследники. Они будут реализовывать метод 
абстрактного класса ___Pharm___. В данном случае:

* ___Antibiotic___ - Антибиотики
* ___AntiVirus___ - Противовирусные
* ___Bad___ - Биологически активные добавки
* ___Vitamin___ - Витамины

Класс ___Antibiotic___

```C#
using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class Antibiotic : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("Антибиотик");
        }
    }
}
```

Класс ___AntiVirus___

```C#
using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class AntiVirus : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("Противовирусное");
        }
    }
}
```

Класс ___Bad___

```C#
using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class Bad : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("БАД (Биологически активная добавка)");
        }
    }
}
```

Класс ___Vitamin___

```C#
using PharmFactoryLib.AbstractModels;
using System;

namespace PharmFactoryLib.Models
{
    public class Vitamin : Pharm
    {
        public override void Display()
        {
            Console.WriteLine("Витамин");
        }
    }
}
```
___Пункт___ ___3___
Следующий шаг: реализация абстрактного класса по созданию препаратов
___PharmFactory___ , в котором будет 2 метода: 
создание рецептурного препарата CreateResipeProduct() и создание 
безрецептурного препарата CreateNonResipeProduct().

Абстрактный класс ___PharmFactory___

```C#
using PharmFactoryLib.AbstractModels;

namespace PharmFactoryLib.Factories
{
    public abstract class PharmFactory
    {
        public abstract Pharm CreateResipeProduct();
        public abstract Pharm CreateNonResipeProduct();
    }
}
```
___Пункт___ ___4___
Начинаем реализацию конкретного производства, которое будет создавать 
объекты одной категории. Из главного производителя два дочерних производителя наследуют методы.

* ___PharmFactory___ - главное производство
* ___ResipeFactory___ - рецептурное производство
* ___UsualFactory___ - нерецептурное производство

Класс ___ResipeFactory___

```C#
using PharmFactoryLib.AbstractModels;
using PharmFactoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmFactoryLib.Factories
{
    public class ResipeFactory : PharmFactory
    {
        public override Pharm CreateResipeProduct()
        {
            return new AntiVirus();
        }

        public override Pharm CreateNonResipeProduct()
        {
            return new Antibiotic();
        }
    }
}
```

Класс ___UsualFactory___

```C#
using PharmFactoryLib.AbstractModels;
using PharmFactoryLib.Models;

namespace PharmFactoryLib.Factories
{
    public class UsualFactory : PharmFactory
    {
        public override Pharm CreateResipeProduct()
        {
            return new Bad();
        }

        public override Pharm CreateNonResipeProduct()
        {
            return new Vitamin();
        }
    }
}
```
___Пункт___ ___5___
Чтобы убедиться, что мы все сделали правильно, напишем консольное приложение.
Создаем фабрики препаратов.

После этого мы можем создать экземляр класса вызвав метод
CreateNonResipeProduct() или CreateNonResipeProduct() для создания
препаратов, затем, вызвать метод Display() для отображения имени продукта.

```C#
using PharmFactoryLib.AbstractModels;
using PharmFactoryLib.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmFactoryLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            PharmFactory usualFactory = new UsualFactory();
            Pharm usualProduct = usualFactory.CreateResipeProduct();
            Pharm usualConfectionery = usualFactory.CreateNonResipeProduct();

            Console.WriteLine("Производим безрецептурные препараты:");
            usualProduct.Display();
            usualConfectionery.Display();

            // Создаем фабрику 
            PharmFactory resipeFactory = new ResipeFactory();
            Pharm antiVirusProduct = resipeFactory.CreateResipeProduct();
            Pharm antibioticProduct = resipeFactory.CreateNonResipeProduct();

            Console.WriteLine("\nПроизводим рецептурные препараты:");
            antiVirusProduct.Display();
            antibioticProduct.Display();

            Console.ReadKey();
        }
    }
}
```
