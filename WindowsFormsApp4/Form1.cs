using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{   
    public partial class Form1 : Form
    {
        Count count = new Count();

         public static int cntGl = 0;
        public class kkk
        {
            public static int q;
        }
       bool turn = true;// true=x and false=o .
                         //bool against_computer = false;

        public Form1()
        {
            InitializeComponent();
        }
        Button[,] buttons;// = new Button[q, q];                
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            int top = 80;
            int left = 180;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(" give an odd number!");
          

            }
            kkk.q = int.Parse(textBox1.Text);
            buttons = new Button[kkk.q, kkk.q];

            //Δημιουργία κουμπιών
            if (kkk.q % 2 == 1 && kkk.q != 1 && kkk.q != 3)
            {
                for (int j = 0; j < kkk.q; j++)
                {
                    left = left + 52;
                    top = 80;
                    for (int i = 0; i < kkk.q; i++)
                    {
                        Button button = new Button();
                        button.Size = new Size(50, 50);
                        button.Left = left;
                        button.Top = top;
                        button.BackColor = System.Drawing.Color.Gray;
                        button.Font = new Font("Arial", 16);
                        Controls.Add(button);
                        top += button.Height + 2;
                        button.Click += new EventHandler(this.button_Click);
                        buttons[i, j] = button;                      

                    }
                }
            }
            else
            {
                MessageBox.Show(" give an odd number!");
            }        

        }
        //Χ ή Ο και να παίζει ο υπολογιστής
        void button_Click(object sender, EventArgs e)
        {
            int r1=0, r2=0;
            Random rand = new Random();
            Button button = sender as Button;  //Then you can access the Button properties. 

            button.Text = "X";
            button.Enabled = false;
            do
            {
                if (cntGl >= (kkk.q * kkk.q) / 2) 
                {
                    break; //gia na mhn ginei atermon
                }
                r1 = rand.Next(0, kkk.q);
                r2 = rand.Next(0, kkk.q);
            } while (buttons[r1, r2].Text == "X" || buttons[r1, r2].Text == "O"); //oso einai true 


            if (cntGl < (kkk.q * kkk.q) / 2)
            {
                buttons[r1, r2].Text = "O";
                buttons[r1, r2].Enabled = false;
            }
            
            cntGl++;
            checkForWinner();

        }
       
        
         private void checkForWinner()
         {
            int cnt = 0;
            int cntDx = 0;
            int cntDo = 0;
            int cntVdx = 0;
            int cntVdo = 0;
            bool iso = false;
            
            for (int i = 0; i < kkk.q; i++) {
                int cnt1 = 0;
                int cnt2 = 0;
                for (int j = 0; j < kkk.q -1; j++)
                {
                    if ((buttons[i, j].Text == buttons[i, j+1].Text) && (buttons[i, j].Text == "X")) //gia tis grammmes me x
                    {
                        cnt1++;
                    }
                    if ((buttons[i, j].Text == buttons[i, j + 1].Text) && (buttons[i, j].Text == "O")) //gia tis grammmes me o
                    {
                        cnt2++;
                    }
                    if (i == j)//gia thn kuria diagwnio
                    {
                        if (buttons[i, j].Text == "X")
                        {
                            cntDx++;
                        }
                        if (buttons[i, j].Text == "O")
                        {
                            cntDo++;
                        }
                    }
                    if (i == (kkk.q) - j - 1)// gia thn deutereboysa diagwnio
                    {
                        if (buttons[i, j].Text == "X")
                            cntVdx++;
                        if (buttons[i, j].Text == "O")
                            cntVdo++;
                    }
                    
                }
          
                if (cnt1 == kkk.q - 1)
                {
                    MessageBox.Show(" X wins , tic-tac-toe!");
                    iso = true;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Close();
                }
                if (cnt2 == kkk.q - 1)
                {
                    MessageBox.Show(" O  wins , tic-tac-toe!");
                    iso = true;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Close();
                }
                if ( (cntDx == kkk.q - 1 && buttons[kkk.q - 1, kkk.q - 1].Text == "X")|| (cntVdx == kkk.q - 1 && buttons[kkk.q - 1, 0].Text == "X"))
                {
                    MessageBox.Show(" x  wins , tic-tac-toe!");
                    iso = true;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Close();
                }
                if ((cntDo == kkk.q - 1 && buttons[kkk.q - 1, kkk.q - 1].Text == "O") || (cntVdo == kkk.q - 1 && buttons[kkk.q - 1, 0].Text == "O"))
                {
                    MessageBox.Show(" O  wins , tic-tac-toe!");
                    iso = true;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Close();
                }
                
            }
            //gia tis sthles
           for (int j = 0; j < kkk.q; j++)
            {
               int cnt1 = 0;
                int cnt2 = 0;
                for (int i = 0; i < kkk.q - 1; i++)
                    {
                    if ((buttons[i, j].Text == buttons[i+1, j].Text) && ( buttons[i, j].Text=="X"))
                    {
                        cnt1++;
                    }
                    if ((buttons[i, j].Text == buttons[i + 1, j].Text) && (buttons[i, j].Text == "O"))
                    {
                        cnt2++;
                    }
                    }
                if (cnt1 == kkk.q - 1)
                {
                    MessageBox.Show(" X  wins , tic-tac-toe!");
                    iso = true;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Close();
                }
                if (cnt2 == kkk.q - 1)
                {
                    MessageBox.Show(" O  wins , tic-tac-toe!");
                    iso = true;
                   
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Close();
                }
               
            }
            for (int i = 0; i < kkk.q; i++)
            {
                for (int j = 0; j < kkk.q; j++)
                {
                    if ((buttons[i, j].Text == "O") || (buttons[i, j].Text == "X"))
                    {
                        cnt++; //counter για να δουμε αν ολα τα κουμπια ειναι γεματα,βοηθαει για την ισοπαλια μετα 

                    }
                }
            }
            if ((cnt == kkk.q * kkk.q) && (iso == false))
                {
                MessageBox.Show("no one wins!!!");
                
                Form2 f2 = new Form2();
                f2.Show();
                this.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int top = 80;
            int left = 180;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(" give an odd number!");
            }
            kkk.q = int.Parse(textBox1.Text);
            buttons = new Button[kkk.q, kkk.q];


            if (kkk.q % 2 == 1 && kkk.q != 1 && kkk.q != 3)
            {
                for (int j = 0; j < kkk.q; j++)
                {
                    left = left + 52;
                    top = 80;
                    for (int i = 0; i < kkk.q; i++)
                    {
                        Button buttonn = new Button();
                        buttonn.Size = new Size(50, 50);
                        buttonn.Left = left;
                        buttonn.Top = top;
                        buttonn.BackColor = System.Drawing.Color.Gray;
                        buttonn.Font = new Font("Arial", 16);
                        Controls.Add(buttonn);
                        top += buttonn.Height + 2;
                        buttonn.Click += new EventHandler(this.buttonn_Click);
                        buttons[i, j] = buttonn;                      

                    }
                }
            }
            else
            {
                MessageBox.Show(" give an odd number!");
            }        

        }
       
            void buttonn_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;


            if (turn)           //Turn=true=X
            {
                button.Text = "X";
                count.countuserx++;
            }
            else
            { button.Text = "O";
                count.countusero++;
            }
                
                button.Enabled = false;
                checkForWinner();


                turn = !turn; // Turn =false=O (changes the true to false <=> kai to antistrofo)
                button.Enabled = false; // not change value

            label5.Text = count.countuserx.ToString();
            label6.Text = count.countusero.ToString();
        }
           
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
 
    }



