namespace ContainerShip
{
    public partial class Form1 : Form
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        private Ships _car;
        /// <summary>
        /// Конструктор
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки машины
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new(pictureBoxCars.Width, pictureBoxCars.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _car?.DrawTransport(gr);
            pictureBoxCars.Image = bmp;
        }
        /// <summary>
        /// Изменение размеров формы отрисовки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxCars_Resize(object sender, EventArgs e)
        {
            _car?.ChangeBorders(pictureBoxCars.Width, pictureBoxCars.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new();
            _car = new Ships();
            _car.Init(rnd.Next(100, 300), rnd.Next(1000, 2000),
            Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
            _car.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100),
            pictureBoxCars.Width, pictureBoxCars.Height);
            toolStripStatusLabelSpeed.Text = "Скорость:" + _car.Speed;
            toolStripStatusLabelWeight.Text = "Вес: " + _car.Weight;
            toolStripStatusLabelColor.Text = "Цвет: " + _car.BodyColor.Name;
            Draw();
        }
        /// <summary>
         /// Обработка нажатия кнопок управления
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    _car?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    _car?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    _car?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    _car?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
        

        ///InitializeComponent();
    }
}
