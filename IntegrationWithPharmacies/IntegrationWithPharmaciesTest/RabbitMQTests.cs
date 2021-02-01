﻿using System;
using System.Collections.Generic;
using Moq;
using Shouldly;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Service;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;


using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class RebbitMQTests
    {

        [Fact]
        public static void Create_message_successfuly()
        {
            MessageService service = new MessageService(CreateStubRepository());
            Message message = service.Create(new MessageDto("Message", "02/02/2020", new DateTime(), "12345", "02/02/2020"));
            message.ShouldNotBeNull();
        }

        private static IMessageRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMessageRepository>();
            Message message = new Message(3, "Message", "02/02/2020", new DateTime(), false, "Apoteka Jankovic", "02/02/2020");
            var messages = new List<Message>();
            stubRepository.Setup(m => m.Create(It.IsAny<Message>())).Returns(message);
            return stubRepository.Object;
        }
    }
}