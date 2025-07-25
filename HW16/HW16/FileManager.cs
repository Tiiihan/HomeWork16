using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16
{
	internal class FileManager
	{
		private string sourcePath = @"";
		private string destinationPath = @"";

		public string SourcePath { get; set; }
		public string DestinationPath { get; set; }

		public string ReadAllText()
		{
			if (IsSourceFileExists(SourcePath))
				return File.ReadAllText(SourcePath, Encoding.UTF8);
			else
			{
				Console.WriteLine("File does not exist");
				return null;
			}
		}
		public void CopyText()
		{ 
			string content = ReadAllText();

			if (content != null)
			{
				File.WriteAllText(DestinationPath, content);
				Console.WriteLine("File was successfuly copied");
			}
			else Console.WriteLine("File could not be read");
		}
		public static (string source, string destination) GetPathFromUser()
		{
			(string source, string destination) paths;

			Console.Write("Enter path from: ");
			paths.source = Console.ReadLine();

			Console.Write("Enter path to: ");
			paths.destination = Console.ReadLine();

			return paths;
		}
		public void ValidPath()
		{
			bool isValid = false;
			(string source, string destination) paths = GetPathFromUser();

			while (!isValid)
			{
				if (IsPathEmpty(paths) || ArePathsEqual(paths) || !IsSourceFileExists(paths.source))
				{
					Console.WriteLine("Invalid input");
					paths = GetPathFromUser();
				}
				else
				{
					isValid = true;
					SourcePath = paths.source;
					DestinationPath = paths.destination;
				}
			}
		}
		public bool IsPathEmpty((string source, string destination) paths)
		{
			bool IsPathEmpty = false;

			if (string.IsNullOrEmpty(paths.source) || string.IsNullOrEmpty(paths.destination))
				IsPathEmpty = true;
			return IsPathEmpty;
		}

		public bool ArePathsEqual((string source, string destination) paths)
		{
			bool IsPathsEqual = false;

			if (paths.destination == paths.source)
				IsPathsEqual = true;
			return IsPathsEqual;
		}

		public bool IsSourceFileExists(string source) => File.Exists(source);
	}
}
