namespace Quiz;

public class QuizResult
{
    public Guid Id { get; set; }

    // Значение 0-4 (оценка)
    public short CountOfResult { get; set; }

    // Количество попыток
    public int CountOfTries {  get; set; } = 0;

    public User User { get; set; }

}
