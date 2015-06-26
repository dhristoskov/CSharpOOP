namespace ConsoleForum.Entities.Posts
{
    using System.Collections.Generic;
    using ConsoleForum.Contracts;

    public class Question : Post, IQuestion
    {
        public Question(int id, string body, IUser author, string title)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public int BestAnswerId { get; set; }

        public IList<IAnswer> Answers { get; private set; }

        public static int QuestionCount { get; set; }
    }
}
