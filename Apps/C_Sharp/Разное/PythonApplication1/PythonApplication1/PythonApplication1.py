
import math
"""
a = 'random Text';
print(a.capitalize());
print(a.upper());
print(a.lower());
print(a.swapcase());
print(a.find('n'));  #поиск слева
print(a.rfind('t'));  #поиск справа
print(a.index('a'));
print(a.rindex('o'));
print(a.replace('d','s'));
"""
"""
b = 'Let there be light'
c = b.split(' ')
print(b)
print(c)
var = ';'.join(c)
print(var)
str = '-'
list = ('a', 'b', 'c')
print(str.join(list));
"""
"""
a = int(input('Type count: '))
b = 26
c = 67;
if (a < b):
    print(b)
elif (a > b and a < c):
    print(c)
else:
    print(a)
"""
"""
list = [2, 'table', True]
for x in list:
    print(x)
list1 = [5, 10, 23]
list2 = ['adsad','asdasdsa','rhthfg','dfgrtyret']
list3 = [list, list1, list2]
print(list3)
""" 
#У кортежей меньше методов
#Кортеж - immutable
"""
.append .extend .pop .remove

_list = ['asdasds', 5,6,8,True]
_tuple = ('fgrewr',3,'qweqwe',3,3,3,3)
a = [2,3,4,5]
b = tuple(a)
c = (4,5,6,7)
d = list(c)
print(type(b))
print(type(d))
print(_tuple.count(3))
print(_list.index(6))
print(_tuple)
print(type(_tuple))
c.__iter__
v = int(a[2])
print(v)
n = 'Text random'
x = tuple(n)
print(x)
"""
'''
a = ['name1', 'name2', 'name3', 'name4']
b = ['surname1','surname2','surname3','surname4']
i = 0
for value in a:
    print(a[i], b[i], sep=' ')
    i+=1
'''
'''
Калькулятор
def arythmetic(left, right, sign):
    if (sign == '+'):
        return left + right
    elif (sign == '-'):
        return left - right
    elif (sign == '*'):
        return left * right
    elif (sign == '/'):
        if (right != 0):
            return left / right    
        else:
            print('DivideByZeroException')
    else:
        print('InvalidOperationException')
try:
    left = complex(input('Left: '))
    sign = input('Sign: ')
    right = complex(input('Right: '))
    print(arythmetic(left, right, sign))
except ValueError:
    print('No string allowed')
'''
'''
Высоты треугольника
try:
    a = int(input('A = '))
    b = int(input('B = '))
    c = int(input('C = '))
    p = (a + b + c) * 0.5
    psq = 2 * (p * (p - a) * (p - b) * (p - c)) ** 0.5
    ha = psq / a
    hb = psq / b
    hc = psq / c 
    print('Ha = {}, Hb = {}, Hc = {}'.format(ha,hb,hc))
except ValueError:
    print('Error')
'''
'''
try:
    a = int(input('Number: '))
    print(a & 1 == 0 and a > 0 and a < 100)
except ValueError:
    print('error')
'''
#12