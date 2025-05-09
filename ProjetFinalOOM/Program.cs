public abstract class Protagonist{
    public string Name { get; set; }
    public string SourceSerie { get; set; }
    public Protagonist(string name, string sourceSerie){
        Name = name;
        SourceSerie = sourceSerie;
    }
    public abstract void Interacting(Protagonist otherPortagonist);
}

public class Serie{
    public string Title { get; set; }
    public int BeginningYear { get; set; }
    public string Gender { get; set; }
    List<Season> Season; 
    public Serie(string title, int beginningYear, string gender){
        Title = title;
        BeginningYear = beginningYear;
        Gender = gender;
    }
}

public class Season{
    public int Number { get; set; }
    List<Episode> Episode;
}

public class Episode{
    public string Title;
    public int DurationInMinutes;
}