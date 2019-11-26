using AgendaWebApplication.Models;
using AgendaWebApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendaWebApplication.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository _pessoaR;

        public ActionResult ListPessoa()
        {
            _pessoaR = new PessoaRepository();

            ModelState.Clear();

            return View(_pessoaR.ListPessoa());
        }

        [HttpGet]
        public ActionResult AddPessoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPessoa(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pessoaR = new PessoaRepository();

                    if (_pessoaR.AddPessoa(pessoa))
                    {
                        ViewBag.Mensagem = "Pessoa cadastrada com sucesso!";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return View("ListPessoa");
            }
        }

        public ActionResult UpdatePessoa(int idPessoa)
        {
            _pessoaR = new PessoaRepository();

            return View(_pessoaR.ListPessoa().Find(p => p.idPessoa == idPessoa));
        }

        [HttpPost]
        public ActionResult UpdatePessoa(Pessoa pessoa)
        {
            try
            {
                _pessoaR = new PessoaRepository();
                _pessoaR.UpdatePessoa(pessoa);
                return RedirectToAction("ListPessoa");
            }
            catch (Exception)
            {
                return View("ListPessoa");
            }
        }
        
        public ActionResult DeletePessoa(int idPessoa)
        {
            try
            {
                _pessoaR = new PessoaRepository();
                if (_pessoaR.DeletePessoa(idPessoa))
                {
                    ViewBag.Mensagem = "Pessoa excluida com sucesso!";
                }
                return RedirectToAction("ListPessoa");
            }
            catch (Exception)
            {
                return View("ListPessoa");
            }
        }
    }
}