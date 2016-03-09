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

void main()
{
	int D = 0;
	cin >> D;
	double n, HA, HB, HC, p, a, k = 0;
	int l = 0;

	switch (D)
	{
	case 1:
	{
		int A, B, C;
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
		break;
	}

	case 2:
	{
		n = 2000000;
		a = pow((1 + 1 / n), n);
		cout << a << endl;

		cout << M_E << endl;
		cout << M_E - a;
		break;
	}
	case 3:
	{
		do
		{
			k++;
			l++;
		} while (M_E - pow((1 + 1 / k), k) > 0.00001);
		cout << "Итераций: " << l << endl;
		break;
	}
	case 4:
	{
		cout << "Go impulse 101 on their heads: ";
		cin >> HA;
		cout << "Log(10): " << log10(HA) << endl;
		cout << "Log(e): " << log10(HA) / M_LOG10E << endl;
		break;
	}
	case 5:
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
		break;
	}
	case 6:
	{
		cout << "Factorial" << endl;
		cout << "To ";
		int k = 0;
		cin >> k;
		double out = 1;
		for (int i = 1; i <= k; i++)
			out += 1.0 / Fact(i);
		cout << out;
		break;
	}
	case 7:
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

		break;
	}
	case 8:
	{
		cout << "sin 2 / 2 = " << 1.0*sin(2.0) / 2 << endl;
		double Mult = 1.0 - 4.0 / (M_PI * M_PI);
		int i = 2;
		do
		{
			Mult *= (1.0 - 4.0 / (M_PI * M_PI * i * i++));
		} while (i != 10000 && 1.0 - 4.0 / (M_PI*M_PI) - Mult > 0.001);

		cout << endl << Mult << " for " << i;
		break;
	}

	case 13:
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
		break;
	}
	case 14:
	{
		{
			double First = M_LN2 - 0.5;
			cout << "1/2 * (1 - ln 2) = " << First << endl;
			double Sum = 0;
			double n = 1;
			for (double i = 1; First - Sum > 0.0001; i++)
			{
				Sum += 1.0 / ((2.0 * i - 1.0) * 2.0 * i * (2.0 * i + 1.0));
				n = i;
				cout << Sum << endl;
			}

			/*do
			{
			Sum += pow(-1.0, n + 1) * 1.0 / ((2 * n - 1) * 2 * n * (2 * n + 1));
			} while (n++ != 1000);*/

			cout << endl << Sum << " for " << n;
		}
		break;
	}
	default:
		cout << "FUCK YOU, FAGGOT";
		break;
	}
	cin.ignore();
	cin.ignore();
}