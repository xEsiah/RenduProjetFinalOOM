// Classe abstraite pour tout protagoniste, assurant une base commune
public abstract class Protagonist {
    protected string name;
    protected string sourceSerie;

    // Propriété pour le nom du protagoniste (assure l'unicité du nom)
    public string Name {
        get { return name; }
        set { name = value; }
    }

    // Propriété pour la série d’origine du personnage (une seule série par personnage)
    public string SourceSerie {
        get { return sourceSerie; }
        set { sourceSerie = value; }
    }

    public Protagonist(string name, string sourceSerie) {
        Name = name;
        SourceSerie = sourceSerie;
    }

    // Méthode abstraite que chaque type de protagoniste devra implémenter
    public abstract void Interacting(Protagonist otherProtagonist);
}

// Classe Episode pour modéliser un épisode avec un titre et une durée
public class Episode {
    public string Title { get; set; }
    public int DurationInMinutes { get; set; }

    public Episode(string title, int durationInMinutes) {
        Title = title;
        DurationInMinutes = durationInMinutes;
    }
}

// Classe Season, contenant un numéro de saison et une liste d’épisodes
public class Season {
    public int Number { get; set; }
    public List<Episode> Episodes { get; set; }

    public Season(int number, List<Episode> episodes) {
        Number = number;
        Episodes = episodes;
    }
}

// Classe Serie représentant une série complète avec ses saisons
public class Serie {
    public string Title { get; set; }
    public int BeginningYear { get; set; }
    public string Genre { get; set; }
    public List<Season> Seasons { get; set; }

    public Serie(string title, int beginningYear, string gender, List<Season> seasons) {
        Title = title;
        BeginningYear = beginningYear;
        Genre = gender;
        Seasons = seasons;
    }

    // Méthode pour calculer la durée totale de la série (toutes saisons et épisodes inclus)
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

// Implémentation d’un héros typique de shonen (pouvoirs, slogans, etc.)
public class ShonenHero : Protagonist, IBecomeStronger {
    private string mainAbility;
    private string slogan;

    // Une compétence principale par personnage
    public string MainAbility {
        get { return mainAbility; } 
        set { mainAbility = value; }
    }

    // Un slogan distinctif par héros
    public string Slogan {
        get { return slogan; }
        set { slogan = value; }
    }

    public ShonenHero(string name, string sourceSerie, string mainAbility, string slogan)
        : base(name, sourceSerie) {
        MainAbility = mainAbility;
        Slogan = slogan;
    }

    // Interaction simple entre protagonistes
    public override void Interacting(Protagonist otherProtagonist) {
        Console.WriteLine($"{Name} salue {otherProtagonist.Name}");
    }

    // Méthode spécifique à ce type de héros pour se renforcer
    public void Empowering(string cause) {
        Console.WriteLine($"{Name} power up grâce {cause}!");
    }
}

// Héros plus mature venant de seinen : motivations profondes et progression mesurée
public class SeinenHero : Protagonist {
    private string purpose;
    private float accomplished;

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

// Interface spécifique aux héros de shonen qui évoluent au combat
public interface IBecomeStronger {
    void Empowering(string cause);
}

public class Program
{
    // Méthode de création des séries avec leurs saisons et épisodes
    public static List<Serie> CreateAnimeSeries()
    {
        return new List<Serie>
        {
            // Plusieurs séries sont initialisées ici avec des saisons et épisodes renseignés
            // Certaines comme Bleach ont volontairement une saison vide pour tester les cas limites
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
            ),
            new Serie(
                "Bleach",
                2006,
                "Thriller",
                new List<Season>
                {
                    new Season(1, new List<Episode>
                    {
                       
                    }),
                }
            )
        };
    }
    public static void Main()
    {
        Console.WriteLine("\n------------- Début du programme -------------\n");

        // Démonstration d’interaction entre un héros de shonen et un héros de seinen
        ShonenHero Naruto = new ShonenHero("Naruto", "Naruto", "Rasengan", "Dattebayo");
        SeinenHero Guts = new SeinenHero("Guts", "Berserk", "Vengeance", 75.5f);
        Console.WriteLine("\nAffichage de la méthode interaction: ");
        Naruto.Interacting(Guts);
        Guts.Interacting(Naruto);

        // Affichage général des séries avec durée, genre et année
        Console.WriteLine("\n\nAffichage de tous les animes renseignés: ");
        List<Serie> animeList = CreateAnimeSeries();
        foreach (var serie in animeList)
        {
            Console.WriteLine($"- {serie.Title} \nDurée totale de l'anime: {serie.CalculatingTotalDuration()} minutes | Genre: {serie.Genre} | Année de début de diffusion: {serie.BeginningYear} ");
        }

        // Requête Linq pour afficher les animes d’action sortis avant 2010
        Console.WriteLine("\n\nAffichage des animes d'action parru(s) avant 2010: ");
        var actionBefore2010 = from aB2 in animeList
                               where aB2.BeginningYear <= 2010 && aB2.Genre == "Action"
                               select aB2.Title;
        foreach (var title in actionBefore2010)
        {
            Console.WriteLine($"- {title}");
        }

        // Recherche de l’épisode ayant la plus longue durée dans toutes les séries
        var longestEpisode = animeList
            .SelectMany(serie => serie.Seasons)
            .SelectMany(season => season.Episodes)
            .OrderByDescending(episode => episode.DurationInMinutes)
            .FirstOrDefault();
        Console.WriteLine($"\n\nEpisode le plus long renseigné: {longestEpisode.Title}, Durée: {longestEpisode.DurationInMinutes} minutes\n");
        
        // Affiche toutes les séries en fonction du genre passé en paramètre
        void DisplayAnimeByGender(List<Serie> animeListFunc, string gender)
        {
            Console.WriteLine($"\nAffichage de tous les animes de genre {gender} :");
            var animesByGender = from anime in animeListFunc
                                 where anime.Genre == gender
                                 select anime.Title;

            foreach (var title in animesByGender)
            {
                Console.WriteLine($"- {title}");
            }
        }

        DisplayAnimeByGender(animeList, "Action");
        DisplayAnimeByGender(animeList, "Aventure");
        DisplayAnimeByGender(animeList, "Thriller");

        // Calcul de la durée moyenne des épisodes d’une série spécifique
        Console.Write("\n\nAffichage des durées moyennes des épisodes d'une série:\n");
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

            Console.WriteLine($"Durée moyenne des épisodes de {title} : {averageDuration / episodeCount} minutes");
        }

