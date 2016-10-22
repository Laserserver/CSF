import clr
clr.AddReference('System.Drawing')
clr.AddReference('System.Windows.Forms')

from System.Drawing import *
from System.Windows.Forms import *

class MyForm(Form):
    def __init__(self):
        # Create child controls and initialize form
        pass


Application.EnableVisualStyles()
Application.SetCompatibleTextRenderingDefault(False)

form = MyForm()
form.Text = 'Задание 4.45'
button = Button(Text='Нажать')
txbA = TextBox(Text='A')
form.Controls.Add(button)
form.Controls.Add(txbA)
Application.Run(form)
