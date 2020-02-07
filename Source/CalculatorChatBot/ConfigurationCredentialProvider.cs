// <copyright file="ConfigurationCredentialProvider.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot
{
    using System;
    using Microsoft.Bot.Connector.Authentication;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Initializes the configuration credential provider.
    /// </summary>
    public class ConfigurationCredentialProvider : SimpleCredentialProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationCredentialProvider"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration settings.</param>
        public ConfigurationCredentialProvider(IConfiguration configuration)
#pragma warning disable CA1062 // Validate arguments of public methods
            : base(configuration["MicrosoftAppId"], configuration["MicrosoftAppPassword"])
#pragma warning restore CA1062 // Validate arguments of public methods
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
        }
    }
}