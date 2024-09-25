using System.Data;

List<Player> list = new List<Player>();

string filePath = "./names.txt";
string fileContent = "";

try
{
    fileContent = File.ReadAllText(filePath);
    Console.WriteLine(fileContent);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}


string[] givers = fileContent.Split(',');

string[] recievers = new string[givers.Length];
Array.Copy(givers, recievers, givers.Length);

// for(int i=0; i<recievers.Length; i++){
//     Console.WriteLine(i+": "+recievers[i]);
// }
string title = @"
    
      ___           ___           ___           ___           ___           ___                    ___           ___           ___           ___           ___     
     /\  \         /\  \         /\  \         /\  \         /\  \         /\  \                  /\  \         /\  \         /\__\         /\  \         /\  \    
    /::\  \       /::\  \       /::\  \       /::\  \       /::\  \        \:\  \                /::\  \       /::\  \       /::|  |        \:\  \       /::\  \   
   /:/\ \  \     /:/\:\  \     /:/\:\  \     /:/\:\  \     /:/\:\  \        \:\  \              /:/\ \  \     /:/\:\  \     /:|:|  |         \:\  \     /:/\:\  \  
  _\:\~\ \  \   /::\~\:\  \   /:/  \:\  \   /::\~\:\  \   /::\~\:\  \       /::\  \            _\:\~\ \  \   /::\~\:\  \   /:/|:|  |__       /::\  \   /::\~\:\  \ 
 /\ \:\ \ \__\ /:/\:\ \:\__\ /:/__/ \:\__\ /:/\:\ \:\__\ /:/\:\ \:\__\     /:/\:\__\          /\ \:\ \ \__\ /:/\:\ \:\__\ /:/ |:| /\__\     /:/\:\__\ /:/\:\ \:\__\
 \:\ \:\ \/__/ \:\~\:\ \/__/ \:\  \  \/__/ \/_|::\/:/  / \:\~\:\ \/__/    /:/  \/__/          \:\ \:\ \/__/ \/__\:\/:/  / \/__|:|/:/  /    /:/  \/__/ \/__\:\/:/  /
  \:\ \:\__\    \:\ \:\__\    \:\  \          |:|::/  /   \:\ \:\__\     /:/  /                \:\ \:\__\        \::/  /      |:/:/  /    /:/  /           \::/  / 
   \:\/:/  /     \:\ \/__/     \:\  \         |:|\/__/     \:\ \/__/     \/__/                  \:\/:/  /        /:/  /       |::/  /     \/__/            /:/  /  
    \::/  /       \:\__\        \:\__\        |:|  |        \:\__\                               \::/  /        /:/  /        /:/  /                      /:/  /   
     \/__/         \/__/         \/__/         \|__|         \/__/                                \/__/         \/__/         \/__/                       \/__/    

    ";

// string ending = @"
//             _____________,--,
//             | | | | | | |/ .-.\   HANG IN THERE
//             |_|_|_|_|_|_/ /   `.      SANTA
//             |_|__|__|_; |      \
//             |___|__|_/| |     .'`}
//             |_|__|__/ | |   .'.'`\
//             |__|__|/  ; ;  / /    \.-'-.
//             ||__|_;   \ \  ||    /`___. \
//             |_|___/\  /;.`,\\   {_'___.;{}
//             |__|_/ `;`__|`-.;|  |C` e e`\
//             |___`L  \__|__|__|  | `'-o-' }
//             ||___|\__)___|__||__|\   ^  /`\
//             |__|__|__|__|__|_{___}'.__.`\_.'}
//             ||___|__|__|__|__;\_)-'`\   {_.-;
//             |__|__|__|__|__|/` (`\__/     '-'
//             |_|___|__|__/`      |
//         -----|__|___|__/`         \-------------------
//         -.__.-.|___|___;`            |.__.-.__.-.__.-.__
//         |     |     ||             |  |     |     |
//         -' '---' '---' \             /-' '---' '---' '--
//             |     |    '.        .' |     |     |     |
//         '---' '---' '---' `-===-'`--' '---' '---' '---'
//         |     |     |     |     |     |     |     |
//         -' '---' '---' '---' '---' '---' '---' '---' '--
//             |     |     |     |     |     |     |     |
//         '---' '---' '---' '---' '---' '---' '---' '---'
//     ";

string ending = @"
                        .--------.
   *               .    |________|        .          *
                        |      __|/\
             *        .-'======\_\o/.
                     /___________<>__\
               ||||||  /  (o) (o)  \
               |||||| |   _  O  _   |          .
     .         |||||| |  (_)   (_)  |
               ||||||  \   '---'   /    *
               \====/   [~~~~~~~~~]
                \\//  _/~||~`|~~~~~\_
                _||-'`/  ||  |      \`'-._       *
        *    .-` )|  ;   ||  |)      ;    '. 
            /    `--.|   ||  |       |      `\
           |         \   |||||)      |-,      \         .
            \       .;       _       ; |_,    |
             `'''||` ,\     (_)     /,    `.__/
                 ||.`  '.         .'  `.             *
      *          ||       ` ' ' `       \
                 ||                      ;
   .          *  ||                      |    .
                 ||                      |              *
                 ||                      |
 .__.-''-.__.-'''||                      ;.-'''-.__.-''-.__.
                 ||                     /
                 ||'.                 .'
                 ||  '-._  _ _  _ _.-'
                `""`       

";

Random rand = new Random();
for(int i=0; i<givers.Length; i++){
    if(i == givers.Length-1 && givers[i].Trim().Equals(recievers[i].Trim())){
        Console.WriteLine("HEEEERRRRREEEEE");
        string temp = givers[i-1].Trim();
        string fileNameTemp = $"{temp}.txt";
        string tempAssigned = recievers[i].Trim();
        Utilities.swap(i, i-1, recievers);
        string tempContent = $"{title}\n\n\nThis year for secret santa, you will be getting a gift for {tempAssigned}! Merry Christmas!\n\n {ending}";
        File.WriteAllText($"./{fileNameTemp}", tempContent);
    }
    string name = givers[i].Trim();
    string fileName = $"{name}.txt";
    Console.WriteLine(fileName);
    int index = rand.Next(i, givers.Length);
    string assigned = recievers[index].Trim();
    while(assigned.Equals(name)){
        index = rand.Next(i, givers.Length);
        assigned = recievers[index].Trim();
    }
    Utilities.swap(i, index, recievers);
    string content = $"{title}\n\n\nThis year for secret santa, you will be getting a gift for {assigned}! Merry Christmas!\n\n {ending}";
    File.WriteAllText($"./{fileName}", content);
}



