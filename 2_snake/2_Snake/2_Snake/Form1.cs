using _2_Snake;
using System.Drawing.Text;

namespace _2_Snake
{
    public partial class Form1 : Form
    {

        private List<Cercle> Snake = new List<Cercle>();
        private Cercle food = new Cercle();
        private Cercle mina = new Cercle();
        private bool menuPrincipal = true; //Mires si esta en el menu principal
        private int nivellSeleccionat = 2; //per defecte el nivell normal qu és el 2

        public Form1()
        {
            InitializeComponent();

            //Inicialitzem el timer
            gameTimer.Interval = 1000 / Math.Max(1, Settings.Speed);
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
            SelNivell(nivellSeleccionat);
            StartGame();


        }

        private void StartGame()
        {    
     
            
            //Creem un nou objecte jugador
            Snake.Clear();
            Cercle head = new Cercle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            lblPunts.Text = Settings.Score.ToString();
            GenerateFood();
  
        }
        private void SelNivell(int nivell)
        {
            Settings.Reset();
            // Assigna la velocitat segons el nivell
            switch (nivell)
            {
                case 1:
                    Settings.Speed = 8;
                    Settings.Points = 100;
                    Settings.Width = 24;
                    Settings.Height = 24;
                    break;      // Fàcil
                case 2:
                    Settings.Speed = 50;
                    Settings.Points = 25;
                    break;     // Normal
                case 3:
                    Settings.Speed = 24;
                    Settings.Points = 25;
                    Settings.Width = 12;
                    Settings.Height = 12;                    
                    
                    break;     // Difícil
                default: Settings.Speed = 16; break;
            }
            gameTimer.Interval = 1000 / Math.Max(1, Settings.Speed);

        }

private void GenerateFood()//Genero manjar, pero comprovo que no coincideixi amb la serp
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;
            Random r = new Random();

            bool lliure = false;
            int x = 0, y = 0;

            while (!lliure)
            {
                // 1. Genera una posició aleatòria
                x = r.Next(0, maxXPos);
                y = r.Next(0, maxYPos);

                // 2. Comprova si coincideix amb alguna part de la serp
                lliure = true;
                foreach (var serp in Snake)
                {
                    if (serp.X == x && serp.Y == y)
                    {
                        lliure = false; // Si coincideix, no és vàlida
                        break;
                    }
                }
            }

            // 3. Quan troba una posició lliure, assigna el menjar
            food = new Cercle { X = x, Y = y };
        }
        private void polsartecles()
        {
            if(Input.KeyPressed(Keys.Space))
               {
                gameTimer.Interval = 1000 / Math.Max(1, Settings.Speed*2);
            }
            else 
            {
                gameTimer.Interval = 1000 / Math.Max(1, Settings.Speed);
            }
            //si apreta escape, game over
            if (Input.KeyPressed(Keys.Escape))
            {
                Settings.GameOver = true;
            }

            //mirem si el joc ha acabat
            if (Settings.GameOver)
            {

                //Mirem si apretem l'Enter
                if (Input.KeyPressed(Keys.Enter))
                {
                    //Tornem a jugar
                    menuPrincipal = true;
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
                //Comprovem si la serp ha xocat
                
            }
        }
        private void UpdateScreen(Object sender, EventArgs e)
        {
            EscoltarMenu();
            SnakeXoc();
            polsartecles();
            pbCanvas.Invalidate();
            return;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        //manejo el pbcanvas per mostrar diferents pantalles i el separo amb funcions
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;            
            canvas.Clear(Color.MidnightBlue);

            if (menuPrincipal)
            {
                PantallaMenu(canvas);
                return;//obliga a sortir per evitar que s'executi el codi de sota
            }

            if (!Settings.GameOver && !menuPrincipal)
            {
                PantallaJoc(canvas);
            }
            else
            {
                DrawGameOver(canvas);
            }
        }

        private void PantallaMenu(Graphics canvas)
        {
            
            string titol = "SNAKE";
            string instruccions = "1 - Fàcil\n2 - Normal\n3 - Difícil";
            string info = "Selecciona per començar";

            using (Font fontTitol = new Font("Arial", 48, FontStyle.Bold))
            using (Font fontOpcions = new Font("Arial", 24, FontStyle.Regular))
            using (Font fontInfo = new Font("Arial", 16, FontStyle.Italic))
            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                canvas.DrawString(titol, fontTitol, Brushes.Gold, new Rectangle(0, 40, pbCanvas.Width, 80), format);
                canvas.DrawString(instruccions, fontOpcions, Brushes.White, new Rectangle(0, 150, pbCanvas.Width, 200), format);
                canvas.DrawString(info, fontInfo, Brushes.LightGray, new Rectangle(0, 350, pbCanvas.Width, 50), format);
            }
            
        }

