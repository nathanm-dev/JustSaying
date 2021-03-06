using System.Threading.Tasks;
using JustBehave;
using JustSaying.Messaging.Monitoring;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace JustSaying.UnitTests.JustSayingBus
{
    public abstract class GivenAServiceBus : XAsyncBehaviourTest<JustSaying.JustSayingBus>
    {
        protected IMessagingConfig Config;
        protected IMessageMonitor Monitor;
        protected ILoggerFactory LoggerFactory;

        protected override Task Given()
        {
            Config = Substitute.For<IMessagingConfig>();
            Monitor = Substitute.For<IMessageMonitor>();
            LoggerFactory = Substitute.For<ILoggerFactory>();
            return Task.CompletedTask;
        }

        protected override Task<JustSaying.JustSayingBus> CreateSystemUnderTestAsync()
            => Task.FromResult(new JustSaying.JustSayingBus(Config, null, LoggerFactory) {Monitor = Monitor});
    }
}
