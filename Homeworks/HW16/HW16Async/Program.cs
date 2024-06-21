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
        string  type { get; set; }
        generator generator { get; set; }

    }
    class generator
    {
        string type { get; set; }
        biome_source biome_source { get; set; }
    }
    class biome_source
    {
        biomes[] biomes { get; set; }
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
            Task readJson = readJSON();
            Task printBiomes = readBiomes();

            await readJson;
            await printBiomes;

        }

        static Task readJSON()
        {
            return Task.Run(() =>
            {
            string path = "overworld.json";
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                Console.WriteLine(json);
            }
            }
            );
        }
        static Task readBiomes()
        {
            return Task.Run(() =>
            {
                //read json pieces into different classes...
            }
            );
        }


    }
}