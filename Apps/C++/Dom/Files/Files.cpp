// Files.cpp: определяет точку входа для консольного приложения.
//
#include <iostream>
#define _USE_MATH_DEFINES
#include <math.h>
#include <stdlib.h>
#include <fstream>
using namespace std;

struct Sub
{
	int Case;
	char Name[12];
	char Surname[20];
	union
	{
		struct
		{
			char Class[10];
			char Hours[10];
			char Age[10];
		} Pupil;
		struct
		{
			char MidName[20];
			char Profession[20];
			char Classes[11][3];
		} Teacher;
	};
};
struct List2
{
	Sub Data;
	List2 *Next;
};

char Add();
char Delete();
char Save();
char Load();
char GetList();
void Exit();

List2 *LST = new List2();
int Count = 0;
void main()
{
	typedef char(*TItm)();
	setlocale(LC_CTYPE, "Russian");
	LST->Next = NULL;
	TItm menu[] = { Add, Delete, GetList, Save, Load };

	int itm = 0, res = 0;
	do
	{
		cout << "1. Добавить\n2. Удалить\n3. Вывести\n4. Сохранить\n5. Загрузить\n6. Выход\n";
		cin >> itm;
		if (itm > 0 && itm < 6)
		{
			res = menu[itm - 1]();
		}
		cout << endl;
	} while (itm < 6 && res);
	Exit();
	cin.ignore();
}

char Add()
{
	try
	{
		int temp = 0;
		cout << "Добавка. Ввод общих данных:\n";
		Sub New;
		cout << "Имя" << endl;
		cin >> New.Name;
		cout << "Фамилия" << endl;
		cin >> New.Surname;
		cout << "0 - ученик, не 0 - учитель.\n";
		cin >> temp;
		if (!(New.Case = temp))
		{
			cout << "Ввод данных школяра:\nКласс" << endl;
			cin >> New.Pupil.Class;
			cout << "Возраст" << endl;
			cin >> New.Pupil.Age;
			cout << "Часы учебы" << endl;
			cin >> New.Pupil.Hours;
		}
		else
		{
			cout << "Ввод данных учителя:\nОтчество" << endl;
			cin >> New.Teacher.MidName;
			cout << "Направление" << endl;
			cin >> New.Teacher.Profession;
			int i = -1;
			int CC = 0;
			cout << "Классы, введите количество: ";
			cin >> CC;

			for (i = 0; i < CC; i++)
				cin >> New.Teacher.Classes[i];
			while (i < 11)
				*New.Teacher.Classes[i++] = NULL;
		}
		List2 *x = new List2();
		x->Next = LST;
		x->Data = New;
		LST = x;
		Count++;
		return 1;
	}
	catch (int res)
	{
		res = 0;
		return res;
	}
}

char Delete()
{
	try
	{
		int Num = 0;
		cout << endl << "Какой удалить? ";
		cin >> Num;
		Num--;
		List2 *p = LST, *q = LST;
		if (Num)
		{
			for (int i = 0; i < Num; i++)
				p = p->Next;
			q = p->Next;
			p->Next = q->Next;
			delete q;
		}
		else
		{
			p = LST;
			LST = LST->Next;
			delete p;
		}
		Count--;
		return 1;
	}
	catch (int res)
	{
		res = 0; return res;
	}
}

char GetList()
{
	try
	{
		int Num = 1;
		List2 *p = LST;
		while (p->Next)
		{
			cout << endl << Num++ << " запись:\n" << "Имя: " << p->Data.Name << endl << "Фамилия: " << p->Data.Surname << endl << "Тип: ";
			if (!(p->Data.Case))
				cout << "Ученик" << endl << "Возраст: " << p->Data.Pupil.Age << endl << "Класс: " << p->Data.Pupil.Class << endl << "Часы учебы: " << p->Data.Pupil.Hours;
			else
			{
				cout << "Учитель" << endl << "Отчество: " << p->Data.Teacher.MidName << endl << "Направление: " << p->Data.Teacher.Profession << endl << "Классы: ";
				int i = 0;
				while (*p->Data.Teacher.Classes[i])
					cout << p->Data.Teacher.Classes[i++] << ' ';
			}
			p = p->Next;
		}
		cout << endl;
		return 1;
	}
	catch (int res)
	{
		res = 0;
		return res;
	}
}

char Save()
{
	try
	{
		ofstream font("tex.txt");
		List2 *p = LST;
		font << Count << endl;
		while (p->Next)
		{
			font << p->Data.Name << endl << p->Data.Surname << endl << p->Data.Case << endl;
			if (p->Data.Case) //Учитель
			{
				font << p->Data.Teacher.MidName << endl << p->Data.Teacher.Profession << endl;
				for (int i = 0; i < 10; i++)
					font << p->Data.Teacher.Classes[i] << endl;
				font << p->Data.Teacher.Classes[10];
			}
			else
				font << p->Data.Pupil.Class << endl << p->Data.Pupil.Age << endl << p->Data.Pupil.Hours;
			font << endl;
			p = p->Next;
		}
		font.close();
		return 1;
	}
	catch (int res)
	{
		res = 0; return res;
	}
}

char Load()
{
	try
	{
		Exit();
		LST = new List2();
		LST->Next = NULL;
		Count = 0;
		ifstream fin("tex.txt");
		char buff[50];
		fin.getline(buff, 50);
		char Let = buff[0];
		for (char i = 0; i < Let % 48; i++, Count++)
		{
			Sub *New = new Sub();
			fin.getline(New->Name, 50);
			fin.getline(New->Surname, 50);
			char Case[50];
			fin.getline(Case, 50);
			New->Case = Case[0] % 48;
			if (New->Case) //Учитель
			{
				fin.getline(New->Teacher.MidName, 50);
				fin.getline(New->Teacher.Profession, 50);
				for (int i = 0; i < 11; i++)
					fin.getline(New->Teacher.Classes[i], 3);
			}
			else
			{
				fin.getline(New->Pupil.Class, 50);
				fin.getline(New->Pupil.Age, 50);
				fin.getline(New->Pupil.Hours, 50);
			}
			List2 *x = new List2();
			x->Next = LST;
			x->Data = *New;
			LST = x;
		}

		fin.close();
		return 1;
	}
	catch (int res)
	{
		res = 0; return res;
	}
}

void Exit()
{
	List2 *p = LST;
	while (LST)
	{
		p = LST;
		LST = p->Next;
		delete p;
	}
}

void Task29()
{
	int Length = 0;
	cout << "Count" << endl;
	cin >> Length;

	int temp = 0;

	List2 *p = LST;
	int z = 1;

	cout << endl << "What delete? >> ";
	int Num = 0;
	cin >> Num;
	p = LST;
	if ((Num - 1))
	{
		for (int i = 0; i < Num - 2; i++)
			p = p->Next;
		if (p->Next)
			p->Next = p->Next->Next;
	}
	else
	{
		p = LST;
		LST = LST->Next;
	}
	p = LST;
	z = 1;
	while (p->Next)
	{
		cout << endl << z++ << ". ";
		//OutHuman(p->Data);
		p = p->Next;
	}
	p = LST;
	while (p->Next)
	{
		List2 *q = p;
		q = q->Next;
		delete p;
	}
	delete LST;
}