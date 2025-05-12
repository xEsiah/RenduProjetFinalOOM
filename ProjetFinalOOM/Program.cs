public abstract class Protagonist {
    protected string name;
    protected string sourceSerie;
    // Pour la gestion des erreurs plus tard
    public string Name {
        get { return name; }
        set { name = value; } // S'assure qu'il n'y a qu'un nom
    }

    public string SourceSerie {
        get { return sourceSerie; }
        set { sourceSerie = value; } // S'assure que le personnage ne vient que d'une série
    }

    public Protagonist(string name, string sourceSerie) {
        Name = name;
        SourceSerie = sourceSerie;
    }

    public abstract void Interacting(Protagonist otherProtagonist);
}

public class Episode {
    public string Title { get; set; }
    public int DurationInMinutes { get; set; }

    public Episode(string title, int durationInMinutes) {
        Title = title;
        DurationInMinutes = durationInMinutes;
    }
}

public class Season {
    public int Number { get; set; }
    public List<Episode> Episodes { get; set; }

    public Season(int number, List<Episode> episodes) {
        Number = number;
        Episodes = episodes;
    }
}

public class Serie {
    public string Title { get; set; }
    public int BeginningYear { get; set; }
    public string Genre { get; set; }
    public List<Season> Seasons { get; set; }

    public Serie(string title, int beginningYear, string genre, List<Season> seasons) {
        Title = title;
        BeginningYear = beginningYear;
        Genre = genre;
        Seasons = seasons;
    }

    public int CalculatingTotalDuration() {
        int totalDuration = 0;
        
        foreach (var season in Seasons) {
                foreach (var episode in season.Episodes) {
                    totalDuration += episode?.DurationInMinutes ?? 0;
                }
            }
        return totalDuration;
    }
}

public class ShonenHero : Protagonist, IBecomeStronger {
    private string mainAbility;
    private string slogan;
    // Pour la gestion des erreurs plus tard
    public string MainAbility {
        get { return mainAbility; } 
        set { mainAbility = value; } // S'assure qu'il n'y a qu'une compétence principale par exemple
    }

    public string Slogan {
        get { return slogan; }
        set { slogan = value; } // S'assure qu'il n'y a qu'un slogan principale par exemple
    }

    public ShonenHero(string name, string sourceSerie, string mainAbility, string slogan)
        : base(name, sourceSerie) {
        MainAbility = mainAbility;
        Slogan = slogan;
    }

    public override void Interacting(Protagonist otherProtagonist) {
        Console.WriteLine($"{Name} salue {otherProtagonist.Name}");
    }
    public void Empowering(string cause) {
        Console.WriteLine($"{Name} power up grâce {cause}!");
    }
}

public class SeinenHero : Protagonist {
    private string purpose;
    private float accomplished;
    // Pour la gestion des erreurs plus tard
    public string Purpose {
        get { return purpose; }
        set { purpose = value; }
    }
    public float Accomplished {
        get { return accomplished; }
        set { accomplished = value; }
    }
    public SeinenHero(string name, string sourceSerie, string purpose, float accomplished)
        : base(name, sourceSerie) {
        Purpose = purpose;
        Accomplished = accomplished;
    }
    public override void Interacting(Protagonist otherProtagonist) {
        Console.WriteLine($"{Name} salue {otherProtagonist.Name}");
    }
    
}
public interface IBecomeStronger {
    void Empowering(string cause);
}

