using System;
using System.Windows.Forms;

namespace lab12_krestiki_noliki
{
    public partial class Form1 : Form
    {
        private bool curPlayer = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sender.GetType().GetProperty("Text").SetValue(sender, (curPlayer) ? "X" : "O");
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);

            int code = chekWin();
            if (code == 0)
            {
                curPlayer = !curPlayer;
                int n = (curPlayer) ? 1 : 2;
                label1.Text = $"Ход {n} игрок";
            }
            else
            {
                int n = (curPlayer) ? 1 : 2;
                if (code == 1)
                    MessageBox.Show($"Победил игрок {n}");
                else
                    MessageBox.Show($"Ничья");
                button1.Text = "  ";
                button2.Text = "  ";
                button3.Text = "  ";
                button4.Text = "  ";
                button5.Text = "  ";
                button6.Text = "  ";
                button7.Text = "  ";
                button8.Text = "  ";
                button9.Text = "  ";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
        }
        private int chekWin()
        {
            char[,] M = new char[3, 3];
            M[0, 0] = button1.Text[0];
            M[0, 1] = button2.Text[0];
            M[0, 2] = button3.Text[0];
            M[1, 0] = button4.Text[0];
            M[1, 1] = button5.Text[0];
            M[1, 2] = button6.Text[0];
            M[2, 0] = button7.Text[0];
            M[2, 1] = button8.Text[0];
            M[2, 2] = button9.Text[0];

            if (M[1, 1] != ' ')
            {
                if ((M[1, 1] == M[1, 0]) && (M[1, 1] == M[1, 2]))
                    return 1;
                if ((M[1, 1] == M[0, 1]) && (M[1, 1] == M[2, 1]))
                    return 1;
                if ((M[0, 0] == M[1, 1]) && (M[0, 0] == M[2, 2]))
                    return 1; 
                if ((M[0, 2] == M[1, 1]) && (M[1, 1] == M[2, 0]))
                    return 1;
            }
            if (M[0, 0] != ' ')
            {
                if ((M[0, 0] == M[0, 1]) && (M[0, 0] == M[0, 2]))
                    return 1;
                if ((M[0, 0] == M[1, 0]) && (M[0, 0] == M[2, 0]))
                    return 1;
            }
            if (M[2, 2] != ' ')
            {
                if ((M[2, 2] == M[2, 1]) && (M[2, 2] == M[2, 0]))
                    return 1;
                if ((M[2, 2] == M[1, 2]) && (M[2, 2] == M[0, 2]))
                    return 1;
            }
            

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (M[i, j] == ' ')
                        return 0;
                }
            }
            return 2;
        }
    }
}