        private void PantallaJoc(Graphics canvas)
        {
            // Colors de la serp
            for (int i = 0; i < Snake.Count; i++)
            {
                Brush snakeColour;
                if (i == 0)
                    snakeColour = Brushes.Black;
                else if (i == Snake.Count - 1)//Es la cua canviada de color
                    snakeColour = Brushes.DarkGoldenrod;
                else
                    snakeColour = Brushes.Green;

                canvas.FillEllipse(
                    snakeColour,
                    new Rectangle(
                        Snake[i].X * Settings.Width,
                        Snake[i].Y * Settings.Height,
                        Settings.Width,
                        Settings.Height
                    )
                );
            }

            // Menjar (defensiu per si encara no hi és)
            if (food != null)
            {
                canvas.FillEllipse(
                    Brushes.Red,
                    new Rectangle(
                        food.X * Settings.Width,
                        food.Y * Settings.Height,
                        Settings.Width,
                        Settings.Height
                    )
                );
            }
            if (nivellSeleccionat == 3 && mina != null)//copio els altres codis i dibuixem la mina
            {
                canvas.FillEllipse(
                    Brushes.Gray,
                    new Rectangle(
                        mina.X * Settings.Width,
                        mina.Y * Settings.Height,
                        Settings.Width,
                        Settings.Height
                    )
                );
            }

        }

        private void DrawGameOver(Graphics canvas)
        {
            canvas.Clear(Color.DarkTurquoise);

            string text1 = "Game Over";
            string text2 = "Enter per reiniciar";

            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (Font f1 = new Font("Arial", 40, FontStyle.Bold))
            using (Font f2 = new Font("Arial", 20, FontStyle.Bold))
            {
                canvas.DrawString(text1, f1, Brushes.Red, new Rectangle(0, pbCanvas.Height / 2 - 60, pbCanvas.Width, 60), format);
                canvas.DrawString(text2, f2, Brushes.White, new Rectangle(0, pbCanvas.Height / 2 + 10, pbCanvas.Width, 40), format);
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
                              
                //menjar

                if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                {
                    //La serp menja
                    Menja();
                }

            }
        }
        private void Menja()
        {
            //Afegim una boleta a la serp
            Cercle cercle = new Cercle();
            cercle.X = Snake[Snake.Count - 1].X;
            cercle.Y = Snake[Snake.Count - 1].Y;
            Snake.Add(cercle);
            //Incrementem la puntuació
            Settings.Score += Settings.Points;
            lblPunts.Text = Settings.Score.ToString();
            GenerateFood();
            if (nivellSeleccionat == 3) // només si és difícil
                Mina();

        }
        private bool SnakeXoc()//Comprova si la serp ha xocat amb alguna paret o amb ella mateixa
        {
            if (Snake[0].X < 0 || Snake[0].Y < 0 || Snake[0].X >= pbCanvas.Size.Width / Math.Max(1, Settings.Width) || Snake[0].Y >= pbCanvas.Size.Height / Math.Max(1, Settings.Height))

            {
                return Settings.GameOver = true;
            }
            else if (MateixaPosicio())
                return Settings.GameOver = true;
            else if(Snake[0].X == mina.X && Snake[0].Y == mina.Y && nivellSeleccionat == 3)
                return Settings.GameOver = true;
            else
                return Settings.GameOver = false;
        }
        private bool MateixaPosicio()//Comprova si el cap de la serp està a la mateixa posició que alguna altra part del cos
        {
            for (int i = 2; i < Snake.Count - 1; i++)
            {
                if (Snake[0].X == Snake[i].X && Snake[0].Y == Snake[i].Y)
                    return true;
            }
            return false;


        }
        private void EscoltarMenu()
        {
            if (Input.KeyPressed(Keys.D1) || Input.KeyPressed(Keys.NumPad1))
            {
                Settings.Reset();
                nivellSeleccionat = 1;
                SelNivell(nivellSeleccionat);
                menuPrincipal = false;
                StartGame();
                Settings.GameOver = false;

            }
            else if (Input.KeyPressed(Keys.D2) || Input.KeyPressed(Keys.NumPad2))
            {
                Settings.Reset();
                nivellSeleccionat = 2;
                SelNivell(nivellSeleccionat);
                menuPrincipal = false;
                StartGame();
                Settings.GameOver = false;
            }
            else if (Input.KeyPressed(Keys.D3) || Input.KeyPressed(Keys.NumPad3))
            {
                Settings.Reset();
                nivellSeleccionat = 3;
                SelNivell(nivellSeleccionat);
                menuPrincipal = false;                
                StartGame();
                Settings.GameOver = false;
            }
        }
        private void Mina()//Genero mines, pero comprovo que no coincideixi amb la serp
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;
            Random r = new Random();

            bool lliure = false;
            int h = 0, j = 0;

            while (!lliure)
            {
                // 1. Genera una posició aleatòria
                h = r.Next(0, maxXPos);
                j = r.Next(0, maxYPos);

                // 2. Comprova si coincideix amb alguna part de la serp
                lliure = true;
                foreach (var serp in Snake)
                {
                    if (serp.X == h && serp.Y == j)
                    {
                        lliure = false; // Si coincideix, no és vàlida
                        break;
                    }
                }
            }

            // 3. Quan troba una posició lliure, assigna el menjar
            mina = new Cercle { X = h, Y = j };
            

        }

    }
}
