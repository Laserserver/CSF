using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace TextBoxTestingProgram
{
    public partial class RegExpBox : TextBox
    {
        public RegExpBox():base()
        {
            InitializeComponent();
            //temp = BackColor;

            
    }

        //public RegExpBox(IContainer container):base()
        //{
        //    container.Add(this);

        //    InitializeComponent();

        //    Text = "";
        //    temp = BackColor;

        //}

        [Description("Выполняется при проверке валидности текста")]
        public event EventHandler ErrorInput;
        [Description("Выполняется при проверке валидности текста")]
        public event EventHandler CorrectInput;
        string regexp;
        bool isValid;
        Color colorErr = Color.Red;
        Color temp;
        [DefaultValue("")]
        [Category("Функционал")]
        [Description("Регулярное выражение")]
        public string RegularExpression
        {
            get
            {
                
                    return regexp;
            }
            set
            {
                regexp = @value;
            }
        }

    
        [DefaultValue(true)]
        [Category("Функционал")]
        [Description("Блокирует переключение фокуса если текст не удовлетворяет регулярному выражению")]
        public bool BlockFocus { get; set; } = true;
        [DefaultValue(16711680)]//красный
        [Category("Внешний вид")]
        [Description("Цвет при не совпадении строки с регулярным выражением")]
        public Color ColorErr
        {
            get
            {
                return colorErr;
            }

            set
            {
                colorErr = value;
            }
        }
        [DefaultValue(true)]
        private bool IsValid
        {
            get
            {
                return isValid;
            }

            set
            {
               
                isValid = value;
                if(!isValid)
                {
                    if(ErrorInput!=null)
                    ErrorInput(this, new EventArgs());
                }
                else
                {
                    if(CorrectInput!=null)
                    CorrectInput(this, new EventArgs());
                }
                
                
            }
        }
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
                temp = value != ColorErr ? value : temp;

            }
        }
        //protected override void OnPaintBackground(PaintEventArgs pevent)
        //{
        //    base.OnPaintBackground(pevent);
        //    if (!IsValid)
        //    {
        //        pevent.Graphics.FillRectangle(new SolidBrush(ColorErr), new Rectangle(this.Location,Size));
        //    }
        //}
        protected override void OnLostFocus(EventArgs e)
        {
            if(!IsValid&&BlockFocus)
            {
                Focus();
            }
            else
                base.OnLostFocus(e);
        }
        
        protected override void OnTextChanged(EventArgs e)
        {

            base.OnTextChanged(e);
            if (IsValid = Regex.IsMatch(Text,regexp))
            {
                if (temp != null)
                    BackColor = temp;
                else
                    BackColor = DefaultBackColor;
                
            }
            else
            {
                 BackColor = ColorErr;
              // this.TopLevelControl.CreateGraphics().FillRectangle(new SolidBrush(ColorErr), new Rectangle(this.Location.X-10,Location.Y-10, Size.Width+20,Size.Height+20));

            }
            
        }
       
    }
}
