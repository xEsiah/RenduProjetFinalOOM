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
                totalDuration += episode.DurationInMinutes;
            }
        }
        return totalDuration;
    }
}

public class ShonenHero : Protagonist {
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
}

public class SeinenHero : Protagonist, IBecomeStronger {
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
    public void Empowering(string cause) {
        Console.WriteLine($"{Name} becomes stronger because {cause}!");
    }
}
public interface IBecomeStronger {
    void Empowering(string cause);
}

public class Program
{
    public static void Main(string[] args)
    {
        ShonenHero Naruto = new ShonenHero("Naruto", "Naruto", "Rasengan", "Believe it!");
        SeinenHero Guts = new SeinenHero("Guts", "Berserk", "Revenge", 75.5f);

        Naruto.Interacting(Guts);
        Guts.Interacting(Naruto);
    }
}
