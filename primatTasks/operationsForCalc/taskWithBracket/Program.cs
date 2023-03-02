using System;

namespace labApp1
{
    class Program
    {
        // проверка пустой ли у нас стэк
        static bool StackEmpty(string[] stack)
        {
            if (stack[0] == "")
                return true;
            else
                return false;
        }

        //добавляем элемент в стэк
        static void PushStack(ref string[] stack, string smb)
        {
            for (int i = 0; i < stack.Length; i++)
                if (stack[i] == "")
                {
                    stack[i] = smb;
                    break;
                }
        }

        // удаляем элемент из стэка 
        static void PopStack(ref string[] stack)
        {
            if (!StackEmpty(stack))
                for (int i = 0; i < stack.Length; i++)
                    if (stack[i] == "")
                    {
                        stack[i - 1] = "";
                        break;
                    }
        }
        // ищем элемент в стэке (в нашем случаем скобка есть ли там наша)
        static bool SearchElStack(string[] stack, string elem)
        {
            if (!StackEmpty(stack))
                for (int i = 0; i < stack.Length; i++)
                    if (stack[i] == "")
                        if(stack[i-1] == elem)
                            return true;
            return false;
        }
        // сам метод проверки скобок
        static bool CheckBrackets(string brackets)
        {
            // размер строки со скобками
            int lenghtLine = brackets.Length;
            
            //массив где будут лежать строки
            string[] line = new string[lenghtLine];
            for (int i = 0; i < lenghtLine; i++)
                //переводим из char к string в новый массив
                line[i] = Convert.ToString(brackets[i]);
           
            // наш массив строчный стэк
            string[] stack = new string[lenghtLine];
            for (int i = 0; i < lenghtLine; i++)
                stack[i] = "";
            
            //проходим по нашему выражению 
            for (int i = 0; i < lenghtLine; i++)
            {
                // скобка которую будем рассматривать
                string symbol;
                symbol = line[i];
                // если в стэке последний элемент открывающаяся скобка а наша текущая такая же закрывающаяся, то 
                // удаляем ласт скобку со стэка
                if ((symbol == "}" && SearchElStack(stack, "{")) || (symbol == ")" && SearchElStack(stack, "(")) ||
                    (symbol == "]" && SearchElStack(stack, "[")))
                    PopStack(ref stack);
                //иеначе мы заносим эту скобку в стэк(если она не подходит, то она потом останется и будет false)
                else if (symbol == "(" || symbol == "{" || symbol == "[" || symbol == ")" || symbol == "}" || symbol == "]")
                    PushStack(ref stack, line[i]);
            }
            
            //итоговая проверка на пустоту (если пустой то всё ок и скобки правильно расставлены)
            if (StackEmpty(stack))
                return true;
            else 
                return false;
        }
        
        static void Main(string[] args)
        {
            //string brackets = "()[({}())]";
            //string brackets = "())))";
            //string brackets = "()()[{[({}())]}]";
            //string brackets = "({[([{";
            string brackets = "()[({}())][((()))]]";
            Console.WriteLine(CheckBrackets(brackets));
        }
    }
}


/*На вход подаётся строка, состоящая из скобок. 
    Программа должна определить правильность введённого скобочного выражения.
    В строке будут скобки  типа: или "()" , или "{}", или "[]"
Пример входа:
()[({}())]*/
