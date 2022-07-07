using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RefactorMe
{
    static class Painter
    {
        static float x, y;
        private static Graphics s_graphics;

        public static void Initialize(Graphics newGraphics)
        {
            s_graphics = newGraphics;
            s_graphics.SmoothingMode = SmoothingMode.None;
            s_graphics.Clear(Color.Black);
        }

        public static void SetInitialPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        /// <summary>
        /// Рисует линию указанных цвета и длины, в указанном направлении в радианах.
        /// </summary>
        /// <param name="length">Длина линии.</param>
        /// <param name="directionAngleRadians">Угол направления линии в радианах.</param>
        public static void DrawLine(Pen pen, double length, double directionAngleRadians)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию.
            var x1 = (float)(x + length * Math.Cos(directionAngleRadians));
            var y1 = (float)(y + length * Math.Sin(directionAngleRadians));

            s_graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }
        /// <summary>
        /// Меняет начальную позицию посредством перемещения линией из текущей позиции в нужную точку.
        /// </summary>
        /// <param name="length">Длина линии.</param>
        /// <param name="directionAngleRadians">Угол направления линии в радианах.</param>
        public static void ChangeCurrentPosition(double length, double directionAngleRadians)
        {
            x = (float)(x + length * Math.Cos(directionAngleRadians));
            y = (float)(y + length * Math.Sin(directionAngleRadians));
        }
    }

    public static class ImpossibleSquare
    {
        private static readonly double SqrtOfTwo = Math.Sqrt(2);
        private static readonly double HalfPI = Math.PI / 2;
        private static readonly double QuarterPI = Math.PI / 4;
        private static readonly double PI = Math.PI;
        const float LengthСoefficient = 0.375f;
        const float WidthCoefficient = 0.04f;

        /// <summary>
        /// Используется для обозначения стороны квадрата, которую нужно нарисовать.
        /// </summary>
        enum Side
        {
            TopSide,
            LeftSide,
            BottomSide,
            RightSide
        }

        /// <summary>
        /// Рисует квадрат в окне.
        /// </summary>
        /// <param name="screenWidth">Ширина окна.</param>
        /// <param name="screenHeight">Высота окна.</param>
        public static void Draw(int screenWidth, int screenHeight, double rotationAngle, Graphics graphics)
        {
            // rotationAngle пока не используется, но будет использоваться в будущем.
            Painter.Initialize(graphics);

            // Как лучше это назвать? (sz)
            int sizeСoefficient = Math.Min(screenWidth, screenHeight);

            CenterSquare(screenWidth, screenHeight, sizeСoefficient);

            // Рисуем верхнюю сторону.
            DrawSide(Pens.Yellow, Side.TopSide, sizeСoefficient);
            // Рисуем левую сторону.
            DrawSide(Pens.Yellow, Side.LeftSide, sizeСoefficient);
            // Рисуем нижнюю сторону.
            DrawSide(Pens.Yellow, Side.BottomSide, sizeСoefficient);
            // Рисуем правую сторону.
            DrawSide(Pens.Yellow, Side.RightSide, sizeСoefficient);
        }

        /// <summary>
        /// Центрирует квадрат в окне.
        /// </summary>
        /// <param name="screenWidth">Ширина окна.</param>
        /// <param name="screenHeight">Высота окна.</param>
        static void CenterSquare(int screenWidth, int screenHeight, int sizeСoefficient)
        {
            double diagonalLength =
                SqrtOfTwo * (sizeСoefficient * LengthСoefficient + sizeСoefficient * WidthCoefficient) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(QuarterPI + PI)) + screenWidth / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(QuarterPI + PI)) + screenHeight / 2f;

            Painter.SetInitialPosition(x0, y0);
        }

        static double SwitchSide(Side side)
        {
            switch (side)
            {
                case Side.TopSide:
                    return 0;
                case Side.LeftSide:
                    return -HalfPI;
                case Side.BottomSide:
                    return PI;
                case Side.RightSide:
                    return HalfPI;
                default:
                    return 0;
            }
        }

        // Временное решение
        static void DrawSide(Pen color, Side side, int sizeСoefficient)
        {
            // Длина внешних линий.
            float externalLineLength = sizeСoefficient * LengthСoefficient;
            // Ширина между линиями.
            float widthBetweenLines = sizeСoefficient * WidthCoefficient;
            // Длина малых повёрнутых под углом линий.
            double rotatedLineLength = widthBetweenLines * SqrtOfTwo;
            // Длина внутренних линий, образующий чистый квадрат.
            double internalLineLength = externalLineLength - widthBetweenLines;
            // Отвечает за поворты.
            double supportingAngleRadians = SwitchSide(side);

            Painter.DrawLine(color, externalLineLength, supportingAngleRadians);
            Painter.DrawLine(color, rotatedLineLength, QuarterPI + supportingAngleRadians);
            Painter.DrawLine(color, externalLineLength, PI + supportingAngleRadians);
            Painter.DrawLine(color, internalLineLength, HalfPI + supportingAngleRadians);

            Painter.ChangeCurrentPosition(widthBetweenLines, -PI + supportingAngleRadians);
            Painter.ChangeCurrentPosition(rotatedLineLength, 3 * QuarterPI + supportingAngleRadians);
        }
    }
}