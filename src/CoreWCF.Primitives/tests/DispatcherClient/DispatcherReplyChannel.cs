﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;
using System.Threading.Tasks;
using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DispatcherClient
{
    internal class DispatcherReplyChannel : CommunicationObject, IReplyChannel
    {
        private readonly IServiceProvider _serviceProvider;

        public DispatcherReplyChannel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public EndpointAddress LocalAddress => _serviceProvider.GetRequiredService<EndpointAddress>();

        public IServiceChannelDispatcher ChannelDispatcher { get; set; }

        protected override TimeSpan DefaultCloseTimeout => _serviceProvider.GetRequiredService<DispatcherChannelFactory>().CloseTimeout;

        protected override TimeSpan DefaultOpenTimeout => _serviceProvider.GetRequiredService<DispatcherChannelFactory>().OpenTimeout;

        public T GetProperty<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }

        public Task<RequestContext> ReceiveRequestAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RequestContext> ReceiveRequestAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<(RequestContext requestContext, bool success)> TryReceiveRequestAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> WaitForRequestAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        protected override void OnAbort()
        {
        }

        protected override Task OnCloseAsync(CancellationToken token)
        {
            return Task.CompletedTask;
        }

        protected override Task OnOpenAsync(CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}