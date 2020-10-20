using Profile.Domain.CreateProfileWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Profile.Domain.CreateProfileWorkflow.PostQuestionResult;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new CreateQuestionCmd("titlu intrebare", string.Empty, "continut");
            var result = CreateQuestion(cmd);

            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotCreated,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        private static ICreateQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateQuestionResult ProcessQuestionNotCreated(QuestionNotCreated questionNotCreatedResult)
        {
            Console.WriteLine($"Question not posted: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }

        private static ICreateQuestionResult ProcessQuestionPosted(QuestionPosted profile)
        {
            Console.WriteLine($"Profile {profile.Title}");
            return profile;
        }

        public static ICreateQuestionResult CreateQuestion(CreateQuestionCmd createQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(createQuestionCommand.Continut))
            {
                var errors = new List<string>() { "Your question was not passed" };
                return new QuestionValidationFailed(errors);
            }

            if(new Random().Next(10) > 1)
            {
                return new QuestionNotCreated("Question could not be verified");
            }

            var title = Guid.NewGuid();
            var result = new QuestionPosted(title, createQuestionCommand.Continut);

            //execute logic
            return result;
        }
    }
}
