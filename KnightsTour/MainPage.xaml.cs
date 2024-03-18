﻿namespace KnightsTour
    {
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            AddButtonsToGrid();
        }

        private int gridSize = 7; // Grid boyutu

        private void AddButtonsToGrid()
        {
            for (int row = 1; row <= gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button button = new Button
                    {
                        Text = "",
                        Margin = new Thickness(2),
                    };
                    button.Clicked += OnButtonClicked;

                    // Öğeyi Grid'in Children koleksiyonuna ekleyin
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    myGrid.Children.Add(button);
                }
            }
        }
        private void OnResetClicked(object sender, EventArgs e)
        {
            // Sayaçı sıfırla
            count = 1;
            ResultLabel.Text = "0";

            // Tüm butonların metinlerini ve tıklanabilirlik durumlarını sıfırla
            foreach (View view in myGrid.Children)
            {
                if (view is Button button)
                {
                    button.Text = "";
                    button.IsEnabled = true;
                }
            }
        }


        private int count = 1; // Sayaç değişkeni

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Eğer butona daha önce tıklandıysa işlem yapma
            if (!string.IsNullOrEmpty(clickedButton.Text))
            {
                return;
            }

            int clickedRow = Grid.GetRow(clickedButton);
            int clickedCol = Grid.GetColumn(clickedButton);

            int buttonText;
            if (count > 9)
            {
                buttonText = count;
                clickedButton.FontSize = 15;
            }
            else
            {
                buttonText = count;
            }

            clickedButton.Text = count.ToString(); // Sayaç değerini butona yaz
            ResultLabel.Text = $" {count}";

            count++; // Sayaç değerini artır

            clickedButton.IsEnabled = false;

            // Butonların yüksekliğini ayarla
            foreach (View view in myGrid.Children)
            {
                if (view is Button button)
                {
                    button.HeightRequest = clickedButton.Height;
                }
            }

            // Tüm butonları devre dışı bırak
            foreach (View view in myGrid.Children)
            {
                if (view is Button button)
                {
                    button.IsEnabled = false;
                }
            }

            // Tıklanan buton ve komşu butonları aktifleştir
            EnableButtons(clickedRow, clickedCol);
        }





        private bool gameEnded = false; // Oyunun bitip bitmediğini tutan değişken

        private void EnableButtons(int row, int col)
        {
            bool anyButtonEnabled = false; // Aktifleştirilebilecek bir butonun olup olmadığını belirten bayrak

            // Belirtilen koşullara göre komşu butonları aktifleştir
            anyButtonEnabled |= EnableButton(row - 1, col - 2);
            anyButtonEnabled |= EnableButton(row - 1, col + 2);
            anyButtonEnabled |= EnableButton(row + 1, col - 2);
            anyButtonEnabled |= EnableButton(row + 1, col + 2);
            anyButtonEnabled |= EnableButton(row - 2, col - 1);
            anyButtonEnabled |= EnableButton(row - 2, col + 1);
            anyButtonEnabled |= EnableButton(row + 2, col - 1);
            anyButtonEnabled |= EnableButton(row + 2, col + 1);

            // Eğer aktifleştirilebilecek bir buton yoksa oyunu bitir
            if (!anyButtonEnabled)
            {
                gameEnded = true;
                ResultLabel.Text = $"Oyun Bitti! Skor: {count}";
                // Oyun bittiğinde yapılacak işlemler buraya gelebilir
            }
        }

        private bool EnableButton(int row, int col)
        {
            // Belirtilen konumdaki butonu aktifleştir (sınırları kontrol ederek)
            if (row >= 0 && row < 8 && col >= 0 && col < 7)
            {
                Button button = GetButtonByRowColumn(row, col);
                if (button != null)
                {
                    if (string.IsNullOrEmpty(button.Text))
                    {
                        button.IsEnabled = true;
                        return true; // Aktifleştirilebilecek bir buton bulunduğunu belirt
                    }
                }
            }
            return false; // Aktifleştirilebilecek bir buton bulunamadığını belirt
        }

        private Button GetButtonByRowColumn(int row, int col)
        {
            foreach (View view in myGrid.Children)
            {
                if (Grid.GetRow(view) == row && Grid.GetColumn(view) == col && view is Button)
                {
                    return (Button)view;
                }
            }
            return null;
        }


    }
}