using System;

namespace ShortConversation {
    /* A class to communicate with the user to ask for his/her name, ask for his/her income and age.
     * Task: week 3 workshop activity 1
     * Author: Lam Kwok Shing (Toni)
     * Student Number: N9516778
     * Date: 3th November, 2015
     */
    class Conversation {
        private const string WELCOME_MESSAGE = "Welcome";
        private const string QUESTION_PROMPTING_USERNAME = "Enter your name here";
        private const string QUESTION_PROMPTING_INCOME = "So how much money do you earn";
        private const string WARNING_INVALID_INCOME = "Don't play me";
        private const string RESPONSE_INCOME_FEELING = "Wow";
        private const string RESPONSE_INCOME_ALOT = "is a lot of money";
        private const string RESPONSE_INCOME_LESS = "is not enough to live";
        private const string QUESTION_PROMPTING_AGE = "And how old are you";
        private const string WARNING_INVALID_AGE = "Don't play me";
        private const string RESPONSE_AGE_AND_INCOME_PART1 = "So you are";
        private const string RESPONSE_AGE_AND_INCOME_PART2 = "years old and you earn";
        private static string username;
        private static double income;
        private static int age;

        static void Main(string[] args) {
            promptUserName();
            username = readUserName();
            welcomeUser(username);
            income = talkAboutIncome(username);
            talkAboutAge(income);
        }

       
        /// <summary>
        /// Asks the user to enter their name
        /// </summary>
        /// <param>true</param>
        /// <results>Print the question on the console</results>
        private static void promptUserName() {
            Console.Write("{0}: ", QUESTION_PROMPTING_USERNAME);
        }

        /// <summary>
        /// Reads their name
        /// </summary>
        /// <param>true</param>
        /// <results>Return the inputted value in string type</results>
        private static string readUserName() {
            return Console.ReadLine();
        }

        /// <summary>
        /// Write "Hello" on the screen and includes their name
        /// </summary>
        /// <param name = "username">username not null</param>
        /// <results>Print the welcome message with the given username on the console</results>
        private static void welcomeUser(string username) {
            Console.WriteLine("{0} {1}!!!", WELCOME_MESSAGE, username);
        }

        /// <summary>
        /// A method to ask user about his/her income
        /// </summary>
        /// <param name = "username">username not null</param>
        /// <results>Give feedback to user's income and return the income to caller</results>
        private static double talkAboutIncome(string username) {
            bool validIncomeEntry = true;

            /* ask for user input until the user give you a valid value */
            do {
                promptUserIncome(username);
                income = readUserIncome(out validIncomeEntry);
                if (!validIncomeEntry) {
                    promptInvalidIncomeValue();
                }
            } while (!validIncomeEntry);

            responseUserIncome(income);
            return income;
        }

        /// <summary>
        /// Ask the user how much money they earn, including their name in the questions
        /// </summary>
        /// <param name = "username">username not null</param>
        /// <results>Print the question on console to ask for user's income.</results>
        private static void promptUserIncome(string username) {
            Console.WriteLine("{0}, {1}?", QUESTION_PROMPTING_INCOME, username);
        }

        /// <summary>
        /// Reads the number that the user enters
        /// </summary>
        /// <param name = "validIncomeEntry">true</param>
        /// <results>Return user's income to caller and update the value of validIncomeEntry</results>
        private static double readUserIncome(out bool validIncomeEntry) {
            double incomeEntry;
            validIncomeEntry = double.TryParse(Console.ReadLine(), out incomeEntry);
            if (incomeEntry < 0) {
                validIncomeEntry = false;
            }
            return incomeEntry;
        }

        /// <summary>
        /// Warn the user for invalid input value for income
        /// </summary>
        /// <param>true</param>
        /// <results>Print the warning message on console.</results>
        private static void promptInvalidIncomeValue() {
            Console.WriteLine("{0}!", WARNING_INVALID_INCOME);
        }

        /// <summary>
        /// Write the amount of money on the scree in currency format
        /// </summary>
        /// <param name = "income">income not null</param>
        /// <results>Print the response message on the console about the user's income.</results>
        private static void responseUserIncome(double income) {
            string responseIncomrAmount;
            if (income > 10000) {
                responseIncomrAmount = RESPONSE_INCOME_ALOT;
            } else {
                responseIncomrAmount = RESPONSE_INCOME_LESS;
            }
            Console.WriteLine("{0}! {1:C2} {2}!", RESPONSE_INCOME_FEELING, income, responseIncomrAmount);
        }

        /// <summary>
        /// A method to ask user about his/her age
        /// </summary>
        /// <param></param>
        /// <results>Give feedback to user's income and age.</results>
        private static void talkAboutAge(double income) {
            bool validAgeEntry = true;

            /* ask for user input until the user give you a valid value */
            do {
                promptUserAge();
                age = readUserAge(out validAgeEntry);
                if (!validAgeEntry) {
                    promptInvalidAgeValue();
                }
            } while (!validAgeEntry);

            responseUserAgeAndIncome(age, income);
        }

        /// <summary>
        /// Asks the user about how old they are
        /// </summary>
        /// <param>true</param>
        /// <results>Print the question on console to ask for user's age.</results>
        private static void promptUserAge() {
            Console.WriteLine("{0}?", QUESTION_PROMPTING_AGE);
        }

        /// <summary>
        /// Reads the user's age
        /// </summary>
        /// <param name = "validAgeEntry">true</param>
        /// <results>Return user's age to caller and update the value of validAgeEntry</results>
        private static int readUserAge(out bool validAgeEntry) {
            int ageEntry;
            validAgeEntry = int.TryParse(Console.ReadLine(), out ageEntry);
            if (ageEntry < 0) {
                validAgeEntry = false;
            }
            return ageEntry;
        }

        /// <summary>
        /// Warn the user for invalid input value for age
        /// </summary>
        /// <param>true</param>
        /// <results>Print the warning message on console.</results>
        private static void promptInvalidAgeValue() {
            Console.WriteLine("{0}!", WARNING_INVALID_AGE);
        }

        /// <summary>
        /// Writes ther age on the screen in integer format and write the amount of money on the screen in currency format
        /// </summary>
        /// <param name = "age">age not null</param>
        /// <param name = "income">income not null</param>
        /// <results>Print the response message on the console about the user's age and income.</results>
        private static void responseUserAgeAndIncome(int age, double income) {
            Console.WriteLine("{0} {1} {2} {3:C2}!", RESPONSE_AGE_AND_INCOME_PART1, age, RESPONSE_AGE_AND_INCOME_PART2, income);
        }
    }
}
