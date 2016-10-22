import math
print('Введи номер задачи (5 - 9):')
Task = int(input())
if Task == 5:
    y = 0
    for i in range(10, 21):
        y += math.sin(i/10.0)
    print(y)
elif Task == 6:
    Array = ()
    for i in range(1, 21):
        for j in range(1, 21):
            for k in range(1, 21):
                if (k*k + j*j == i*i):
                    Array += (k, j, i)
    print(Array)
elif Task == 7:
    print('Введи n:')
    n = int(input())
    Ans = 0
    Mult = -1
    for i in range(1, n+1):
        Ans += Mult * (i + 1.0)
        Mult = -Mult/(i+1.0)
    print(Ans)
elif Task == 8:
    print('Введи n: ')
    n = int(input())
    print('Введи x: ')
    Ans = 0
    x = float(input())
    print('Часть?')
    Let = input()
    if Let == 'a':
        Mult = 1.0
        Sqr = math.sqrt(math.fabs(x))
        for i in range(1, n+1):
            Ans += Mult + Sqr
            Mult *= 1/(i+1)
    elif Let == 'b':
        Mult = 1.0
        Ans = 1
        for i in range(1, n+1):
            Ans *= 1 + math.sin(i*x) / Mult
            Mult *= 1/(i+1)
    print(Ans)