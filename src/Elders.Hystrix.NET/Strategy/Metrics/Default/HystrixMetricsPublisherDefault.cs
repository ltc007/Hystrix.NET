﻿namespace Elders.Hystrix.NET.Strategy.Metrics
{
    using System;
    using Elders.Hystrix.NET.CircuitBreaker;
    using Elders.Hystrix.NET.ThreadPool;

    public class HystrixMetricsPublisherDefault : IHystrixMetricsPublisher
    {
        private static HystrixMetricsPublisherDefault instance = new HystrixMetricsPublisherDefault();
        public static HystrixMetricsPublisherDefault Instance { get { return instance; } }

        protected HystrixMetricsPublisherDefault()
        {
        }

        public virtual IHystrixMetricsPublisherCommand GetMetricsPublisherForCommand(HystrixCommandKey commandKey, HystrixCommandGroupKey commandGroupKey, HystrixCommandMetrics metrics, IHystrixCircuitBreaker circuitBreaker, IHystrixCommandProperties properties)
        {
            return new HystrixMetricsPublisherCommandDefault(commandKey, commandGroupKey, metrics, circuitBreaker, properties);
        }

        public virtual IHystrixMetricsPublisherThreadPool GetMetricsPublisherForThreadPool(HystrixThreadPoolKey threadPoolKey, HystrixThreadPoolMetrics metrics, IHystrixThreadPoolProperties properties)
        {
            return new HystrixMetricsPublisherThreadPoolDefault(threadPoolKey, metrics, properties);
        }

        public void Dispose()
        {
            // do nothing by default
        }
    }
}
