// See https://aka.ms/new-console-template for more information

using Dungeons.Server;
using Dungeons.Server.Json;

//new DungeonsServer();

string line = "   t    h   i   s is    a te st";

LineReader reader = new(line);

reader.SkipWhitespace();

Console.WriteLine(reader.Get());
reader.SkipWhitespace();

Console.WriteLine(reader.Get());