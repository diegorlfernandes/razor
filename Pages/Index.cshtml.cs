using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RazorPagesPagination.Pages
{
    public class IndexModel : PageModel

    {
        public List<Message> Items { get; set; }
        private db banco;

       
        public void OnGet()
        {
            banco = new db("db\\hello.db");
            Items = banco.SelecionarTodos();
        }

        public IActionResult OnPost()
        {
            string input1 = Request.Form["input1"];
            banco = new db("db\\hello.db");
            banco.inserir(input1);

            return Redirect("/");
        }

        public  IActionResult OnGetDelete()
        {
            return Redirect("/");
        }
    }
}
   
