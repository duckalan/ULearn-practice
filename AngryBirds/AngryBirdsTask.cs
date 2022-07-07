using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		const double G = 9.8;

		/// <param name="v">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public static double FindSightAngle(double v, double distance)
		{
			if (v <= 0)
				return double.NaN;

			// Угол досягаемости.
			return Math.Asin(distance * G / (v * v)) / 2;
		}
	}
}