using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class ImageHandler
    {
        private string _bitmapPath;
        private Bitmap _currentBitmap;
        private Bitmap _bitmapbeforeProcessing;
        private Bitmap _bitmapPrevCropArea;
        private RectArea[] m_arrRects = new RectArea[100];
        private Bitmap[] m_arrBitmaps = new Bitmap[100];
        private NumberRecognition m_numberRecModule = new NumberRecognition();

        private Bitmap m_BtmTemp;
        private RectArea m_RectTemp;
        private int[,] arrNumbers = new int[,] { { 1, 2, 1, 2, 0, 2, 2, 0, 2, 2, 0, 2, 1, 2, 1 }, { 2, 2, 2, 0, 2, 2, 0, 2, 2, 0, 2, 1, 0, 2, 1 }, { 2, 2, 2, 0, 0, 2, 0, 2, 0, 2, 1, 0, 2, 2, 1 }, { 2, 2, 2, 0, 2, 1, 0, 1, 1, 0, 0, 2, 0, 2, 1 }, { 2, 0, 1, 2, 0, 1, 2, 2, 2, 0, 2, 2, 0, 0, 1 }, { 2, 2, 2, 2, 0, 0, 0, 1, 1, 0, 0, 2, 2, 2, 0 }, { 0, 2, 0, 2, 0, 0, 2, 2, 2, 2, 0, 2, 1, 2, 1 }, { 2, 2, 2, 0, 0, 2, 0, 2, 0, 0, 2, 0, 1, 0, 0 }, { 1, 2, 1, 2, 0, 2, 1, 2, 2, 2, 0, 2, 1, 2, 1 }, { 2, 2, 2, 2, 0, 2, 2, 2, 1, 0, 1, 2, 0, 2, 0 } };
        
        private int getNumber(int[] _vector)
        {
            int[] arrDiffs = new int[10];
            for (int i = 0; i < 10; i++)
            {
                int nAllDiff = 0;
                for (int j = 0; j < 15; j++)
                {
                    int curModelVal = arrNumbers[i, j];
                    int curValueVal = _vector[j];
                    int nDiff = Math.Abs((curModelVal - curValueVal) * (curModelVal - curValueVal) * (curModelVal - curValueVal));
                    nAllDiff += nDiff;
                }
                arrDiffs[i] = nAllDiff;
            }
            int nMinDiff = 60;
            int nRetVal = 0;
            for (int i = 0; i < 10; i++)
            {
                if( nMinDiff > arrDiffs[i])
                {
                    nMinDiff = arrDiffs[i];
                    nRetVal = i;
                }
            }
            return nRetVal;
        }
        public ImageHandler()
        {

        }

        public Bitmap CurrentBitmap
        {
            get 
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);
                return _currentBitmap; 
            }
            set { _currentBitmap = value; }
        }

        public Bitmap BitmapBeforeProcessing
        {
            get { return _bitmapbeforeProcessing; }
            set { _bitmapbeforeProcessing = value; }
        }

        public string BitmapPath
        {
            get { return _bitmapPath; }
            set { _bitmapPath = value; }
        }

        public enum ColorFilterTypes
        {
            Red,
            Green,
            Blue
        };

        public void ResetBitmap()
        {
            if (_currentBitmap != null && _bitmapbeforeProcessing != null)
            {
                Bitmap temp = (Bitmap)_currentBitmap.Clone();
                _currentBitmap = (Bitmap)_bitmapbeforeProcessing.Clone();
                _bitmapbeforeProcessing = (Bitmap)temp.Clone();
            }
        }

        public void SaveBitmap(string saveFilePath)
        {
            _bitmapPath = saveFilePath;
            if (System.IO.File.Exists(saveFilePath))
                System.IO.File.Delete(saveFilePath);
            _currentBitmap.Save(saveFilePath);
        }

        public void ClearImage()
        {
            _currentBitmap = new Bitmap(1, 1);
        }

        public void RestorePrevious()
        {
            _bitmapbeforeProcessing = _currentBitmap;
        }

        public void SetColorFilter(ColorFilterTypes colorFilterType)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;
                    if (colorFilterType == ColorFilterTypes.Red)
                    {
                        nPixelR = c.R;
                        nPixelG = c.G - 255;
                        nPixelB = c.B - 255;
                    }
                    else if (colorFilterType == ColorFilterTypes.Green)
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G;
                        nPixelB = c.B - 255;
                    }
                    else if (colorFilterType == ColorFilterTypes.Blue)
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G - 255;
                        nPixelB = c.B;
                    }

                    nPixelR = Math.Max(nPixelR, 0);
                    nPixelR = Math.Min(255, nPixelR);

                    nPixelG = Math.Max(nPixelG, 0);
                    nPixelG = Math.Min(255, nPixelG);

                    nPixelB = Math.Max(nPixelB, 0);
                    nPixelB = Math.Min(255, nPixelB);

                    bmap.SetPixel(i, j, Color.FromArgb((byte)nPixelR, (byte)nPixelG, (byte)nPixelB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void SetGamma(double red, double green, double blue)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            byte[] redGamma = CreateGammaArray(red);
            byte[] greenGamma = CreateGammaArray(green);
            byte[] blueGamma = CreateGammaArray(blue);
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(redGamma[c.R], greenGamma[c.G], blueGamma[c.B]));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        private byte[] CreateGammaArray(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }

        public void SetBrightness(int brightness)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void SetContrast(double contrast)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void SetGrayscale()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }
        public void SetBinaryscale()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            int nMin = 255, nMax = 0;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    if (nMax < gray) nMax = gray;
                    if (nMin > gray) nMin = gray;
                }
            }
            int nMid = (nMin * 3 + nMax * 2) / 5;
            
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    if (gray > nMid) gray = 255;
                    else gray = 0;
                    bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }
        private void travelBitmap(int x, int y)
        {
            if (x < 0 || x >= m_BtmTemp.Width || y < 0 || y >= m_BtmTemp.Height)
                return;

            m_RectTemp.reCalcArea(x, y);
            m_BtmTemp.SetPixel(x, y, Color.FromArgb(0, 0, 0));

            Color c = m_BtmTemp.GetPixel(x - 1, y);
            if (c.R != 0)
                travelBitmap(x - 1, y);
            c = m_BtmTemp.GetPixel(x + 1, y);
            if (c.R != 0)
                travelBitmap(x + 1, y);
            c = m_BtmTemp.GetPixel(x, y + 1);
            if (c.R != 0)
                travelBitmap(x, y + 1);
            c = m_BtmTemp.GetPixel(x, y - 1);
            if (c.R != 0)
                travelBitmap(x, y - 1);
        }
        public void Processing()
        {
            String strVal = m_numberRecModule.Processing(_currentBitmap);
            MessageBox.Show(strVal);
            return;
            Bitmap temp = (Bitmap)_currentBitmap;
            Color c;
            int nMin = 255, nMax = 0;
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    c = temp.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    if (nMax < gray) nMax = gray;
                    if (nMin > gray) nMin = gray;
                }
            }
            int nMid = (nMin * 3 + nMax) / 4;

            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    c = temp.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    if (gray > nMid) gray = 255;
                    else gray = 0;
                    temp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            m_BtmTemp = (Bitmap)temp.Clone();
            int nArrRectCount = -1;
            String strRealVal = "";
            for ( int i = 0; i < m_BtmTemp.Width; i++)
            {
                for ( int j = 0; j < m_BtmTemp.Height; j++)
                {
                    c = m_BtmTemp.GetPixel(i, j);
                    byte value = (byte)c.R;
                    if (value != 0)
                    {
                        m_RectTemp = new RectArea(i, j);
                        travelBitmap(i, j);
                        i = m_RectTemp.right + 1;
                        if( m_RectTemp.Height() * 7 / 10 < m_RectTemp.Width())
                        {
                            int nCount = (int)Math.Round((double)(m_RectTemp.Width() * 2 / m_RectTemp.Height()));
                            for( int t = 0; t < nCount; t++)
                            {
                                nArrRectCount++;
                                m_arrRects[nArrRectCount] = new RectArea();
                                m_arrRects[nArrRectCount].left = (m_RectTemp.left * (nCount - t) + m_RectTemp.right * t) / nCount;
                                m_arrRects[nArrRectCount].right = (m_RectTemp.left * (nCount - t - 1) + m_RectTemp.right * (t + 1)) / nCount;
                                m_arrRects[nArrRectCount].top = m_RectTemp.top;
                                m_arrRects[nArrRectCount].bottom = m_RectTemp.bottom;
                            }
                        }
                        else
                        {
                            nArrRectCount++;
                            m_arrRects[nArrRectCount] = new RectArea();
                            m_arrRects[nArrRectCount].left = m_RectTemp.left;
                            m_arrRects[nArrRectCount].top = m_RectTemp.top;
                            m_arrRects[nArrRectCount].right = m_RectTemp.right;
                            m_arrRects[nArrRectCount].bottom = m_RectTemp.bottom;
                        }
                        break;
                    }
                }
            }
            m_BtmTemp = (Bitmap)temp.Clone();
            String allMessage = "";
            for ( int i = 0; i <= nArrRectCount; i++)
            {
                RectArea rect = m_arrRects[i];
                int nWidth = rect.right - rect.left + 1;
                int nHeight = rect.bottom - rect.top + 1;
                int nThreshold = nWidth * nHeight / 15;
                int[] vector = new int[15];
                for( int a = 0; a < 15; a++)
                {
                    vector[a] = 0;
                }
                for ( int x = rect.left; x <= rect.right; x++)
                {
                    for( int y = rect.top; y <= rect.bottom; y++)
                    {
                        c = m_BtmTemp.GetPixel(x, y);
                        byte value = (byte)(c.R / 255);
                        int nXPos = (x - rect.left) * 3 / nWidth;
                        //if (nXPos >= 3) nXPos = 2;
                        int nYPos = (y - rect.top) * 5 / nHeight;
                        //if (nYPos >= 5) nYPos = 4;
                        vector[nYPos * 3 + nXPos] += value;
                    }
                }
                String message = "";
                for( int a = 0; a < 15; a++)
                {
                    if (vector[a] < nThreshold / 2) vector[a] = 0;
                    else if (vector[a] < nThreshold * 3 / 4) vector[a] = 1;
                    else vector[a] = 2;
                    message = String.Concat( message, vector[a].ToString(), ",");
                }
                int nCurChar;
                if (nWidth < nHeight / 3)
                    nCurChar = 1;
                else
                    nCurChar = getNumber(vector);
                allMessage = String.Concat(allMessage, message, "\n");
                //MessageBox.Show(message);
                strRealVal = String.Concat(strRealVal, nCurChar.ToString());
            }
            MessageBox.Show(strRealVal);
        }
        public void SetInvert()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)_currentBitmap;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb(255, nRed, nGreen, nBlue));
                    }
                }
                _currentBitmap = (Bitmap)bmap.Clone();
            }
        }

        public void RotateFlip(RotateFlipType rotateFlipType)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            bmap.RotateFlip(rotateFlipType);
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void Crop(int xPosition, int yPosition, int width, int height)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (xPosition + width > _currentBitmap.Width)
                width = _currentBitmap.Width - xPosition;
            if (yPosition + height > _currentBitmap.Height)
                height = _currentBitmap.Height - yPosition;
            Rectangle rect = new Rectangle(xPosition, yPosition, width, height);
            _currentBitmap = (Bitmap)bmap.Clone(rect, bmap.PixelFormat);
        }

        public void DrawOutCropArea(int xPosition, int yPosition, int width, int height)
        {
            _bitmapPrevCropArea = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)_bitmapPrevCropArea.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            Brush cBrush = new Pen(Color.FromArgb(150, Color.White)).Brush;
            Rectangle rect1 = new Rectangle(0, 0, _currentBitmap.Width, yPosition);
            Rectangle rect2 = new Rectangle(0, yPosition, xPosition, height);
            Rectangle rect3 = new Rectangle(0, (yPosition + height), _currentBitmap.Width, _currentBitmap.Height);
            Rectangle rect4 = new Rectangle((xPosition + width), yPosition, (_currentBitmap.Width - xPosition - width), height);
            gr.FillRectangle(cBrush, rect1);
            gr.FillRectangle(cBrush, rect2);
            gr.FillRectangle(cBrush, rect3);
            gr.FillRectangle(cBrush, rect4);
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void RemoveCropAreaDraw()
        {
            _currentBitmap = (Bitmap)_bitmapPrevCropArea.Clone();
        }

        public void InsertText(string text, int xPosition, int yPosition, string fontName, float fontSize, string fontStyle, string colorName1, string colorName2)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (string.IsNullOrEmpty(fontName))
                fontName = "Times New Roman";
            if (fontSize.Equals(null))
                fontSize = 10.0F;
            Font font = new Font(fontName, fontSize);
            if (!string.IsNullOrEmpty(fontStyle))
            {
                FontStyle fStyle = FontStyle.Regular;
                switch (fontStyle.ToLower())
                {
                    case "bold":
                        fStyle = FontStyle.Bold;
                        break;
                    case "italic":
                        fStyle = FontStyle.Italic;
                        break;
                    case "underline":
                        fStyle = FontStyle.Underline;
                        break;
                    case "strikeout":
                        fStyle = FontStyle.Strikeout;
                        break;

                }
                font = new Font(fontName, fontSize, fStyle);
            }
            if (string.IsNullOrEmpty(colorName1))
                colorName1 = "Black";
            if (string.IsNullOrEmpty(colorName2))
                colorName2 = colorName1;
            Color color1 = Color.FromName(colorName1);
            Color color2 = Color.FromName(colorName2);
            int gW = (int)(text.Length * fontSize);
            gW = gW == 0 ? 10 : gW;
            LinearGradientBrush LGBrush = new LinearGradientBrush(new Rectangle(0, 0, gW, (int)fontSize), color1, color2, LinearGradientMode.Vertical);
            gr.DrawString(text, font, LGBrush, xPosition, yPosition);
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void InsertImage(string imagePath, int xPosition, int yPosition)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (!string.IsNullOrEmpty(imagePath))
            {
                Bitmap i_bitmap = (Bitmap)Bitmap.FromFile(imagePath);
                Rectangle rect = new Rectangle(xPosition, yPosition, i_bitmap.Width, i_bitmap.Height);
                gr.DrawImage(Bitmap.FromFile(imagePath), rect);
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void InsertShape(string shapeType, int xPosition, int yPosition, int width, int height, string colorName)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (string.IsNullOrEmpty(colorName))
                colorName = "Black";
            Pen pen = new Pen(Color.FromName(colorName));
            switch (shapeType.ToLower())
            {
                case "filledellipse":
                    gr.FillEllipse(pen.Brush, xPosition, yPosition, width, height);
                    break;
                case "filledrectangle":
                    gr.FillRectangle(pen.Brush, xPosition, yPosition, width, height);
                    break;
                case "ellipse":
                    gr.DrawEllipse(pen, xPosition, yPosition, width, height);
                    break;
                case "rectangle":
                default:
                    gr.DrawRectangle(pen, xPosition, yPosition, width, height);
                    break;
               
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }
    }
}
