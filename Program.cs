﻿///   Подключение отдельных модулей кода
using System;
//using System.Drawing;
using ДиминКод;



///   ╒═╕├─┤ │╘═╛

///   Основной модуль кода нашей программы
namespace ИграПроФерму
{
    class РецептФермера
    {
        public string Имя;

    }


    class РецептФермы
    {
       public string Название;

       public bool ДождьИдет = true;

    }



    class МояПрограмма
    {
        static void Main (String[] ВходныеДанные)
        {
            РецептФермера МойФермер = new РецептФермера();
            РецептФермы МояФерма = new РецептФермы();
            Random ГенСлучДождя = new Random();

            Console.WriteLine("Как вас называть?");             //  Консоль -> ВыводСтроки (...)
            МойФермер.Имя = Console.ReadLine();                      //  Консоль -> СчитатьСтроку ()
            Console.WriteLine("Как назвается ваша ферма?");
            МояФерма.Название = Console.ReadLine();

            Console.WriteLine("Начинаем играть...");


            Меню МенюНовыйДень = new Меню ();
            МенюНовыйДень.ДобавитьЗаголовок
            (
                "Доброе утро, " + МойФермер.Имя + "! " +
                "Вы проснулись у себя на ферме " + МояФерма.Название + "." 
            );
            
            int СлучЧисло = ГенСлучДождя.Next(1, 100);
            МояФерма.ДождьИдет = СлучЧисло <= 25;
            if (МояФерма.ДождьИдет == true)  МенюНовыйДень.ДобавитьЗаголовок("За окном сегодня дождь.");
            if (МояФерма.ДождьИдет == false) МенюНовыйДень.ДобавитьЗаголовок("На улице сегодня ясно.");
            
            МенюНовыйДень.ДобавитьЗаголовок("Что будем делать?");
            МенюНовыйДень.ДобавитьПункт(1, "Смотреть новости в телевизоре");
            МенюНовыйДень.ДобавитьПункт(2, "Расчищать ферму (размер: 100)");
            МенюНовыйДень.ДобавитьПункт(3, "Ухаживать за посевами (посажено: 0)");
            МенюНовыйДень.ДобавитьПункт(4, "Исследовать новую территорию");
            int КодДействия = МенюНовыйДень.Выбор();


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Доброе утро! Вы проснулись у себя на ферме. ");
            Console.WriteLine(" На улице за окном сегодня ясно. ");
            Console.WriteLine(" Что будем делать? ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" 1. Смотреть новости в телевизоре ");
            Console.WriteLine(" 2. Расчищать ферму (размер: 100) ");
            Console.WriteLine(" 3. Ухаживать за посевами (посажено: 0) ");
            Console.WriteLine(" 4. Исследовать новую территорию ");
            Console.WriteLine("--------------------------------------------------");
            String ЧтоДелать = Console.ReadLine();
            Int32 НомерДействия2 = Int32.Parse(ЧтоДелать);
        }
    }
}


/*
            if (НашНаборВходящихАргументов.Length <= 0)
            {
                Console.BackgroundColor = (ConsoleColor) 11;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Привет, неизвестно кто!");
                Console.ReadLine();
            }
            else
            { 
                foreach (String ОдноИзИмен in НашНаборВходящихАргументов)
                {
                    Console.WriteLine("Привет, " + ОдноИзИмен + "!");
                }
            }
 */

 


///   Модуль кода "МатематикаОтВасяна"
namespace МатематикаОтВасяна
{
    public class ВасянскоеЧисло
    {
        public Int32 Значение;

        ///   Конструктор
        public ВасянскоеЧисло (Int32 НачальноеЗначение)
        {
            this.Значение = НачальноеЗначение;
        }

        ///   Функция переопределения оператора "плюс" 
        public static ВасянскоеЧисло operator + (ВасянскоеЧисло A, ВасянскоеЧисло B)
        {
            if ((A.Значение == 2) && (B.Значение == 2))
                return new ВасянскоеЧисло (5);
            else
                return new ВасянскоеЧисло (A.Значение + B.Значение);
        }

        ///   Второй вариант функции переопределения оператора "плюс" 
        public static ВасянскоеЧисло operator + (Int32 A, ВасянскоеЧисло B)
        {
            if ((B.Значение == 2) && (A == 2))
                return new ВасянскоеЧисло (5);
            else
                return new ВасянскоеЧисло (A + B.Значение);
        }

        ///   Второй вариант функции переопределения оператора "плюс" 
        public static ВасянскоеЧисло operator + (ВасянскоеЧисло A, Int32 B)
        {
            if ((B == 2) && (A.Значение == 2))
                return new ВасянскоеЧисло (5);
            else
                return new ВасянскоеЧисло (A.Значение + B);
        }
    }
}
