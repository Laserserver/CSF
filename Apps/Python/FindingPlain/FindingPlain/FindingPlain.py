MyLst = [1,2,3,4,5,6,7,8,9,10,11]
MyNum = int(input('Number to find: '))
Switcher = int(input('Type of search: '))
Count = 0
if Switcher == 1:
    for Number in MyLst:
        Count += 1
        if Number == MyNum:
            break
    else:
       print('Number is not present')
    print('Counts: ', Count)
else:
    bottom = 0
    top = len(MyLst) - 1
    while bottom <= top:
        Count += 1
        middle = (bottom + top)//2
        if MyLst[middle] == MyNum:
            Count += 1
            print('Found: ', middle)
            break
        elif MyLst[middle] < MyNum:
            Count += 2  
            bottom = middle + 1
        else:
            Count += 3
            top = middle - 1
    else:
        print('Number is not present')
    print('Counts: ', Count)