namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			string stringCount = count.ToString();
			int amountOfDigits = stringCount.Length;
			char lastDigit = stringCount[amountOfDigits - 1];

            // Проверка на *11-*14 рублей. Лучше пока не придумал
            if (amountOfDigits > 1)
            {
                string twoLastDigits = stringCount.Substring(amountOfDigits - 2, 2);
                if (twoLastDigits == "11" || twoLastDigits == "12"
                    || twoLastDigits == "13" || twoLastDigits == "14")
                {
                    return "рублей";
                }
            }

            if (lastDigit == '1')
			{
				return "рубль";
            }
			else if (lastDigit == '2' || lastDigit == '3' || lastDigit == '4') 				
			{ 
				return "рубля";
            }
            else
            {
				return "рублей";
			}
		}
	}
}