public class Program
{
    public static List<Serie> CreateAnimeSeries()
    {
        return new List<Serie>
        {
            new Serie(
                "Naruto",
                2002,
                "Aventure",
                new List<Season>
                {
                    new Season(1, new List<Episode>
                    {
                        new Episode("L'arrivée de Naruto Uzumaki !", 23),
                        new Episode("Je m'appelle Konohamaru !", 22)
                    }),
                    new Season(2, new List<Episode>
                    {
                        new Episode("Le début de l'examen Chunin", 24),
                        new Episode("La Forêt de la Mort", 26)
                    })
                }
            ),
            new Serie(
                "L'Attaque des Titans",
                2013,
                "Action",
                new List<Season>
                {
                    new Season(1, new List<Episode>
                    {
                        new Episode("À toi, dans 2000 ans", 25),
                        new Episode("Ce jour-là", 24)
                    }),
                    new Season(2, new List<Episode>
                    {
                        new Episode("Le Titan Bestial", 25),
                        new Episode("Historia", 26)
                    })
                }
            ),
            new Serie(
                "Black Lagoon",
                2006,
                "Action",
                new List<Season>
                {
                    new Season(1, new List<Episode>
                    {
                        new Episode("The Black Lagoon", 24),
                        new Episode("Mangrove Heaven", 23)
                    }),
                    new Season(2, new List<Episode>
                    {
                        new Episode("Bloodsport Fairytale", 25),
                        new Episode("Greenback Jane", 26)
                    })
                }
            ),
            new Serie(
                "One Piece",
                1999,
                "Aventure",
                new List<Season>
                {
                    new Season(1, new List<Episode>
                    {
                        new Episode("Je suis Luffy ! Celui qui deviendra le roi des pirates !", 24),
                        new Episode("Le grand épéiste entre en scène ! Le chasseur de pirates Roronoa Zoro !", 25)
                    }),
                    new Season(2, new List<Episode>
                    {
                        new Episode("Premier obstacle ? Le géant Laboon apparaît", 26),
                        new Episode("Une promesse entre hommes ! Luffy et la baleine se jurent de se revoir", 25)
                    })
                }
            ),
            new Serie(
                "Death Note",
                2006,
                "Thriller",
                new List<Season>
                {
                    new Season(1, new List<Episode>
                    {
                        new Episode("Renaissance", 22),
                        new Episode("Confrontation", 23)
                    }),
                    new Season(2, new List<Episode>
                    {
                        new Episode("Impatience", 24),
                        new Episode("Frénésie", 25)
                    })
                }
            )
        };
    }
    public static void Main()
    {   
        Console.WriteLine("\n------------- Début du programme -------------\n");
        ShonenHero Naruto = new ShonenHero("Naruto", "Naruto", "Rasengan", "Dattebayo");
        SeinenHero Guts = new SeinenHero("Guts", "Berserk", "Vengeance", 75.5f);
        Console.WriteLine("\nAffichage de la méthode interaction: ");
        Naruto.Interacting(Guts);
        Guts.Interacting(Naruto);


        Console.WriteLine("\n\nAffichage de tous les animes renseignés: ");
        List<Serie> animeList = CreateAnimeSeries();
        foreach (var serie in animeList)
        {
            Console.WriteLine($"- {serie.Title} \nDurée totale de l'anime: {serie.CalculatingTotalDuration()} minutes | Genre: {serie.Genre} | Année de début de diffusion: {serie.BeginningYear} ");
        }   // Les durées totales sont incorrectes dans l'exemple car tous les épisodes 
            // de chaque saison ne sont pas renseignés


        Console.WriteLine("\n\nAffichage des animes d'action parru(s) avant 2010: ");
        // Synthaxe SQL de Linq
        var actionBefore2010 = from aB2 in animeList
                       where aB2.BeginningYear <= 2010 && aB2.Genre == "Action"
                       select aB2.Title;
        foreach (var title in actionBefore2010)
        {
            Console.WriteLine($"- {title}");
        }

        // Synthaxe de méthode de Linq
        var longestEpisode = animeList
            .SelectMany(serie => serie.Seasons)           
            .SelectMany(season => season.Episodes)    
            .OrderByDescending(episode => episode.DurationInMinutes) 
            .FirstOrDefault();
        Console.WriteLine($"\n\nEpisode le plus long renseigné: {longestEpisode.Title}, Durée: {longestEpisode.DurationInMinutes} minutes\n");
        
        // Méthode pour afficher toutes les séries en les groupant par leur genre
        void DisplayAnimeByGender(List<Serie> animeListFunc, string genre)
        {
            Console.WriteLine($"\nAffichage de tous les animes de genre {genre} :");
            var animesByGender = from anime in animeListFunc
                                where anime.Genre == genre
                                select anime.Title;

            foreach (var title in animesByGender)
            {
                Console.WriteLine($"- {title}");
            }
        }
        DisplayAnimeByGender(animeList, "Action");
        DisplayAnimeByGender(animeList, "Aventure");
        DisplayAnimeByGender(animeList, "Thriller");
       

       Console.Write("\n\nAffichage des durées moyennes des épisodes d'une série:\n");
       // Méthode pour afficher la durée moyenne des épisodes d'une série
        void CalculatingAverageDuration(List<Serie> animeListFunc, string title)
        {   
            var episodeCount = 0;
            var averageDuration = 0;
            var durations = animeListFunc
                .FirstOrDefault(s => s.Title == title)?
                .Seasons?
                .SelectMany(season => season.Episodes)
                .Where(ep => ep?.DurationInMinutes != null)
                .Select(ep => ep.DurationInMinutes)
                .ToList();
            foreach (var dur in durations)
            {
                averageDuration += dur;
                episodeCount++;
            }
            
            Console.WriteLine($"Durée moyenne des épisodes de {title} : {averageDuration/episodeCount} minutes");
        
        }
        CalculatingAverageDuration(animeList, "Death Note");
        CalculatingAverageDuration(animeList, "L'Attaque des Titans");

        Console.Write("\n\nAffichage des séries et de leur nombres d'épisodes: ");

        List<Serie> animeListTitleNumberEp = animeList;
        void TitleAndTotalOfEpisodes(List<Serie> animeListFunc)
        {
            Console.WriteLine("\n\nAffichage des séries et de leur nombre total d'épisodes :");

            var totalEpisodesBySerie =
                from serie in animeListFunc
                select new
                {
                    Title = serie.Title,
                    TotalEpisodes = (from season in serie.Seasons
                                    from episode in season.Episodes
                                    select episode).Count()
                };

            foreach (var item in totalEpisodesBySerie)
            {
                Console.WriteLine($"- {item.Title} : {item.TotalEpisodes} épisodes");
            }
        }
        TitleAndTotalOfEpisodes(animeList);
    }
}
