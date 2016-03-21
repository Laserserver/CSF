// TEST.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#define _USE_MATH_DEFINES
#include <math.h>
using namespace std;

static long Fact(int To)
{
	long Factor = 1;
	if (To = 0)
		Factor = 1;
	else
		for (int l = To; l > 0; l--)
			Factor *= l;
	return Factor;
}
static void GetData()
{
	cout << "1 - Triangle" << endl;
	cout << "2 - Not working shit" << endl;
	cout << "3 - Exponent iterations" << endl;
	cout << "4 - Logarithms" << endl;
	cout << "5 - Cycles" << endl;
	cout << "6 - Factorial" << endl;
	cout << "7 - Precise factorial" << endl;
	cout << "8 - Sinus summation" << endl;
	cout << "9 - Arithm if-else" << endl;
	cout << "10 - Arithm switch" << endl;
	cout << "11 - Arithm ternar" << endl;
	cout << "12 - Chetnost'" << endl;
	cout << "13 - Summation" << endl;
	cout << "14 - Array/Matrix" << endl;
	cout << "15 - Binary chet" << endl;
	cout << "16 - Pointers" << endl;
	cout << "17 - Strings" << endl;
}

static void Task1()
{
	int A, B, C;
	double HA, HB, HC, p;
	cout << "A: ";
	cin >> A;
	cout << "B: ";
	cin >> B;
	cout << "C: ";
	cin >> C;

	p = (A + B + C) / 3;

	HA = (double)sqrt(p*(A - p)*(A - p)*(A - p)) * 2 / A;
	HB = (double)sqrt(p*(A - p)*(A - p)*(A - p)) * 2 / B;
	HC = (double)sqrt(p*(A - p)*(A - p)*(A - p)) * 2 / C;

	cout << HA << endl << HB << endl << HC;
}

static void Task2()
{
	double n = 2000000, a = pow((1 + 1 / n), n);
	cout << a << endl;

	cout << M_E << endl;
	cout << M_E - a;
}

static void Task3()
{
	double k = 0, l = 0;
	do
	{
		k++;
		l++;
	} while (M_E - pow((1 + 1 / k), k) > 0.00001);
	cout << "Итераций: " << l << endl;
}

static void Task4()
{
	double HA = 0;
	cout << "Go impulse 101 on their heads: ";
	cin >> HA;
	cout << "Log(10): " << log10(HA) << endl;
	cout << "Log(e): " << log10(HA) / M_LOG10E << endl;
}

static void Task5()
{
	cout << "for" << endl;
	for (int i = 1; i < 11; i++)
		cout << i << " ";

	cout << endl << "do-while" << endl;
	int l = 1;
	do
	{
		cout << l << " ";
		l++;
	} while (l < 11);
	cout << endl << "while" << endl;
	l = 1;
	while (l < 11)
	{
		cout << l << " ";
		l++;
	}

	cout << endl << "goto" << endl;
	l = 1;
Increment:
	cout << l << " ";
	l++;
	if (l < 11)
		goto Increment;
}

static void Task6()
{
	cout << "Factorial" << endl;
	cout << "To ";
	int k = 0;
	cin >> k;
	double out = 1;
	for (int i = 1; i <= k; i++)
		out += 1.0 / Fact(i);
	cout << out;
}

static void Task7()
{
	cout << "Factorial" << endl;
	double a = 0;
	cin >> a;
	double out = 1;
	int i = 0;
	do
	{
		out += 1.0 / Fact(i);
		i++;
	} while (M_E - out < a);
	cout << endl << i << " iterations for " << a << " precise";
}

static void Task8()
{
	cout << "sin 2 / 2 = " << 1.0*sin(2.0) / 2 << endl;
	double Mult = 1.0 - 4.0 / (M_PI * M_PI);
	int i = 2;
	do
	{
		Mult *= (1.0 - 4.0 / (M_PI * M_PI * i * i++));
	} while (i != 10000 && 1.0 - 4.0 / (M_PI*M_PI) - Mult > 0.001);

	cout << endl << Mult << " for " << i;
}

static void Task9()
{
	cout << "Aryphmetic if-else" << endl;
	char Sign;
	cin >> Sign;
	int L, R;
	cin >> L;
	cin >> R;
	if (R == 0 && Sign == '/')
		cout << "Problem";
	else
	{
		if (Sign == '+')
			cout << L + R;
		else
			if (Sign == '-')
				cout << L - R;
			else
				if (Sign == '/')
					cout << L / R;
				else
					if (Sign == '*')
						cout << L*R;
					else
						cout << "Fuck u";
	}
}

static void Task10()
{
	cout << "Aryphmetic switch" << endl;
	char Sign;
	cin >> Sign;
	int L, R;
	cin >> L;
	cin >> R;
	if (R == 0 && Sign == '/')
		cout << "Problem";
	else
	{
		switch (Sign)
		{
		case '+':
			cout << L + R;
			break;
		case '-':
			cout << L - R;
			break;
		case '/':
			cout << L / R;
			break;
		case '*':
			cout << L*R;
			break;
		default:
			cout << "Fuck u";
			break;
		}
	}
}

