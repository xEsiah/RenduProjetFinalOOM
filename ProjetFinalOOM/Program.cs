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
        Console.WriteLine($"{Name} interacts with {otherProtagonist.Name}");
    }
    public void Empowering(string cause) {
        Console.WriteLine($"{Name} becomes stronger because {cause}!");
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
        Console.WriteLine($"{Name} interacts with {otherProtagonist.Name}");
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
                "Shonen",
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
                "Fullmetal Alchemist : Brotherhood",
                2009,
                "Aventure",
                new List<Season>
                {
                    new Season(1, new List<Episode>
                    {
                        new Episode("Alchimiste Fullmetal", 24),
                        new Episode("Le premier jour", 23)
                    }),
                    new Season(2, new List<Episode>
                    {
                        new Episode("Le cinquième laboratoire", 25),
                        new Episode("L'émissaire de l'Est", 26)
                    })
                }
            ),
            new Serie(
                "One Piece",
                1999,
                "Shonen",
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
        ShonenHero Naruto = new ShonenHero("Naruto", "Naruto", "Rasengan", "Believe it!");
        SeinenHero Guts = new SeinenHero("Guts", "Berserk", "Revenge", 75.5f);
        Naruto.Interacting(Guts);
        Guts.Interacting(Naruto);


        List<Serie> animeList = CreateAnimeSeries();
        foreach (var serie in animeList)
        {
            Console.WriteLine($"{serie.Title} - Durée Totale de l'anime: {serie.CalculatingTotalDuration()} minutes");
        }
    }
}
