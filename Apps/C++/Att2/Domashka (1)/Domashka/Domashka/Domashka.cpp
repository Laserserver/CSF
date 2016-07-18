// Domashka.cpp: определяет точку входа для консольного приложения.
//


#include <iostream> 
#include <math.h> 

using namespace std;
/*void main()
{
	int a[][3] = {7,1,6,6,7,3,9,0,9,1 };
	cout << sizeof(a) / sizeof(int) << ' '
		<< sizeof(a[3])/sizeof(int) << ' ' << sizeof(a);
}*/
/*void main()
{
	int a[] = { 5, 1, 3, 2, 4, 4, 0, 8, 2, 8 };
	cout << sizeof(a) / sizeof(int) << ' '
		<< sizeof(a[7]) << ' ' << sizeof(a);
}*/
/*void main()
{
	int a[][3] = { { 5, 0 }, { 7, 3 }, { 8, 7 }, { 8, 3 }, { 5, 3 } };
cout << sizeof(a) / sizeof(int) << ' '
<< sizeof(a[0]) << ' ' << sizeof(a[1][1]);
}
/*void main()
{
	int a[][3] = { 6,3,7,1,3,9,1,3,1,1 };
	cout << sizeof(a) / sizeof(int) << ' '
		<< sizeof(a[0])/sizeof(int) << ' ' << sizeof(a);
}*/
/*void main()
{
	int a[5][2] = { (1, 2), (3, 3), (5, 9),(6,7),(9,3)};
	cout << a[4][1] << ' '
		<< (*(a + 3))[1] << ' ' << *(*(a + 3) + 1);
}*/
/*void main()
{
	int i = 2, j = 8, k, l, **a = new int*[i];
	for (k = 0; k < i; k++)
	{
		a[k] = new int[j];
		for (l = 0; l < j; l++) a[k][l] = 10 * k + l;
	}
	for (k = 0; k < i; k++) cout << ' ' << a[k][k];
	for (k = 0; k < i; k++)delete[]a[k]; delete[]a;
}*/
/*void main()
{
	char *s = "bjvkhgclphfojtvaur";
	int i, a[] = { 1, 4, 8, 2, 8 };
	for (i = 0; i < sizeof(a) / sizeof(a[0]); i++)
	cout << s[a[i]];
}*/
/*void main()
{
	char *s[] = { "XGRZLZG", "92771493", "xbkuxfudok", "CRDTKEW", "65095811",
		"sbbtsgtsq" };
	int i = 2, j = 1;
	cout << s[i][j] << *(*(s + i) + j) << *((*s + i) + j);
}*/
/*void main()
{
	char *s = "RMPPDORINHGLNEGGLU",
		*p[] = { s + 3, s + 2, s + 1, s + 5, s + 5 };
	cout << s[5] << *p[4] << **(p + 3);
}*/
/////////////////////ВТОРАЯ ЧАСТЬ /////////////////////////////////
int k = 0;
	int f(int l, int *m)
	{
		l++; (*m)++; return k++;
	}
	void main()
	{
		int i = 5, j = 2; cout << f(i, &j);
		cout << ' ' << i << ' ' << j << ' ' << k;
}
/*double f(double(*f1)(double x), double(*f2)(double x), double x)
{
	return f1(f2(x));
}
void main()
{
	cout << f(exp, &log, 3) << ' ' << f(&exp, log, 8);
}*/
/*double f(double(*f1)(double x), double x)
{
	double y = f1(x);
	return y*y;
}
void main()
{
	cout << f(sqrt, 4) << ' '<<f(&sqrt, 9);
}*/
/*void f(int A[10], int lenA, int *B, int lenB)
{
	int i;
	for (i = 0; i < lenA; i++) A[i] = 0;
	for (i = 0; i < lenB; i++) B[i] = 0;
}
void main()
{
	int a[] = { 7, 8, 3, 2, 5, 6, 6, 4, 2, 9 },
		b[] = { 5, 4, 4, 2, 7 };
	f(a, sizeof(a) / sizeof(int), b, sizeof(b) / sizeof(int));
	cout << a[8] << ' ' << b[0];
}*/
/*int f(int a[], int len)
{
	int *p = a, sum = 0;
	while (p - a < len) sum += *p++;
	return sum;
}
void main()
{
	int a[] = { 4, 0, 8, 6, 7 };
	cout << f(a, sizeof(a) / sizeof(a[0]));
}*/
/*int diag(int a[][5], int i)
{
	int sum = 0;
	while (i--) sum += a[i][i];
	return sum;
}
void main()
{ int a[][5] = { { 0, 5, 6, 0, 1 } , { 3, 1, 1, 6, 1 }, { 8, 3, 0, 8, 9 }, { 4, 4, 4, 7, 0 }, { 0, 9, 1, 3, 2 } };
  cout << diag(a, 4);
}*/
/*int f(int a[], int len)
{
	if (len) return f(a, len - 1) - a[len - 1];
	else return 0;
}
void main()
{
	int a[] = { 6, 2, 5, 1, 3 };
	cout << f(a, sizeof(a) / sizeof(a[0]));
}*/
/*int f(int A[10], int B[], int *C)
{
	return sizeof(A)+sizeof(B)+sizeof(C);
}
void main()
{
	int a[] = { 5, 5, 8, 8, 9, 2, 5, 3, 0, 1 };
	cout << f(a, a, a);
}*/
/*int f(int A[][3], int *sizeA0)
{
	*sizeA0 = sizeof(A[0]); return sizeof(A);
}
void main()
{
	int a[][3] = { 3, 6, 5, 8, 7, 6, 9, 2, 7, 8 },
		size;
	cout << f(a, &size) << ' ';
	cout << size << ' ' << sizeof(a[0]);
}*/


