using Application.Services;
using Domain.CustomExeptions;
using Domain.Models;
using Domain.Repositories;
using Moq;

namespace ApplicationTest.Services
{
    public class EstacionServiceTest
    {
        [Fact]
        public async void GetById_HaveToReturnExtistEstacion()
        {
            // Arrange
            var repositoryMock = new Mock<IEstacionRepository>();
            EstacionId expectedId = new EstacionId(3);
            var expectedEstacion = new Estacion(
                expectedId,
                "Mi estacion",
                DateTime.Now,
                new EstacionLatitud(3.143),
                new EstacionLongitud(6.345)
            );

            repositoryMock.Setup(repo => repo.FindbyId(expectedId)).ReturnsAsync(expectedEstacion);

            var estacionService = new EstacionService(repositoryMock.Object);

            // Act
            var result = await estacionService.GetById(expectedId);

            // Assert
            await Assert.ThrowsAsync<NotFoundElementException>(() => estacionService.GetById(new EstacionId(1)));

            Assert.NotNull(result);
            Assert.Equal(result.Id, expectedEstacion.Id);
            Assert.Equal(result.Nombre, expectedEstacion.Nombre);
            Assert.Equal(result.Longitud, expectedEstacion.Longitud);
            Assert.Equal(result.Latitud, expectedEstacion.Latitud);
            Assert.Equal(result.FechaHoraCreacion, expectedEstacion.FechaHoraCreacion);
        }

        [Fact]
        public async void GetAll_HaveToReturnAllEstaciones()
        {
            // Arrange
            var repositoryMock = new Mock<IEstacionRepository>();

            Estacion estacion1 = new Estacion(new EstacionId(1), "Puente", DateTime.Now, new EstacionLatitud(1.324), new EstacionLongitud(6.234));
            Estacion estacion2 = new Estacion(new EstacionId(1), "Puente", DateTime.Now, new EstacionLatitud(1.324), new EstacionLongitud(6.234));

            List<Estacion> estacionList = new List<Estacion>() { estacion1, estacion2 };

            repositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(estacionList);
            var estacionService = new EstacionService(repositoryMock.Object);

            // Act
            var result = await estacionService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void Update_HaveToUpdateAEstaciones()
        {
            // Arrange
            var repositoryMock = new Mock<IEstacionRepository>();
            EstacionId estacionId = new EstacionId(5);
            Estacion originalEstacion = new Estacion(
                estacionId,
                "Puente",
                DateTime.Now,
                new EstacionLatitud(1.324),
                new EstacionLongitud(6.234)
            );
            Estacion expectedEstacion = new Estacion(
                estacionId,
                "Mar",
                originalEstacion.FechaHoraCreacion,
                new EstacionLatitud(1.543),
                new EstacionLongitud(6.0877)
            );
            Estacion returnedEstacion = new Estacion(
                estacionId,
                "Puente",
                DateTime.Now,
                new EstacionLatitud(1.324),
                new EstacionLongitud(6.234)
            );
            repositoryMock.Setup(repo => repo.FindbyId(estacionId)).ReturnsAsync(originalEstacion);
            repositoryMock
                .Setup(repo => repo.Update(It.IsAny<Estacion>()))
                .Callback(
                    (Estacion est) =>
                    {
                        returnedEstacion = est;
                    }
                );

            //repositoryMock
            //   .Setup(repo => repo.Update(It.IsAny<Estacion>()))
            // .ThrowsAsync(new Exception());

            var estacionService = new EstacionService(repositoryMock.Object);

            // Act
            await estacionService.Update(estacionId, expectedEstacion.Nombre, expectedEstacion.Latitud, expectedEstacion.Longitud);

            // Assert

            repositoryMock.Verify(repo => repo.FindbyId(estacionId), Times.Once);
            repositoryMock.Verify(repo => repo.Update(It.IsAny<Estacion>()), Times.Once);
            await Assert.ThrowsAsync<NotFoundElementException>(
                () => estacionService.Update(new EstacionId(9), expectedEstacion.Nombre, expectedEstacion.Latitud, expectedEstacion.Longitud)
            );
            Assert.Equal(expectedEstacion.Id, returnedEstacion.Id);
            Assert.Equal(expectedEstacion.Nombre, returnedEstacion.Nombre);
            Assert.Equal(expectedEstacion.Latitud, returnedEstacion.Latitud);
            Assert.Equal(expectedEstacion.Longitud, returnedEstacion.Longitud);
            Assert.Equal(expectedEstacion.FechaHoraCreacion, returnedEstacion.FechaHoraCreacion);
        }

        [Fact]
        public async Task Update_ReturnThrowAsync()
        {
            // Arrange
            var repositoryMock = new Mock<IEstacionRepository>();
            EstacionId estacionId = new EstacionId(5);
            Estacion originalEstacion = new Estacion(
                estacionId,
                "Puente",
                DateTime.Now,
                new EstacionLatitud(1.324),
                new EstacionLongitud(6.234)
            );
            Estacion expectedEstacion = new Estacion(
                estacionId,
                "Mar",
                originalEstacion.FechaHoraCreacion,
                new EstacionLatitud(1.543),
                new EstacionLongitud(6.0877)
            );
            Estacion expectedEstacionFall = new Estacion(
                estacionId,
                "",
                originalEstacion.FechaHoraCreacion,
                new EstacionLatitud(1.543),
                new EstacionLongitud(6.0877)
            );
            repositoryMock.Setup(repo => repo.FindbyId(estacionId)).ReturnsAsync(originalEstacion);
            repositoryMock
                .Setup(repo => repo.Update(It.IsAny<Estacion>()))
                .ThrowsAsync(new Exception());
            //repositoryMock
            //   .Setup(repo => repo.Update(It.IsAny<Estacion>()))
            // .ThrowsAsync(new Exception());

            var estacionService = new EstacionService(repositoryMock.Object);

            // Act
            // await estacionService.Update(estacionId, expectedEstacionFall);

            // Assert
            await Assert.ThrowsAsync<NotFoundElementException>(
                () => estacionService.Update(new EstacionId(9), expectedEstacion.Nombre, expectedEstacion.Latitud, expectedEstacion.Longitud)
            );
            await Assert.ThrowsAsync<CouldNotUpdateDBException>(
                () => estacionService.Update(estacionId, expectedEstacionFall.Nombre, expectedEstacionFall.Latitud, expectedEstacionFall.Longitud)
            );
        }

        [Fact]
        public async void Delete_RemoveAEstacion()
        {
            // Arrange
            var repositoryMock = new Mock<IEstacionRepository>();

            EstacionId estacionId = new EstacionId(8);
            Estacion originalEstacion = new Estacion(
                estacionId,
                "Puente",
                DateTime.Now,
                new EstacionLatitud(1.324),
                new EstacionLongitud(6.234)
            );
            repositoryMock.Setup(repo => repo.FindbyId(estacionId)).ReturnsAsync(originalEstacion);

            repositoryMock.Setup(repo => repo.Delete(originalEstacion));

            var estacionService = new EstacionService(repositoryMock.Object);

            // Act
            await estacionService.Delete(estacionId);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(originalEstacion), Times.Once);
            repositoryMock.Verify(repo => repo.FindbyId(estacionId), Times.Once);
            await Assert.ThrowsAsync<NotFoundElementException>(() => estacionService.Delete(new EstacionId(1)));
        }
    }
}
