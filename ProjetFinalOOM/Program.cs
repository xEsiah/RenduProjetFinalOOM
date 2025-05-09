public abstract class Protagonist{
    public string Name { get; set; }
    public string SourceSerie { get; set; }
    public Protagonist(string name, string sourceSerie){
        Name = name;
        SourceSerie = sourceSerie;
    }
    public abstract void Interacting(Protagonist otherPortagonist);
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
    public string Gender { get; set; }
    public List<Season> Seasons { get; set; }

    public Serie(string title, int beginningYear, string gender, List<Season> seasons) {
        Title = title;
        BeginningYear = beginningYear;
        Gender = gender;
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