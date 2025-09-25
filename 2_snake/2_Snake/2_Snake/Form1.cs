namespace _2_Snake
{
    public partial class Form1 : Form
    {
        private List<Cercle> Snake = new List<Cercle>();
        private Cercle food = new Cercle();
        public Form1()
        {
            InitializeComponent();

            new Settings();

            //Inicialitzem el timer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Start new game
            StartGame();

        }

        private void StartGame()
        {
            //Settings a Default
            new Settings();

            //Creem un nou objecte jugador
            Snake.Clear();
            Cercle head = new Cercle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            lblPunts.Text = Settings.Score.ToString();
            GenerateFood();

        }
        private void GenerateFood()
        {
            //Creem menjar a una posició random
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random r = new Random();
            food = new Cercle();
            food.X = r.Next(0, maxXPos);
            food.Y = r.Next(0, maxYPos);
        }
        private void UpdateScreen(Object sender, EventArgs e)
        {
            //mirem si el joc ha acabat
            if (Settings.GameOver)
            {
                //Mirem si apretem l'Enter
                if (Input.KeyPressed(Keys.Enter))
                {
                    //Tornem a jugar
                    StartGame();
                }
            }
            else//Mirem quin moviment fem
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }
            pbCanvas.Invalidate();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                //Pintem la serp
                for (int i = 0; i < Snake.Count; i++)
                {
                    //Assignem el color de la serp
                    Brush snakeColour;
                    if (i == 0)
                        snakeColour = Brushes.Black;    //Draw head
                    else
                        snakeColour = Brushes.Green;    //Rest of body

                    //Dibuixem cada boleta
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Width,
                                      Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));


                    //Dibuixem el menjar
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width,
                             food.Y * Settings.Height, Settings.Width, Settings.Height));

                }
            }
        }
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Move head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }
                }
                else
                {
                    //Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }

                //Comprobar colisions

            }
        }


    }
}
