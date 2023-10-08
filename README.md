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
>___Недостатки___: возможное усложнение кода из-за создания огромного 
>количества вспомогательных классов.

## Оглавление

1. [Пример реализации паттерна в области Книг](#реализация-паттерна-на-примере-Книг)
2. [Пример реализации паттерна в области Одежды](#реализация-паттерна-на-примере-Одежды)
3. [Пример реализации паттерна в области Фарм Компании](#реализация-паттерна-на-примере-Фарм-Компании)

### Пример реализации паттерна в области Книг

Книги бывают 2 видов: электронные и бумажные. Пусть, к этим видам будут относиться конкретные книги, а именно: "Му-му", "Ревизорро" и "Десять негритят".
___Пункт___ ___1___. Создаем абстрактный класс Books, который будет содержать абстрактный метод Create (он будет реализован в дочерних классах).

```C#
namespace BooksFactoryLib.AbstractModels
{
    public abstract class Books
    {
        public abstract void Create();
    }
}
```
___Пункт___ ___2___. Создаем классы - насследники. Они будут реализовывать метод 
абстрактного класса ___Books___.
* ___ClassicMumu___ - Бумажная книга Му-му
* ___ClassicRevizorro___ - Бумажная книга Ревизорро
* ___ClassicTenLittleIndians___ - Бумажная книга Десять негритят
* ___ElectronicMumu___ - Электронная книга Му-му
* ___ElectronicRevizorro___ - Электронная книга Ревизорро
* ___ElectronicTenLittleIndians___ - Электронная книга Десять негритят

```C#
using BooksFactoryLib.AbstractModels;
using System;

namespace BooksFactoryLib.Models
{
    public class ClassicMumu : Books
    {
        public override void Create()
        {
            Console.WriteLine("Читаем бумажную книгу Му-му");
        }
    }
}
```
```C#
using BooksFactoryLib.AbstractModels;
using System;

namespace BooksFactoryLib.Models
{
    public class ElectronicMumu : Books
    {
        public override void Create()
        {
            Console.WriteLine("Читаем электронную книгу Му-му");
        }
    }
}
```
Аналогично и другие классы.

___Пункт___ ___3___. Создаем абстрактный класс фабрики по созданию книг BooksFactory. В нем будет 3 метода: создание Му-му CreateMumu(), создание Ревизорро CreateRevizorro() и создание Десять негритят CreateTenLittleIndians().

```C#
using BooksFactoryLib.AbstractModels;

namespace BooksFactoryLib.Factories
{
    public abstract class BooksFactory
    {
        public abstract Books CreateMumu();
        public abstract Books CreateRevizorro();
        public abstract Books CreateTenLittleIndians();
    }
}
```
___Пункт___ ___4___. Реализуем конкретные фабрики, создающие объекты одного семейства. В нашем случае - две фабрики, которые наследуют методы из главной фабриики: фабрика бумажных книг ClassicBooksFactory и фабрика электронных книг ElectronicBooksFacrtory.

Фабрика для создания бумажных книг ClassicBooksFactory

```C#
using BooksFactoryLib.Factories;
using BooksFactoryLib.AbstractModels;
using BooksFactoryLib.Models;

namespace BooksFactoryLib.Factories
{
    public class ClassicBooksFactory : BooksFactory
    {
        public override Books CreateMumu()
        {
            return new ClassicMumu();
        }

        public override Books CreateRevizorro()
        {
            return new ClassicRevizorro();
        }

        public override Books CreateTenLittleIndians()
        {
            return new ClassicTenLittleIndians();
        }
    }
}
```
Фабрика для создания электронных книг ElectronicBooksFacrtory
```C#
using BooksFactoryLib.AbstractModels;
using BooksFactoryLib.Models;

namespace BooksFactoryLib.Factories
{
    public class ElectronicBooksFacrtory : BooksFactory
    {
        public override Books CreateMumu()
        {
            return new ElectronicMumu();
        }

        public override Books CreateRevizorro()
        {
            return new ElectronicRevizorro();
        }

        public override Books CreateTenLittleIndians()
        {
            return new ElectronicTenLittleIndians();
        }
    }
}
```
___Пункт___ ___5___
Проверим работу и напишем консольное приложение.
Создаем фабрики книг. После этого мы можем создать экземляр класса вызвав метод CreateMumu(), CreateRevizorro() или CreateTenLittleIndians(), а затем вызвать метод Create() для создания определенной книги.

```C#
using BooksFactoryLib.AbstractModels;
using BooksFactoryLib.Factories;
using BooksFactoryLib.Models;
using System;

namespace BooksFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем фабрику для электронных книг
            ElectronicBooksFacrtory electronicFactory = new ElectronicBooksFacrtory();

            // Создаем электронные книги (экземпляры класса)
            Books electronicMumu = electronicFactory.CreateMumu();
            Books electronicRevizorro = electronicFactory.CreateRevizorro();
            Books electronicTenLittleIndians = electronicFactory.CreateTenLittleIndians();

            // Создаем книги с помощью метода Create
            electronicMumu.Create();
            electronicRevizorro.Create();
            electronicTenLittleIndians.Create();

            // Создаем фабрику для бумажных книг
            ClassicBooksFactory classicFactory = new ClassicBooksFactory();

            // Создаем бумажные книги
            Books classicMumu = classicFactory.CreateMumu();
            Books classicRevizorro = classicFactory.CreateRevizorro();
            Books classicTenLittleIndian = classicFactory.CreateTenLittleIndians();

            // Создаем книги с помощью метода Create
            classicMumu.Create();
            classicRevizorro.Create();
            classicTenLittleIndian.Create();
            Console.ReadKey();
        }
    }
}
```


### Пример реализации паттерна в области Одежды

Допустим, одежда бывает 2 видов: спортивная и повседневная. Пусть, к этим видам будут относятся конкретные предметы гардероба, а именно: футболка и штаны.
___Пункт___ ___1___. Создаем два абстрактных класса Tshirt и Trousers. Для них можно создать как один метод, так и два разных, мы создадим два для лучшей наглядности. UpClothes() для футболки и DownClothes() для штанов.

```C#
namespace abstractFactoryLib
{
    public abstract class Tshirt
    {
        public abstract void UpClothes();
    }
}
```
```C#
namespace abstractFactoryLib
{
    public abstract class Trousers
    {
        public abstract void DownClothes();
    }
}
```

___Пункт___ ___2___
Далее, создаем классы-наследники. Они будут реализовывать методы вышесозданных абстрактных классов. В данном случае:

```C#
using System;

namespace abstractFactoryLib
{
    public class CasualTrousers : Trousers
    {
        public override void DownClothes()
        {
            Console.WriteLine("Надеты повседневные штаны");
        }
    }
}
```
```C#
using System;

namespace abstractFactoryLib
{
    public class SportsTrousers : Trousers
    {
        public override void DownClothes()
        {
            Console.WriteLine("Надеты спортивные штаны");
        }
    }
}
```
Аналогично для остальных.

___Пункт___ ___3___. Создаем класс фабрики по производству одежды, в котором будет 2 метода: создание футболки CreateTshirt() и создание штанов CreateTrousers().

```C#
namespace abstractFactoryLib
{
    public abstract class ClothesFactory
    {
        public abstract Tshirt CreateTshirt();
        public abstract Trousers CreateTrousers();
    }
}
```

___Пункт___ ___4___. Создаем конкретные фабрики, которые будет создвать объекты одного семейства. Они наследуют методы из главной фабриики: фабрика спортивной одежды SportsClothesFactory и фабрика повседневной одежды CasualClothesFactory.

```C#
namespace abstractFactoryLib
{
    public class CasualClothesFactory : ClothesFactory
    {
        public override Tshirt CreateTshirt()
        {
            return new CasualTshirt();
        }

        public override Trousers CreateTrousers()
        {
            return new CasualTrousers();
        }
    }
}

```

```C#
namespace abstractFactoryLib
{
    public class SportsClothesFactory: ClothesFactory
    {
        public override Tshirt CreateTshirt()
        {
            return new SportsTshirt();
        }

        public override Trousers CreateTrousers()
        {
            return new SportsTrousers();
        }
    }
}

```

___Пункт___ ___4___. Создадим консольное приложение для того, чтобы убедиться в правильности нашей реализации. Далее создаем экземляр класса вызвав метод CreateTshirt() или CreateTrousers(), а затем вызвать метод, который будет показывать "что надето".

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abstractFactoryLib;


namespace abstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем фабрику для спортивной одежды
            ClothesFactory sportsFactory = new SportsClothesFactory();

            // Создаем спортивные штаны и футболку
            Tshirt sportsTshirt = sportsFactory.CreateTshirt();
            Trousers sportsTrousers = sportsFactory.CreateTrousers();

            Console.WriteLine("Спортивная одежда\n");

            sportsTshirt.UpClothes();
            sportsTrousers.DownClothes();

            // Создаем фабрику для повседневной одежды
            ClothesFactory casualFactory = new CasualClothesFactory();

            // Создаем повседневные штаны и футболку
            Tshirt casualTshirt = casualFactory.CreateTshirt();
            Trousers casualTrousers = casualFactory.CreateTrousers();

            Console.WriteLine("\nПовседневная одежда\n");

            casualTshirt.UpClothes();
            casualTrousers.DownClothes();
            Console.ReadKey();
        }
    }
}
```

### Пример реализации паттерна в области Фарм Компании

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
Проверим работу и напишем консольное приложение.
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
