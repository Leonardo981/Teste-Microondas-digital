using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicroondasApp;
using System;


                                                       //Estrutura para exemplos de testes unitarios



namespace MicroondasApp.Tests
{
    [TestClass]
    public class Form1Tests
    {
        private Form1 form1;
        private Microondas _microondas;

        [TestInitialize]
        public void Setup()
        {
            form1 = new Form1();
            _microondas = new Microondas();
        }

        [TestMethod]
        public void BtnIniciar_Click_ValidInput_ShouldStartHeating()
        {
            // Arrange
            form1.txtMinutos.Text = "1";
            form1.txtSegundos.Text = "30";
            form1.txtPotencia.Text = "8";

            // Act
            form1.btnIniciar_Click(this, EventArgs.Empty);

            // Assert
            Assert.IsTrue(_microondas.AquecimentoIniciado);
            Assert.AreEqual(90, _microondas.GetTempo());
            Assert.AreEqual(8, _microondas.GetPotencia());
        }

        [TestMethod]
        public void BtnIniciar_Click_InvalidTime_ShouldShowErrorMessage()
        {
            // Arrange
            form1.txtMinutos.Text = "0";
            form1.txtSegundos.Text = "0";
            form1.txtPotencia.Text = "8";

            // Act
            form1.btnIniciar_Click(this, EventArgs.Empty);

            // Assert
            // Verificar se a mensagem de erro foi exibida
        }

        [TestMethod]
        public void BtnIniciar_Click_InvalidPotencia_ShouldShowErrorMessage()
        {
            // Arrange
            form1.txtMinutos.Text = "1";
            form1.txtSegundos.Text = "30";
            form1.txtPotencia.Text = "20";

            // Act
            form1.btnIniciar_Click(this, EventArgs.Empty);

            // Assert
            // Verificar se a mensagem de erro foi exibida
        }
    }
}

[TestClass]
public class MicroondasTests
{
    private Microondas microondas;

    [TestInitialize]
    public void Setup()
    {
        microondas = new Microondas();
    }

    [TestMethod]
    public void IniciarAquecimento_ValidParameters_ShouldSetProperties()
    {
        // Act
        microondas.IniciarAquecimento(90, 8);

        // Assert
        Assert.AreEqual(90, microondas.GetTempo());
        Assert.AreEqual(8, microondas.GetPotencia());
        Assert.IsTrue(microondas.AquecimentoIniciado);
    }

    [TestMethod]
    public void CancelarAquecimento_ShouldResetProperties()
    {
        // Arrange
        microondas.IniciarAquecimento(90, 8);

        // Act
        microondas.CancelarAquecimento();

        // Assert
        Assert.AreEqual(0, microondas.GetTempo());
        Assert.AreEqual(0, microondas.GetPotencia());
        Assert.IsFalse(microondas.AquecimentoIniciado);
    }
}

