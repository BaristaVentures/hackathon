using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Hackatonwebtalk
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			String filePath = Console.ReadLine();


			StreamReader streamReader = new StreamReader(filePath);
			string wholeFile = streamReader.ReadToEnd();
			streamReader.Close();

			string[] usersAndProducts = wholeFile.Split(';');

			string usersString = usersAndProducts[0];
			string ProductsString = usersAndProducts[1];

			string[] users = usersString.Split(',');
			float VSs;
			string[] products = ProductsString.Split(',');

			for (int i = 0; i < users.Length; i++) {
				int vowels = 0;
				int consonants = 0;
				int usernameLetterCount = users[i].Length;
				countVowelsAndConsts(users[i], out vowels, out consonants);

				List<int> factors;
				factors = new List<int>(1);
				factors.Add(1);

				VSs = 0f;

				for (int j = 0; j < products.Length; j++) {
					int productLetterCount = products[j].Length;
					bool isOdd = productLetterCount % 2 == 0;
					float newVS = 0;
					if (isOdd) {
						newVS = vowels * 1.5f;
					} else {
						newVS = consonants;
					}

					newVS = countVowelsAndConsts(usernameLetterCount, productLetterCount, newVS);

					VSs = Math.Max(VSs, newVS);
				}

				Console.Out.WriteLine("{0:N2}", VSs);
			}
		}

		public static void countVowelsAndConsts(string str, out int vowels, out int consontans) {
			str = str.Split('@')[0];
			vowels = 0;
			consontans = 0;
			for (int i = 0; i < str.Length; i++) {
				if ("aeiouAEIOU".IndexOf(str[i]) >= 0) {
					vowels++;
				} else {
					consontans++;
				}
			}
		}

		public static float countVowelsAndConsts(int userLetterCount, int productLetterCount, float VS) {
			bool mult = false;
			int userLetterCountMax = (int) Math.Sqrt(userLetterCount);
			int productLetterCountMax = (int) Math.Sqrt(productLetterCount);
			for(int i = 2; i <= userLetterCountMax && i <= productLetterCountMax; ++i) {
				if(userLetterCount % i == 0 && productLetterCount % i == 0) {
					mult = true;
					break;
				}
			}

			if (mult)
				return VS * 1.5f;
			else
				return VS;
		}
	}
}
