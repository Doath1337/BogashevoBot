using System.Linq;

namespace Quiz;

public static class DbHandler
{
    //static QuizContext db;

    static DbHandler()
    {
        //using db = new QuizContext();
    }


    public static async Task<User> GetUserAsync(long Id)
    {
        using var db = new QuizContext();
        User user = db.Users.Where(x => x.UserId == Id).FirstOrDefault();
        if (user is null)
        {
            user = new User()
            {
                Id = Guid.NewGuid(),
                UserId = Id
            };
            db.Add(user);
            await db.SaveChangesAsync();
        }
        
        return user;
    }

    public static async Task<bool> CheckAnswer(string questionText, string answer)
    {
        using var db = new QuizContext();
        Question question = await GetQuestion(questionText);
        if (question is null)
        {
            return false;
        }

        return question.CorrectAnswer.Equals(answer);
    }

    public static async Task<Question> GetLastQuestionForUser(long userId)
    {
        using var db = new QuizContext();
        QuestionForUser givenQuestion = db.GivenQuestionsForUser.Where(x => x.User.UserId == null).FirstOrDefault();
        if (givenQuestion is null)
        {
            return null;
        }

        return givenQuestion.Question;

    }

    public static async Task<List<Question>> GetAllQuestions()
    {
        using var db = new QuizContext();
        List<Question> questions = db.Questions.ToList();
        return questions;
    }

    public static async Task SaveGivenQuestion(User user, Question question)
    {
        using var db = new QuizContext();

        QuestionForUser q4u = new QuestionForUser()
        {
            Id = Guid.NewGuid(),
            Question = question,
            User = user,
            Created = DateTime.UtcNow
        };

        db.Add(q4u);
        await db.SaveChangesAsync();
    }

    public static async Task AddMarkForAnswer(User user, Question question)
    {
        using var db = new QuizContext();
        QuizResult quizResult = new QuizResult()
        {
            Id = Guid.NewGuid(),
            CountOfResult = 1,
            User = user
        };

        db.Add(quizResult);
        await db.SaveChangesAsync();
    }

    public static async Task<Question> GetQuestion(string question)
    {
        using var db = new QuizContext();
        return db.Questions.Where(q => q.Text.Equals(question)).FirstOrDefault();
    }

    public static async Task<List<Question>> GetGivenQuestionsList(User user)
    {
        using var db = new QuizContext();
        List<Question> givenQuestions = db.GivenQuestionsForUser.Where(qr => qr.User == user).Select(qr => qr.Question).ToList();
        return givenQuestions;
    }

}
