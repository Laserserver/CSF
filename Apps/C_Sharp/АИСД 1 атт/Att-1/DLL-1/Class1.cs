using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DLL_1
{
    public class MyNodeStr
    {
        public string inf { get; set; }
        public MyNodeStr next { get; set; }
        public int count { get; set; }
        public MyNodeStr(string inf, MyNodeStr next)            // Конструктор
        {
            this.inf = inf;
            this.next = next;
            this.count = 1;
        }
        public void AddCount()
        { count++; }
    }

    public class Dist
    {
        public string[] st;
        public MyNodeStr head { get; set; }                  // голова списка
        public int count { get; set; }                       // число элементов

        public Dist()
        {
            st = new string[0];
            head = null;
            count = 0;
        }

        public void AddSort(string inf)
        {
            if (head != null)
            {
                MyNodeStr q = head;
                int k = string.CompareOrdinal(inf, q.inf); // -1:s1<s2 0:s1=s2 1:s1>s2

                if (k <= 0)
                    if (k == 0)
                        q.AddCount();
                    else // вставить перед головой
                    {
                        MyNodeStr p = new MyNodeStr(inf, q);
                        head = p;
                    }
                else
                {
                    MyNodeStr r; // поиск: inf >= q.inf
                    do
                    {
                        r = q;
                        q = q.next;
                        if (q != null)
                            k = string.CompareOrdinal(q.inf, inf);
                    }
                    while ((q != null) && (k < 0));

                    if (q != null)
                        if (k == 0)
                            q.AddCount();
                        else // между r и q
                        {
                            MyNodeStr p = new MyNodeStr(inf, q);
                            r.next = p;
                        }
                    else    // за r
                    {
                        MyNodeStr p = new MyNodeStr(inf, null);
                        r.next = p;
                    }
                }
            }
            else
                head = new MyNodeStr(inf, null); // список пуст
            count++;
        }

        public void Open(string FileName)
        {
            FileStream aFile = new FileStream(FileName, FileMode.Open);
            StreamReader f = new StreamReader(aFile);
            int L = 0;
            string s = f.ReadLine();
            while (s != null)
            {
                L++;
                Array.Resize<string>(ref st, ++L);
                st[L - 1] = s;
                s = f.ReadLine();
            }
            f.Close();
            aFile.Close();
        }

        public string[] Printer()               // Вывод списка
        {
            string[] st = new string[0];
            int L = 0;
            MyNodeStr p = head;
            if (p != null)
                do
                {
                    Array.Resize<string>(ref st, ++L);
                    st[L - 1] = p.count.ToString() + " " + p.inf.ToString();
                    p = p.next;
                }
                while (p != null);
            return st;
        }

        public void SetList()
        {
            int L = st.Length;
            for (int i = 0; i < L; i++)
            {
                char[] sep = { ' ', '.', ';',':', '(',')', '{', '}', 
                                 '[', ']', '"', '=', '!', '<', '>','+','-','/','&', ',','|'};
                if (st[i] != null)
                {
                    string[] sArr = st[i].Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < sArr.Length; j++)
                        AddSort(sArr[j]);
                }
            }
        }

    }
}
