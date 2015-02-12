using System;
using System.Linq;

namespace Hackatonwebtalk
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int cases  = int.Parse(Console.ReadLine());
			for(int i = 0; i < cases; i++) {
				String word = Console.ReadLine();
				char[] chars = word.ToCharArray();
				int index = 0;
				char lastChar;
				do {
					index--;

					if(chars.Length + index < 0) {
						chars = Enumerable.Repeat('a', chars.Length + 1).ToArray();
						lastChar = 'z';
					} else {
						lastChar = chars[chars.Length + index];
						lastChar++;

						if(lastChar == ('z'+1)) lastChar = 'a';

						chars[chars.Length + index] = lastChar;
					}

				} while (lastChar == 'a');

				String newWord = new string(chars);
				Console.Out.WriteLine(newWord);
			}
		}
	}
}
