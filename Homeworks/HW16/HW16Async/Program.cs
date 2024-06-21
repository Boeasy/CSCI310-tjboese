/*
Create and demonstrate at least 2 functions that are different than what I created and at least one must be async.

*/

using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HW16Async
{

    class dimension
    {
        public string  type { get; set; }
        public generator generator { get; set; }

    }
    class generator
    {
        public string type { get; set; }
        public biome_source biome_source { get; set; }
    }
    class biome_source
    {
        public biomes[] biomes { get; set; }
    }
    class biomes
    {

        public string biome { get; set; }
        public parameters parameters { get; set; }

    }

    class parameters
    {
        public double[] continentalness { get; set; }
        public double depth { get; set; }
        public double[] erosion { get; set; }
        public double[] humidity { get; set; }
        public double offset { get; set; }
        public double[] temperature { get; set; }
        public double[] weirdness { get; set; }
    }


    class Program
    {
        static async Task Main(string[] args)
        {
            string json = await readJSON(); //if this takes too long ue JsonTextReader to do it incrementally...
            Task printBiomes = readBiomes(json);

            await printBiomes;

        }

        static Task<string> readJSON()
        {
            return Task.Run(() =>
            {
            string path = "overworld.json";
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                return json;
            }
            }
            );
        }
        static Task readBiomes(string jsonBiomes)
        {
            return Task.Run(() =>
            {
                //read json pieces into different classes...
                dimension dim = JsonConvert.DeserializeObject<dimension>(jsonBiomes);
                foreach (biomes temp in dim.generator.biome_source.biomes)
                {
                    Console.WriteLine("Biome: " + temp.biome);
                    Console.WriteLine("Continentalness: " + temp.parameters.continentalness[0] + " - " + temp.parameters.continentalness[1]);
                    Console.WriteLine("Depth: " + temp.parameters.depth); //causes annoying error with dripstone & lush caves because it is an array instead of single value like the rest... deleting for now
                    Console.WriteLine("Erosion: " + temp.parameters.erosion[0] + " - " + temp.parameters.erosion[1]);
                    Console.WriteLine("Humidity: " + temp.parameters.humidity[0] + " - " + temp.parameters.humidity[1]);
                    Console.WriteLine("Offset: " + temp.parameters.offset);
                    Console.WriteLine("Temperature: " + temp.parameters.temperature[0] + " - " + temp.parameters.temperature[1]);
                    Console.WriteLine("Weirdness: " + temp.parameters.weirdness[0] + " - " + temp.parameters.weirdness[1]);
                    Console.WriteLine();
                }
                

            }
            );
        }


    }
}