// Lexa.cpp: ���������� ����� ����� ��� ����������� ����������.
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
	cout << "������� ���������� x,y � ������ r ������� ��� 1 ����������, � ����� ��� ������." << endl;
	cin >> x[0];
	cin >> y[0];
	cin >> r[0];
	cin >> x[1];
	cin >> y[1];
	cin >> r[1];
	d = sqrt((x[0] - x[1])*(x[0] - x[1]) + (y[0] - y[1])*(y[0] - y[1]));
	//D<R1 + R2 
	if ((d < r[0] + r[1]) && (d != 0) && ((d + r[0] == r[1]) || (d + r[1] == r[0]))) cout << "���������� ����� ���������� �������" << endl;
	else if ((d < r[0] + r[1]) && ((d + r[0] < r[1]) || (d + r[1] < r[0]))) cout << "���� ���������� ��������� ������ ������" << endl;
	else if ((d < r[0] + r[1]) && (d != 0)) cout << "���������� ������������ � ���� ������" << endl;
	else if ((d == r[0] + r[1]) && (d != 0)) cout << "���������� �������� � ����� �����" << endl;
	else if ((d == 0) && (r[1] == r[0]) && (x[1] == x[0]) && (y[1] == y[0])) cout << "���������� ���������" << endl;
	else if ((d > r[1] + r[2]) && (d != 0)) cout << "���������� �� ������������" << endl;
	_getch();
	return 0;
}