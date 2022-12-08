using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Calc_set
{
    public partial class MainPage : ContentPage
    {
        public int[] Universum = new int[101];
        public int[] A;
        public int[] B;
        public int[] C;

        public MainPage()
        {
            InitializeComponent();

            int el_univers = -50;
            for (int i = 0; i < 101; i++)
            {
                Universum[i] = el_univers;
                el_univers++;
            }

        }

        protected override void OnAppearing()//Создание пользовательского интерфейса через переопределение метода OnAppearing
        {
            key_A.Clicked += Key_Clicked;
            key_B.Clicked += Key_Clicked;
            key_C.Clicked += Key_Clicked;
            key_intersection.Clicked += Key_Clicked;
            key_unification.Clicked += Key_Clicked;
            key_subtraction.Clicked += Key_Clicked;
            key_symetrical_subtraction.Clicked += Key_Clicked;
            key_adiition.Clicked += Key_Clicked;
            key_left.Clicked += Key_Clicked;
            key_right.Clicked += Key_Clicked;
            key_backspace.Clicked += Key_Backspace_Clicked;
            key_equal.Clicked += Key_Equal_Clicked;
            random_A.Clicked += Random_A_Clicked;
            random_B.Clicked += Random_B_Clicked;
            random_C.Clicked += Random_C_Clicked;
        }

        private async void Random_C_Clicked(object sender, EventArgs e)
        {
            if (size.Text != null)
            {
                set_C.Text = null;
                int size_set;
                bool success = int.TryParse(size.Text.ToString(), out size_set);
                if (success)
                {
                    C = new int[size_set];
                    Random rnd = new Random();
                    int count = 0;

                    while (count != size_set)
                    {
                        bool fnd = false;
                        int num = rnd.Next(-50, 51);
                        for (int i = 0; i < count; i++)
                            if (C[i] == num)
                            {
                                fnd = true;
                                break;
                            }
                        if (!fnd)
                        {
                            C[count] = num;
                            count++;
                        }
                    }

                    for (int i = 0; i < count; i++)
                    {
                        set_C.Text += C[i].ToString();
                        if (i != count - 1)
                            set_C.Text += ",";
                    }
                }
                else
                {
                    await DisplayAlert("Error!", "В поле размер может находиться только целое число!", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error!", "Размер при рандомном заполнении не может быть пустым!", "Ok");
            }
        }

        private async void Random_B_Clicked(object sender, EventArgs e)
        {
            if (size.Text != null)
            {
                set_B.Text = null;
                int size_set;
                bool success = int.TryParse(size.Text.ToString(), out size_set);
                if (success)
                {
                    B = new int[size_set];
                    Random rnd = new Random();
                    int count = 0;

                    while (count != size_set)
                    {
                        bool fnd = false;
                        int num = rnd.Next(-50, 51);
                        for (int i = 0; i < count; i++)
                            if (B[i] == num)
                            {
                                fnd = true;
                                break;
                            }
                        if (!fnd)
                        {
                            B[count] = num;
                            count++;
                        }
                    }

                    for (int i = 0; i < count; i++)
                    {
                        set_B.Text += B[i].ToString();
                        if (i != count - 1)
                            set_B.Text += ",";
                    }
                }
                else
                {
                    await DisplayAlert("Error!", "В поле размер может находиться только целое число!", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error!", "Размер при рандомном заполнении не может быть пустым!", "Ok");
            }
        }

        private async void Random_A_Clicked(object sender, EventArgs e)
        {
            if (size.Text != null)
            {
                set_A.Text = null;
                int size_set;
                bool success = int.TryParse(size.Text.ToString(), out size_set);
                if (success)
                {
                    A = new int[size_set];
                    Random rnd = new Random();
                    int count = 0;

                    while (count != size_set)
                    {
                        bool fnd = false;
                        int num = rnd.Next(-50, 51);
                        for (int i = 0; i < count; i++)
                            if (A[i] == num)
                            {
                                fnd = true;
                                break;
                            }
                        if (!fnd)
                        {
                            A[count] = num;
                            count++;
                        }
                    }

                    for (int i = 0; i < count; i++)
                    {
                        set_A.Text += A[i].ToString();
                        if (i != count - 1)
                            set_A.Text += ",";
                    }
                }
                else
                {
                    await DisplayAlert("Error!", "В поле размер может находиться только целое число!", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error!", "Размер при рандомном заполнении не может быть пустым!", "Ok");
            }
        }

        public int buf_type = 0;
        public int count_left = 0;
        private void Key_Clicked(object sender, EventArgs e)
        {
            if ((sender as Button).Text == key_left.Text)
            {
                if (buf_type == 0 || buf_type == 2 || buf_type == 4 || entry_expression.Text == null)
                {
                    entry_expression.Text += (sender as Button).Text.ToString();
                    buf_type = 2;
                    count_left++;
                }
            }
            else if ((sender as Button).Text == key_right.Text)
            {
                if ((buf_type == 1 || buf_type == 3) && count_left != 0)
                {
                    entry_expression.Text += (sender as Button).Text.ToString();
                    buf_type = 3;
                    count_left--;
                }
            }
            else if ((sender as Button).Text == key_A.Text ||
                    (sender as Button).Text == key_B.Text ||
                    (sender as Button).Text == key_C.Text)
            {
                if (buf_type == 0 || buf_type == 2 || buf_type == 4)
                {
                    entry_expression.Text += (sender as Button).Text.ToString();
                    buf_type = 1;
                }
            }
            else if ((sender as Button).Text == key_adiition.Text)
            {
                if (buf_type != 1 && buf_type != 3)
                {
                    entry_expression.Text += (sender as Button).Text.ToString();
                    buf_type = 4;
                }
            }    
            else if (buf_type == 1 || buf_type == 3)
            {
                entry_expression.Text += (sender as Button).Text.ToString();
                buf_type = 0;
            }

        }
        private async void Key_Equal_Clicked(object sender, EventArgs e)
        {
            if (entry_expression.Text != null)
            {
                answer.Text = null;
                answer_layout.IsVisible = true;
                if (set_A.Text != null)
                {
                        char[] delimeter = { ' ', ',', ';', '.' };
                        string[] text = set_A.Text.Split(delimeter);
                        for (int i = 0; i < text.Length; i++)
                            text[i] = string.Join("", text[i].Where(c => char.IsDigit(c) || c == '-'));
                        text = text.Where(c => c != "").ToArray();

                        int size_set = text.Length;
                        A = new int[size_set];
                        for (int i = 0; i < size_set; i++)
                            int.TryParse(text[i], out A[i]);

                        set_A.Text = null;
                        for (int i = 0; i < size_set; i++)
                        {
                            set_A.Text += A[i].ToString();
                            if (i != size_set - 1)
                                set_A.Text += ",";
                        }
                }
                else answer.Text = null;

                if (set_B.Text != null)
                {
                        char[] delimeter = { ' ', ',', ';', '.' };
                        string[] text = set_B.Text.Split(delimeter);
                        for (int i = 0; i < text.Length; i++)
                            text[i] = string.Join("", text[i].Where(c => char.IsDigit(c) || c == '-'));
                        text = text.Where(c => c != "").ToArray();

                        int size_set = text.Length;
                        B = new int[size_set];
                        for (int i = 0; i < size_set; i++)
                            int.TryParse(text[i], out B[i]);

                        set_B.Text = null;
                        for (int i = 0; i < size_set; i++)
                        {
                            set_B.Text += B[i].ToString();
                            if (i != size_set - 1)
                                set_B.Text += ",";
                        }
                }
                else answer.Text = null;

                if (set_C.Text != null)
                {
                        char[] delimeter = { ' ', ',', ';', '.' };
                        string[] text = set_C.Text.Split(delimeter);
                        for (int i = 0; i < text.Length; i++)
                            text[i] = string.Join("", text[i].Where(c => char.IsDigit(c) || c == '-'));
                        text = text.Where(c => c != "").ToArray();

                        int size_set = text.Length;
                        C = new int[size_set];
                        for (int i = 0; i < size_set; i++)
                            int.TryParse(text[i], out C[i]);

                        set_C.Text = null;
                        for (int i = 0; i < size_set; i++)
                        {
                            set_C.Text += C[i].ToString();
                            if (i != size_set - 1)
                                set_C.Text += ",";
                        }
                }
                else answer.Text = null;

                
                string text_exp = entry_expression.Text.ToString();
                char[] expression = text_exp.ToCharArray();
                string ans = "";
                int[] buf = { };
                while (expression.Length != 1)
                {
                    bool cont = false;
                    char[] buf_expression = expression;

                    for (int i = 0; i < buf_expression.Length; i++)
                    {
                        if (buf_expression[i] == '‾')
                        {
                            int[] a_buf = { };
                            switch (buf_expression[i + 1])
                            {
                                case 'A':
                                    a_buf = A;
                                    break;
                                case 'B':
                                    a_buf = B;
                                    break;
                                case 'C':
                                    a_buf = C;
                                    break;
                                case 'D':
                                    a_buf = buf;
                                    break;
                            }

                            Array.Resize(ref buf, 0);

                            for (int j = 0; j < Universum.Length; j++)
                            {
                                bool flag1 = true;
                                for (int k = 0; k < a_buf.Length; k++)
                                {
                                    if (Universum[j] == a_buf[k])
                                        flag1 = false;
                                }
                                if (flag1)
                                {
                                    Array.Resize(ref buf, buf.Length + 1);
                                    buf[buf.Length - 1] = Universum[j];
                                }
                                    
                            }
                            expression[i] = 'D';//меняеям выражение, удаляем то что посчитали и вставляем переменную D
                            for (int y = i; y < expression.Length - 1; y++)
                                expression[y] = expression[y + 1];
                            Array.Resize(ref expression, expression.Length - 1);
                            cont = true;
                            break;
                        }
                            
                     
                    }
                    if (!cont)
                    {
                        for (int i = 0; i < buf_expression.Length; i++)
                        {
                            if (buf_expression[i] == '⋂')
                            {
                                int[] a_buf = { };
                                int[] b_buf = { };
                                switch (buf_expression[i - 1])
                                {
                                    case 'A':
                                        a_buf = A;
                                        break;
                                    case 'B':
                                        a_buf = B;
                                        break;
                                    case 'C':
                                        a_buf = C;
                                        break;
                                    case 'D':
                                        a_buf = buf;
                                        break;
                                }
                                switch (buf_expression[i + 1])
                                {
                                    case 'A':
                                        b_buf = A;
                                        break;
                                    case 'B':
                                        b_buf = B;
                                        break;
                                    case 'C':
                                        b_buf = C;
                                        break;
                                    case 'D':
                                        b_buf = buf;
                                        break;
                                }

                                Array.Resize(ref buf, 0);

                                for (int j = 0; j < a_buf.Length; j++)
                                    for (int k = 0; k < b_buf.Length; k++)
                                        if (a_buf[j] == b_buf[k])
                                        {
                                            Array.Resize(ref buf, buf.Length + 1);
                                            buf[buf.Length - 1] = a_buf[j];
                                            break;
                                        }
                                expression[i - 1] = 'D';//меняеям выражение, удаляем то что посчитали и вставляем переменную D
                                for (int y = i; y < expression.Length - 2; y++)
                                    expression[y] = expression[y + 2];
                                Array.Resize(ref expression, expression.Length - 2);
                                cont = true;
                                break;
                            }
                                
                            
                        }
                    }
                    if (!cont)
                    {
                        for (int i = 0; i < buf_expression.Length; i++)
                        {
                            if (buf_expression[i] == '⋃')
                            {
                                int[] a_buf = { };
                                int[] b_buf = { };
                                switch (buf_expression[i - 1])
                                {
                                    case 'A':
                                        a_buf = A;
                                        break;
                                    case 'B':
                                        a_buf = B;
                                        break;
                                    case 'C':
                                        a_buf = C;
                                        break;
                                    case 'D':
                                        a_buf = buf;
                                        break;
                                }
                                switch (buf_expression[i + 1])
                                {
                                    case 'A':
                                        b_buf = A;
                                        break;
                                    case 'B':
                                        b_buf = B;
                                        break;
                                    case 'C':
                                        b_buf = C;
                                        break;
                                    case 'D':
                                        b_buf = buf;
                                        break;
                                }

                                Array.Resize(ref buf, 0);

                                for (int j = 0; j < a_buf.Length; j++)
                                {
                                    Array.Resize(ref buf, buf.Length + 1);
                                    buf[buf.Length - 1] = a_buf[j];
                                }
                                for (int j = 0; j < b_buf.Length; j++)
                                {
                                    Array.Resize(ref buf, buf.Length + 1);
                                    buf[buf.Length - 1] = b_buf[j];
                                }
                                expression[i - 1] = 'D';//меняеям выражение, удаляем то что посчитали и вставляем переменную D
                                for (int y = i; y < expression.Length - 2; y++)
                                    expression[y] = expression[y + 2];
                                Array.Resize(ref expression, expression.Length - 2);
                                cont = true;
                                break;
                            }
                                
                        }
                    }
                    if (!cont)
                    {
                        for (int i = 0; i < buf_expression.Length; i++)
                        {
                            if (buf_expression[i] == '\\')
                            {
                                int[] a_buf = { };
                                int[] b_buf = { };
                                switch (buf_expression[i - 1])
                                {
                                    case 'A':
                                        a_buf = A;
                                        break;
                                    case 'B':
                                        a_buf = B;
                                        break;
                                    case 'C':
                                        a_buf = C;
                                        break;
                                    case 'D':
                                        a_buf = buf;
                                        break;
                                }
                                switch (buf_expression[i + 1])
                                {
                                    case 'A':
                                        b_buf = A;
                                        break;
                                    case 'B':
                                        b_buf = B;
                                        break;
                                    case 'C':
                                        b_buf = C;
                                        break;
                                    case 'D':
                                        b_buf = buf;
                                        break;
                                }

                                Array.Resize(ref buf, 0);

                                for (int j = 0; j < a_buf.Length; j++)
                                {
                                    bool flag1 = true;
                                    for (int k = 0; k < b_buf.Length; k++)
                                    {
                                        if (a_buf[j] == b_buf[k])
                                            flag1 = false;
                                    }
                                    if (flag1)
                                    {
                                        Array.Resize(ref buf, buf.Length + 1);
                                        buf[buf.Length - 1] = a_buf[j];
                                    }
                                }
                                expression[i - 1] = 'D';//меняеям выражение, удаляем то что посчитали и вставляем переменную D
                                for (int y = i; y < expression.Length - 2; y++)
                                    expression[y] = expression[y + 2];
                                Array.Resize(ref expression, expression.Length - 2);
                                cont = true;
                                break;
                            }
                                
                        }
                    }
                    if (!cont)
                    {
                        for (int i = 0; i < buf_expression.Length; i++)
                        {
                            if (buf_expression[i] == '△')
                            {
                                int[] a_buf = { };
                                int[] b_buf = { };
                                switch (buf_expression[i - 1])
                                {
                                    case 'A':
                                        a_buf = A;
                                        break;
                                    case 'B':
                                        a_buf = B;
                                        break;
                                    case 'C':
                                        a_buf = C;
                                        break;
                                    case 'D':
                                        a_buf = buf;
                                        break;
                                }
                                switch (buf_expression[i + 1])
                                {
                                    case 'A':
                                        b_buf = A;
                                        break;
                                    case 'B':
                                        b_buf = B;
                                        break;
                                    case 'C':
                                        b_buf = C;
                                        break;
                                    case 'D':
                                        b_buf = buf;
                                        break;
                                }

                                Array.Resize(ref buf, 0);

                                for (int j = 0; j < a_buf.Length; j++)
                                {
                                    bool flag1 = true;
                                    for (int k = 0; k < b_buf.Length; k++)
                                    {
                                        if (a_buf[j] == b_buf[k])
                                            flag1 = false;
                                    }
                                    if (flag1)
                                    {
                                        Array.Resize(ref buf, buf.Length + 1);
                                        buf[buf.Length - 1] = a_buf[j];
                                    }
                                }
                                for (int j = 0; j < b_buf.Length; j++)
                                {
                                    bool flag1 = true;
                                    for (int k = 0; k < a_buf.Length; k++)
                                    {
                                        if (b_buf[j] == a_buf[k])
                                            flag1 = false;
                                    }
                                    if (flag1)
                                    {
                                        Array.Resize(ref buf, buf.Length + 1);
                                        buf[buf.Length - 1] = b_buf[j];
                                    }
                                }
                                expression[i - 1] = 'D';//меняеям выражение, удаляем то что посчитали и вставляем переменную D
                                for (int y = i; y < expression.Length - 2; y++)
                                    expression[y] = expression[y + 2];
                                Array.Resize(ref expression, expression.Length - 2);
                                cont = true;
                                break;
                            }
                                
                        }
                    }
                    
                        
                }
                buf = buf.Distinct().ToArray();//удалить повторения
                for (int i = 0; i < buf.Length; i++)
                    ans += buf[i].ToString() + " ";
                answer.Text = ans;
            }
            else
                await DisplayAlert("Error", "Выражение не может быть пустым", "Ok");

        }

        private void Key_Backspace_Clicked(object sender, EventArgs e)
        {
            
            if (entry_expression.Text != null)
            {
                if (entry_expression.Text.ToString()[entry_expression.Text.ToString().Length - 1] == ')')
                    count_left++;
                if (entry_expression.Text.ToString()[entry_expression.Text.ToString().Length - 1] == '(')
                    count_left--;
                if (entry_expression.Text.ToString().Length == 1)
                {
                    entry_expression.Text = null;
                    buf_type = 0;
                }
                else
                {
                    entry_expression.Text = entry_expression.Text.ToString().Remove(entry_expression.Text.ToString().Length - 1);
                    char a = entry_expression.Text.ToString()[entry_expression.Text.ToString().Length - 1];
                    if (a == 'A' || a == 'B' || a == 'C')
                        buf_type = 1;
                    else if (a == '(')
                        buf_type = 2;
                    else if (a == ')')
                        buf_type = 3;
                    else
                        buf_type = 0;
                }
            }
        }

    }
}