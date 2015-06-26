namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;

    public class Answer : Post , IAnswer
    {
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public static int AnswerCount { get; set; }
    }
}
