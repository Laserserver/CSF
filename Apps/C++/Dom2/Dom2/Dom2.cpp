// Dom2.cpp: определяет точку входа для консольного приложения.
//
#include <iostream> 
using namespace std;

void T1()
{
	struct S
	{
		char c;
		S *next, *prev;
	};
	S a[] = {
		{ 'O', a + 1, NULL },
		{ 'R', a + 2, a },
		{ 'R', a + 3, a + 1 },
		{ 'O', a + 4, a + 2 },
		{ 'S', a + 5, a + 3 },
		{ 'G', a + 6, a + 4 },
		{ 'S', NULL, a + 5 } };
	S *p = a; /////двусвязный список
	do {
		cout << p->c;
		p = p->next;
	} while (p->next != NULL);
	while (p != NULL);
	{
		cout << p->c;
		p = p->next;
	}

}

void T2()
{
	struct S { S *next; int d; };
	S *list = NULL, *p, *last; //очередь
	int d[] = { 8,0,5,8,9,9,9,7,1,5 }, i;
	for (i = 0; i < sizeof(d) / sizeof(int); i++)
	{
		p = new S; p->d = d[i]; p->next = NULL;
		if (i)last = last->next = p;
		else list = last = p;
	}
	while (list != NULL)
	{
		p = list; cout << p->d << ' ';
		list = list->next; delete p;
	}
}

void T3()
{
	struct S { S *next; char c; };
	S *list = NULL, *p;
	char *s = "ZGNYRKLJWW";
	while (*s) ///стек
	{
		p = new S; p->c = *s++;
		p->next = list; list = p;
	}
	while (list != NULL)
	{
		p = list;; cout << p->c;
		list = list->next; delete p;
	}
}

void T4()
{
	struct S { char *s; S *next; };
	S a[] = { "tmglkd", a + 1, "HZKMGL", a + 2, "vpogd", a + 3, "PBTX", a + 4, "hyp", NULL };
	S *p = a;
	while (p != NULL)
	{
		cout << p->s << ' '; p = p->next;
	}
}

void T5()
{
	struct S { int d; S *next; };
	S a[] = { 1, a + 1, 8, a + 2, 3, a + 3, 5, a + 4, 5, a + 5, 7, a + 6, 2, NULL };
	S *p = a + 4;
	p->next = p->next->next; p = a;
	while (p != NULL)
	{
		cout << p->d << ' '; p = p->next;
	}
}


void T6()
{
	struct S { S *next; int d; };
	S a[] = { a + 6,5,a,5,a + 1,6,a + 2,7,a + 3,4,a + 4,6,a + 5,0 };
	S *p = a;
	do {
		cout << p->d << ' '; p = p->next;
	} while (p != a);
}

//pfvtyf 
void T7()
{
	struct S { S *next; char c; };
	S a[] = { a + 1, 'i', a + 2, 'k', a + 3, 'm', a + 4, 'q', a + 5, 'x', a + 6, 'q', NULL,'s' };
	S s = { NULL, 'G' }, *p = a + 5;
	s.next = p->next->next; p->next = &s; p = a;
	while (p != NULL)
	{
		cout << p->c << ' '; p = p->next;
	}
}

void T8()
{
	struct S { int d; S *next; };
	S a[] = { 2, NULL, 8, a, 2, a + 1, 1, a + 2, 6, a + 3, 2, a + 4, 5, a + 5 };
	S *p = a + sizeof(a) / sizeof(S) - 1;
	while (p != NULL)
	{
		cout << p->d << ' '; p = p->next;
	}
}

//////////////////////////////АТТ 3 by Y.miller 
void T9()
{
	struct S
	{
		char c[4]; int i[4]; float f[4];
	};
	union U
	{
		char c[4]; int i[4]; float f[4];
	};
	cout << sizeof(S) << ' ' << sizeof(U);
}

void T10()
{
	struct S
	{
		char c, *s;
	}
	s = { 'c', "vwdx" };
	cout << ++s.c << ' ' << ++s.s;
}

void T11()
{
	struct
	{
		struct {
			char c[10];
		} s;
		char c[10];
	} s1 = { "bye", "twr" };
	cout << s1.c[2] << ' ' << s1.c << s1.s.c[0] << ' ' << s1.s.c;
}

void T12()
{
	struct //////такой же struct
	{
		union { int a[4], b[4]; };
		union { int c[6], d[6]; };
	} u = { 3,1,7,7,0,5,9,7,2,0 };
	cout << u.a[2] << ' ' << u.b[2] << ' '
		<< u.c[4] << ' ' << u.d[4];
}

///////////////////////////ВНУТРЕННЕЕ ПРЕДСТАВЛЕНИЕ 
void T13()
{
	union
	{
		short s; unsigned char c[2];
	} u = { 808 };
	cout << (int)u.c[0] << ' ' << (int)u.c[1];
}
///////////////////////////ВНУТРЕННЕЕ ПРЕДСТАВЛЕНИЕ 
void T14()
{
	union { unsigned char c[2]; short s; } u = { 39, 2 };
	cout << sizeof(u) << ' ' << u.s;
}
//////////////////ВНУТРЕННЕЕ ПРЕДСТАВЛЕНИЕ 
void T15()
{
	struct S { short a, b; };
	union U
	{
		long c[5];
		S d[5];
	}
	u = { 8,5,0,7,8 };
	cout << u.c[2] << ' ' << u.d[1].a
		<< ' ' << u.d[2].b;

}

void T16()
{
	union /////union
	{
		struct ///struct
		{
			union { char a[2]; char b[3]; }c[4];
			struct { char a[5]; char b[6]; }d[7];
		}e[8];
	}f[9];
	cout << sizeof(f) << ' ' << sizeof(f[3].e)
		<< ' ' << sizeof(f[4].e[1].d) << ' '
		<< sizeof(f[0].e[4].c[3]) << ' '
		<< sizeof(f[4].e[6].d[6].a);
}

void main()
{
	int Case = 0;
	cin >> Case;
	switch (Case)
	{
	case 1:
		T1();
		break;
	case 2:
		T2();
		break;
	case 3:
		T3();
		break;
	case 4:
		T4();
		break;
	case 5:
		T5();
		break;
	case 6:
		T6();
		break;
	case 7:
		T7();
		break;
	case 8:
		T8();
		break;
	case 9:
		T9();
		break;
	case 10:
		T10();
		break;
	case 11:
		T11();
		break;
	case 12:
		T12();
		break;
	case 13:
		T13();
		break;
	case 14:
		T14();
		break;
	case 15:
		T15();
		break;
	case 16:
		T16();
		break;
	}
	cin.ignore();
}