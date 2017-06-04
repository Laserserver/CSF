#include "stdafx.h" 
#include <stdio.h> 
#include <locale.h> 
#include <stdlib.h> 
#include <math.h> 

double Ds, Vs, Dr, Vr, KR, Sr;
FILE *out;
FILE *in;
void math(double Data, double Sr);
void math2(double Data, double Sr);
void mainType(int flag);
void mainMath(double Ds, double Vs, double Dr, double Vr, double Sr, short flag);
void typeCons();
void typeFile();


int main(void)
{
	int i;
	setlocale(LC_ALL, "RUS");
	printf("�������� ����-����� ������ : \n");
	printf("1)� ������� �� ������� - ������� 1\n");
	printf("2)� ����� � ���� - ������� 2\n");
	scanf("%d", &i);
	mainType(i);
}

void mainType(int flag)
{
	switch (flag)
	{
	case 1:
		typeCons();
		system("pause");
		break;
	case 2:
		typeFile();
		system("pause");
		break;
	default:
		break;
	}
}

void typeCons()
{
	printf("������� ����� ����� : ");
	scanf_s("%lf", &Ds);
	printf("������� ������ ����� : ");
	scanf_s("%lf", &Vs);
	printf("������� ����� ������ : ");
	scanf_s("%lf", &Dr);
	printf("������� ������ ������ : ");
	scanf_s("%lf", &Vr);
	printf("������� ��������� ������ : ");
	scanf_s("%lf", &Sr);
	mainMath(Ds, Vs, Dr, Vr, Sr, 0);
}

void typeFile()
{
	char fname[20] = "output.dat";
	puts("������ �� �����");
	if (!(in = fopen("input.dat", "rt")))
	{
		printf("������ �������� �����");
		system("pause");
	}
	puts("������ � ����");
	if (!(out = fopen("output.dat", "wt")))
	{
		printf("������ �������� �����");
		system("pause");
	}
	while (!feof(in))
	{
		fscanf(in, "%lf", &Ds);
		fscanf(in, "%lf", &Vs);
		fscanf(in, "%lf", &Dr);
		fscanf(in, "%lf", &Vr);
		fscanf(in, "%lf", &Sr);
		mainMath(Ds, Vs, Dr, Vr, Sr, 1);
	}
	fclose(in);
	fclose(out);
}

void mainMath(double Ds, double Vs, double Dr, double Vr, double Sr, short flag)
{
	KR = (Ds*Vs) / (Dr*Vr);
	KR = KR - (int)KR ? (int)KR + 1 : KR;
	if (!flag)
		math(KR, Sr);
	else
		math2(KR, Sr);
}

void math(double Data, double Sr)
{
		printf("���������� ������ ������� : %.0lf\n", Data);
		printf("��������� ����� ��� ���� ����� : %.2lf ���.\n", Sr*Data);
}

void math2(double Data, double Sr)
{
	fprintf(out, "���������� ������ ������� : %.0lf\n", Data);
	fprintf(out, "��������� ����� ��� ���� ����� : %.2lf ���.\n", Sr*Data);
}