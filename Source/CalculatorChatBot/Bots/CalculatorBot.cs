// <copyright file="CalculatorBot.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Bots
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Initializes the CalculatorBot class.
    /// </summary>
    public class CalculatorBot : ActivityHandler
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<CalculatorBot> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorBot"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="logger">Use of the logging mechanisms.</param>
        public CalculatorBot(IConfiguration configuration, ILogger<CalculatorBot> logger)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        /// <summary>
        /// Method that gets fired when a message comes in.
        /// </summary>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a unit of execution.</returns>
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);
        }

        /// <summary>
        /// Method that gets fired when there are system events being fired.
        /// </summary>
        /// <param name="membersAdded">The list of members being added.</param>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a unit of execution.</returns>
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var botDisplayName = this.configuration["BotDisplayName"];
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and Welcome!"), cancellationToken);
                }
            }
        }
    }
}