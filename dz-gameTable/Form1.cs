using dz_gameTable.Models;

namespace dz_gameTable
{
    public partial class Form1 : Form
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                Studio at = new Studio() { Name = textBox1.Text,year = Convert.ToInt32(textBox2.Text) };
                db.studios.Add(at);
                db.SaveChanges();
                MessageBox.Show("Студия добавлена");
            }
            else
            {
                MessageBox.Show("Введите значение");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var at = db.studios.ToList();
            foreach (Studio a in at)
            {
                if (a.Name == textBox5.Text)
                {
                    Game pt = new Game() { Name = textBox3.Text, genre = textBox4.Text, studio = a.Id,multiplayer = Convert.ToBoolean(textBox7.Text) , copiesSold = Convert.ToInt32(textBox6.Text), year = Convert.ToInt32(textBox8.Text) };
                    db.Games.Add(pt);
                    db.SaveChanges();
                    MessageBox.Show("Игра добавлена");
                    break;
                }
                else
                {
                    MessageBox.Show("Введите значение");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = "True";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Text = "False";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var at = db.Games.ToList();
            foreach (Game a in at)
            {
                if (a.Name == textBox9.Text)
                {
                    db.Games.Remove(a);
                    db.SaveChanges();
                    MessageBox.Show("Игра удаленна");
                }
                else
                {
                    MessageBox.Show("Игра не найдена");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var st = db.studios.ToList();
            foreach (Studio s in st)
            {
                var at = db.Games.ToList();
                foreach (Game a in at)
                {
                    if (s.Id == a.studio)
                    {
                        textBox3.Text = a.Name;
                        textBox4.Text = a.genre;
                        textBox5.Text = s.Name;
                        textBox6.Text = Convert.ToString(a.copiesSold);
                        textBox7.Text = Convert.ToString(a.multiplayer);
                        textBox8.Text = Convert.ToString(a.year);

                        db.Games.Remove(a);
                        db.SaveChanges();
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var st = db.studios.ToList();
            foreach (Studio s in st)
            {
                var at = db.Games.ToList();
                foreach (Game a in at)
                {
                    if (a.Name == textBox10.Text)
                    {
                        if (s.Id == a.studio)
                        {
                            listBox1.Items.Add(a.Name);
                            listBox1.Items.Add(a.genre);
                            listBox1.Items.Add(s.Name);
                            listBox1.Items.Add(a.copiesSold);
                            listBox1.Items.Add(a.multiplayer);
                            listBox1.Items.Add(a.year);
                        }
                    }
                     if(s.Name == textBox10.Text && s.Id == a.studio)
                    {
                        listBox1.Items.Add(a.Name);
                        listBox1.Items.Add(a.genre);
                        listBox1.Items.Add(s.Name);
                        listBox1.Items.Add(a.copiesSold);
                        listBox1.Items.Add(a.multiplayer);
                        listBox1.Items.Add(a.year);
                    }
                    if(a.genre == textBox10.Text)
                    {
                        listBox1.Items.Add(a.Name);
                        listBox1.Items.Add(a.genre);
                        listBox1.Items.Add(s.Name);
                        listBox1.Items.Add(a.copiesSold);
                        listBox1.Items.Add(a.multiplayer);
                        listBox1.Items.Add(a.year);
                    }
                    if (a.year == Convert.ToInt32(textBox10.Text))
                    {
                        listBox1.Items.Add(a.Name);
                        listBox1.Items.Add(a.genre);
                        listBox1.Items.Add(s.Name);
                        listBox1.Items.Add(a.copiesSold);
                        listBox1.Items.Add(a.multiplayer);
                        listBox1.Items.Add(a.year);
                    }
                    else
                    {
                        MessageBox.Show("Игра не найдена");
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var ct = db.Games
              .Where(c => c.multiplayer == false)
              .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var ct = db.Games
              .Where(c => c.multiplayer == true)
              .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var ct = db.Games
               .OrderByDescending(c => c.copiesSold)
               .Take(1)
               .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var ct = db.Games
              .OrderBy(c => c.copiesSold)
              .Take(1)
              .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var ct = db.Games
               .OrderByDescending(c => c.copiesSold)
               .Take(3)
               .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var ct = db.Games
              .OrderBy(c => c.copiesSold)
              .Take(3)
              .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }
    }
}