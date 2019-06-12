// <copyright file="ArithmeticCarouselCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers.AdaptiveCards
{
    using System.Collections.Generic;
    using System.IO;
    using CalculatorChatBot.Properties;

    /// <summary>
    /// This class is generating the arithmetic carousel card.
    /// </summary>
    public class ArithmeticCarouselCard
    {
        private static readonly string CardTemplate;

        static ArithmeticCarouselCard()
        {
            var cardJsonFilePath = Path.Combine(".", "Helpers", "AdaptiveCards", "ArithmeticCarouselCard.json");
            CardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// Method that will generate the JSON string for the arithmetic carousel card. This card is one
        /// of 3 that will appear as part of the welcome tour.
        /// </summary>
        /// <returns>The JSON string for the adaptive card.</returns>
        public static string GetCard()
        {
            var arithmeticCarouselCardTitleText = Resources.ArithmeticCarouselCardTitleText;
            var arithmeticCarouselCardContent = Resources.ArithmeticCarouselCardContent;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "arithmeticCarouselCardTitleText", arithmeticCarouselCardTitleText },
                { "arithmeticCarouselCardContent", arithmeticCarouselCardContent },
            };

            var cardBody = CardTemplate;
            foreach (var kvp in variablesToValues)
            {
                cardBody = cardBody.Replace($"%{kvp.Key}%", kvp.Value);
            }

            return cardBody;
        }
    }
}