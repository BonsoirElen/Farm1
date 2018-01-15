using System;
using System.Collections.Generic;

namespace ДиминКод
{
    public enum РамкаРежимВывода
    {
        Неопределенный      = -1,
        ВнутреннийБордюр    = 0,
        ЛинияВерхняя        = 1,
        ЛинияПромежуточная  = 2,
        ЛинияНижняя         = 3,
    }



    public interface IРамкаКонсоли
    {
        void ВыводСтрокиРамки (РамкаРежимВывода Режим, int Ширина = 0);
        void ВыводЗаголовка (int Строка);
        void ВыводСодержимого (int Строка);
    }



    public class РамкаКонсоли : IРамкаКонсоли
    {
        void IРамкаКонсоли.ВыводЗаголовка (int Строка)
        {
        }

        void IРамкаКонсоли.ВыводСодержимого (int Строка)
        {
        }

        void IРамкаКонсоли.ВыводСтрокиРамки (РамкаРежимВывода Режим, int Ширина)
        {
        }
    }




    static class ВыводРамки
    {
        public static char[] ВерхняяЛиния   = {'╒', '═', '╕'};
        public static char[] ЛинияЗаголовка = {'├', '─', '┤'};
        public static char[] СредняяЛиния   = {'│', ' ', '│'};
        public static char[] НижняяЛиния    = {'╘', '═', '╛'};

        public static void ВыводЛинии (int Ширина, char[] НаборСимволов)
        {
            Console.Write(НаборСимволов[0]);

            for (int I = 1; I < Ширина - 2; I++)
            {
                Console.Write(НаборСимволов[1]);
            }

            Console.WriteLine(НаборСимволов[2]);
        }

        public static void ВыводЛинии (char[] НаборСимволов)
        {
            int ШиринаЭкрана = Console.WindowWidth;
            ВыводЛинии(ШиринаЭкрана, НаборСимволов);
        }

        public static void ВыводВерхнейЛинии ()
        {
            ВыводЛинии(ВерхняяЛиния);
        }

        public static void ВыводНижнейЛинии ()
        {
            ВыводЛинии(НижняяЛиния);
        }

        public static void Вывод (string Текст, int Ширина, bool Инверсия = false)
        {
            int ИтоговаяШирина = Текст.Length - 2;
            int ШиринаЭкрана = Console.WindowWidth;

            if (ИтоговаяШирина <= ШиринаЭкрана)
            {
                Текст = Текст.PadRight(ШиринаЭкрана - 3, ' ');
            }

            Console.Write(СредняяЛиния[0]);

            ConsoleColor ЦветФона    = Console.BackgroundColor;
            ConsoleColor ЦветТекста  = Console.ForegroundColor;

            if (Инверсия)
            {
                Console.BackgroundColor = ЦветТекста;
                Console.ForegroundColor = ЦветФона;
            }

            Console.Write(Текст);

            Console.BackgroundColor = ЦветФона;
            Console.ForegroundColor = ЦветТекста;

            Console.Write(СредняяЛиния[2]);
            Console.WriteLine();
        }

        public static void Вывод (string Текст, bool Инверсия = false)
        {
            int ШиринаЭкрана = Console.WindowWidth;
            Вывод(Текст, ШиринаЭкрана, Инверсия);
        }
    }



    class Меню
    {
        List<string>    СписокЗаголовков    = new List<string> ();
        List<string>    СписокПункт         = new List<string> ();
        List<int>       СписокЗначений      = new List<int> ();

        int ВыбранныйПункт = 1;

        public void ДобавитьЗаголовок (string Заголовок)
        {
            СписокЗаголовков    .Add(Заголовок);
        }

        public void ДобавитьПункт (int Значение, string Заголовок)
        {
            СписокПункт         .Add(Заголовок);
            СписокЗначений      .Add(Значение);
        }

        public int Выбор (params string[] ВопросыМеню)
        {
            Console.CursorVisible = false;

            int ТекущаяСтрока = Console.CursorTop;
            bool ВыборСделан = false;

            while (! ВыборСделан)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = ТекущаяСтрока;
                ВыводРамки.ВыводВерхнейЛинии();

                if (ВопросыМеню.Length > 0)
                    СписокЗаголовков.AddRange(ВопросыМеню);

                foreach (string ЗаголовокМеню in СписокЗаголовков)
                {
                    ВыводРамки.Вывод(" " + ЗаголовокМеню + " ");
                }

                ВыводРамки.ВыводЛинии(ВыводРамки.ЛинияЗаголовка);

                int НомерДействия = 1;
                foreach (string ОдинПункт in СписокПункт)
                {
                    ВыводРамки.Вывод(" " + ОдинПункт + " ", НомерДействия == ВыбранныйПункт);
                    НомерДействия++;
                }

                ВыводРамки.ВыводНижнейЛинии();

                ConsoleKeyInfo ОтветИгрока = Console.ReadKey(true);
                if (ОтветИгрока.Key == ConsoleKey.UpArrow)
                {
                    if (ВыбранныйПункт > 1) ВыбранныйПункт--;
                }
                else if (ОтветИгрока.Key == ConsoleKey.DownArrow)
                {
                    if (ВыбранныйПункт < СписокЗначений.Count) ВыбранныйПункт++;
                }
                else if (ОтветИгрока.Key == ConsoleKey.Enter)
                {
                    return СписокЗначений[ВыбранныйПункт - 1];
                }
            }

            return 0;
        }
    }



    class Меню1
    {
        List<string>    СписокЗаголовков    = new List<string> ();
        List<int>       СписокЗначений      = new List<int> ();

        public void ДобавитьПункт (int Значение, string Заголовок)
        {
            СписокЗаголовков    .Add(Заголовок);
            СписокЗначений      .Add(Значение);
        }

        public int Выбор (params string[] ВопросыМеню)
        {
            int ТекущаяСтрока = Console.CursorTop;
            bool ВыборСделан = false;
            int ПовторВопроса = 0;

            while (! ВыборСделан)
            {
                Console.CursorTop = ТекущаяСтрока;
                ВыводРамки.ВыводВерхнейЛинии();

                foreach (string ВопросМеню in ВопросыМеню)
                {
                    ВыводРамки.Вывод(" " + ВопросМеню + " ");
                }

                ВыводРамки.ВыводЛинии(ВыводРамки.ЛинияЗаголовка);

                int НомерДействия = 1;
                foreach (string ОдинЗаголовок in СписокЗаголовков)
                {
                    ВыводРамки.Вывод(" " + НомерДействия + ". " + ОдинЗаголовок + " ");
                    НомерДействия++;
                }

                ВыводРамки.ВыводНижнейЛинии();

                if (ПовторВопроса > 0)
                {
                    int НомерСтроки = Console.CursorTop;
                    Console.WriteLine(" ".PadRight(Console.WindowWidth));
                    Console.CursorTop = НомерСтроки;

                    ConsoleColor ПредыдущийЦвет = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Повторите ввод: ");
                    Console.ForegroundColor = ПредыдущийЦвет;
                }
                else
                {
                    Console.Write("Укажите номер действия: ");
                }
                ПовторВопроса++;

                string ОтветИгрока = Console.ReadLine();
                int ВыборИгрока;
                if (int.TryParse(ОтветИгрока, out ВыборИгрока))
                {
                    if ((ВыборИгрока >= 1) && (ВыборИгрока <= СписокЗначений.Count))
                    {
                        return СписокЗначений[ВыборИгрока - 1];
                    }
                }
            }

            return 0;
        }
    }
}

