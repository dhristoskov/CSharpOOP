namespace ConsoleForum.Commands
{
    using System.Linq;
    using System.Text;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.Questions.Count <= 0)
            {
                throw new CommandException(Messages.NoQuestions);
            }
            this.Forum.CurrentQuestion = null;
            foreach (var question in Forum.Questions.OrderBy(s => s.Id))
            {
                if (this.Forum.Questions.Count <= 0)
                {
                    throw new CommandException(Messages.NoQuestions);
                }
                StringBuilder sb = new StringBuilder();
                sb.Append(PrintQuestion(question));
                this.Forum.Output.Append(sb);
            }
        }

        public static string PrintQuestion(IQuestion question)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[ Question ID: {0} ]", question.Id)
                .AppendLine()
                .AppendFormat("Posted by: {0}", question.Author.Username)
                .AppendLine()
                .AppendFormat("Question Title: {0}", question.Title)
                .AppendLine()
                .AppendFormat("Question Body: {0}", question.Body)
                .AppendLine()
                .AppendLine("====================");
            if (question.Answers.Count > 0)
            {
                sb.AppendLine("Answers:");
                var bestAnswer = question as Question;
                if (bestAnswer != null && bestAnswer.BestAnswerId != 0)
                {
                    var answer = bestAnswer.Answers.First(s => s.Id == bestAnswer.BestAnswerId);
                    sb.AppendLine("********************")
                        .AppendFormat("[ Answer ID: {0} ]", answer.Id)
                        .AppendLine()
                        .AppendFormat("Posted by: {0}", answer.Author.Username)
                        .AppendLine()
                        .AppendFormat("Answer Body: {0}", answer.Body)
                        .AppendLine()
                        .AppendLine("--------------------")
                        .AppendLine("********************");

                }
                var otherAnswers = question.Answers.Where(s => s.Id != bestAnswer.BestAnswerId);
                foreach (var otherAnswer in otherAnswers.OrderBy(s => s.Id))
                {
                    sb.AppendLine(PrintAnswer(otherAnswer));
                }
            }
            else
            {
                sb.AppendLine("No answers");
            }
            return sb.ToString();
        }


        public static string PrintAnswer(IAnswer answer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[ Answer ID: {0} ]", answer.Id)
                .AppendLine()
                .AppendFormat("Posted by: {0}", answer.Author.Username)
                .AppendLine()
                .AppendFormat("Answer Body: {0}", answer.Body)
                .AppendLine()
                .Append("--------------------");

            return sb.ToString();
        }
    }
}/*
********************
[Answer ID: {id} ]
Posted by: {author}
Answer Body: {body}
--------------------
********************

*/
