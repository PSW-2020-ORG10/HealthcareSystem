using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class RebbitMQTests
    {

        [Fact]
        public static void  Deserializes_messages()
        {

            var test = new Mock<BackgroundService>();
            test.Verify(verify => verify.StartAsync(new CancellationToken()));

        }


    }
}
