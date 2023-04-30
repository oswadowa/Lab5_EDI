using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

public class Program
{
	public class InputLab
	{
		public Dictionary<string, bool>[] input1 { get; set; }
		public string[] input2 { get; set; }
	}

	public static void Main()
	{
		string jsonText = File.ReadAllText(@"C:/Users/usuario/source/repos/ejemplojson/ejemplojson/input_example.jsonl");
		string[] jsonObjects = jsonText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		int apartment = 0;
		int requerimiento = 1;
		do
		{
			{
				foreach (string jsonObject in jsonObjects)
				{
					InputLab input = JsonConvert.DeserializeObject<InputLab>(jsonObject);

					foreach (Dictionary<string, bool> map in input.input1)
					{
						Console.WriteLine($"apartment: {apartment}");
						foreach (KeyValuePair<string, bool> entry in map)
						{
							Console.WriteLine($"key {entry.Key} - value {entry.Value}");
						}
						apartment++;
						Console.WriteLine($"-----------");
					}
					foreach (string requirement in input.input2)
					{
						Console.WriteLine($"requirement: {requirement}");
					}						
					Console.WriteLine("Requerimiento No."+ requerimiento++ +" es:");
					apartment = 0;

				}
			}
		
		} while (apartment < 0);
	}
}