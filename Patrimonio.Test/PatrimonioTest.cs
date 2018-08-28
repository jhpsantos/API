using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patrimonio.Business;
using Patrimonio.Entities;
using Moq;
using Patrimonio.Business.Interface;
using Patrimonio.Repository.Interface;
using Patrimonio.Repository.RepositoriosEntidades;

namespace Patrimonio.Test
{

    [TestClass]
    public class PatrimonioTest
    {
        [TestMethod]
        public void InserirPatrimonioTest()
        {
            PatrimonioEntity entity = new PatrimonioEntity();
            entity.Descricao = "sdfsdfsd";
            entity.Nome = "dsdfsd";
            entity.MarcaId = 1;

            var mockPatrimonio = new Mock<IPatrimonioBusiness>();
            mockPatrimonio.Setup(c => c.InserirPatrimonio(entity)).Returns(true);

        }
    }
}
