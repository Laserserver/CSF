#45. Даны действительные положительные числа a, b, c, x, y.
#Выяснить, пройдет ли кирпич с ребрами a, b, c в прямоугольное
#отверстие со сторонами x и y. Просовывать кирпич в отверстие
#разрешается только так, чтобы каждое из его ребер было параллельно
#или перпендикулярно каждой из сторон отверстия.
print('Длина кирпича: ')
a = float(input())
print('Ширина кирпича: ')
b = float(input())
print('Высота кирпича: ')
c = float(input())
print('Вертикаль отверстия: ')
x = float(input())
print('Горизонталь отверстия: ')
y = float(input())
NotGo = False  #Пока проходит

if (x < a or x < b or x < c) and (y < a or y < b or y < c):
    NotGo = True
#Положение один
elif x < c and y < b:
    NotGo = True
#Положение один-повернуто
elif x < b and y < c:
    NotGo = True
#Положение два
elif x < c and y < a:
    NotGo = True
#Положение два-повернуто
elif x < a and y < c:
    NotGo = True
#Положение три
elif x < a and y < b:
    NotGo = True
#Положение три-повернуто
elif x < b and y < a:
    NotGo = True

if (NotGo):
    print('Кирпич не пройдёт')
else:
    print('Кирпич пройдёт')