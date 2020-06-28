// <copyright file="ResponseCard.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers
{
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// This is the class that will return the response cards accordingly.
    /// </summary>
    public static class ResponseCard
    {
        /// <summary>
        /// This method will return the necessary results to the end user.
        /// </summary>
        /// <param name="result">The numerical result.</param>
        /// <param name="command">The command that produced the result.</param>
        /// <returns>An attachment to append to a message.</returns>
        public static Attachment GetCardWithIntResult(int result, string command)
        {
            AdaptiveCard cardToReturn = new AdaptiveCard(new AdaptiveSchemaVersion(1, 2))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = $"Command: {command}",
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = $"Result: {result}",
                        Wrap = true,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = cardToReturn,
            };
        }

        /// <summary>
        /// This method will return the necessary results to the end user.
        /// </summary>
        /// <param name="result">The decimal result.</param>
        /// <param name="command">The command that produced the result.</param>
        /// <returns>An attachment to append to a message.</returns>
        public static Attachment GetCardWithDecimalResult(decimal result, string command)
        {
            AdaptiveCard cardToReturn = new AdaptiveCard(new AdaptiveSchemaVersion(1, 2))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = $"Command: {command}",
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = $"Result: {result}",
                        Wrap = true,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = cardToReturn,
            };
        }

        /// <summary>
        /// This method will return the necessary results to the end user.
        /// </summary>
        /// <param name="result">The decimal result.</param>
        /// <param name="command">The command that produced the result.</param>
        /// <returns>An attachment to append to a message.</returns>
        public static Attachment GetCardWithStringResult(string result, string command)
        {
            AdaptiveCard cardToReturn = new AdaptiveCard(new AdaptiveSchemaVersion(1, 2))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = $"Command: {command}",
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = $"Result: {result}",
                        Wrap = true,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = cardToReturn,
            };
        }

        /// <summary>
        /// This method will return the necessary double data type results to the end user.
        /// </summary>
        /// <param name="result">The result of the operation specified by the command.</param>
        /// <param name="command">The command being executed as part of what the user tells the bot.</param>
        /// <returns>An attachment to append to a message.</returns>
        public static Attachment GetCardWithDoubleResult(double result, string command)
        {
            AdaptiveCard cardToReturn = new AdaptiveCard(new AdaptiveSchemaVersion(1, 2))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = $"Command: {command}",
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = $"Result: {result}",
                        Wrap = true,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = cardToReturn,
            };
        }

        /// <summary>
        /// This method will return a card when there is an array returned as a result.
        /// </summary>
        /// <param name="result">The result of an operation specified by a command.</param>
        /// <param name="command">The command that the user provides to the bot.</param>
        /// <returns>An attachment to append to a message.</returns>
        public static Attachment GetCardWithIntArrayResult(int[] result, string command)
        {
            AdaptiveCard cardToReturn = new AdaptiveCard(new AdaptiveSchemaVersion(1, 2))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = $"Command: {command}",
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = $"Result: {string.Join(string.Empty, result)}",
                        Wrap = true,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = cardToReturn,
            };
        }
    }
}