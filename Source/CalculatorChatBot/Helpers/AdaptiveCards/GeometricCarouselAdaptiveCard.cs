// <copyright file="GeometricCarouselAdaptiveCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers.AdaptiveCards
{
    using System.Collections.Generic;
    using System.IO;
    using CalculatorChatBot.Properties;

    /// <summary>
    /// This class is generating the geometric carousel card.
    /// </summary>
    public class GeometricCarouselAdaptiveCard
    {
        private static readonly string CardTemplate;

        /// <summary>
        /// Initializes static members of the <see cref="GeometricCarouselAdaptiveCard"/> class.
        /// </summary>
        static GeometricCarouselAdaptiveCard()
        {
            var cardJsonFilePath = Path.Combine(".", "Helpers", "AdaptiveCards", "GeometricCarouselAdaptiveCard.json");
            CardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// Method that will generate the JSON string for the arithmetic carousel card.This card is the second
        /// of 3 that will appear as part of the welcome tour.
        /// </summary>
        /// <returns>JSON string of the adaptive card.</returns>
        public static string GetCard()
        {
            var geometricCarouselCardTitleText = Resources.GeometricCarouselCardTitleText;
            var geometricCarouselCardContent = Resources.GeometricCarouselCardContent;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "geometricCarouselCardTitleText", geometricCarouselCardTitleText },
                { "geometricCarouselCardContent", geometricCarouselCardContent },
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