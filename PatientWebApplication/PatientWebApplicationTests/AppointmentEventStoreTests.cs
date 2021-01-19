using EventStore.Dtos;
using EventStore.Events;
using EventStore.Repository;
using EventStore.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PatientWebApplicationTests
{
    public class AppointmentEventStoreTests
    {
        [Fact]
        public void Find_Statistic_Attempts_Ratio()
        {

            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            double ratio = service.GetSuccessfulAttemptsRatio();

            Assert.Equal(ratio, 0.5);
        }

        [Fact]
        public void Find_Statistic_Min_Steps()
        {

            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            CountStepsEventDto countStepsEventDto = service.GetStatisticsMinSteps();

            countStepsEventDto.ShouldNotBeNull();
            Assert.Equal(countStepsEventDto.CountSteps, 4);
        }    

        [Fact]
        public void Find_Statistic_Max_Steps()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            CountStepsEventDto countStepsEventDto = service.GetStatisticsMaxSteps();

            countStepsEventDto.ShouldNotBeNull();
            Assert.Equal(countStepsEventDto.CountSteps, 6);
        }

        [Fact]
        public void Find_Statistic_Most_Canceled_Step()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            double step = service.GetMostCanceledStep();

            Assert.Equal(step, 2);
        }

        [Fact]
        public void Find_Statistic_Average_Steps_Create()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            double step = service.GetAverageStepsForSuccessfulAttempt();

            Assert.Equal(step, 5);
        }

        [Fact]
        public void Find_Statistic_Average_Steps_Cancel()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            double step = service.GetAverageStepsForUnsuccessfulAttempt();

            Assert.Equal(step, 4);
        }

        [Fact]
        public void Find_Statistic_Min_Steps_For_Canceling()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            CountStepsEventDto countStepsEventDto = service.GetStatisticsMinStepsForCancelling();

            countStepsEventDto.ShouldNotBeNull();
            Assert.Equal(countStepsEventDto.CountSteps, 4);
        }

        [Fact]
        public void Find_Statistic_Max_Steps_For_Canceling()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            CountStepsEventDto countStepsEventDto = service.GetStatisticsMaxStepsForCancelling();

            countStepsEventDto.ShouldNotBeNull();
            Assert.Equal(countStepsEventDto.CountSteps, 4);
        }

        [Fact]
        public void Find_Statistic_How_Many_In_Min_Steps()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            double patients = service.GetHowManySchedulesInMinimumSteps();

            Assert.Equal(patients, 1);
        }

        [Fact]
        public void Find_Statistic_How_Many_In_Medium_Steps()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            double patients = service.GetHowManySchedulesInMediumSteps();

            Assert.Equal(patients, 1);
        }

        [Fact]
        public void Find_Statistic_How_Many_In_Max_Steps()
        {
            AppointmentSchedulingEventService service = new AppointmentSchedulingEventService(CreateStubRepository());

            double patients = service.GetHowManySchedulesInMoreSteps();

            Assert.Equal(patients, 0);
        }

        private static IAppointmentSchedulingEventRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentSchedulingEventRepository>();

            var appointmentEvents = new List<AppointmentSchedulingEvent>();

            AppointmentSchedulingEvent appointmentEvent1 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 0, "start", "start", 1);
            AppointmentSchedulingEvent appointmentEvent2 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 1, "next", "", 1);
            AppointmentSchedulingEvent appointmentEvent3 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 2, "previous", "", 1);
            AppointmentSchedulingEvent appointmentEvent4 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 1, "next", "", 1);
            AppointmentSchedulingEvent appointmentEvent5 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 2, "next", "", 1);
            AppointmentSchedulingEvent appointmentEvent14 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 3, "next", "", 1);
            AppointmentSchedulingEvent appointmentEvent6 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 4, "create", "end", 1);
            AppointmentSchedulingEvent appointmentEvent7 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 4, "cancel", "end", 1);

            AppointmentSchedulingEvent appointmentEvent8 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 0, "start", "start", 2);
            AppointmentSchedulingEvent appointmentEvent9 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 1, "next", "", 2);
            AppointmentSchedulingEvent appointmentEvent10 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 2, "next", "", 2);
            AppointmentSchedulingEvent appointmentEvent11 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 3, "next", "", 2);
            AppointmentSchedulingEvent appointmentEvent12 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 4, "create", "end", 2);
            AppointmentSchedulingEvent appointmentEvent13 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 4, "cancel", "end", 2);

            AppointmentSchedulingEvent appointmentEvent15 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 0, "start", "start", 3);
            AppointmentSchedulingEvent appointmentEvent16 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 1, "next", "", 3);
            AppointmentSchedulingEvent appointmentEvent17 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 2, "cancel", "end", 3);

            AppointmentSchedulingEvent appointmentEvent18 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 0, "start", "start", 4);
            AppointmentSchedulingEvent appointmentEvent19 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 1, "next", "", 4);
            AppointmentSchedulingEvent appointmentEvent20 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 2, "previous", "", 4);
            AppointmentSchedulingEvent appointmentEvent21 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 1, "next", "", 4);
            AppointmentSchedulingEvent appointmentEvent22 = new AppointmentSchedulingEvent(Guid.NewGuid(), DateTime.UtcNow, 1, 2, "cancel", "cancel", 4);


            appointmentEvents.Add(appointmentEvent1);
            appointmentEvents.Add(appointmentEvent2);
            appointmentEvents.Add(appointmentEvent3);
            appointmentEvents.Add(appointmentEvent4);
            appointmentEvents.Add(appointmentEvent5);
            appointmentEvents.Add(appointmentEvent6);
            appointmentEvents.Add(appointmentEvent7);
            appointmentEvents.Add(appointmentEvent8);
            appointmentEvents.Add(appointmentEvent9);
            appointmentEvents.Add(appointmentEvent10);
            appointmentEvents.Add(appointmentEvent11);
            appointmentEvents.Add(appointmentEvent12);
            appointmentEvents.Add(appointmentEvent13);
            appointmentEvents.Add(appointmentEvent14);
            appointmentEvents.Add(appointmentEvent15);
            appointmentEvents.Add(appointmentEvent16);
            appointmentEvents.Add(appointmentEvent18);
            appointmentEvents.Add(appointmentEvent19);
            appointmentEvents.Add(appointmentEvent20);
            appointmentEvents.Add(appointmentEvent21);
            appointmentEvents.Add(appointmentEvent22);

            stubRepository.Setup(m => m.GetAll()).Returns(appointmentEvents);

            return stubRepository.Object;
        }
    }
}
