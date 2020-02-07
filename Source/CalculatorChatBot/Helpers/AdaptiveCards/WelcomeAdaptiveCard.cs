// <copyright file="WelcomeAdaptiveCard.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers.AdaptiveCards
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using CalculatorChatBot.Properties;

    /// <summary>
    /// This class is responsible for the generation of the welcome adaptive card.
    /// </summary>
    public static class WelcomeAdaptiveCard
    {
        private static readonly string CardTemplate;

#pragma warning disable CA1810 // Initialize reference type static fields inline
        static WelcomeAdaptiveCard()
#pragma warning restore CA1810 // Initialize reference type static fields inline
        {
            var cardJsonFilePath = Path.Combine(".", "Helpers", "AdaptiveCards", "WelcomeAdaptiveCard.json");
            CardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// Generates the JSON string of the adaptive card.
        /// </summary>
        /// <param name="botDisplayName">The display name for the bot.</param>
        /// <returns>JSON string of the welcome adaptive card.</returns>
        public static string GetCard(string botDisplayName)
        {
            var welcomeCardTitleText = Resources.WelcomeCardTitle;
            var welcomeCardContentPart1 = string.Format(CultureInfo.InvariantCulture, Resources.WelcomeCardContentPart1, botDisplayName);
            var welcomeCardContentPart2 = Resources.WelcomeCardContentPart2;
            var welcomeCardBulletListItem1 = Resources.WelcomeCardBulletListItem1;
            var welcomeCardBulletListItem2 = Resources.WelcomeCardBulletListItem2;
            var welcomeCardBulletListItem3 = Resources.WelcomeCardBulletListItem3;
            var takeATourButtonText = Resources.TakeATourText;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "welcomeCardTitleText", welcomeCardTitleText },
                { "welcomeCardContentPart1", welcomeCardContentPart1 },
                { "welcomeCardContentPart2", welcomeCardContentPart2 },
                { "welcomeCardBulletListItem1", welcomeCardBulletListItem1 },
                { "welcomeCardBulletListItem2", welcomeCardBulletListItem2 },
                { "welcomeCardBulletListItem3", welcomeCardBulletListItem3 },
                { "takeATourButtonText", takeATourButtonText },
            };

            var cardBody = CardTemplate;
            foreach (var kvp in variablesToValues)
            {
                cardBody = cardBody.Replace($"%{kvp.Key}%", kvp.Value, StringComparison.InvariantCulture);
            }

            return cardBody;
        }
    }
}