// Lexa.cpp: определяет точку входа для консольного приложения.
//
#include "stdafx.h" 
#include "typeinfo" 
#include "iostream" 
#include "conio.h" 
#include "stdio.h" 
#include "locale" 
#include "math.h" 


int main()
{
	setlocale(LC_ALL, "Russian");
	using namespace std;
	float x[2];
	float y[2];
	float r[2];
	float d, h, j;
	cout << "Введите координаты x,y и радиус r сначала для 1 окружности, а затем для второй." << endl;
	cin >> x[0];
	cin >> y[0];
	cin >> r[0];
	cin >> x[1];
	cin >> y[1];
	cin >> r[1];
	d = sqrt((x[0] - x[1])*(x[0] - x[1]) + (y[0] - y[1])*(y[0] - y[1]));
	//D<R1 + R2 
	if ((d < r[0] + r[1]) && (d != 0) && ((d + r[0] == r[1]) || (d + r[1] == r[0]))) cout << "Окружности имеют внутреннее касание" << endl;
	else if ((d < r[0] + r[1]) && ((d + r[0] < r[1]) || (d + r[1] < r[0]))) cout << "Одна окружность находится внутри другой" << endl;
	else if ((d < r[0] + r[1]) && (d != 0)) cout << "Окружности пересекаются в двух точках" << endl;
	else if ((d == r[0] + r[1]) && (d != 0)) cout << "Окружности касаются в одной точке" << endl;
	else if ((d == 0) && (r[1] == r[0]) && (x[1] == x[0]) && (y[1] == y[0])) cout << "Окружности совпадают" << endl;
	else if ((d > r[1] + r[2]) && (d != 0)) cout << "Окружности не пересекаются" << endl;
	_getch();
	return 0;
}