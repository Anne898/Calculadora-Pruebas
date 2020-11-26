using System;
using NUnit.Framework;

namespace calculadora
{
    // Agregar atributo para indicar que es una clase con pruebas
    [TestFixture]
    class UnitTests
    {
        // Estado inicial de la calculadora
        // CalculadoraEstadoInicialTest
        //
        //Description -> Debe decir qué funcionalidad/restricción 
        //debe cumplir la Calculadora
        [Test]
        [TestCase(TestName = "Calculator should not work until turned on")]
        public void CalculatorInitialStateTest()
        {
            Calculator calculator = new Calculator();

            // Debe estar apagada
            //1- El valor actual
            //2- El valor que debería de ser
            // "Probar que el valor de estar encendida sea false"
            Assert.That(calculator.IsOn(), Is.EqualTo(false));

            // No muestra nada en pantalla
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));

            // Presionar botones no hace nada, excepto el de encender

        }

        // Encendido / Apagado
        // CalculadoraEncendidoApagadoTest
        [Test]
        [TestCase(TestName = "Calculator should turn on and off correctly")]
        public void CalculatorOnOffTest()
        {
            Calculator calculator = new Calculator();

            // Apagado no debe servir
            Assert.That(calculator.IsOn(), Is.EqualTo(false));

            calculator.PressNumber(2);
            calculator.Sum();
            calculator.PressNumber(3);
            calculator.CalculateResult();

            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));

            // Al presionar el botón de encendido se enciende
            calculator.TurnOn();
            Assert.That(calculator.IsOn(), Is.EqualTo(true));

            // Que sirve encendida
            calculator.PressNumber(2);
            calculator.Sum();
            calculator.PressNumber(3);
            calculator.CalculateResult();

            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5"));

            // Apagar regresa al estado inicial
            calculator.TurnOff();
            Assert.That(calculator.IsOn(), Is.EqualTo(false));
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));

            calculator.PressNumber(2);
            calculator.Sum();
            calculator.PressNumber(3);
            calculator.CalculateResult();

            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));
        }

        [Test]
        [TestCase(TestName = "Calculator should Substract correctly")]
        public void CalculatorSubstractTest()
        {
            Calculator calculator = new Calculator();

            calculator.TurnOn();

            // 0-0
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0-"));

            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0-0"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            // 3-1
            calculator.PressNumber(3);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3"));

            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3-"));

            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3-1"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            // 5-9
            calculator.PressNumber(5);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5"));

            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5-"));

            calculator.PressNumber(9);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5-9"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("-4"));

            // 200-10-300
            calculator.PressNumber(2);
            calculator.PressNumber(0);
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("200"));

            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("200-"));

            calculator.PressNumber(1);
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("200-10"));

            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("200-10-"));

            calculator.PressNumber(3);
            calculator.PressNumber(0);
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("200-10-300"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("-110"));

        }

        [Test]
        [TestCase(TestName = "Calculator should sum correctly")]
        public void CalculatorSumTest()
        {
            Calculator calculator = new Calculator();

            calculator.TurnOn();

            // 1+1+1
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));

            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+"));

            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+1"));

            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+1+"));

            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+1+2"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("4"));

            //2+3+4
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+"));

            calculator.PressNumber(3);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+3"));

            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+3+"));

            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+3+4"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("9"));

            // 12+34
            calculator.PressNumber(1);
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+"));
            calculator.PressNumber(3);
            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("46"));

            // 12+34+56
            calculator.PressNumber(1);
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+"));
            calculator.PressNumber(3);
            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34+"));
            calculator.PressNumber(5);
            calculator.PressNumber(6);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34+56"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("102"));

            //1+22+333
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+"));
            calculator.PressNumber(2);
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+22"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+22+"));
            calculator.PressNumber(3);
            calculator.PressNumber(3);
            calculator.PressNumber(3);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+22+333"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("356"));

            //0+0+0
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+"));
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+0"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+0+"));
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+0+0"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

        }

        [Test]
        [TestCase(TestName = "Calculator should Divide correctly")]
        public void CalculatorDivideTest()
        {
            Calculator calculator = new Calculator();

            calculator.TurnOn();

            // 4/2
            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("4"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("4/"));

            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("4/2"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));


            // 2/4
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2/"));

            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2/4"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            // 0/2
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0/"));

            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0/2"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            // 2/0
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2/"));

            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2/0"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            // 9/4
            calculator.PressNumber(9);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("9"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("9/"));

            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("9/4"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            // 49/5
            calculator.PressNumber(4);
            calculator.PressNumber(9);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("49"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("49/"));

            calculator.PressNumber(5);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("49/5"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("9"));


            // 3/4/0
            calculator.PressNumber(3);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3/"));

            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3/4"));

            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3/4/"));

            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("3/4/0"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));



        }


        // Suma
        // Resta
        // Multipliación
        // División
        // Borrar
        // Exponente
        // Raiz
        // Pi
        // E

        /*Edge Cases
        a+b
        numeros muy muy grandes
        input incompletos o en desorden 
        -5


        */

    }
}