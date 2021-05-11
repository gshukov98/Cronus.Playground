using Cronus.Contracts;
using Cronus.Contracts.Commands;
using Elders.Cronus;
using Elders.Cronus.Api;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cronus.Host
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICronusHost cronusHost;
        private readonly IPublisher<ICommand> commandPublisher;

        public Worker(IServiceProvider provider, ICronusHost cronusHost, IPublisher<ICommand> commandPublisher, ILogger<Worker> logger)
        {
            _logger = logger;
            this.cronusHost = cronusHost;
            this.commandPublisher = commandPublisher;
            CronusBooter.BootstrapCronus(provider);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting service...");

            cronusHost.Start();

            _logger.LogInformation("Service started");

            //Input number of messages and type of messages
            var list = CreateMessages<CreateSimpleMessage>(10_000);

            //Input list of commangs, batchSize and delay
            //If batch size is less than 1 all messages that will be sent together
            PublishCommandList(list, 0, 10);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping service...");

            cronusHost.Stop();

            _logger.LogInformation("Service stopped!");
            return Task.CompletedTask;
        }

        #region Trash
        ///////////////////////////////////////////////////////////////////////////////////
        private void CreateSimpleMessageCommand(int index)
        {
            SimpleMessageId simpleMessageId = new SimpleMessageId(Guid.NewGuid().ToString(), "elders");
            commandPublisher.Publish(new CreateSimpleMessage(simpleMessageId, DateTimeOffset.Now));
        }

        private void CreateGGMessageCommand(int index)
        {
            //Don't have implementation for Handle in AppService
            SimpleMessageId simpleMessageId = new SimpleMessageId(Guid.NewGuid().ToString(), "elders");
            commandPublisher.Publish(new CreateEmptyMessage(simpleMessageId, DateTimeOffset.Now));
        }
        ///////////////////////////////////////////////////////////////////////////////////
        #endregion

        public void PublishCommandList(IEnumerable<ICommand> commands, int batchSize, int delay)
        {
            if (batchSize <= 0)
            {
                SendCommandsGG(commands.ToList());
                return;
            }
            var count = commands.Count();

            for (int i = 0; i < count / batchSize; i++)
            {
                List<ICommand> batch = commands.Skip(batchSize * i).Take(batchSize).ToList();
                SendCommandsGG(batch);
                Thread.Sleep(delay);
            }
        }

        private void SendCommandsGG(List<ICommand> commands)
        {
            foreach (var item in commands)
            {
                commandPublisher.Publish(item);
            }
        }

        public List<ICommand> CreateMessages<T>(int count)
        {
            List<ICommand> list = new List<ICommand>();
            for (int i = 0; i < count; i++)
            {
                ICommand message = Activator.CreateInstance<T>() as ICommand;
                list.Add(message);
            }
            return list;
        }

        public List<ICommand> CreateGGMessages(int count)
        {
            List<ICommand> list = new List<ICommand>();
            for (int i = 0; i < count; i++)
            {
                SimpleMessageId simpleMessageId = new SimpleMessageId(Guid.NewGuid().ToString(), "elders");
                var message = new CreateEmptyMessage(simpleMessageId, DateTimeOffset.UtcNow);
                list.Add(message);
            }
            return list;
        }
    }
}
