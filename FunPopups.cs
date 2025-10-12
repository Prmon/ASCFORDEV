using System;
using System.Windows.Forms;
using System.Drawing;

public class FunPopups
{
    private static bool popupOpen = false;

    // Call this in your main update loop
    public static void CheckKeyPress()
    {
        if (popupOpen) return;

        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.P: // Nyanza Cat
                    ShowPopup("Nyanza Cat!", "https://cataas.com/cat/gif");
                    break;

                case ConsoleKey.D0: // Dog GIF
                    ShowPopup("Doggo!", "https://placedog.net/300/300"); // Replace with your favorite dog GIF
                    break;
            }
        }
    }

    private static void ShowPopup(string title, string imageUrl)
    {
        popupOpen = true;

        Form popup = new Form()
        {
            Width = 300,
            Height = 300,
            FormBorderStyle = FormBorderStyle.FixedToolWindow,
            StartPosition = FormStartPosition.CenterScreen,
            Text = title
        };

        PictureBox pb = new PictureBox()
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.StretchImage,
            ImageLocation = imageUrl
        };

        popup.Controls.Add(pb);

        popup.FormClosed += (s, e) => { popupOpen = false; };

        popup.Show();
    }
}
