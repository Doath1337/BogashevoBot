namespace Quiz;

public class QuestionForUser
{

    public Guid Id { get; set; }

    public Question Question{ get; set; }

    public User User { get; set; }

    public DateTime Created { get; set; }

}
