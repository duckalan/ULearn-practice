namespace Billiards
{
    public static class BilliardsTask
    {
        /// <summary>
        /// Вычисляет угол отскока шарика от стены.
        /// </summary>
        /// <param name="directionRadians">Угол направления движения шара в радианах.</param>
        /// <param name="wallInclinationRadians">Угол в радианах.</param>
        /// <returns>Угол отскока шарика от стены в радианах.</returns>
        // Так и не смог сам решить, пришлось подсмотреть.
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            return wallInclinationRadians * 2 - directionRadians;
        }
    }
}