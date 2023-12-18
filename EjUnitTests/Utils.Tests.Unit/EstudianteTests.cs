using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Tests.Unit
{
    public class EstudianteTests
    {
        public class TheMethod_CalcularEdad : EstudianteTests
        {
            [Theory]
            [InlineData("1990-12-31", "2023-12-07", 33)]
            [InlineData("1990-01-01", "2023-12-07", 33)]
            [InlineData("1991-01-01", "2023-12-07", 32)]
            public void Should_calculate_correctly(string fechaNacimiento, string fechaEdad, int expected)
            {
                // arrange
                var estudiante = new Estudiante()
                {
                    FechaNacimiento = DateOnly.ParseExact(fechaNacimiento, "yyyy-MM-dd")
                };

                // act
                int actual = estudiante.CalcularEdad(DateOnly.ParseExact(fechaEdad, "yyy-MM-dd"));

                // assert
                actual.Should().Be(expected);
            }
        }
    }
}
