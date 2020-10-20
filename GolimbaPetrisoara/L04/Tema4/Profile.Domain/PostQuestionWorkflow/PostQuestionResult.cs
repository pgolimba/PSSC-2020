using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.Choices;

namespace Profile.Domain.CreateProfileWorkflow
{
    [AsChoice]
    public static partial class PostQuestionResult
    {
        public interface ICreateProfileResult { }

        public class QuestionPosted: ICreateProfileResult
        {
            public Guid Title { get; private set; }
            public string Continut { get; private set; }

            public QuestionPosted(Guid title, string continut)
            {
                Title = title;
                Continut = continut;
            }
        }

        public class ProfileNotCreated: ICreateProfileResult
        {
            public string Reason { get; set; }

            public ProfileNotCreated(string reason)
            {
                Reason = reason;
            }
        }

        public class ProfileValidationFailed: ICreateProfileResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public ProfileValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