        CalculatingAverageDuration(animeList, "Death Note");
        CalculatingAverageDuration(animeList, "L'Attaque des Titans");

        // Affiche toutes les séries avec leur nombre total d’épisodes
        void TitleAndTotalOfEpisodes(List<Serie> animeListFunc)
        {
            Console.WriteLine("\n\nAffichage des séries et de leur nombre total d'épisodes :");
            var totalEpisodesBySerie =
                from serie in animeListFunc
                select new
                {
                    TitleAnime = serie.Title,
                    TotalEpisodes = (from season in serie.Seasons
                                     from episode in season.Episodes
                                     select episode).Count()
                };

            foreach (var item in totalEpisodesBySerie)
            {
                Console.WriteLine($"- {item.TitleAnime} : {item.TotalEpisodes} épisodes");
            }
        }

        TitleAndTotalOfEpisodes(animeList);

        // Affiche le nombre d’épisodes d’une saison donnée d’une série donnée
        Console.WriteLine($"\n\nAffichage du nombre d'épisodes d'une saison spécifique :");

        int NumberOfEpisodesOfThisSeason(List<Serie> animeListFunc, string title, int number)
        {
            try
            {
                // Force une exception si la liste est nulle
                if (animeListFunc == null)
                    throw new ArgumentNullException(nameof(animeListFunc), "La liste fournie est nulle.");

                // Recherche directe
                var serie = animeListFunc.First(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

                // Si le numéro de saison est invalide
                if (number < 1)
                    throw new ArgumentOutOfRangeException(nameof(number), "Le numéro de saison doit être >= 1 !");

                var saison = serie.Seasons.First(s => s.Number == number);

                // Force une exception si la liste d'épisodes est nulle
                if (saison.Episodes == null)
                    throw new NullReferenceException("La liste des épisodes est nulle.");

                // Affiche le résultat s’il n’y a pas d’épisodes
                if (saison.Episodes.Count == 0)
                {
                    Console.WriteLine($"La saison {number} de « {title} » n'a pas d'épisode renseigné.");
                    return 0;
                }

                Console.WriteLine($"La saison {number} de « {title} » contient {saison.Episodes.Count} épisode(s).");
                return saison.Episodes.Count;
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine($"[ArgumentNullException] {exc.Message}");
                return -1;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("[InvalidOperationException] L'objet recherché n'existe pas dans la collection.");
                return -1;
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine($"[ArgumentOutOfRangeException] {exc.Message}");
                return -1;
            }
            catch (Exception exc)
            {
                Console.WriteLine($"[Exception] Une erreur inattendue est survenue : {exc.Message}");
                return -1;
            }
        }

        NumberOfEpisodesOfThisSeason(null, "Naruto", 1); // ArgumentNullException
        NumberOfEpisodesOfThisSeason(animeList, "Série Inconnue", 1); // InvalidOperationException
        NumberOfEpisodesOfThisSeason(animeList, "Naruto", 0); // ArgumentOutOfRangeException
        NumberOfEpisodesOfThisSeason(animeList, "Bleach", 1); // NullReferenceException si Episodes est null
        NumberOfEpisodesOfThisSeason(animeList, "L'Attaque des Titans", 1); // Cas normal

    }
}
