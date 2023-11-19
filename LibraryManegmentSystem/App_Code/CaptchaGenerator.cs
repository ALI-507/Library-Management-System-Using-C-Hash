using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;


public class CaptchaGenerator
{
    public static Bitmap GenerateCaptcha(out string captchaText)
    {
        const int captchaLength = 5; // Length of the captcha (number of characters)
        const int imageWidth = 200;
        const int imageHeight = 60;
        const int lineCount = 10;
        const int lineThickness = 2;
        const int borderWidth = 2;
        const int borderOffset = borderWidth / 2;

        Random random = new Random();
        StringBuilder captchaBuilder = new StringBuilder();

        // Generate captcha text with random numbers and characters
        string captchaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        for (int i = 0; i < captchaLength; i++)
        {
            int index = random.Next(0, captchaChars.Length);
            captchaBuilder.Append(captchaChars[index]);
        }

        captchaText = captchaBuilder.ToString();

        // Calculate the total image size including the border
        int totalWidth = imageWidth + borderWidth;
        int totalHeight = imageHeight + borderWidth;

        // Generate captcha image
        Bitmap captchaImage = new Bitmap(totalWidth, totalHeight);
        using (Graphics graphics = Graphics.FromImage(captchaImage))
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Fill the image background with white color
            graphics.Clear(Color.White);

            // Add black border
            using (Pen borderPen = new Pen(Color.Black, borderWidth))
            {
                graphics.DrawRectangle(borderPen, borderOffset, borderOffset, imageWidth, imageHeight);
            }

            // Add random color lines on top of characters
            int linesOnTopOfCharacters = lineCount / 2;
            for (int i = 0; i < linesOnTopOfCharacters; i++)
            {
                int x1 = random.Next(imageWidth) + borderOffset;
                int y1 = random.Next(imageHeight) + borderOffset;
                int x2 = random.Next(imageWidth) + borderOffset;
                int y2 = random.Next(imageHeight) + borderOffset;
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                using (Pen pen = new Pen(randomColor, lineThickness))
                {
                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }

            // Add the captcha text
            int xPosition = 10 + borderOffset;
            int yPosition = imageHeight / 2 + borderOffset;

            float charSpacing = (float)(imageWidth - 20) / (captchaLength + 1);

            for (int i = 0; i < captchaText.Length; i++)
            {
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    // Randomly choose font size and style
                    int fontSize = random.Next(30, 35);
                    FontStyle fontStyle = (random.Next(2) == 0) ? FontStyle.Bold : FontStyle.Regular;

                    // Create font with random size and style
                    Font font = new Font("Arial", fontSize, fontStyle);

                    // Calculate the position of the character
                    SizeF textSize = graphics.MeasureString(captchaText[i].ToString(), font);
                    float charX = xPosition + (i + 1) * charSpacing - textSize.Width / 2;
                    float charY = yPosition - textSize.Height / 2;

                    // Draw the character
                    graphics.DrawString(captchaText[i].ToString(), font, brush, charX, charY);
                }
            }
        }

        return captchaImage;
    }
}


