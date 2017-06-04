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
	printf("Выбираем ввод-вывод данных : \n");
	printf("1)С консоли на консоль - введите 1\n");
	printf("2)С файла в файл - введите 2\n");
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
	printf("Введите длину стены : ");
	scanf_s("%lf", &Ds);
	printf("Введите высоту стены : ");
	scanf_s("%lf", &Vs);
	printf("Введите длину рулона : ");
	scanf_s("%lf", &Dr);
	printf("Введите высоту рулона : ");
	scanf_s("%lf", &Vr);
	printf("Введите стоимость рулона : ");
	scanf_s("%lf", &Sr);
	mainMath(Ds, Vs, Dr, Vr, Sr, 0);
}

void typeFile()
{
	char fname[20] = "output.dat";
	puts("Чтение из файла");
	if (!(in = fopen("input.dat", "rt")))
	{
		printf("Ошибка открытия файла");
		system("pause");
	}
	puts("Запись в файл");
	if (!(out = fopen("output.dat", "wt")))
	{
		printf("Ошибка открытия файла");
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
		printf("Необходимо купить рулонов : %.0lf\n", Data);
		printf("Стоимость обоев для всей стены : %.2lf руб.\n", Sr*Data);
}

void math2(double Data, double Sr)
{
	fprintf(out, "Необходимо купить рулонов : %.0lf\n", Data);
	fprintf(out, "Стоимость обоев для всей стены : %.2lf руб.\n", Sr*Data);
}