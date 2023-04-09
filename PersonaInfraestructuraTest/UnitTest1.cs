using Microsoft.AspNetCore.Mvc;
using PersonaInfraestructura.Controllers;
using PersonaInfraestructura.Models;
using PersonaInfraestructura.Sevices;
using System.Net;

namespace PersonaInfraestructuraTest
{
    public class PersonaControllerTest
    {
        private readonly PersonasController _controller;
        private readonly IPersonaServices _service;

        public PersonaControllerTest()
        {
            _service = new PersonaServices();
            _controller = new PersonasController(_service);

        }


        [Fact]
        public void GetPersonas_Expected_Success()
        {

            //act
            var result = _controller.GetPersonas();

            //assert
            Assert.IsType<OkObjectResult>(result);

        }


        [Fact]
        public void GetPersonas_Expected_ListPersona()
        {

            //act
            var result = (OkObjectResult)_controller.GetPersonas();

            //assert
            var ListaPersona = Assert.IsType<List<Persona>>(result.Value);
            Assert.True(ListaPersona.Count > 0);

        }


        [Theory]
        [InlineData(1)]
        public void GetPersonas_Given_id_Expected_Object_Persona(int id)
        {
            //act
            var result = _controller.GetPersonas(id) as OkObjectResult;

            //Assert
            var persona = Assert.IsType<Persona>(result.Value);
            Assert.True(persona != null);
            Assert.True(persona.PerdonsaID == id);

        }
        [Theory]
        [InlineData(15)]
        public void GetPersonas_Given_error_id_Expected_NotFoundResult(int id)
        {
            //act
            var result = _controller.GetPersonas(id);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }


        [Theory]
        [InlineData(19)]
        public void PostPersona_Creating_New_Persona_expected_Ok(int id)
        {
            //arrange

            Persona p1 = new Persona
            {
                PerdonsaID = id,
                Nombre = "Albert",
                Apellido = "Lee",
                Edad = 11,
                Casado = true
            };

            //act
            var resultPost = _controller.PostPersona(p1) as OkObjectResult;

            //assert
            var responsePosted = Assert.IsType<Persona>(resultPost.Value);

            Assert.True(responsePosted != null);
            Assert.Equal(responsePosted.PerdonsaID, id);

        }


        [Theory]
        [InlineData(1)]
        public void PostPersona_Creating_New_Persona_expected_BadRequestResult(int id)
        {
            //arrange
            Persona p1 = new Persona
            {
                PerdonsaID = id,
                Nombre = "Albert",
                Apellido = "Lee",
                Edad = 11,
                Casado = true
            };

            //act
            var result = _controller.PostPersona(p1) as BadRequestObjectResult;

            //assert
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode.Value);
        }

        [Theory]
        [InlineData(2, 2, "update", "update", 29, false)]
        public void PutPersona_Updating_Record_In_ListPersona_Expected_Success(int id1, int id2, string nombre, string apellido, int edad, bool casado)
        {
            //arrange
            Persona personaNewReods = new Persona()
            {
                PerdonsaID = id2,
                Nombre = nombre,
                Apellido = apellido,
                Casado = casado,
                Edad = edad
            };

            //act
            var resultPut = _controller.PutPersona(id1, personaNewReods) as OkObjectResult;

            //assert

            var responsePut = Assert.IsType<Persona>(resultPut.Value);

            Assert.True(responsePut != null);

        }

        [Theory]
        [InlineData(2, 5, "update", "update", 29, false)]
        public void PutPersona_Updating_Record_Given_difretenIDs_Expected_BadRequestResult(int id1, int id2, string nombre, string apellido, int edad, bool casado)
        {
            //arrange
            Persona personaNewReods = new Persona()
            {
                PerdonsaID = id2,
                Nombre = nombre,
                Apellido = apellido,
                Casado = casado,
                Edad = edad
            };

            //act
            var resultPut = _controller.PutPersona(id1, personaNewReods) as BadRequestObjectResult;

            // assert

            Assert.Equal((int)HttpStatusCode.BadRequest, resultPut.StatusCode.Value);

        }

        [Theory]
        [InlineData(50, 50, "update", "update", 29, false)]
        public void PutPersona_Updating_Record_Given_Id_Expected_NotFoundResult(int id1, int id2, string nombre, string apellido, int edad, bool casado)
        {
            //arrange
            Persona personaNewReods = new Persona()
            {
                PerdonsaID = id2,
                Nombre = nombre,
                Apellido = apellido,
                Casado = casado,
                Edad = edad
            };


            //act
            var resultPut = _controller.PutPersona(id1, personaNewReods);

            // assert

            Assert.IsType<NotFoundResult>(resultPut);

        }

        [Theory]
        [InlineData(5)]
        public void DeletePersona_Deleting_Persona_Expected_Success(int idPersona)
        {

            // act
            var result = _controller.DeletePersona(idPersona) as OkObjectResult;

            //assert

            var responseDelete = Assert.IsType<List<Persona>>(result.Value);

            Assert.True(6 > responseDelete.Count());
            Assert.Equal(5, responseDelete.Count());

        }

        [Theory]
        [InlineData(null)]
        public void DeletePersona_Deleting_Persona_Given_NullId_Expected_NotFoundResult(int idPersona)
        {

            // act
            var result = _controller.DeletePersona(idPersona);

            //assert

            Assert.IsType<NotFoundResult>(result);

        }

        [Theory]
        [InlineData(500)]
        public void DeletePersona_Deleting_Persona_Given_Id_Expected_NotFoundResult(int idPersona)
        {

            // act
            var result = _controller.DeletePersona(idPersona);

            //assert

            Assert.IsType<NotFoundResult>(result);

        }
    }
}