using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoDuit.Model
{
    public class QuestionModel
    {
        public class QuestionOne
        {
            public int id { get; set; }
            public int category { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string footer { get; set; }
            public string[] tags { get; set; }
            public string createdAt { get; set; }
        }

        public class QuestionTwo
        {
            public int id { get; set; }
            public int category { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string footer { get; set; }
            public string[] tags { get; set; }
            public DateTime createdAt { get; set; }
        }

        public class QuestionThree
        {
            public int id { get; set; }
            public int category { get; set; }
            public ChildQuestionThree[] items { get; set; }
            public DateTime createdAt { get; set; }
        }

        public class ChildQuestionThree
        {
            public string title { get; set; }
            public string description { get; set; }
            public string footer { get; set; }
        }


        public class AnswerQuestionThree
        {
            public int id { get; set; }
            public int category { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string footer { get; set; }
            public DateTime createdAt { get; set; }
        }




    }
}
