// <copyright file="WelcomeAdaptiveCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers.AdaptiveCards
{
    using System.Collections.Generic;
    using System.IO;
    using CalculatorChatBot.Properties;

    /// <summary>
    /// This class is responsible for the generation of the welcome adaptive card.
    /// </summary>
    public class WelcomeAdaptiveCard
    {
        private static readonly string CardTemplate;

        static WelcomeAdaptiveCard()
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
            var welcomeCardContentPart1 = string.Format(Resources.WelcomeCardContentPart1, botDisplayName);
            var welcomeCardContentPart2 = Resources.WelcomeCardContentPart2;
            var welcomeCardBulletListItem1 = Resources.WelcomeCardBulletListItem1;
            var welcomeCardBulletListItem2 = Resources.WelcomeCardBulletListItem2;
            var welcomeCardBulletListItem3 = Resources.WelcomeCardBulletListItem3;
            var takeATourText = Resources.TakeATourText;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "welcomeCardTitleText", welcomeCardTitleText },
                { "welcomeCardContentPart1", welcomeCardContentPart1 },
                { "welcomeCardContentPart2", welcomeCardContentPart2 },
                { "welcomeCardBulletListItem1", welcomeCardBulletListItem1 },
                { "welcomeCardBulletListItem2", welcomeCardBulletListItem2 },
                { "welcomeCardBulletListItem3", welcomeCardBulletListItem3 },
                { "takeATourText", takeATourText },
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