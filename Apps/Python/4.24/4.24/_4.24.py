#24. Даны три переменные: X, Y, Z. Если их значения упорядочены по убыванию, то удвоить их; в противном случае заменить значение каждой переменной на противоположное. 
print('Введи Х')
X = int(input(''))
print('Введи Y')
Y = int(input(''))
print('Введи Z')
Z = int(input(''))
if (X < Y and Y < Z):
    print('X: {}'.format(X*2))
    print('Y: {}'.format(Y*2))
    print('Z: {}'.format(Z*2))
else:
    print('X: {}'.format(-X))
    print('Y: {}'.format(-Y))
    print('Z: {}'.format(-Z))