using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game
{
    public class clsGame
    {
        public enum GameType {  Add, Subtract, Mult, Divide };
        private static GameType eGameType;

        /// <summary>
        /// public property eGameType
        /// </summary>
        public static GameType CurrentGameType
        {
            get { return eGameType; }
            set { eGameType = value; }
        }

        /// <summary>
        /// Variable to store the current question
        /// </summary>
        private MathGameQuestion currentQuestion;

        /// <summary>
        /// Generates questions
        /// </summary>
        /// <returns></returns>
        public MathGameQuestion GenerateQuestion()
        {
            // Use eGameType enum to generate a question of the MathGameQuestion type and return it
            MathGameQuestion question = new MathGameQuestion();
            Random random = new Random();

            // Set left and right numbers based on game type
            switch (eGameType)
            {
                case GameType.Add:
                    question.LeftNumber = random.Next(1, 11);
                    question.RightNumber = random.Next(1, 11);
                    question.Answer = question.LeftNumber + question.RightNumber;
                    break;

                case GameType.Subtract:
                    question.RightNumber = random.Next(1, 11);
                    question.Answer = random.Next(1, 11);
                    question.LeftNumber = question.Answer + question.RightNumber;
                    break;

                case GameType.Mult:
                    question.LeftNumber = random.Next(1, 11);
                    question.RightNumber = random.Next(1, 11);
                    question.Answer = question.LeftNumber * question.RightNumber;
                    break;

                case GameType.Divide:
                    int divisor = random.Next(1, 11);
                    question.Answer = random.Next(1, 11);
                    question.LeftNumber = divisor * question.Answer;
                    question.RightNumber = divisor;
                    break;
            }

            // Store the generated question
            currentQuestion = question;

            return question;
        }

        /// <summary>
        /// Determines if the answer is correct
        /// </summary>
        /// <param name="iUserGuess"></param>
        /// <returns></returns>
        public bool ValidateUserGuess(int iUserGuess)
        {
            // Compare the user's guess with the correct answer
            return iUserGuess == currentQuestion.Answer;
        }
    }

    /// <summary>
    /// Math Game Question class
    /// </summary>
    public class MathGameQuestion
    {
        // create integer variables that will hold each math question
        public int LeftNumber { get; set; }
        public int RightNumber { get; set; }
        public int Answer { get; set; }

    }
}
