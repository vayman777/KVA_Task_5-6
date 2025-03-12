using System.Xml.Linq;

namespace KVA_Task_5
{
    public partial class Form1 : Form
    {
        const int sizeField = 60;
        private SudokuFiles _game = new SudokuFiles();
        int[,] _field = new int[9,9];
        private TextBox[,] _textBoxes = new TextBox[9, 9];

        private Button _loadButton;
        private Button _checkButton;
        private ComboBox _сomboBox; 

        public Form1()
        {
            InitializeComponent();
            GenerateField();
        }

        public void GenerateField()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _textBoxes[i, j] = new TextBox();
                }
            }

            CreateField();
        }


        public void CreateField()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox textbox_field = new TextBox();
                    _textBoxes[i, j] = textbox_field;

                    _textBoxes[i, j].Name = Convert.ToString(i) + " " + Convert.ToString(j);
                    textbox_field.Size = new Size(sizeField, sizeField);
                    textbox_field.Text = _field[i, j] == 0 ? "" : _field[i, j].ToString();
                    textbox_field.ForeColor = Color.FromArgb(0, 0, 0);
                    textbox_field.BackColor = Color.FromArgb(250, 250, 250);
                    textbox_field.Font = new Font("", 18F, FontStyle.Bold);
                    textbox_field.Location = new Point(j * sizeField + 140, i * sizeField + 60);
                    textbox_field.Multiline = true;
                    textbox_field.TextAlign = HorizontalAlignment.Center;

                    textbox_field.KeyPress += (sender, e) =>
                    {
                        if (!char.IsControl(e.KeyChar) && (e.KeyChar < '1' || e.KeyChar > '9'))
                        {
                            e.Handled = true; 
                        }

                        if (textbox_field.Text.Length >= 1 && !char.IsControl(e.KeyChar))
                        {
                            e.Handled = true; 
                        }
                    };

                    textbox_field.TextChanged += (sender, e) =>
                    {
                        ValidateSudoku();
                    };
                    textbox_field.LostFocus += (sender, e) =>
                    {
                        ValidateSudoku();
                    };

                    textbox_field.Click += (sender, e) =>
                    {
                        var index = textbox_field.Name.Split(' ');
                        for (int k = 0; k < 9; k++)
                        {
                            _textBoxes[Convert.ToInt32(index[0]), k].BackColor = Color.Gray;
                        }
                        for (int m = 0; m < 9; m++)
                        {
                            _textBoxes[m, Convert.ToInt32(index[1])].BackColor = Color.Gray;
                        }
                    };
                    this.Controls.Add(textbox_field);
                }
            }
        }


        private void LoadButton_Click(object sender, EventArgs e)
        {
            _game.LoadFromFile(_сomboBox.Text == "Легкий" ? "easylevel.txt" : _сomboBox.Text == "Средний" ? "midlevel.txt" : "hardlevel.txt");

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_game.Board[i, j] == 0)
                    {
                        _textBoxes[i, j].Text = "";
                        _textBoxes[i, j].ReadOnly = false;
                    }
                    else
                    {
                        _textBoxes[i, j].Text = _game.Board[i, j].ToString();
                        _textBoxes[i, j].ReadOnly = true;
                    }
                    _textBoxes[i, j].Text = _game.Board[i, j] == 0 ? "" : _game.Board[i, j].ToString();
                    _textBoxes[i, j].BackColor = _game.Board[i, j] != 0 ? Color.LightGray : Color.White;
                }
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            var difficulty = _сomboBox.Text;
            bool isCorrect = CheckSolution(difficulty);
            MessageBox.Show(isCorrect ? "Решение верное!" : "Решение неверное.");
        }

        private bool CheckSolution(string difficulty)
        {
            var solution = new SudokuFiles();
            string fileName = difficulty == "Легкий" ? "easycheck.txt" : difficulty == "Средний" ? "midcheck.txt" : "hardcheck.txt";
            solution.LoadFromFile(fileName);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_textBoxes[i, j].Text != solution.Board[i, j].ToString())
                    {
                        return false;
                    }

                }
            }

            return true;
        }

        private void ValidateSudoku()
        {
            Recolor();

            bool[,] isBlockValid = new bool[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    isBlockValid[i, j] = true;

            for (int i = 0; i < 9; i++)
            {
                Dictionary<string, List<TextBox>> rowDuplicates = new Dictionary<string, List<TextBox>>();
                Dictionary<string, List<TextBox>> colDuplicates = new Dictionary<string, List<TextBox>>();

                for (int j = 0; j < 9; j++)
                {
                    string rowValue = _textBoxes[i, j].Text;
                    string colValue = _textBoxes[j, i].Text;

                    if (!string.IsNullOrEmpty(rowValue))
                    {
                        if (!rowDuplicates.ContainsKey(rowValue))
                            rowDuplicates[rowValue] = new List<TextBox>();
                        rowDuplicates[rowValue].Add(_textBoxes[i, j]);
                    }

                    if (!string.IsNullOrEmpty(colValue))
                    {
                        if (!colDuplicates.ContainsKey(colValue))
                            colDuplicates[colValue] = new List<TextBox>();
                        colDuplicates[colValue].Add(_textBoxes[j, i]);
                    }
                }

                foreach (var pair in rowDuplicates)
                    if (pair.Value.Count > 1)
                        foreach (var textBox in pair.Value)
                            textBox.BackColor = Color.Red;
                foreach (var pair in colDuplicates)
                    if (pair.Value.Count > 1)
                        foreach (var textBox in pair.Value)
                            textBox.BackColor = Color.Red;
            }

            // Проверка блоков 3×3
            for (int blockRow = 0; blockRow < 3; blockRow++)
            {
                for (int blockCol = 0; blockCol < 3; blockCol++)
                {
                    Dictionary<string, List<TextBox>> blockDuplicates = new Dictionary<string, List<TextBox>>();
                    bool blockComplete = true;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int row = blockRow * 3 + i;
                            int col = blockCol * 3 + j;
                            string value = _textBoxes[row, col].Text;

                            if (string.IsNullOrEmpty(value))
                                blockComplete = false;

                            if (!string.IsNullOrEmpty(value))
                            {
                                if (!blockDuplicates.ContainsKey(value))
                                    blockDuplicates[value] = new List<TextBox>();
                                blockDuplicates[value].Add(_textBoxes[row, col]);
                            }
                        }
                    }

                    foreach (var pair in blockDuplicates)
                        if (pair.Value.Count > 1)
                            foreach (var textBox in pair.Value)
                                textBox.BackColor = Color.Red;

                    if (blockComplete && blockDuplicates.Values.All(list => list.Count == 1))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                int row = blockRow * 3 + i;
                                int col = blockCol * 3 + j;
                                _textBoxes[row, col].BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
        }
        private void Recolor()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //_textBoxes[i, j].Text = "";
                    _textBoxes[i, j].BackColor = _game.Board[i, j] != 0 ? Color.LightGray : Color.White;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
