using System.Linq;

const string Key = "1987304876298745017645449830875611094356923076019854398671285463";

if (args.Length != 1)
{
    Console.Error.WriteLine("Usage: reolink-reset <input-code>");
    Environment.Exit(2);
}

var seed = args[0].Trim();
if (seed.Length < 8)
{
    Console.Error.WriteLine("Input code must be at least 8 characters.");
    Environment.Exit(2);
}

Console.WriteLine(FindKey(seed));

static string FindKey(string seed)
{
    var pass = new char[12];

    pass[0] = Key[seed[0] >> 2];
    pass[1] = Key[((16 * seed[0]) & 0x30) + (seed[1] >> 4)];
    pass[2] = Key[((4 * seed[1]) & 0x3C) + (seed[2] >> 6)];
    pass[3] = Key[seed[2] & 0x3F];
    pass[4] = Key[seed[3] >> 2];
    pass[5] = Key[((16 * seed[3]) & 0x30) + (seed[4] >> 4)];
    pass[6] = Key[((4 * seed[4]) & 0x3C) + (seed[5] >> 6)];
    pass[7] = Key[seed[5] & 0x3F];
    pass[8] = Key[seed[6] >> 2];
    pass[9] = Key[((16 * seed[6]) & 0x30) + (seed[7] >> 4)];
    pass[10] = Key[(4 * seed[7]) & 0x3C];

    var sum = seed.Select(x => (int)x).Sum();
    pass[11] = Key[sum % 10];

    for (var i = 0; i < pass.Length; i++)
    {
        pass[i] = Key[pass[i] % 10];
    }

    return new string(pass);
}
