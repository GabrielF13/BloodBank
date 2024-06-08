using BloodBank.Application.Abstractions;
using BloodBank.Application.Commands.CreateDonate;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using Moq;
using System.Diagnostics.Eventing.Reader;

namespace BloodBank.UnitTests.Application.Commands
{
    public class CreateDonationCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnDonateId()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var donateRepositoryMock = new Mock<IDonateRepository>();

            unitOfWork.SetupGet(uow => uow.Donates).Returns(donateRepositoryMock.Object);

            var createDonateCommand = new CreateDonateCommand
            {
                QuantityMl = 450,
                DonorPersonId = 5
            };

            var createDonateCommandHandler = new CreateDonateCommandHandler(unitOfWork.Object);

            var id = await createDonateCommandHandler.Handle(createDonateCommand, new CancellationToken());


            Assert.True(id.IsSuccess);

            unitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
        }
    }
}