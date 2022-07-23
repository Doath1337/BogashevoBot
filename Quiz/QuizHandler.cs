namespace Quiz;

public static class QuizHandler
{
    
    public async static Task<bool> HandleQuizAnswer(long userId, string question, string answer)
    {
        User user = await DbHandler.GetUserAsync(userId);
        bool isCorrect = await DbHandler.CheckAnswer(question, answer);
        if (isCorrect)
        {
            await DbHandler.AddMarkForAnswer( // +1 балл
                await DbHandler.GetUserAsync(userId),
                await DbHandler.GetQuestion(question));
            return true;
        }
        else
            return false;        
    }

    public async static Task<string> GetLastUserQuestion(long userId)
    {
        User user = await DbHandler.GetUserAsync(userId);
        Question question = await DbHandler.GetLastQuestionForUser(userId);
        return question.Text;
    }

    public async static Task<string> GiveQuizQuestion(long userId)
    {
        User user = await DbHandler.GetUserAsync(userId);
        Question question = await DbHandler.GetLastQuestionForUser(userId);
        List<Question> allQuestions = await DbHandler.GetAllQuestions();
        if (question is not null)
        { // если ранее выдавали пользователю вопрос
            // проверка QuizResult, отвечал ли пользователь на выданный вопрос
            List<Question> givenQuestions = await DbHandler.GetGivenQuestionsList(user);
            List<Question> listToChooseFrom = allQuestions.Except(givenQuestions).ToList();
            // выдать вопрос пользователю
            Random generator = new Random();
            question = listToChooseFrom.ElementAt(generator.Next(listToChooseFrom.Count));
            await DbHandler.SaveGivenQuestion(user, question);
            return question.Text;
        }
        else
        {
            // выдать новый вопрос новому пользователю
            Random generator = new Random();
            question = allQuestions.ElementAt(generator.Next(allQuestions.Count));
            await DbHandler.SaveGivenQuestion(user, question);
            return question.Text;
        }
        //return await DbHandler.CheckAnswer(question, answer);
        return question.Text;
    }

}
