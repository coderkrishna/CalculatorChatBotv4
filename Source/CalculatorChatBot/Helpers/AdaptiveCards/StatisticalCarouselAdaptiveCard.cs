// <copyright file="StatisticalCarouselAdaptiveCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers.AdaptiveCards
{
    using System.Collections.Generic;
    using System.IO;
    using CalculatorChatBot.Properties;

    /// <summary>
    /// Generates the statistical carousel adaptive card.
    /// </summary>
    public class StatisticalCarouselAdaptiveCard
    {
        private static readonly string CardTemplate;

        /// <summary>
        /// Initializes static members of the <see cref="StatisticalCarouselAdaptiveCard"/> class.
        /// </summary>
        static StatisticalCarouselAdaptiveCard()
        {
            var cardJsonFilePath = Path.Combine(".", "Helpers", "AdaptiveCards", "StatisticalCarouselAdaptiveCard.json");
            CardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// Ensures to generate the JSON string for the statistical carousel card.
        /// </summary>
        /// <returns>JSON string of the adaptive card.</returns>
        public static string GetCard()
        {
            var statisticalCarouselCardTitleText = Resources.StatisticalCarouselCardTitleText;
            var statisticalCarouselCardContent = Resources.StatisticalCarouselCardContent;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "statisticalCarouselCardTitleText", statisticalCarouselCardTitleText },
                { "statisticalCarouselCardContent", statisticalCarouselCardContent },
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