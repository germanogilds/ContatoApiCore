using med.domain;
using med.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace med.test
{
    [TestClass]
    public class ContatoTest
    {
        
        // IContatoService _contatoService;
        ContatoController _controller;
        
        IContatoService service ; 
        private readonly IContatoService _contatoService;
        public ContatoTest()
        {
          var service = new ServiceCollection();
            service.AddTransient<IContatoService, ContatoService>();
            var provider = service.BuildServiceProvider();
            _contatoService =provider.GetService<IContatoService>();
        }

        [TestMethod]
        public void Contato_UsuarioTentaInformarSexoValido()
        {

          var contato = new Contato(){
            Id=1,
            Nome = "German",
            DataNascimento= new DateTime(1970,1,12),
            Sexo="M"
           } ;

           Assert.AreEqual(true,contato.VerificaSexo());
          
         }

       [TestMethod]
        public void Contato_UsuarioTentaInformarSexoInValido()
        {

          var contato = new Contato(){
            Id=1,
            Nome = "German",
            DataNascimento= new DateTime(1970,1,12),
            Sexo="A"
           } ;

          Assert.AreEqual(false,contato.VerificaSexo(),"Sexo Inválido!");
          
        }

            
        // [TestMethod]
        // public void InformadoSexoInvalidoErro()
        // {

        //   var contato = new Contato(){
        //     Id = 10,
        //     Nome = "Germano 10",
        //     DataNascimento= new DateTime(1970,01,12),
        //     Sexo="A"
        //    } ;

        //      try  
        //      {
        //        _contatoService.SalvarContato(contato);
        //        Assert.IsTrue(true);
        //      }
        //      catch
        //      {
        //        Assert.IsFalse(false); 
        //      }
        // }
      
        // [TestMethod]
        // public void TesteSalvarUsuarioInValido()
        // {

        //   var contato = new Contato(){
        //     Id = 10,
        //     Nome = "G",
        //     DataNascimento= new DateTime(1970,01,12),
        //     Sexo="X"
        //    } ;

        //      try  
        //      {
        //        _contatoService.SalvarContato(contato);
        //        Assert.IsTrue(true);
        //      }
        //      catch
        //      {
        //        Assert.IsFalse(false); 
        //      }
        //
   }

}
