// Domashka.cpp: определ€ет точку входа дл€ консольного приложени€.
//


#include <iostream> 
#include <math.h> 

using namespace std;
/*int i = 8;
void main()
{
	int i = 10; cout << i << ' ';
	{int i = 2; cout << i << ' '; }
	cout << i;
}*/
/*void main()
{
	int i = -1, j = 0;
	if (++i || ++j)cout << i;
	else cout << -i;
}*/
/*void main()
{
	int i = -1, j = -1, k = -1;
if (++i || ++j||++k)cout << i;
else cout << -i;
}*/
/*void main()
{
	int i = 5;
	switch (i)
	{
	case 0:case 1: i++;
	case 2: --i; break;
	default: i += 4;
	case 3: i -= 2;
	case 4: i += 5;
	}
	cout << i;
}*/
/*void main()
{
int i = 4, j=7;
while(j) i+=j--;
cout<<i<<' '<<j;
}*/
/*void main()
{
	int i;
	for (i = -9; i <= 1; i++)
	{
		if (i < -1) continue;
		cout <<' '<< i;
	}
}*/
/*void main()
{
	int i;
	for (i = 4; i > -8; i--)
	{
		cout <<' '<< i;
		if (i < -1) break;
	}
}*/
/*void main()
{
	int i = 0, j = -1; /*¬нимание логические выражени€ выполн€ютс€ условно!
	if (++i||++j) cout << i;
	else cout << -i;
}*/

///**********“–≈“№≈
/*void main()
{
	char *s = "xsyxxy";
	while (*s > 'e') cout << *s++;
}*/
/*void main()
{
char *s = "757348";
while (*++s > '1') cout << *s;
}*/
/*void main()
{
char *s = "mpadf",*p=s;
while (*p++); cout << p-s;
}*/
void main()
{
char *s = "OFSRWPRM"; int i=0;
while (*s++) i++; cout<<i;
cin.ignore();
}
/*void main()
{
int i=1,*p=&i;
cout<<++i; cout<<' '<<++*p;
}*/
/*void main()
{
int a[]={6,7,1,2,2,0,-6,5,-3,3},
*p=a;
cout<<*++p; cout<<' '<<++*p;
}*/
/*void main()
{
int a[]=(-1,-4,-3,-3,6,-4,2,1,-2,3},
*p=a;
cout<<*++p; cout<<' '<<++*p;
}*/
/*void main()
{
	char *s = "fonlaybmptlhjkmmuhh",
		*p = s + 7, *q = s + 2, *r = s + 9;
	cout << s[3] << *p << *q << *r;
}*/
/*void main()
{
	int i, a[] {4, 7, 5, 1, 1, 8, 5, 6, 3, 0};
	for (i = 0; i < sizeof(a) / sizeof(a[0]); i++)
	{
		if (a[i]>2) continue;
		cout<<' '<<*(a + i);
	}
}*/
/*void main()
{
	int a[] = {1, 1, 2, 4, 5, 4, 3, 2, 5, 5 }, *p = a + 3;
	while (p < a + 9) cout << ' ' << *p++;
}*/
/*void main()
{
	int  i, j = 35; i = --j;
	cout << i << endl << j;
	/*int x = ~- 14;
	cout << x;
}*/
