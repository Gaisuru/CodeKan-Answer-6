using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
	class Program
	{
		
		static void Main(string[] args)
		{
			RunApp();
		

		}

		static void RunApp()
		{
			Console.WriteLine("Enter word to find");
			var searchWord = Console.ReadLine();

			var tempallStrings = File.ReadAllLines(@"C:\wordlist.txt");
			var wordList = tempallStrings.ToList();
			if (searchWord == null)
				return;

			var searchChars = searchWord.ToList();
			var length = searchWord.Length;
			searchChars.Sort();

			var possibleWords = new List<string>();
			foreach (var searchChar in searchChars.Distinct())
			{
				possibleWords.AddRange(wordList.Where(x => x[0] == searchChar && x.Length == length));
			}


			var results = new List<string>();
			foreach (var possibleWord in possibleWords)
			{
				var shouldAdd = true;
				var word = possibleWord;
				foreach (var searchChar in searchChars)
				{
					if (word.Contains(searchChar))
					{
						word = word.Replace(searchChar.ToString(),string.Empty);
					}
					else
					{
						shouldAdd = false;
						break;
					}

				}
				
				if(shouldAdd && word.Length == 0)
					results.Add(possibleWord);
			}
			foreach (var result in results)
			{
				Console.WriteLine(result);
			}
			Console.WriteLine("DONE");
			Console.ReadLine();
			

		}
	}
}
