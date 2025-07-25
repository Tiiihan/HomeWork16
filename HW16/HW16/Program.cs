//Ваша мета - створити програму, яка копіює вміст одного текстового файлу в інший. 
//Користувач повинен ввести шлях до вихідного файлу та шлях до файлу, в який потрібно скопіювати дані. 
//Після виконання копіювання виведіть повідомлення про успішне завершення.

using HW16;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

FileManager fileManager = new FileManager();

fileManager.ValidPath();

try
{
	fileManager.CopyText();
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}