static void Task11()
{
	cout << "Aryphmetic ternar" << endl;
	char Sign;
	cin >> Sign;
	int L, R;
	cin >> L;
	cin >> R;
	if (R == 0 && Sign == '/')
		cout << "Problem";
	else
	{
		Sign == '+' ? (cout << L + R) :
			(Sign == '-' ? cout << L - R :
				(Sign == '/' ? cout << L / R :
					(Sign == '*' ? cout << L*R : cout << "Fuck u")));
	}
}

static void Task12()
{
	int In = 0;
	cin >> In;
	cout << "If" << endl;
	if (In % 2 == 1)
		cout << "Nechet";
	else
		cout << "Chet";
	cout << endl << "Switch" << endl;

	switch (In % 2)
	{
	case 1:
		cout << "Nechet";
		break;

	case 0:
		cout << "Chet";
		break;
	}

	cout << endl << "Ternar" << endl;
	In % 2 == 0 ? cout << "Chet" : cout << "Nechet";
}

static void Task13()
{
	double First = 0.5*(1 - M_LN2);
	cout << "1/2 * (1 - ln 2) = " << First << endl;
	double Sum = 0;
	double n = 1;
	do
	{
		Sum += pow(-1.0, n + 1) * 1.0 / ((2 * n - 1) * 2 * n * (2 * n + 1));
	} while (n++ != 1000);

	cout << endl << Sum << " for " << n;
}

static void Task14()
{

	int Caser = 0;
	cout << "1 - Array, 2 - Matrix" << endl;
	cin >> Caser;
	switch (Caser)
	{
		cout << "Arrays" << endl;
	case 1:
	{
		cout << "Max and Min" << endl;

		int Arr[10];
		for (int i = 0; i < 10; i++)
			cin >> Arr[i];
		int Min = Arr[0];
		int Max = Arr[0];
		for (int i = 0; i < 10; i++)
		{
			if (Arr[i] > Max)
				Max = Arr[i];
			if (Arr[i] < Min)
				Min = Arr[i];
		}
		cout << "Max: " << Max << endl << "Min: " << Min;
		break;
	}
	case 3:
	{
		cout << "Max and Min as one" << endl;

		int Arr[10];

		for (int i = 0; i < 10; i++)
			cin >> Arr[i];



		for (int i = 0; i < 10; i++)
		{
			int Count = 0;
			for (int j = 0; j < 10; j++)
				if (Arr[i] == Arr[j])
					Count++;
			if (Count > 1)
				cout << Arr[i];
		}
		break;
	}
	case 2:
	{
		cout << "Matrix" << endl;

		int Arr[3][3];
		for (int i = 0; i < 3; i++)
			for (int k = 0; k < 3; k++)
				cin >> Arr[i][k]; //по строкам
		for (int i = 0; i < 3; i++)
		{
			for (int k = 0; k < 3; k++)
				cout << Arr[i][k] << " ";
			cout << endl;
		}

		double Det = Arr[0][0] * Arr[1][1] * Arr[2][2] + Arr[0][2] * Arr[1][0] * Arr[2][1] + Arr[2][0] * Arr[0][1] * Arr[1][2] -
			Arr[0][2] * Arr[1][1] * Arr[2][0] - Arr[0][1] * Arr[1][0] * Arr[2][2] - Arr[0][0] * Arr[2][1] * Arr[1][2];
		cout << endl << "Det = " << Det;
		break;
	}
	}

}

static void Task15()
{
	int In = 0;
	cin >> In;
	cout << "Binary" << endl;
	if (In & 1)
		cout << "Nechet";
	else
		cout << "Chet";
}

static void Task16()
{
	cout << "Pointers" << endl;
	int a[10], *pa, i;

	for (i = 0, pa = a; i < 10; i++)
	{
		*pa = i;
		pa++;
		cout << pa << endl;
	}
	for (int i = 0; i < 10; i++)
	{
		cout << a[i] << endl;
	}
}

static void Task17()
{
	cout << "Strings" << endl;
	char str[13], *plol1, *plol2, *plol3, *plol4;
	cin >> str;
	int i;

	plol1 = &str[0];
	plol2 = &str[1];
	plol3 = &str[2];
	plol4 = &str[3];
	cout << *plol4 << *plol3 << *plol1 << *plol2;
	for (i = 0; i < 2; i++)
	{
		plol1 += 4;
		plol2 += 4;
		plol3 += 4;
		plol4 += 4;
		cout << *plol4 << *plol3 << *plol1 << *plol2;
	}
}

void main()
{
	GetData();
	int D = 0;
	cin >> D;

	switch (D)
	{
	case 1:
		Task1();
		break;

	case 2:
		Task2();
		break;

	case 3:
		Task3();
		break;

	case 4:
		Task4();
		break;

	case 5:
		Task5();
		break;

	case 6:
		Task6();
		break;

	case 7:
		Task7();
		break;

	case 8:
		Task8();
		break;

	case 9:
		Task9();
		break;

	case 10:
		Task10();
		break;

	case 11:
		Task11();
		break;

	case 12:
		Task12();
		break;

	case 13:
		Task13();
		break;

	case 14:
		Task14();
		break;

	case 15:
		Task15();
		break;

	case 16:
		Task16();
	break;

	case 17:
		Task17();
	break;

	default:
		cout << "FUCK YOU, FAGGOT";
		break;
	}

	cin.ignore();
	cin.ignore();
}