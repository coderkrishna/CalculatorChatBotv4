// <copyright file="ResponseCard.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers
{
    using AdaptiveCards;
    using System.Collections.Generic;
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
    }
}